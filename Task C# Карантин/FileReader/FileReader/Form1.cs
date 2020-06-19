using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileReader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        private void OpenFile_Click_1(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
                textBox1.Text = "";
                ReadFile(openFileDialog1.FileName);
            
        }

        private void ReadFile(string path)
        {
            using (FileStream f = new FileStream(path, FileMode.Open))
            {
                int val = f.ReadByte();
                while (val != -1)
                {
                    textBox1.Text += (char)val;
                    val = f.ReadByte();
                }
            }
        }
    }
}
