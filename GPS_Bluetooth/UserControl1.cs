using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPS_Bluetooth
{
	public partial class UserControl1 : UserControl
	{
		public bool			m_bMSL;
		public double		m_dLatitude_Center;
		public double		m_dLongitude_Center;
		public double		m_dMSL_Center;

		public double		m_dLatitude;
		public double		m_dLongitude;
		public double		m_dMSL;

        private bool		m_bNextWillBeTheCenter;
		private double		m_dOffset_X;
		private double		m_dOffset_Y;
		private double		m_dOffset_Z;
		private bool		m_bZoomed;
		private double		m_bZoom;
		private Font		m_cFont;
		private Brush		m_brushBackground;
		private bool			m_bTracking;
		private bool			m_bShowCurrentPosition;
		private UserControl1	m_cLinkObjectMSL;

		public UserControl1()
		{
			m_dOffset_X = 0.0;
			m_dOffset_Y = 0.0;
			m_dOffset_Z = 0.0;
			m_bMSL = false;
			m_bZoomed = false;
			m_bZoom = 10.0;
            m_bNextWillBeTheCenter = true;
			InitializeComponent();
			m_brushBackground = Brushes.White;
			m_bTracking = false;
			m_bShowCurrentPosition = false;
			m_cLinkObjectMSL = null;
		}

		public void LinkObject(UserControl1	cLinkObjectMSL)
		{
			this.m_bNextWillBeTheCenter = false;
			cLinkObjectMSL.m_bNextWillBeTheCenter = false;
			m_cLinkObjectMSL = cLinkObjectMSL;
		}

		private void UserControl1_Paint(object sender, PaintEventArgs e)
		{
			Graphics		g = e.Graphics;
			float			fX;
			float			fY;
			float			fZ;
			double			dZoomFaktor;

			g.FillRectangle(m_brushBackground, 0, 0, Width, Height);

			g.DrawLine(Pens.Blue, Width * 0.5f, 0, Width * 0.5f, Height);
			g.DrawLine(Pens.Blue, 0, Height * 0.5f, Width, Height * 0.5f);

			fX = Width * 0.5f;
			while (true)
			{
				fX -= 10.0f;
				if (fX > 0)
					g.DrawLine(Pens.LightBlue, fX, 0, fX, Height);
				else
					break;
			}
			fX = Width * 0.5f;
			while (true)
			{
				fX += 10.0f;
				if (fX < Width)
					g.DrawLine(Pens.LightBlue, fX, 0, fX, Height);
				else
					break;
			}
			fY = Height * 0.5f;
			while (true)
			{
				fY -= 10.0f;
				if (fY > 0)
					g.DrawLine(Pens.LightBlue, 0, fY, Width, fY);
				else
					break;
			}
			fY = Height * 0.5f;
			while (true)
			{
				fY += 10.0f;
				if (fY < Height)
					g.DrawLine(Pens.LightBlue, 0, fY, Width, fY);
				else
					break;
			}

			dZoomFaktor = m_bZoom; // m_bZoomed ? 1000.0 : 10.0;
			if (m_cFont == null)
				m_cFont = new Font("Arial", 10.0f, FontStyle.Regular, GraphicsUnit.Point);
			g.DrawString(string.Format("Δ={0:0}mm{1}", 1000.0 / m_bZoom, m_bMSL ? ", MSL" : ", X-Y"), m_cFont, Brushes.DarkOliveGreen, 0, 0);

			if (m_bShowCurrentPosition)
			{
				if (m_bMSL == false)
					g.DrawString(string.Format("{0}, {1}", m_dLatitude, m_dLongitude), m_cFont, Brushes.DarkOliveGreen, 0, 12);
				else
					g.DrawString(string.Format("{0}", m_dMSL), m_cFont, Brushes.DarkOliveGreen, 0, 12);
			}

			if (m_bMSL == false)
			{
				fX = Width * 0.5f + (float)(m_dOffset_X * dZoomFaktor);
				fY = Height * 0.5f + (float)(m_dOffset_Y * dZoomFaktor);

				g.FillEllipse(Brushes.Red, fX - 5, fY - 5, 10, 10);
			}
			else
			{
				fX = Width * 0.5f;
				fZ = Height * 0.5f + (float)(m_dOffset_Z * dZoomFaktor);
				g.FillEllipse(Brushes.Red, fX - 5, fZ - 5, 10, 10);
			}
		}
		public void SetTracking(bool bTracking)
		{
			if (m_bTracking != bTracking)
			{
				m_bTracking = bTracking;
				m_brushBackground = m_bTracking ? Brushes.YellowGreen : Brushes.White;
				this.Invalidate();
			}
		}
		public void SetCenter()
		{
			m_bNextWillBeTheCenter = true;
		}
		public void ToggleZoom()
		{
			m_bZoomed = !m_bZoomed;

			this.Invalidate();
		}
		public void IncreaseZoom()
		{
            if (m_bZoom > 1.0)
                m_bZoom /= 10.0;

            this.Invalidate();
        }

		public void DecreaseZoom()
		{
            if (m_bZoom < 1000.0)
                m_bZoom *= 10.0;

            this.Invalidate();
        }

		public void SetCenterToPosition()
		{
            SetCurrentPosition(m_dLatitude, m_dLongitude, m_dMSL, true);
        }

        public void SetCurrentPosition(double dLatitude, double dLongitude, double dMSL, bool bNextWillBeTheCenter = false)
		{
			m_dLatitude = dLatitude;
			m_dLongitude = dLongitude;
			m_dMSL = dMSL;

			if (bNextWillBeTheCenter)
				m_bNextWillBeTheCenter = true;
			
			if (m_bNextWillBeTheCenter)
			{
				m_bNextWillBeTheCenter = false;

				m_dLatitude_Center = dLatitude;
				m_dLongitude_Center = dLongitude;
				m_dMSL_Center = dMSL;
			}

			m_dOffset_Y = CVincenty.inverse(m_dLatitude_Center, m_dLongitude_Center, dLatitude, m_dLongitude_Center);
			if (dLatitude > m_dLatitude_Center)
				m_dOffset_Y = -m_dOffset_Y;

			m_dOffset_X = CVincenty.inverse(m_dLatitude_Center, m_dLongitude_Center, m_dLatitude_Center, dLongitude);
			if (dLongitude < m_dLongitude_Center)
				m_dOffset_X = -m_dOffset_X;

			m_dOffset_Z = m_dMSL_Center - dMSL;
			this.Invalidate();

			if (m_cLinkObjectMSL != null)
				m_cLinkObjectMSL.SetCurrentPosition(dLatitude, dLongitude, dMSL, bNextWillBeTheCenter);
		}
		public void Simu_OffsetZ(double dOffsetZ)
		{
			m_dMSL += dOffsetZ;
			SetCurrentPosition(m_dLatitude, m_dLongitude, m_dMSL);
		}
		public void Simu_OffsetXY(double dOffsetX, double dOffsetY)
		{
			double		dDistance;
			double		dInitialBearingRadiant;
			double		dLatitude2;
			double		dLongitude2;

			dOffsetX -= m_dOffset_X;
			dOffsetY -= m_dOffset_Y;

			dDistance = Math.Sqrt(dOffsetX * dOffsetX + dOffsetY * dOffsetY);
			if (dDistance == 0.0)
				return;

//			System.Diagnostics.Trace.WriteLine(string.Format("{0:00}.{1:000} X={2} Y={3}", DateTime.Now.Second, DateTime.Now.Millisecond, dOffsetX, dOffsetY));

			dInitialBearingRadiant = Math.Asin(dOffsetX / dDistance);
			if (dOffsetY > 0)
				dInitialBearingRadiant = Math.PI - dInitialBearingRadiant;
			CVincenty.direct(m_dLatitude, m_dLongitude, dDistance, dInitialBearingRadiant, out dLatitude2, out dLongitude2);
			SetCurrentPosition(dLatitude2, dLongitude2, m_dMSL);
		}
		public bool ShowCurrentPosition
		{
			get { return m_bShowCurrentPosition; }
			set { m_bShowCurrentPosition = value; }
		}
		public bool Zoomed
		{
			get { return m_bZoomed; }
			set { m_bZoomed = value; }
		}
		public double Zoom
		{
			get { return m_bZoom; }
		}
	}
}
