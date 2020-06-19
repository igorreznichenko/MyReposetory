using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoadFromFille
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string[] s;
            using (StreamReader rd = new StreamReader("Data.txt"))
            {
                textBox1.Text = rd.ReadLine();
                s = rd.ReadLine().Split(' ');
                numericUpDown1.Value = decimal.Parse(s[0]);
                numericUpDown2.Value = decimal.Parse(s[1]);
                s = rd.ReadLine().Split(' ');
               BackColor =  Color.FromArgb(int.Parse(s[0]), int.Parse(s[1]), int.Parse(s[2]));
               
            }
            int width = (int)numericUpDown1.Value;
            int height = (int)numericUpDown2.Value;
            Size = new Size(width, height);
            
        }

        private void ChangeHeight_Click(object sender, EventArgs e)
        {
            Height = (int)numericUpDown1.Value;
            Width = (int)numericUpDown2.Value;
        }

        private void ChangeBackColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            BackColor = colorDialog1.Color;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

     

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
        using (StreamWriter sw = new StreamWriter("Data.txt"))
        {
            sw.WriteLine(textBox1.Text);
            sw.WriteLine(Width + " " + Height);
            sw.WriteLine(BackColor.R + " " + BackColor.G + " " + BackColor.B);
        }

        }
    }
}
