using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPS_Bluetooth
{
	public partial class frmSimulator : Form
	{
		private System.IO.Ports.SerialPort		m_cPort;
		private DateTime						m_datPortOpen;
		private bool							m_bTrackMouse;
		private DateTime						m_datLast_MouseTracking;
		private bool							m_bDelayed_MouseTracking;
		private byte[]							m_byteArrayBT_Data;
		private string							m_strWrite;
		private bool							m_bSend_BTData;
		private DateTime						m_datLast_Send_BTData;
		private readonly object					m_lockBT_Data = new object();
		private Configuration					m_config;

		public frmSimulator(Configuration config)
		{
			m_config = config;
			m_datPortOpen = DateTime.MinValue;
			InitializeComponent();
			cbOpen.Enabled = false;

			userControl11.m_bMSL = false;
			userControl12.m_bMSL = true;

			userControl11.ShowCurrentPosition = true;
			userControl12.ShowCurrentPosition = true;

			userControl11.LinkObject(userControl12);

			userControl11.MouseWheel += new MouseEventHandler(userControl11_MouseWheel);
			receiverCheck.CheckedChanged += receiverCheck_CheckedChanged;

			PopulateFixTypeItems();
			if (cbFixType.Items.Count > m_config.Simulate.iFixType)
				cbFixType.SelectedIndex = m_config.Simulate.iFixType;
			tbNumSV.Text = m_config.Simulate.strNumSV;
			tbHAcc.Text = m_config.Simulate.hAcc;
			tbVAcc.Text = m_config.Simulate.vAcc;
			cbSend.Checked = m_config.Simulate.bSend;

			userControl11.SetCurrentPosition(m_config.Simulate.dLatitude_Center, m_config.Simulate.dLongitude_Center, m_config.Simulate.dMSL_Center, true);
			userControl11.SetCurrentPosition(m_config.Simulate.dLatitude, m_config.Simulate.dLongitude, m_config.Simulate.dMSL, false);

			m_bTrackMouse = false;
			m_bDelayed_MouseTracking = false;
			m_datLast_MouseTracking = DateTime.MinValue;

			lock (m_lockBT_Data)
			{
				m_byteArrayBT_Data = new byte[7 + 1 + 64];
				m_byteArrayBT_Data[0] = (byte)'/';
				m_byteArrayBT_Data[1] = (byte)'b';
				m_byteArrayBT_Data[2] = (byte)'t';
				m_byteArrayBT_Data[3] = (byte)'d';
				m_byteArrayBT_Data[4] = (byte)'a';
				m_byteArrayBT_Data[5] = (byte)'t';
				m_byteArrayBT_Data[6] = (byte)'a';
				m_byteArrayBT_Data[7] = 64;
				// Hier geht die eigentliche Bluetooth Nachricht los...
				m_byteArrayBT_Data[8 + 0] = 0xAC;				// Magic Number
				m_byteArrayBT_Data[8 + 1] = 0x01;				// Version
				m_byteArrayBT_Data[8 + 2] = 60;					// Länge 60 ... 4byte Reserve hinten vergessen :/
				for (int i = 11; i < m_byteArrayBT_Data.Length; ++i)
					m_byteArrayBT_Data[i] = 0x00;
			}

			m_strWrite = "";
			m_datLast_Send_BTData = DateTime.MinValue;
			m_bSend_BTData = false;

			userControl11.SetCenterToPosition();
			userControl12.SetCenterToPosition();
        }
		public void SetPort(string strPort)
		{
			tbPort.Text = strPort;
		}
		public string GetPort()
		{
			return tbPort.Text;
		}

		private void frmSimulator_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.Hide();
			e.Cancel = true;
		}

		private void frmSimulator_Resize(object sender, EventArgs e)
		{
			if (!DesignMode)
				LayoutControls();
		}

		private void LayoutControls()
		{
			int iPadding = 12;
			int iTop = 40;
			int iAvailableWidth = ClientSize.Width - iPadding * 3;
			int iAvailableHeight = ClientSize.Height - iTop - iPadding;

			if (iAvailableWidth < 1 || iAvailableHeight < 1)
				return;

			int iWidth12 = (int)(iAvailableWidth * 0.15);
			int iWidth11 = iAvailableWidth - iWidth12;

			userControl12.SetBounds(iPadding, iTop, iWidth12, iAvailableHeight);
			userControl11.SetBounds(iPadding + iWidth12 + iPadding, iTop, iWidth11, iAvailableHeight);

			userControl11.Invalidate();
			userControl12.Invalidate();
		}

		private void btZoom_Click(object sender, EventArgs e)
		{
			userControl11.ToggleZoom();
			userControl12.ToggleZoom();
		}
		public void TickTack()
		{
			bool			bTryOpenPort;
			byte[]			byteRead;
			byte[]			byteWrite;
			string			strRead;

			if (m_bDelayed_MouseTracking)
				this.CheckMouseTracking();

			try
			{
				if (m_cPort != null)
					cbOpen.Checked = m_cPort.IsOpen;

				bTryOpenPort = true;
				if (m_datPortOpen != DateTime.MinValue)
				{
					if ((DateTime.Now - m_datPortOpen).TotalSeconds < 1)
						bTryOpenPort = false;
				}
				if (bTryOpenPort)
				{
					if (m_cPort == null)
					{
						m_cPort = new System.IO.Ports.SerialPort();
						m_cPort.BaudRate = 115200;
						m_cPort.DataBits = 8;
						m_cPort.StopBits = System.IO.Ports.StopBits.One;
						m_cPort.Handshake = System.IO.Ports.Handshake.None;
					}

					if (m_cPort.PortName != tbPort.Text)
					{
						if (m_cPort.IsOpen)
							m_cPort.Close();

						m_cPort.PortName = tbPort.Text;
						m_datPortOpen = DateTime.Now;
						m_cPort.Open();
					}
				}

				if (m_cPort != null)
				{
					if (m_cPort.IsOpen)
					{
						if (m_cPort.BytesToRead > 0)
						{
							byteRead = new byte[m_cPort.BytesToRead];
							m_cPort.Read(byteRead, 0, byteRead.Length);
							strRead = Encoding.ASCII.GetString(byteRead);
//							System.Diagnostics.Trace.WriteLine("RX: " + strRead);
							byteRead = null;
						}

						if (m_strWrite.Length > 0)
						{
							byteWrite = Encoding.ASCII.GetBytes(m_strWrite);
							m_strWrite = "";
							m_cPort.Write(byteWrite, 0, byteWrite.Length);
						}

						if (cbSend.Checked && (DateTime.Now - m_datLast_Send_BTData).TotalMilliseconds >= 100)
						{
							m_bSend_BTData = true;
						}

						if (m_bSend_BTData)
						{
							m_bSend_BTData = false;
							m_datLast_Send_BTData = DateTime.Now;
							lock (m_lockBT_Data)
							{
								this.BuildBTData();
								m_cPort.Write(m_byteArrayBT_Data, 0, m_byteArrayBT_Data.Length);
							}
						}
					}
				}
			}
			catch (Exception err)
			{
				System.Diagnostics.Trace.WriteLine("err: " + err.Message);
				if (m_cPort != null)
					m_cPort.PortName = "?";
			}
		}

		private void userControl11_MouseHover(object sender, EventArgs e)
		{

		}

		private void userControl11_MouseEnter(object sender, EventArgs e)
		{
			this.Cursor = Cursors.Cross;
		}

		private void userControl11_MouseLeave(object sender, EventArgs e)
		{
			this.Cursor = Cursors.Default;
			m_bTrackMouse = false;
			userControl11.SetTracking(m_bTrackMouse);
		}

		private void userControl11_MouseDown(object sender, MouseEventArgs e)
		{
			MenuItem								item;
			MenuItem								subitem;
			System.Windows.Forms.ContextMenu		cContextMenu;
			Point									point;

			if (e.Button == MouseButtons.Left)
			{
				m_bTrackMouse = !m_bTrackMouse;
				if (m_bTrackMouse)
					CheckMouseTracking();
				userControl11.SetTracking(m_bTrackMouse);
			}
			if (e.Button == MouseButtons.Right)
			{
				cContextMenu = new	ContextMenu();

				item = cContextMenu.MenuItems.Add("jump to");
				subitem = item.MenuItems.Add("Konrad Headquarters", frmSimulator_OnContextMenu);
				subitem.Tag = 1;
				subitem = item.MenuItems.Add("Chile T-Skidder Einsatz 1", frmSimulator_OnContextMenu);
				subitem.Tag = 2;
				subitem = item.MenuItems.Add("Other", frmSimulator_OnContextMenu);
				subitem.Tag = 3;

                item = cContextMenu.MenuItems.Add("Tests");
				subitem = item.MenuItems.Add("/info", frmSimulator_OnContextMenu);
				subitem.Tag = 100;
				subitem = item.MenuItems.Add("/btdata", frmSimulator_OnContextMenu);
				subitem.Tag = 101;

				point = new Point(userControl11.Left, userControl11.Top);
				point.Offset(e.X, e.Y);
				cContextMenu.Show(this, point);
			}
		}

		private void frmSimulator_OnContextMenu(object sender, System.EventArgs e)
		{
			int										iTag;
			System.Windows.Forms.MenuItem			menuItem;

			menuItem = (System.Windows.Forms.MenuItem)sender;
			int.TryParse(menuItem.Tag.ToString(), out iTag);
			switch (iTag)
			{
				case 1:
					userControl11.SetCurrentPosition(14.958683236227163, 46.935078513209845, 1140, true);
					break;
				case 2:
					userControl11.SetCurrentPosition(-72.94362021260869, -39.23945692522164, 300, true);
					break;
				case 3:
					using (NewLocationSelector dlg = new NewLocationSelector())
					{
						if (dlg.ShowDialog(this) == DialogResult.OK)
							userControl11.SetCurrentPosition(dlg.Latitude, dlg.Longitude, dlg.SML, true);
					}
					break;
                case 100:
					m_strWrite = "/info";
					break;
				case 101:
					m_bSend_BTData = true;
					//m_strWrite = "/btdata";
					break;
			}
		}

		private void Buffer2Array(byte[] byteBuffer, byte[] byteArray, int iOffset)
		{
			for (int i = 0; i < byteBuffer.Length; ++i)
			{
				byteArray[iOffset + i] = byteBuffer[i];
			}
		}

		private void BuildBTData()
		{
			ushort		crc;
			byte		byteVal;
			UInt32		ui32Val;

			byte byteFlags = 0x00;
			if (samplePoint.Checked)    byteFlags |= 0x01;
			if (receiverCheck.Checked)  byteFlags |= 0x02;
			if (rtkCheck.Checked)       byteFlags |= 0x04;
			m_byteArrayBT_Data[8 + 3] = byteFlags;

			Buffer2Array(BitConverter.GetBytes(userControl11.m_dLatitude), m_byteArrayBT_Data, 8 + 16);
			Buffer2Array(BitConverter.GetBytes(userControl11.m_dLongitude), m_byteArrayBT_Data, 8 + 24);
			Buffer2Array(BitConverter.GetBytes(userControl11.m_dMSL), m_byteArrayBT_Data, 8 + 32);
			Buffer2Array(BitConverter.GetBytes(userControl11.m_dMSL), m_byteArrayBT_Data, 8 + 40);

			if (UInt32.TryParse(tbHAcc.Text, out ui32Val))
				Buffer2Array(BitConverter.GetBytes(ui32Val), m_byteArrayBT_Data, 8 + 48);
			if (UInt32.TryParse(tbVAcc.Text, out ui32Val))
				Buffer2Array(BitConverter.GetBytes(ui32Val), m_byteArrayBT_Data, 8 + 52);
			byte fixTypeValue = 0;
			fixType selectedFixType = cbFixType.SelectedItem as fixType;
			if (selectedFixType != null)
				fixTypeValue = (byte)selectedFixType.Value;
			Buffer2Array(BitConverter.GetBytes(fixTypeValue), m_byteArrayBT_Data, 8 + 56);
			if (byte.TryParse(tbNumSV.Text, out byteVal))
				Buffer2Array(BitConverter.GetBytes(byteVal), m_byteArrayBT_Data, 8 + 57);

			crc = Crc16.CRC16_Calc(m_byteArrayBT_Data, 8 + m_byteArrayBT_Data[8 + 2] - 2, 8);

			m_byteArrayBT_Data[8 + 58] = (byte)(crc & 0xFF);
			m_byteArrayBT_Data[8 + 59] = (byte)(crc >> 8);
		}

		private void userControl11_MouseUp(object sender, MouseEventArgs e)
		{
		}

		private void userControl11_MouseMove(object sender, MouseEventArgs e)
		{
			if (m_bTrackMouse)
				CheckMouseTracking();
		}

		private void userControl11_MouseWheel(object sender, MouseEventArgs e)
		{
			double			dOffsetZ;

			if (m_bTrackMouse)
			{
				dOffsetZ = e.Delta / 120.0 * 0.5;

				userControl11.Simu_OffsetZ(dOffsetZ);
			}
		}

		private void CheckMouseTracking()
		{
			Point					point;
			double					dX;
			double					dY;
			double					dZoomFaktor;

			if ((DateTime.Now - m_datLast_MouseTracking).TotalMilliseconds < 100)
			{
				m_bDelayed_MouseTracking = true;
				return;
			}
			m_datLast_MouseTracking = DateTime.Now;
			m_bDelayed_MouseTracking = false;

			point = Cursor.Position;
			point = this.PointToClient(point);

			point.Offset(-userControl11.Left, -userControl11.Top);
			point.Offset(-userControl11.Width / 2, -userControl11.Height / 2);

			dZoomFaktor = userControl11.Zoom;

			dX = point.X / dZoomFaktor;
			dY = point.Y / dZoomFaktor;

			userControl11.Simu_OffsetXY(dX, dY);

//			System.Diagnostics.Trace.WriteLine(string.Format("{0:00}.{1:000} X={2} Y={3}", DateTime.Now.Second, DateTime.Now.Millisecond, dX, dY));
		}

		private void frmSimulator_Load(object sender, EventArgs e)
		{
			if (!DesignMode)
				LayoutControls();
		}

		public void SaveSettings()
		{
			Configuration.structSIMULATE		structSimulate;

			structSimulate = m_config.Simulate;
			structSimulate.iFixType = cbFixType.SelectedIndex;
			structSimulate.strNumSV = tbNumSV.Text;
			structSimulate.hAcc = tbHAcc.Text;
			structSimulate.vAcc = tbVAcc.Text;
			structSimulate.bSend = cbSend.Checked;

			structSimulate.dLatitude_Center = userControl11.m_dLatitude_Center;
			structSimulate.dLatitude = userControl11.m_dLatitude;
			structSimulate.dLongitude_Center = userControl11.m_dLongitude_Center;
			structSimulate.dLongitude = userControl11.m_dLongitude;
			structSimulate.dMSL_Center = userControl11.m_dMSL_Center;
			structSimulate.dMSL = userControl11.m_dMSL;

			m_config.Simulate = structSimulate;
		}

        private void zoomInBtn_Click(object sender, EventArgs e)
        {
			userControl11.IncreaseZoom();
            userControl12.IncreaseZoom();
        }

		private void zoomOutBtn_Click(object sender, EventArgs e)
		{
			userControl11.DecreaseZoom();
			userControl12.DecreaseZoom();
		}

        private void centerBtn_Click(object sender, EventArgs e)
        {
			userControl11.SetCenterToPosition();
            userControl12.SetCenterToPosition();
        }

		private void samplePoint_CheckedChanged(object sender, EventArgs e)
		{

		}

		private void receiverCheck_CheckedChanged(object sender, EventArgs e)
		{
			PopulateFixTypeItems();
		}

		private void PopulateFixTypeItems()
		{
			cbFixType.Items.Clear();
			if (receiverCheck.Checked)
			{
				cbFixType.Items.Add(new fixType(0, "No solution"));
				cbFixType.Items.Add(new fixType(1, "Position has been fixed by the FIX position position command or by position averaging."));
				cbFixType.Items.Add(new fixType(2, "Not supported for now"));
				cbFixType.Items.Add(new fixType(8, "Velocity computed using instantaneous Doppler"));
				cbFixType.Items.Add(new fixType(16, "Single point position"));
				cbFixType.Items.Add(new fixType(17, "Pseudorange differential solution"));
				cbFixType.Items.Add(new fixType(18, "Solution calculated using corrections from an SBAS"));
				cbFixType.Items.Add(new fixType(32, "Floating L1 ambiguity solution"));
				cbFixType.Items.Add(new fixType(33, "Floating ionosphere ambiguity solution"));
				cbFixType.Items.Add(new fixType(34, "Floating narrow-lane ambiguity solution"));
				cbFixType.Items.Add(new fixType(48, "Integer L1 ambiguity solution"));
				cbFixType.Items.Add(new fixType(49, "Integer wide-lane ambiguity solution"));
				cbFixType.Items.Add(new fixType(50, "Integer narrow-lane ambiguity solution"));
				cbFixType.Items.Add(new fixType(52, "INS position solution"));
				cbFixType.Items.Add(new fixType(53, "INS pseudorange single point solution – no DGPS corrections"));
				cbFixType.Items.Add(new fixType(54, "INS pseudorange differential solution"));
				cbFixType.Items.Add(new fixType(55, "INS RTK floating point ambiguities solution"));
				cbFixType.Items.Add(new fixType(56, "INS RTK fixed ambiguities solution"));
				cbFixType.Items.Add(new fixType(68, "PPP in convergence"));
				cbFixType.Items.Add(new fixType(69, "PPP positioning"));
				cbFixType.Items.Add(new fixType(70, "PPP fixed solution, PPP_AR status"));
				cbFixType.Items.Add(new fixType(71, "PPP fixed solution, PPP_RTK status"));
			}
			else
			{
				cbFixType.Items.Add(new fixType(0, "no fix"));
				cbFixType.Items.Add(new fixType(1, "dead reckoning only"));
				cbFixType.Items.Add(new fixType(2, "2D-fix"));
				cbFixType.Items.Add(new fixType(3, "3D-fix"));
				cbFixType.Items.Add(new fixType(4, "GNSS + dead reckoning combined"));
				cbFixType.Items.Add(new fixType(5, "time only fix"));
			}
			if (cbFixType.Items.Count > 0)
				cbFixType.SelectedIndex = 0;
		}

        private void userControl11_Load(object sender, EventArgs e)
        {

        }
    }
}
