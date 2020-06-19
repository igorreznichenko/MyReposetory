using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Collections.Specialized;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crossword
{
    public partial class Form1 : Form
    {
        List<List<Letter>> letters = new List<List<Letter>>();
        int size = 30;

        public Form1()
        {
            
            InitializeComponent();
            NameValueCollection nameValue = ConfigurationSettings.AppSettings;

            this.Width = int.Parse(nameValue["Width"]);
            this.Height = int.Parse(nameValue["Height"]);
            int i = 2;
            int X, Y, L;
            int n, j;
         
            Letter node;
            List<Letter> letter;
            TextBox t;
            string Word, Definition, Direct;
           

            while (i < nameValue.Count)
            {
                letter = new List<Letter>();
                Word = nameValue.Keys[i];
                Definition = nameValue[i++];
                X = int.Parse(nameValue[i++]);
                Y = int.Parse(nameValue[i++]);
                L = int.Parse(nameValue[i++]);
                Direct = nameValue[i++];
                
                j = 0;

                node = IsExist(X, Y);
                if (Direct == "H")
                    Definition = "По Горизонталі: \n" + Definition + '\n';
                else
                    Definition = "По Вертикалі: \n" + Definition + '\n';

                if (node == null)
                {
                    t = new TextBox();
                    t.BackColor = Color.Yellow;
                    t.Location = new Point(X, Y);
                    t.Size = new Size(size, size);
                    t.Multiline = true;
                    t.TextChanged += TextBox_TextChanged;
                    t.MouseClick += TextBox_MouseClick;
                    t.KeyPress += KeyPress_TextBox;
                    Controls.Add(t);
                    letter = new List<Letter>();
                    letter.Add(new Letter(t, Word[j++].ToString(), Definition));
                }
                else
                {
                    
                    letter.Add(node);
                    if(node.Definition == "")
                    {
                        node.AddMouseHandler(TextBox_MouseClick);
                        node.color = Color.Yellow;
                    }
                    node.Definition += Definition;
                    j++;
                }

                if (Direct == "H")
                {
                    for(n = X + size; n< X + L * size; n += size)
                    {
                        node = IsExist(n, Y);
                        if (node != null)
                        {
                            letter.Add(node);
                            j++;
                            continue;
                        }

                        t = new TextBox();                      
                        t.Location = new Point(n, Y);
                        t.Size = new Size(size,size);
                        t.TextChanged += TextBox_TextChanged;
                        t.Multiline = true;
                        t.KeyPress += KeyPress_TextBox;
                        letter.Add(new Letter(t, Word[j++].ToString()));
                        Controls.Add(t);
                    }
                }
                else
                {
                    for (n = Y + size; n < Y + L * size; n += size)
                    {
                        node = IsExist(X, n);
                        if (node != null)
                        {
                            letter.Add(node);
                            j++;
                            continue;
                        }

                        t = new TextBox();
                        t.Location = new Point(X, n);
                        t.Size = new Size(size, size);
                        t.Multiline = true;
                        t.TextChanged += TextBox_TextChanged;
                        t.KeyPress += KeyPress_TextBox;
                        letter.Add(new Letter(t, Word[j++].ToString()));
                        Controls.Add(t);
                    }
                }
                letters.Add(letter);
                Focus();
            }
        }
        
        private Letter IsExist(int X, int Y)
        {
            for(int i = 0; i < letters.Count; i++)
            {
                for(int j = 0; j < letters[i].Count; j++)
                {
                    if (letters[i][j].X == X && letters[i][j].Y == Y)
                        return letters[i][j];
                }
            }
            return null;
        }
    
        class Letter
        {
             public Letter(TextBox t, string Sign, string Definition)
            {
                this.t = t;            
                this.sign = Sign;
                this.Definition += Definition;
            }
            public Letter(Letter l)
            {
                this.t = l.t;
                this.sign = l.Sign;
            }

            public Letter(Letter l, string Definition)
            {
                
                this.t = l.t;
                this.sign = l.Sign;
                this.Definition += Definition;
            }
            public Letter(TextBox t,  string Sign)
            {
               
                this.t = t;
                this.sign = Sign;
            }

            
            TextBox t; 
           public Color color
            {
                set
                {
                    t.BackColor = value;
                }
            }
           public void AddMouseHandler(MouseEventHandler e)
            {
                t.MouseClick += e;
            }
            public int X
            {
                get
                {
                    return t.Location.X;
                }
            }
            public int Y
            {
                get
                {
                    return t.Location.Y;
                }
            }
            public string Sign
            {
                get
                {
                    return sign;
                }
            }
            
            public string Text
            {
                get
                {
                    return t.Text;
                }
            }
            string sign;
            public string Definition = "";
        }
        
        private List<int> GetIndex(int X, int Y)
        {
            List<int> l = new List<int>();
            int i, j;
            for(i = 0; i<letters.Count; i++)
            {
                for(j = 0; j< letters[i].Count; j++)
                {
                    if (letters[i][j].X == X && letters[i][j].Y == Y)
                        l.Add(i);
                }
            }
            return l;
        }
        private bool IsMainCell(int X, int Y)
        {
            for(int i = 0; i< letters.Count; i++)
            {
                if (letters[i][0].X == X && letters[i][0].Y == Y)
                    return true;
            }
            return false;
        }
        private void CheckWord(int index)
        {
            int i;
            for(i = 0; i< letters[index].Count; i++)
            {
                if (letters[index][i].Sign.ToUpper() != letters[index][i].Text.ToUpper())
                    break;
            }
            if(i == letters[index].Count)
            {
                for (i = 1; i < letters[index].Count; i++)
                {
                    if (!IsMainCell(letters[index][i].X, letters[index][i].Y))
                    letters[index][i].color = Color.LightGreen;
                }
            }
            else
            {
                for (i = 1; i < letters[index].Count; i++)
                {
                    if (!IsMainCell(letters[index][i].X, letters[index][i].Y))
                        letters[index][i].color = Color.White;
                    
                }
            }
           
            
        }
       private void  TextBox_TextChanged(object sender, EventArgs e)
        {
            int i = 0;
            TextBox text = (sender as TextBox);           
            List<int> index = GetIndex(text.Location.X, text.Location.Y);
            while (i < index.Count)
            {
                for (int j = 0; j < letters[index[i]].Count; j++)
                {
                    string s = letters[index[i]][j].Sign;
                }
                CheckWord(index[i]);
                i++;
            }
       }
        private void TextBox_MouseClick(object sender, EventArgs e)
        {
            TextBox t = (sender as TextBox);
             Letter def = IsExist(t.Location.X, t.Location.Y);
            MessageBox.Show(def.Definition);

        }
        private void KeyPress_TextBox(object sender, KeyPressEventArgs e)
        {
            TextBox t = sender as TextBox;
            
            if (e.KeyChar != (char)Keys.Back && t.TextLength == 1)
                e.Handled = true;

        }
        
    }
}
