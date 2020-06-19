using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Xml;
using System.Xml.XPath;
namespace LoadFromXmlFille
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            int R, G, B;
            InitializeComponent();
            XPathDocument document = new XPathDocument(File.Open("Data.xml", FileMode.Open));
            XPathNavigator xPath = document.CreateNavigator();
            xPath.MoveToFirstChild();
            xPath.MoveToFirstChild();
            textBox1.Text = xPath.Value;
            xPath.MoveToNext();
            numericUpDown1.Value = int.Parse(xPath.Value);
            xPath.MoveToNext();
            numericUpDown2.Value = int.Parse(xPath.Value);
            xPath.MoveToNext();
            R = int.Parse(xPath.Value);
            xPath.MoveToNext();
            G = int.Parse(xPath.Value);
            xPath.MoveToNext();
            B = int.Parse(xPath.Value);

            Width = (int)numericUpDown1.Value;
            Height = (int)numericUpDown2.Value;
            BackColor = Color.FromArgb(R, G, B);
        }

        private void ChangeSize_Click(object sender, EventArgs e)
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
         
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
           XmlDocument xml = new XmlDocument();
            xml.Load("Data.xml");
            XPathNavigator xPath = xml.CreateNavigator();
            xPath = xPath.SelectSingleNode("Data");
            xPath = xPath.SelectSingleNode("Text");
            xPath.SetValue(textBox1.Text);
            xPath.MoveToNext();
            xPath.SetValue(Width.ToString());
            xPath.MoveToNext();
            xPath.SetValue(Height.ToString());
            xPath.MoveToNext();
            xPath.SetValue(BackColor.R.ToString());
            xPath.MoveToNext();
            xPath.SetValue(BackColor.G.ToString());
            xPath.MoveToNext();
            xPath.SetValue(BackColor.B.ToString());
            xml.Save("Data.xml");




        }
    }
}
