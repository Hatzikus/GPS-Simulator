using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPS_Bluetooth
{
	[Serializable]
	public class Configuration
	{
		public struct structSIMULATE
		{
			public int			iFixType;
			public string		strNumSV;
			public string		hAcc;
			public string		vAcc;
			public bool			bSend;
			public double		dLatitude_Center;
			public double		dLongitude_Center;
			public double		dMSL_Center;
			public double		dLatitude;
			public double		dLongitude;
			public double		dMSL;
		}

		string				m_strBT_Device_Address;
		string				m_strPort_Simulate;
		structSIMULATE		m_structSimulate;

		public Configuration()
		{
			m_strBT_Device_Address = "";
			m_strPort_Simulate = "";
			m_structSimulate.iFixType = 0;
			m_structSimulate.strNumSV = "0";
			m_structSimulate.hAcc = "0";
			m_structSimulate.vAcc = "0";
			m_structSimulate.bSend = false;
		}
		public static void Serialize(string file, Configuration c)
		{
			System.Xml.Serialization.XmlSerializer		xs;
			System.IO.StreamWriter						writer;

			xs = new System.Xml.Serialization.XmlSerializer(c.GetType());
			writer = System.IO.File.CreateText(file);
			xs.Serialize(writer, c);
			writer.Flush();
			writer.Close();
		}
		public static Configuration Deserialize(string file)
		{
			Configuration			c;

			System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(typeof(Configuration));
			try
			{
				System.IO.StreamReader reader = System.IO.File.OpenText(file);
				c = (Configuration)xs.Deserialize(reader);
				reader.Close();
			}
			catch (Exception /*err*/)
			{
				c = new Configuration();
			}
			return c;
		}
		public string BT_Device_Address
		{
			get { return m_strBT_Device_Address; }
			set { m_strBT_Device_Address = value; }
		}

		public string Port_Simulate
		{
			get { return m_strPort_Simulate; }
			set { m_strPort_Simulate = value; }
		}

		public structSIMULATE Simulate
		{
			get { return m_structSimulate; }
			set { m_structSimulate = value; }
		}
	}
}
