using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_3_sem4
{
    public partial class Form1 : Form
    {
        int n;
        Button[,] ButtonsArr;
        int counter = 1;
        int seconds = 0;
        public Form1()
        {
            InitializeComponent();
            
        }


        public void MixNumbers()
        {
            int c = counter;
            int i, j, k;

            List<int> arr = new List<int>();
            Random r = new Random();
            for(i = 0; i< n; i++)
            {
                for(j = 0; j<n; j++)
                {
                   
                    if (ButtonsArr[i, j].Visible)
                    {
                        do {
                            
                            k = r.Next(c, (n * n)+1);
                        }
                        while (arr.Contains(k));
                        arr.Add(k);
                        ButtonsArr[i, j].Text = k.ToString();                 
                    }
                    else                          
                        continue;
                }
            }

        }
        private void DoVisible()
        {
            int i, j;
            for(i = 0; i< n; i++)
            {
                for(j = 0; j< n; j++)
                {
                    if (!ButtonsArr[i, j].Visible)
                        ButtonsArr[i, j].Visible = true;
                }
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            n = 4;
            ButtonsArr = new Button[n, n];
            int i, j;
            int posx, posy = 30;

            for (i = 0; i < 4; i++, posy += 70)
            {
                for (j = 0, posx = 30; j < 4; j++, posx += 130)
                {
                    ButtonsArr[i, j] = new Button();
                    ButtonsArr[i, j].Name = "Button" + i.ToString() + j.ToString();
                    ButtonsArr[i, j].Size = new Size(75, 41);
                    ButtonsArr[i, j].Location = new Point(posx, posy);
                    ButtonsArr[i, j].Click += ButtonClick;
                    tabPage2.Controls.Add(ButtonsArr[i, j]);

                }
            }
            tabControl1.SelectedIndexChanged += ChangeTab;
            label2.Text = seconds.ToString();
        }
        private void ChangeTab(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
                MixNumbers();
            if (!timer1.Enabled)
            {
                timer1.Start();
            }
           
        }

        private void Reset()
        {
            progressBar1.Value = 0;
            DoVisible();
            counter = 1;
            textBox2.Text = "";
        }
        private void WriteRes()
        {
            button3.Visible = true;
            label1.Visible = true;
            label2.Visible = true; 
            textBox2.Text = "Attaboy !";
            textBox2.TextAlign = HorizontalAlignment.Center;
            timer1.Stop();
            label1.Text = String.Format($"{seconds} sec");
            seconds = 0;
        }

        private void ButtonClick(object sender, EventArgs e)
        {


            if ((sender as Button).Text == counter.ToString())
            {
                (sender as Button).Hide();
                counter++;
                MixNumbers();
                progressBar1.Value++;
            }
            else
                Reset();
                
            
            if (counter == 17)
                WriteRes();               
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
                return;
            comboBox1.Items.Add(textBox1.Text);
            textBox1.Text = null;

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int length = comboBox1.Items.Count;
            if(length != 0)
            comboBox1.Items.RemoveAt(length-1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Hide();
            Reset();
            label1.Visible = false;
            timer1.Start();
            label2.Visible = true;
            label2.Text = seconds.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            seconds++;
            label2.Text = seconds.ToString();
        }

 
    }
}