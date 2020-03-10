using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
          
            InitializeComponent();

        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
         
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += (sender as Button).Text;
        }
        private void button9_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += (sender as Button).Text;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += (sender as Button).Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += (sender as Button).Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += (sender as Button).Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += (sender as Button).Text;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += (sender as Button).Text;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += (sender as Button).Text;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += (sender as Button).Text;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += (sender as Button).Text;

        }

        public string DoOperation(string s)
        {
            int i, j;
            char sign;
            string res;
            string val1 = "";
            string val2 = "";
            double sum;
            i = 0;
            if (s[0] == '-')
            {
                val1 += '-';
                i++;
            }

            while (!IsSign(s[i]) && i < s.Length)
            {
                
                val1 += s[i];
                i++;
            }
            sign = s[i];
            i++;
            while (i < s.Length)
            {
                val2 += s[i];
                i++;
            }
            if (sign == '*')
            {
                sum = double.Parse(val1) * double.Parse(val2);
                res = double.Parse(val1) < 0 && double.Parse(val2) < 0 ? "+" + sum.ToString() : sum.ToString();
            }
            else
                if (sign == '/')
            {
                sum = double.Parse(val1) / double.Parse(val2);
                res = double.Parse(val1) < 0 && double.Parse(val2) < 0 ? "+" + sum.ToString() : sum.ToString();
            }
            else
                    if (sign == '+')
            {
                sum = double.Parse(val1) + double.Parse(val2);
                res = sum.ToString();
            }
            else
            {
                sum = double.Parse(val1) - double.Parse(val2);
                res = sum.ToString();
            }
            return res;
        }
        string DoAllOperations(string s)
        {
            int i, j;
            int pos1, pos2;
            string sum;
            i = 0;
            while(i < s.Length) {
                if (s[i] == '/' || s[i] == '*')
                {

                    sum = "";
                    pos1 = i - 1;
                    pos2 = i + 1;
                    if (s[pos2] == '-')
                        pos2++;
                    while (pos1 > 0 && !IsSign(s[pos1]))
                        pos1--;
                    while (pos2 < s.Length-1 && !IsSign(s[pos2+1]))
                        pos2++;

                    if (pos1 > 0 && s[pos1] != '-')
                    pos1++;
                    

                    for(j = pos1; j <= pos2; j++)
                        sum += s[j];
                   s =  s.Remove(pos1, pos2-pos1+1);
                    sum = DoOperation(sum);
                    s = s.Insert(pos1, sum);
                    i = pos1;
                }
                i++;
            }
            i = 0;
            while (i < s.Length)
            {
                if ((s[i] == '+' || s[i] == '-') && i != 0)
                {
                    sum = "";
                    pos1 = i - 1;
                    pos2 = i + 1;
                    while (pos1 > 0)
                        pos1--;
                    while (pos2 < s.Length - 1 && !IsSign(s[pos2 + 1]))
                        pos2++;
                    for (j = pos1; j <= pos2; j++)
                        sum += s[j];
                    s = s.Remove(pos1, pos2-pos1+1);
                    sum = DoOperation(sum);
                    s = s.Insert(pos1, sum);
                    i = pos1;
                }
                i++;
            }
            return s;
        }
        private void button12_Click(object sender, EventArgs e)
        {
            int length = textBox1.Text.Length;
            if(textBox1.TextLength == 0)
            {
                textBox1.Text = "0";
                return;
            }
            if (textBox1.Text[length - 1] == '+' || textBox1.Text[length - 1] == '-') {
                textBox1.Text += "0";
                length = textBox1.Text.Length;
            }
            int i = 0;
            double sum = double.Parse(DoAllOperations(textBox1.Text));
            textBox1.Text = sum.ToString();
        }
        private bool IsSign(char s)
        {
            char[] arr = { '+', '-', '/', '*' };
            int i;
            for (i = 0; i < arr.Length; i++)
                if (s == arr[i])
                    return true;
            return false;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            int length = textBox1.Text.Length;
            if (textBox1.Text.Length == 0 || IsSign(textBox1.Text[length - 1]))
                return;
            this.textBox1.Text += (sender as Button).Text;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            int length = textBox1.Text.Length;
            if (textBox1.Text.Length == 0 || IsSign(textBox1.Text[length-1]))
                return;
            this.textBox1.Text += (sender as Button).Text;
        }
        private void button13_Click(object sender, EventArgs e)
        {
            int length = textBox1.Text.Length;
            if (textBox1.Text.Length == 0 || IsSign(textBox1.Text[length - 1]))
                return;
            this.textBox1.Text += (sender as Button).Text;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            int length = textBox1.Text.Length;
            if(length != 0 && (textBox1.Text[length-1] == '-' || textBox1.Text[length - 1] == '+'))
                return;
            this.textBox1.Text += (sender as Button).Text;
        }
        private void button17_Click(object sender, EventArgs e)
        {
            int length = textBox1.Text.Length;
            if (textBox1.Text.Length == 0 || IsSign(textBox1.Text[length - 1]))
                return;
            this.textBox1.Text += (sender as Button).Text;
        }
    }
}
