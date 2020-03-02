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
        TextBox textBox1;
        public Form1()
        {
            InitializeComponent();
         
        }
        private void Operation_Button_Click(object sender, EventArgs e)
        {
            int length = textBox1.Text.Length;
            if (textBox1.Text.Length == 0 || IsSign(textBox1.Text[length - 1]))
                return;
            this.textBox1.Text += (sender as Button).Text;
        }
        private void TextBox_Changed(object sender, EventArgs e) {
            
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
        public string DoOperation(string val1, string val2, char sign)
        {

            double sum;
            if (sign == '*')
                sum = double.Parse(val1) * double.Parse(val2);
            else
                if (sign == '/')
                sum = double.Parse(val1) / double.Parse(val2);
            else
                    if (sign == '+')
                sum = double.Parse(val1) + double.Parse(val2);
            else
                sum = double.Parse(val1) - double.Parse(val2);
            return sum.ToString();

        }
        string DoAllOperations(string s)
        {
            int i, j;
            int pos1, pos2;
            string sum1, sum2;
            char sign;
            i = 0;
            while (i < s.Length)
            {
                if (s[i] == '/' || s[i] == '*')
                {
                    sum1 = sum2 = "";
                    pos1 = i - 1;
                    pos2 = i + 1;
                    while (pos1 > 0 && !IsSign(s[pos1 - 1]))
                        pos1--;
                    while (pos2 < s.Length - 1 && !IsSign(s[pos2 + 1]))
                        pos2++;

                    for (j = pos1; j < i; j++)
                        sum1 += s[j];
                    for (j = i + 1; j <= pos2; j++)
                        sum2 += s[j];
                    sign = s[i];
                    s = s.Remove(pos1, pos2 - pos1 + 1);
                    sum1 = DoOperation(sum1, sum2, sign);
                    s = s.Insert(pos1, sum1);
                    i = pos1;
                }
                i++;
            }
            i = 0;
            while (i < s.Length)
            {
                sum1 = sum2 = "";
                while (i < s.Length && !IsSign(s[i]))
                {
                    sum1 += s[i];
                    i++;
                }
                if (i < s.Length)
                {
                    sign = s[i];
                    i++;
                    while (i < s.Length && !IsSign(s[i]))
                    {
                        sum2 += s[i];
                        i++;
                    }
                    sum1 = DoOperation(sum1, sum2, sign);
                    s = s.Remove(0, i);
                    s = s.Insert(0, sum1);
                    i = 0;
                }
            }
            return s;
        }
        private void Do_Operation(object sender, EventArgs e)
        {
            int length = textBox1.Text.Length;
            if (textBox1.TextLength == 0)
            {
                textBox1.Text = "0";
                return;
            }
            if (textBox1.Text[length - 1] == '+' || textBox1.Text[length - 1] == '-')
            {
                textBox1.Text += "0";
                length = textBox1.Text.Length;
            }

            double sum = double.Parse(DoAllOperations(textBox1.Text));
            textBox1.Text = sum.ToString();
        }
        private void Number_Button_Click(object sender, EventArgs e)
        {
            textBox1.Text += (sender as Button).Text;
        }
        private void Clear_Box(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Calculator";
            this.Width = 241;
            this.Height = 355;
            textBox1 = new TextBox();
            textBox1.Location = new Point(9, 12);
            int x, y;
            //Text box
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(201, 20);
            textBox1.TextChanged += new EventHandler(TextBox_Changed);
            this.Controls.Add(textBox1);
            int counter;

            //buttons numeric
            counter = 0;
            for (y = 132; y <= 222; y += 45)
            {
                for (x = 77; x <= 167; x += 45)
                {
                    Button button = new Button();
                    button.Size = new Size(40, 40);
                    button.Text = counter.ToString();
                    button.Location = new Point(x, y);
                    button.Name = "Button" + counter;
                    button.Click += Number_Button_Click;
                    this.Controls.Add(button);
                    counter++;
                }
            }
            //operation button
            counter = 0;
            string[] arr = { "-", "*", "/", "+", "C", ",", "=", "0" };

            for (x = 77; x <= 167; x += 45)
            {
                Button button = new Button();
                button.Size = new Size(40, 40);
                button.Text = arr[counter];
                button.Location = new Point(x, 87);
                button.Name = "Button1" + counter;
                button.Click += Operation_Button_Click;
                this.Controls.Add(button);
                counter++;
            }
            //buttons + C = ,
            int counter1 = 0;
            EventHandler[] func = {Operation_Button_Click, Clear_Box,
                Operation_Button_Click,Do_Operation};
            for (y = 87; y <= 222; y += 45)
            {
                Button button1 = new Button();
                button1.Size = new Size(60, 40);
                button1.Text = arr[counter];
                button1.Location = new Point(10, y);
                button1.Click += func[counter1];
                button1.Name = "Button1" + counter;

                this.Controls.Add(button1);
                counter++;
                counter1++;
            }


            //button 0
            Button button2 = new Button();
            button2.Size = new Size(197, 40);
            button2.Text = arr[counter];
            button2.Location = new Point(10, y);
            button2.Name = "Button" + counter;
            button2.Click += Operation_Button_Click;
            this.Controls.Add(button2);
            counter++;

        }
    }
}
