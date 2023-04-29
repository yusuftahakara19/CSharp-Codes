using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpecPro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dosyaYükleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog file = new OpenFileDialog();
                lblYukleniyor.Visible = true;
                DialogResult result = file.ShowDialog();
                file.Filter = "TXT DOSYASI |*.txt";
                if (result == DialogResult.OK)
                {
                    dataGridView1.Rows.Clear();
                    StreamReader sr = new StreamReader(file.FileName);
                    string satir = sr.ReadLine();
                    while (satir != null)
                    {
                        string[] words = satir.Split('\t');
                        dataGridView1.Rows.Add(words[0], words[1], words[2], words[3]);

                        satir = sr.ReadLine();
                    }
                    lblYukleniyor.Visible = false;
                    btnGrafik.Visible = true;
                }
                else
                {
                    lblYukleniyor.Visible = false;

                }   
            }
            catch (Exception a)
            {
    
                MessageBox.Show("Beklenmeyen bir hata oluştu\n", a.ToString());
            }
              
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnGrafik_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int kacinci = 0,x,y,z;
            Grafik frm = new Grafik();
            
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                if (dataGridView1.Rows[i].Cells[1].Value.ToString() == "1")
                {
                    kacinci++;
                    x = random.Next(256);
                    y = random.Next(256);
                    z = random.Next(256);  
                    frm.seriesEkle("3K-1-SG" + kacinci + ".mn", x, y, z);
                }
                frm.grafikEkle("3K-1-SG" + kacinci + ".mn",dataGridView1.Rows[i].Cells[2].Value.ToString(), dataGridView1.Rows[i].Cells[3].Value.ToString());
            }
            frm.Show();
        }
    }
}
