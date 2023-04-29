using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;
namespace SpecPro
{
    public partial class Grafik : Form
    {
        public Grafik()
        {
            InitializeComponent();
        }
        public void seriesEkle(string series,int x,int y, int z)
        {
            chart1.Series.Add(series);
            chart1.Series[series].Color = Color.FromArgb(x, y, z);
            chart1.Series[series].Legend = "Legend1";
            chart1.Series[series].ChartArea = "ChartArea1";
            chart1.Series[series].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.ChartAreas["ChartArea1"].AxisX.Title = "Wavelength";  // Chart X Axis Title
            chart1.ChartAreas["ChartArea1"].AxisX.TitleAlignment = StringAlignment.Center;
            chart1.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font("Arial", 8, FontStyle.Bold); // Chart X axis
            chart1.ChartAreas["ChartArea1"].AxisX.TextOrientation = TextOrientation.Horizontal; // Chart Y Axis Text Orientation
           
            chart1.ChartAreas["ChartArea1"].AxisY.TitleAlignment = StringAlignment.Center;  // Chart Y axis Text Alignment 
            chart1.ChartAreas["ChartArea1"].AxisY.TextOrientation = TextOrientation.Horizontal; // Chart Y Axis Text Orientation
            chart1.ChartAreas["ChartArea1"].AxisY.TitleFont = new Font("Arial", 8, FontStyle.Bold); // Chart Y axis Title Font
            
        }
        public void grafikEkle(string series,string x, string y)
        {
            chart1.Series[series].Points.AddXY(x, y);
        }
        private void Grafik_Load(object sender, EventArgs e)
        {
            chart1.ChartAreas["ChartArea1"].AxisX.Title = "Wavelength";
            chart1.Titles.Add("Spectral Data").Font = new Font("Arial", 10, FontStyle.Bold);
            chart1.ChartAreas["ChartArea1"].AxisY.Title = "[...]"; // Chart Y Axis Title 

         }

        private void chart1_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void chart1_MouseClick(object sender, MouseEventArgs e)
        {
            double xValue = chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X);
            double yValue = chart1.ChartAreas[0].AxisY.PixelPositionToValue(e.Y);

            lblX.Text = xValue.ToString("N3");
            lblY.Text = yValue.ToString("N3");
        }
    }
}
