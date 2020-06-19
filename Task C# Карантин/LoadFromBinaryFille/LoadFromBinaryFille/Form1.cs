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

namespace LoadFromBinaryFille
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            using (BinaryReader f = new BinaryReader(File.Open("Data.txt", FileMode.Open), Encoding.UTF8))
            {
                char s = f.ReadChar();
                int R, G, B;
                while (s != '\n')
                {
                    textBox1.Text += s.ToString();
                    s = (char)f.ReadChar();
                }
                numericUpDown1.Value = f.ReadInt32();
                numericUpDown2.Value = f.ReadInt32();
                R = f.ReadByte();
                G = f.ReadByte();
                B = f.ReadByte();

                Width = (int)numericUpDown1.Value;
                Height= (int)numericUpDown2.Value;
                BackColor = Color.FromArgb(R, G, B);
            }
        }


        private void ChangeBackColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            BackColor = colorDialog1.Color;
        }

        private void ChangeHeight_Click(object sender, EventArgs e)
        {
            Width = (int)numericUpDown1.Value;
            Height = (int)numericUpDown2.Value;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            using (BinaryWriter f = new BinaryWriter(File.Open("Data.txt",FileMode.Open),Encoding.UTF8))
            {
                for (int i = 0; i < textBox1.Text.Length; i++) {
                    f.Write(textBox1.Text[i]);
                }
                f.Write('\n');
                f.Write(Width);
                f.Write(Height);
                f.Write(BackColor.R);
                f.Write(BackColor.G);
                f.Write(BackColor.B);

            }
        }
    }
}
