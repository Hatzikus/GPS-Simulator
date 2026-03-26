using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace GPS_Bluetooth
{
    public partial class NewLocationSelector : Form
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double SML { get; set; }

        public NewLocationSelector()
        {
            InitializeComponent();
            checkBox1.Checked = true;
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                Latitude = (double.Parse(latA.Text) + double.Parse(latB.Text)) / 2;
                Longitude = (double.Parse(lonA.Text) + double.Parse(lonB.Text)) / 2;
                SML = (double.Parse(mslA.Text) + double.Parse(mslB.Text)) / 2;
            }else
            {
                Latitude = double.Parse(latA.Text);
                Longitude = double.Parse(lonA.Text);
                SML = double.Parse(mslA.Text);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                latB.Enabled = true;
                lonB.Enabled = true;
                mslB.Enabled = true;

                label3.Enabled = true;
                label4.Enabled = true;
                label5.Enabled = true;
            }
            else
            {
                latB.Enabled = false;
                lonB.Enabled = false;
                mslB.Enabled = false;

                label3.Enabled = false;
                label4.Enabled = false;
                label5.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "KML Files (*.kml)|*.kml";
                ofd.Title = "Select KML File";

                if (ofd.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    XDocument doc = XDocument.Load(ofd.FileName);

                    var coordinates = doc.Descendants()
                        .Where(el => el.Name.LocalName == "Point")
                        .Select(p => p.Elements().FirstOrDefault(el => el.Name.LocalName == "coordinates")?.Value?.Trim())
                        .Where(c => !string.IsNullOrEmpty(c))
                        .ToList();

                    if (coordinates.Count == 0)
                    {
                        return;
                    }

                    ParseAndFillPoint(coordinates.First(), latA, lonA, mslA);
                    ParseAndFillPoint(coordinates.Last(), latB, lonB, mslB);
                }
                catch { /* ignore */ }
            }
        }

        private void ParseAndFillPoint(string coordinateString, TextBox latBox, TextBox lonBox, TextBox mslBox)
        {
            string[] parts = coordinateString.Split(',');

            if (parts.Length < 3)
                return;

            if (double.TryParse(parts[0], NumberStyles.Any, CultureInfo.InvariantCulture, out double lon) &&
                double.TryParse(parts[1], NumberStyles.Any, CultureInfo.InvariantCulture, out double lat) &&
                double.TryParse(parts[2], NumberStyles.Any, CultureInfo.InvariantCulture, out double alt))
            {
                latBox.Text = lat.ToString(CultureInfo.CurrentCulture);
                lonBox.Text = lon.ToString(CultureInfo.CurrentCulture);
                mslBox.Text = alt.ToString(CultureInfo.CurrentCulture);
            }
        }
    }
}
