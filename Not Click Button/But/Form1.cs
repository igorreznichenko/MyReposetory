using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace But
{
    public partial class Form1 : Form
    {
        int time = 0;
        string[] message = { "Press OK button", "You can't press OK" };
        int pos = 0;
        public Form1()
        {
            InitializeComponent();
            timer1.Tick += ChangeText;
            this.MouseMove += Form1_Mouserange;
            this.button2.LostFocus += GotCursor_Button2;
            timer1.Start();
        }
  
        private void GotCursor_Button2(object sender, EventArgs e)
        {
            if (!button2.Focused)
                button2.Focus();
        }
        private void ChangeText(object sender, EventArgs e)
        {
            if (time == 7)
            {
                time = 0;
                pos++;
                timer1.Stop();
                return;
            }
            if (time % 2 == 0)
                this.Text = message[pos];
            else
                this.Text = "";

            time++;
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Mouserange(object sender, MouseEventArgs e)
        {
            int range = 20;
            int move = 10;
            Point point1 = new Point(button1.Location.X, button1.Location.Y);
            Point point2 = new Point(button1.Location.X + button1.Width, button1.Location.Y);
            Point point3 = new Point(button1.Location.X, button1.Location.Y + button1.Height);
            Point point4 = new Point(button1.Location.X + button1.Width, button1.Location.Y + button1.Height);

            if (e.X > point1.X - range && e.X < point2.X + range)
            {
                if (e.Y > point1.Y - range && e.Y < point3.Y + range)
                {
                    if (e.X > point1.X && e.X < point2.X && e.Y > point3.Y)
                    {
                        button1.Location = new Point(point1.X, point1.Y - move);
                    }
                    else
                    {
                        if (e.X > point1.X && e.X < point2.X && e.Y < point3.Y)
                        {
                            button1.Location = new Point(point1.X, point1.Y + move);
                        }
                        else
                        {
                            if (e.Y > point1.Y && e.Y < point3.Y && e.X < point1.X)
                            {
                                button1.Location = new Point(point1.X + move, point1.Y);
                            }
                            else
                            {
                                if (e.Y > point1.Y && e.Y < point3.Y && e.Y > point2.Y)
                                {
                                    button1.Location = new Point(point1.X - move, point1.Y);
                                }
                                else
                                {
                                    if (e.X > point1.X - range && e.X < point1.X && e.Y > point1.Y - range && e.Y < point1.Y)
                                    {
                                        button1.Location = new Point(point1.X + move, point1.Y + move);

                                    }
                                    else
                                    {
                                        if (e.X > point2.X && e.X < point2.X+range && e.Y > point2.Y - range && e.Y < point1.Y)
                                        {
                                            button1.Location = new Point(point1.X - move, point1.Y + move);

                                        }
                                        else
                                        {
                                            if (e.X > point3.X-range && e.X < point3.X && e.Y > point3.Y && e.Y < point3.Y+range)
                                            {
                                                button1.Location = new Point(point1.X + move, point1.Y - move);

                                            }
                                            else {
                                                if (e.X > point4.X && e.X < point4.X + range && e.Y > point4.Y && e.Y < point4.Y + range)
                                                {
                                                    button1.Location = new Point(point1.X - move, point1.Y - move);

                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    //button1.Width -= 1;
                    //button1.Height -= 1;
                }
            }
            //end if-else block
            if (button1.Width == 0 || button1.Height == 0)
            {
                this.MouseMove -= Form1_Mouserange;
                button1.Hide();
                timer1.Start();
                return;
            }
            int step = 400;
            point1 = new Point(button1.Location.X, button1.Location.Y);
            point2 = new Point(button1.Location.X + button1.Width, button1.Location.Y + button1.Height);
            if(point1.X < 0 && point1.Y < 0)
            {
                button1.Location = new Point(point1.X + step, point1.Y + step);
            }
            else
            {
                if(point1.Y < 0)
                {
                    button1.Location = new Point(point1.X, point1.Y + step);
  
                }
                else
                {
                    if(point1.X < 0)
                    {
                        button1.Location = new Point(point1.X + step, point1.Y);
                    }
                    else
                    {
                        if(point2.X > Width && point2.Y > Height)
                        {
                            button1.Location = new Point(point2.X - step, point2.Y-step);
                        }
                        else
                        {
                            if(point2.X > Width)
                            {
                                button1.Location = new Point(point2.X - step, point2.Y);
                            }
                            else
                                if(point2.Y > ClientRectangle.Height)
                            {
                                button1.Location = new Point(point2.X, point2.Y - step);
                            }
                        }
                    }
                }
            }

            point1 = new Point(button1.Location.X, button1.Location.Y);
            point2 = new Point(button1.Location.X + button1.Width, button1.Location.Y);
            point3 = new Point(button1.Location.X, button1.Location.Y + button1.Height);
            point4 = new Point(button1.Location.X + button1.Width, button1.Location.Y + button1.Height);


            Point cpoint1 = new Point(button2.Location.X, button2.Location.Y);
            Point cpoint2 = new Point(button2.Location.X + button2.Width, button2.Location.Y);
            Point cpoint3 = new Point(button2.Location.X, button2.Location.Y+button2.Height);
            Point cpoint4 = new Point(button2.Location.X + button2.Width, button2.Location.Y + button2.Height);
            if(point3.Y == cpoint1.Y && (cpoint1.X >= point3.X && cpoint1.X <= point4.X || cpoint2.X >= point3.X && cpoint2.X <= point4.X))
            {
                button1.Location = new Point(point1.X, point1.Y - 60);
            }
            else
            {
                 if(cpoint3.Y == point1.Y && (cpoint3.X >= point1.X && cpoint3.X <= point2.X || cpoint4.X >= point1.X && cpoint4.X <= point2.X))
                {
                    button1.Location = new Point(point1.X, point1.Y + 40);
                }
                else
                {
                    if(cpoint1.X == point2.X && (cpoint1.Y >= point1.Y && cpoint1.Y <= point3.Y || cpoint3.Y >= point1.Y && cpoint3.Y <= point4.Y))
                    {
                        button1.Location = new Point(point1.X-40, point1.Y);

                    }
                    else
                    {
                        if(cpoint2.X == point1.X && (cpoint2.Y >= point2.Y && cpoint2.Y <= point4.Y || cpoint4.Y >= point2.Y && cpoint3.Y <= point4.Y))
                        {
                            button1.Location = new Point(point1.X + 40, point1.Y);

                        }
                    }
                }

            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Enter(object sender, EventArgs e)
        {
            button2.Focus();
        }
    }

     
    
}
