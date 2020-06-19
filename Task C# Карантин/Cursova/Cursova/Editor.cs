using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Xml;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cursova
{
 
    public partial class Editor : Form
    {
        MainMenu form;
        OstTree tree;
        List<Vertice> vertices = new List<Vertice>();
        int n = 0;
        int sz = 30;
        int pos = -1;
        bool ShowWeight = true;
        bool Changed = false;
        Graphics g = null;
        Brush brush = null;
        Brush StringColor;

        string fp = null;
        public Editor()
        {
            InitializeComponent();
        }
        public Editor(MainMenu f, string filename)
        {
            InitializeComponent();
            OpenFile(filename);
           
            form = f;
            g = panel1.CreateGraphics();
            panel1.MouseClick += ChooseVertice;
            fp = filename;
            SetColors();
        }

        public Editor(MainMenu f)
        {
            InitializeComponent();
            form = f;
            g = panel1.CreateGraphics();
            panel1.MouseClick += ChooseVertice;
            SetColors();
           
        }


        private void Editor_Load(object sender, EventArgs e)
        {
        }
        public void SetColors()
        {
            NameValueCollection colors = ConfigurationManager.AppSettings;
            Color c = Color.FromArgb(int.Parse(colors[0]), int.Parse(colors[1]), int.Parse(colors[2]));
            brush = new SolidBrush(c);
            c = Color.FromArgb(int.Parse(colors[3]), int.Parse(colors[4]), int.Parse(colors[5]));
            StringColor = new SolidBrush(c);
          

        }
        public int AdjVertices(int pos)
        {
            Vertice v = vertices[pos].next;
            int i = 0;
            while(v != null)
            {
                i++;
                v = v.next;
            }
            return i;

        }
        private void ChooseVertice(object sender, MouseEventArgs e)
        {
            pos = CheckBound(e.X-15, e.Y-15,sz);
            if(pos!= -1)
            {
                Tethered.Enabled = true;
                FindEillerCycle.Enabled = true;
                GamiltonCycle.Enabled = true;
                GraphTree.Enabled = true;

                MoveVertices.Enabled = true;
                DeleteVertice.Enabled = true;
                AddVertice.Enabled = false;
                FindLength.Enabled = true;
                
                if (vertices[pos].next != null)
                {
                    ChangeEdge.Enabled = true;
                    DeleteEdge.Enabled = true;
                    ShowVertices.Enabled = true;                  
                }
                label2.Text = "Вибрана вершина: V" + vertices[pos].pos.ToString() + '\n';
                label2.Text += "Кількість суміжних вершин: " + AdjVertices(pos) + '\n';

            }
            else
            {
                label2.Text = "";
                ChangeEdge.Enabled = false;
                MoveVertices.Enabled = false;
                DeleteVertice.Enabled = false;
                FindEillerCycle.Enabled = false;
                GamiltonCycle.Enabled = false;
                Tethered.Enabled = false;
                AddVertice.Enabled = true;
                DeleteEdge.Enabled = false;
                ShowVertices.Enabled = false;
                FindLength.Enabled = false;
            }

        }

        private void Editor_FormClosed(object sender, FormClosedEventArgs e)
        {
            form.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tethered.Enabled = false;
            DeleteVertice.Enabled = false;
            AddVertice.Enabled = false;
            ShowVertices.Enabled = false;
            FindLength.Enabled = false;
            Rejection.Enabled = true;
            Rejection.Click += RejectionAddVertice;
            panel1.MouseClick -= ChooseVertice;
            panel1.MouseClick += PanelClick;
            panel1.MouseMove -= HighlightVertice;
            panel1.MouseEnter += panel1_MouseEnter;
            panel1.MouseLeave += panel1_MouseLeave;

            label2.Text = "Виберіть місце де буде розташовуватися вершина ";
            
        }
     
        public void DrawVertices()
        {
            Vertice v;
            for(int i = 0; i< vertices.Count; i++)
            {
                v = vertices[i].next;
                while (v != null)
                {
                    if (v.pos < vertices[i].pos)
                        v = v.next;
                    else
                    {
                        if (v.pos == vertices[i].pos)
                            g.DrawArc(new Pen(Color.Black, 2), v.x, v.y - 20, 30, 80, 0, 180);
                        else
                            g.DrawLine(new Pen(Color.Black, 2), vertices[i].x + 10, vertices[i].y + 10, v.x + 10, v.y + 10);
                        if (ShowWeight)
                        {
                            int mx, my;
                            mx = (vertices[i].x + v.x) / 2;
                            my = (vertices[i].y + v.y) / 2;
                            g.DrawString(v.Weight.ToString(), new Font(FontFamily.GenericSansSerif, 18, FontStyle.Bold), new SolidBrush(Color.Red), mx, my+30);
                            
                        }
                        v = v.next;
                    }

                }

            }
            for (int i = 0; i < vertices.Count; i++)
            {
              
               
                g.FillEllipse(brush, vertices[i].x, vertices[i].y, sz, sz);
                g.DrawString(vertices[i].pos.ToString(), DefaultFont, StringColor, vertices[i].x + 10, vertices[i].y + 10);
            }
        }
        private int CheckBound(int x, int y, int len)
        {
            int i;
            for(i = 0; i<vertices.Count; i++)
            {
                if (Math.Sqrt(Math.Pow(vertices[i].x - x, 2) + Math.Pow(vertices[i].y - y, 2)) < len)
                    return i;
            }
            return -1;
        }
        public void PanelClick(object sender, MouseEventArgs e)
        {
            if (CheckBound(e.X - 15, e.Y - 15, sz) != -1)
            {
                MessageBox.Show("Вершини занадто близькі виберіть інше положення");
                return;
            }

            vertices.Add(new Vertice(e.X-15, e.Y-15,n));
            n++;
            DrawVertices();
            panel1.MouseClick -= PanelClick;
            panel1.MouseClick += ChooseVertice;
            Rejection.Click -= RejectionAddVertice;
            label2.Text = "";
            AddVertice.Enabled = true;
            Rejection.Enabled = false;
            panel1.MouseMove += HighlightVertice;
            panel1.MouseEnter -= panel1_MouseEnter;
            panel1.MouseLeave -= panel1_MouseLeave;
            this.Cursor = Cursors.Default;
            Changed = true;
        }
        
        public void RejectionAddVertice(object sender, EventArgs e)
        {
            FindEillerCycle.Enabled = false;
            GamiltonCycle.Enabled = false;
            FindLength.Enabled = false;
            Rejection.Enabled = false;
            Rejection.Click -= RejectionAddVertice;
            panel1.MouseMove += HighlightVertice;
            panel1.MouseClick -= PanelClick;
            panel1.MouseClick += ChooseVertice;
            AddVertice.Enabled = true;
            panel1.MouseEnter -= panel1_MouseEnter;
            panel1.MouseLeave -= panel1_MouseLeave;
            label2.Text = "";

        }
        public void RejectionMoveVertice(object sender, EventArgs e)
        {
            Rejection.Click -= RejectionMoveVertice;
            panel1.MouseMove += HighlightVertice;
            panel1.MouseClick += ChooseVertice;
            panel1.MouseClick -= PanelClick1;
            panel1.MouseEnter -= panel1_MouseEnter;
            panel1.MouseLeave -= panel1_MouseLeave;
            GraphTree.Enabled = true;
            AddVertice.Enabled = true;
            Rejection.Enabled = false;
            FindEillerCycle.Enabled = false;
            GamiltonCycle.Enabled = false;
            FindLength.Enabled = false;
            GraphTree.Enabled = true;

            label2.Text = "";


        }
        public void RejectionConnectVertice(object sender, EventArgs e)
        {
            AddVertice.Enabled = true;
            Rejection.Enabled = false;
            FindEillerCycle.Enabled = false;
            GamiltonCycle.Enabled = false;
            FindLength.Enabled = false;
            GraphTree.Enabled = true;
            Rejection.Click -= RejectionConnectVertice;
            panel1.MouseClick += ChooseVertice;
            panel1.MouseClick -= ConnectVertices;
            label2.Text = "";
            numericUpDown1.Enabled = false;

        }

        public void RejectionDelEdge(object sender, EventArgs e)
        {
            panel1.MouseClick -= DelEdge;
            panel1.MouseClick += ChooseVertice;
            label2.Text = "";
            AddVertice.Enabled = true;
            Rejection.Enabled = false;
            Rejection.Click -= RejectionDelEdge;
            FindLength.Enabled = false;
            GamiltonCycle.Enabled = false;
            FindEillerCycle.Enabled = false;
            ChangeEdge.Enabled = false;
            GraphTree.Enabled = true;
        }
        public void RejectionEditEdge(object sender, EventArgs e)
        {
            panel1.MouseClick -= EditEdge;
            panel1.MouseClick += ChooseVertice;
            numericUpDown1.Enabled = false;
            ChangeEdge.Enabled = false;
            Rejection.Enabled = false;
            Rejection.Click -= RejectionEditEdge;
            AddVertice.Enabled = true;
            FindEillerCycle.Enabled = false;
            GamiltonCycle.Enabled = false;
            FindLength.Enabled = false;
            AddVertice.Enabled = true;
            GraphTree.Enabled = true;
            label2.Text = "";

        }

        private void MoveVertices_Click(object sender, EventArgs e)
        {
            label2.Text = ("Виберіть нове положення вершини");
            Tethered.Enabled = false;
            MoveVertices.Enabled = false;
            DeleteVertice.Enabled = false;
            DeleteEdge.Enabled = false;
            ShowVertices.Enabled = false;
            AddVertice.Enabled = false;
            FindLength.Enabled = false;
            GraphTree.Enabled =false;
            FindEillerCycle.Enabled = false;
            GamiltonCycle.Enabled = false;
            Rejection.Enabled = true;
            if (ChangeEdge.Enabled == true)
                ChangeEdge.Enabled = false;
            Rejection.Click += RejectionMoveVertice;
            panel1.MouseClick -= ChooseVertice;
            panel1.MouseClick += PanelClick1;
            panel1.MouseMove -= HighlightVertice;
            panel1.MouseEnter += panel1_MouseEnter;
            panel1.MouseLeave += panel1_MouseLeave;
        }
       public void PanelClick1(object sender, MouseEventArgs e)
        {
            if(CheckBound(e.X-15,e.Y-15,sz) != -1)
            {
                MessageBox.Show("Вершини занадто близькі виберіть інше положення");
                return;
            }
            vertices[pos].x = e.X - 15;
            vertices[pos].y = e.Y - 15;
            for(int i= 0; i < vertices.Count; i++)
            {
                Vertice v = vertices[i];
                if (v.next == null)
                    continue;
                
                while (v.next.next != null && v.next.pos != vertices[pos].pos)
                    v = v.next;
                if (v.next.pos == vertices[pos].pos)
                {
                    v.next.x = e.X - 15;
                    v.next.y = e.Y - 15;
                }

            }
            g.Clear(panel1.BackColor);
            DrawVertices();
            pos = -1;
            panel1.MouseClick += ChooseVertice;
            panel1.MouseClick -= PanelClick1;
            Rejection.Click -= RejectionMoveVertice;
            AddVertice.Enabled = true;
            Rejection.Enabled = false;
            GraphTree.Enabled = false;

            label2.Text = "";
            panel1.MouseEnter -= panel1_MouseEnter;
            panel1.MouseLeave -= panel1_MouseLeave;
            panel1.MouseMove += HighlightVertice;
            GraphTree.Enabled = true;
            this.Cursor = Cursors.Default;
            Changed = true;
        }

        private void DeleteVertice_Click(object sender, EventArgs e)
        {
            AddVertice.Enabled = true;
            DeleteVertice.Enabled = false;
            MoveVertices.Enabled = false;
            DeleteEdge.Enabled = false;
            ShowVertices.Enabled = false;
            FindLength.Enabled = false;
            Tethered.Enabled = false;
            FindEillerCycle.Enabled = false;
            GamiltonCycle.Enabled = false;
            ChangeEdge.Enabled = false;
            Vertice v1 = vertices[pos].next;
            Vertice v2;
            int i;
            while(v1!= null)
            {
                i = 0;
                while (vertices[i].pos != v1.pos)
                    i++;
                v2 = vertices[i];
                while (v2.next.pos != vertices[pos].pos)
                    v2 = v2.next;
                    v2.next = v2.next.next;
                v1 = v1.next;
            }
            vertices.RemoveAt(pos);
            
            g.Clear(panel1.BackColor);
            DrawVertices();
            label2.Text = "";
            Changed = true;
        }

        private void Tethered_Click(object sender, EventArgs e)
        {
            DeleteVertice.Enabled = false;
            GraphTree.Enabled = false;
            FindLength.Enabled = false;
            GamiltonCycle.Enabled = false;
            FindEillerCycle.Enabled = false;
            ChangeEdge.Enabled = false;
            MoveVertices.Enabled = false;
            AddVertice.Enabled = false;
            FindLength.Enabled = false;
            ShowVertices.Enabled = false;
            DeleteEdge.Enabled = false;
            Tethered.Enabled = false;
            Rejection.Enabled = true;
            Rejection.Click += RejectionConnectVertice;
            panel1.MouseClick -= ChooseVertice;
            panel1.MouseClick += ConnectVertices;
            label2.Text = "Виберіть одну з вершин";
            numericUpDown1.Enabled = true;

        }
        public void AddEdge(int pos, int pos1)
        {
            Vertice v = vertices[pos];
            decimal Weight = numericUpDown1.Value;

            while (v.next != null)
                v = v.next;
            v.next = new Vertice(vertices[pos1], Weight);

        }
        public bool IsAddedEdge(int pos1)
        {
            Vertice v = vertices[pos];
            if (v.next == null)
                return false;
            while (v.next.next != null && v.next.pos != vertices[pos1].pos)
                v = v.next;
            if (v.next.pos == vertices[pos1].pos)
                return true;
            else
                return false;

        }
        public void ConnectVertices(object sebder, MouseEventArgs e)
        {
            int pos1 = CheckBound(e.X - 15, e.Y - 15, sz);
            if(pos1 == -1)
            {
                 MessageBox.Show("Виберіть одну з вершин");
                return;
            }

            if (IsAddedEdge(pos1))
            {
                MessageBox.Show("Ребро уже існує, виберіть іншу вершину");
                return;
            }

            if(pos == pos1)
                AddEdge(pos, pos1);
            else
            {
                AddEdge(pos, pos1);
                AddEdge(pos1, pos);
            }

            g.Clear(panel1.BackColor);
            DrawVertices();
            panel1.MouseClick += ChooseVertice;
            panel1.MouseClick -= ConnectVertices;
            Rejection.Click -= RejectionConnectVertice;
            Rejection.Enabled = false;
            AddVertice.Enabled = true;
            Tethered.Enabled = false;
            numericUpDown1.Enabled = false;
            numericUpDown1.Value = 1;
            label2.Text = "";
            DeleteVertice.Enabled = false;
            Changed = true;
            GraphTree.Enabled = true;

        }

        private void Editor_SizeChanged(object sender, EventArgs e)
        {
            DrawVertices();
        }

        public void ChangeCursor(object sender, MouseEventArgs e)
        {
            if (CheckBound(e.X - 15, e.Y - 15, sz/2) != -1)
                this.Cursor = Cursors.Hand;
            else
                this.Cursor = Cursors.Default;
        }
        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void DeleteEdge_Click(object sender, EventArgs e)
        {
            
            panel1.MouseClick -= ChooseVertice;
            Rejection.Click += RejectionDelEdge;
            panel1.MouseClick += DelEdge;
            ChangeEdge.Enabled = false;
            GraphTree.Enabled = false;
            Rejection.Enabled = true;
            FindLength.Enabled = false;
            FindEillerCycle.Enabled = false;
            GamiltonCycle.Enabled = false;
            Tethered.Enabled = false;
            DeleteEdge.Enabled = false;
            DeleteVertice.Enabled = false;
            ShowVertices.Enabled = false;
            MoveVertices.Enabled = false;
            GraphTree.Enabled = false;
            label2.Text = "Оберіть суміжну вершину";
           
        }
        public void RmEdge(int pos1, int pos2)
        {
            Vertice v = vertices[pos1];
            if (v.next == null)
                return;
            while (v.next.next != null && v.next.pos != vertices[pos2].pos)
                v = v.next;
            if (v.next.pos == vertices[pos2].pos)
                v.next = v.next.next;
        }
        public void DelEdge(object sender, MouseEventArgs e)
        {
            int pos1 = CheckBound(e.X - 15, e.Y - 15, sz);
            if(pos1 == -1)
            {
                MessageBox.Show("Виберіть одну з вершин");
                return;
            }
            if (!IsAddedEdge(pos1))
            {
                MessageBox.Show("Ребро не icнyє");
                return;
            }
            if (pos == pos1)
                RmEdge(pos, pos1);
            else
            {
                RmEdge(pos, pos1);
                RmEdge(pos1, pos);
            }
            panel1.MouseClick -= DelEdge;
            panel1.MouseClick += ChooseVertice;
            g.Clear(panel1.BackColor);
            DrawVertices();
            label2.Text = "";
            AddVertice.Enabled = true;
            Rejection.Enabled = false;
            Rejection.Click -= RejectionDelEdge;
            FindLength.Enabled = false;
            GamiltonCycle.Enabled = false;
            FindEillerCycle.Enabled = false;
            ChangeEdge.Enabled = false;
            GraphTree.Enabled = true;
            Changed = true;



        }

        private void ShowVertices_Click(object sender, EventArgs e)
        {
            string vs = "";
            vs += "Вершина V" + vertices[pos].pos + '\n';
            vs += "Список суміжних вершин\n";
            Vertice v = vertices[pos].next;
            while (v != null)
            {
                vs += "V" + v.pos + ", l=" + v.Weight + '\n';
                v = v.next;
            }
            vs += "l - довжина спільного ребра";
            MessageBox.Show(vs);
        }

        public int RetPos(int pos)
        {
            for(int i = 0; i< vertices.Count; i++)
            {
                if (vertices[i].pos == pos)
                    return i;
            }
            return -1;
        }
        private void FindLength_Click(object sender, EventArgs e)
        {
            int len = vertices.Count;
            bool[] vis = new bool[len];
            int i;
            int V = pos;
            int index;
            int[] arr = new int[len];
            for (i = 0; i < len; i++)
                arr[i] = int.MaxValue;
            arr[V] = 0;
            Vertice v;
            int min;
            int p;
            do
            {
                v = vertices[V].next;
                min = int.MaxValue;
                p = -1;
                vis[V] = true;
                while (v != null)
                {
                    index = RetPos(v.pos);
                    if (arr[V] + v.Weight < arr[index])
                    {
                        arr[index] = arr[V] + (int)v.Weight;
                        if (arr[index] < min)
                        {
                            min = arr[index];
                            p = index;
                        }

                    }
                    v = v.next;

                }

                if(p == -1)
                {
                    i = 0;
                    while (i < len && (vis[i] || arr[i] == int.MaxValue))
                        i++;
                    if (i < len)
                        p = i;
                }
                V = p;
            } while (p != -1);
            g.Clear(panel1.BackColor);
            DrawVertices();
            DrawPaths(arr);
         
        }
       public void DrawPaths(int[] arr)
        {
            int i;
            Font font = new Font(FontFamily.GenericSansSerif,14,FontStyle.Regular);
            for(i = 0; i< vertices.Count; i++)
            {
                if(arr[i]== int.MaxValue)
                g.DrawString("inf", font, new SolidBrush(Color.Black), vertices[i].x + sz, vertices[i].y);
                else
                    g.DrawString(arr[i].ToString(), font, new SolidBrush(Color.Green), vertices[i].x + sz, vertices[i].y);

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text File(*.txt)|*.txt";

            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string f = saveFileDialog1.FileName;
            if(fp == null)
            fp = f;
            Saving(f);
            MessageBox.Show("Граф успішно збережено");
            Changed = false;
        }
        private void OpenFile(string path)
        {
            string[] res;
            int j, i = 0;
            int x, y, pos;
            Vertice v;
            decimal Weight;
            vertices.Clear();
            using (StreamReader Gr = new StreamReader(path))
            {
                n = int.Parse(Gr.ReadLine());
                while (!Gr.EndOfStream)
                {
                    res = Gr.ReadLine().Split(' ');

                    x = int.Parse(res[0]);
                    y = int.Parse(res[1]);
                    pos = int.Parse(res[2]);
                    Weight = decimal.Parse(res[3]);
                    vertices.Add(new Vertice(x, y, pos, Weight));
                   
                    v = vertices[i];
                    j = 4;
                    while (j < res.Length)
                    {
                        x = int.Parse(res[j++]);
                        y = int.Parse(res[j++]);
                        pos = int.Parse(res[j++]);
                        Weight = decimal.Parse(res[j++]);
                        v.next = new Vertice(x, y, pos, Weight);
                        v = v.next;
                        v.next = null;
                    }
                    i++;
                }
            }
        }
        public void Saving(string file)
        {
            StreamWriter Sg = new StreamWriter(file);
            Vertice v;
            Sg.WriteLine(n);
            for (int i = 0; i < vertices.Count; i++)
            {
                v = vertices[i];

                while (v.next != null)
                {
                    Sg.Write("{0} {1} {2} {3} ", v.x, v.y, v.pos, v.Weight);
                    v = v.next;
                }
                Sg.Write("{0} {1} {2} {3}", v.x, v.y, v.pos, v.Weight);

                Sg.WriteLine();
            }

            Sg.Close();
        }
        private void Editor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Changed)
            {
                DialogResult dialogResult = MessageBox.Show("Зберегти зміни ?", "Збереження", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    string f;
                    if (fp == null)
                    {
                        saveFileDialog1.Filter = "Text File(*.txt)|*.txt";

                        if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                            return;

                        f = saveFileDialog1.FileName;
                    }
                    else
                        f = fp;
                    Saving(f);
                   
                }
                else
                {
                    if (dialogResult == DialogResult.Cancel)
                        e.Cancel = true;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Bmp File(*.bmp)|*.bmp|Jpeg File(*.jpeg)|*.jpeg|Png file(*.png)|*.png";
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filepath = saveFileDialog1.FileName;
            Bitmap Image = new Bitmap(panel1.Width, panel1.Height);
            g = Graphics.FromImage(Image);
            g.Clear(Color.White);
            DrawVertices();
            g = panel1.CreateGraphics();
            string format;
            int pos1 = filepath.LastIndexOf('.');
            format = filepath.Substring(++pos1);
            switch (format) {
            case "bmp":
                    {
                        Image.Save(filepath, ImageFormat.Bmp);
                        break;
                    }
                case "jpeg": {
                        Image.Save(filepath, ImageFormat.Jpeg);
                        break;
                    }
                case "png":
                    {
                        Image.Save(filepath, ImageFormat.Png);
                        break;
                    }
            }
        }
        private void ChangeEdge_Click(object sender, EventArgs e)
        {
            panel1.MouseClick -= ChooseVertice;
            panel1.MouseClick += EditEdge;
            Rejection.MouseClick += RejectionEditEdge;

            ChangeEdge.Enabled = false;


            Rejection.Enabled = true;

            GraphTree.Enabled = false;
            FindLength.Enabled = false;       
            GamiltonCycle.Enabled = false;
            FindEillerCycle.Enabled = false;

           
            Tethered.Enabled = false;
            DeleteEdge.Enabled = false;
            DeleteVertice.Enabled = false;
            ShowVertices.Enabled = false;
            MoveVertices.Enabled = false;
            numericUpDown1.Enabled = true;
            label2.Text = "Змініть вагу і оберіть нову вершину";
        }
        public void Change(int pos1, int pos2)
        {
            int i;
            Vertice v;
            v = vertices[pos1];
            if (v.next == null)
                return;
            while (v.next.next != null && v.next.pos != vertices[pos2].pos)
                v = v.next;
            if (v.next.pos == vertices[pos2].pos)
                v.next.Weight = numericUpDown1.Value;
        }
        public void EditEdge(object sender, MouseEventArgs e)
        {
            
            int pos1 = CheckBound(e.X - 15, e.Y - 15, sz);
            if (pos1 == -1)
            {
                MessageBox.Show("Виберіть одну з вершин");
                return;
            }
            if (!IsAddedEdge(pos1))
            {
                MessageBox.Show("Ребро не icнyє");
                return;
            }
            if (pos == pos1)
                Change(pos, pos1);
            else
            {
                Change(pos, pos1);
                Change(pos1, pos);
            }
            g.Clear(panel1.BackColor);
            DrawVertices();
            panel1.MouseClick -= EditEdge;
            panel1.MouseClick += ChooseVertice;
            Rejection.Click -= RejectionEditEdge;
            numericUpDown1.Value = 1;
            numericUpDown1.Enabled = false;
            Rejection.Enabled = false;
            ChangeEdge.Enabled = false;
            FindEillerCycle.Enabled = false;
            GamiltonCycle.Enabled = false;
            FindLength.Enabled = false;
            AddVertice.Enabled = true;
            GraphTree.Enabled = true;
            label2.Text ="";
            
        }

        private void Editor_Move(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (fp != null)
            {
                Saving(fp);
            }
            else
            {
                saveFileDialog1.Filter = "Text File(*.txt)|*.txt";
                DialogResult d = saveFileDialog1.ShowDialog();

                if (d == DialogResult.Cancel)
                    return;
                fp = saveFileDialog1.FileName;
                Saving(fp);
            }
            MessageBox.Show("Граф успішно збережено !", "Збереження", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
            Changed = false;
        }

        private void OpenGraph_Click(object sender, EventArgs e)
        {
            if (Changed)
            {
                DialogResult dialogResult = MessageBox.Show("Зберегти зміни ?", "Збереження", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(dialogResult == DialogResult.Yes)
                {
                    if(fp != null)
                        Saving(fp);              
                    else
                    {
                        saveFileDialog1.Filter = "Text Files(*.txt)|*.txt";
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            string filePath = saveFileDialog1.FileName;
                            Saving(filePath);
                        }
                        
                    }
                }
            }
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
                fp = openFileDialog1.FileName;
            vertices.Clear();
            OpenFile(fp);
            g.Clear(panel1.BackColor);
            DrawVertices();
            Changed = false;
        }

        private void Editor_LocationChanged(object sender, EventArgs e)
        {

            //if (Location.X < 0 || Location.Y < 0 ||
            //    Location.X + Width > Screen.PrimaryScreen.Bounds.Width || Location.Y + Height > Screen.PrimaryScreen.Bounds.Height)
            //    DrawVertices();
        }

       

        private void button3_Click_1(object sender, EventArgs e)
        {
            ShowWeight = !ShowWeight;
            g.Clear(panel1.BackColor);
            DrawVertices();
        }

        private bool[] DepthFirst(bool[] arr, int V)
        {
            int pos = RetPos(V);
            Vertice v = vertices[pos];
            arr[pos] = true;
            while(v != null)
            {
                pos = RetPos(v.pos);
                if (!arr[pos])
                   arr = DepthFirst(arr, v.pos);
                v = v.next;
            }
            return arr;
            
        }
        private void GraphTree_Click(object sender, EventArgs e)
        {
            if (vertices.Count != 0)
            {
                bool[] arr = new bool[vertices.Count];
                arr = DepthFirst(arr, vertices[0].pos);
                int i = 0;
                while (i < arr.Length && arr[i] == true)
                    i++;
                if (i == arr.Length)
                {
                    Array.Clear(arr,0,arr.Length);
                    int m1 = 1, m2 = RetPos(vertices[0].pos);
                    decimal min;
                    int j;
                    Vertice v = null;
                    List<int> vt = new List<int>();
                    List<Vertice> GTree = new List<Vertice>();
                    GTree.Add(new Vertice(vertices[0],vertices[0].Weight));
                // m1 m2 - ребро яке потрібно буде додати до остовного дерева
                   while (vt.Count < vertices.Count)
                   {
                        arr[m2] = true;
                        vt.Add(m2);
                        min = decimal.MaxValue;
                        for (i = 0; i < vt.Count; i++)
                        {
                            v = vertices[vt[i]].next;
                       
                            while (v != null)
                            {
                                if (!arr[RetPos(v.pos)] && min > v.Weight)
                                {
                                    m1 = vt[i];
                                    m2 = RetPos(v.pos);
                                    min = v.Weight;
                                }
                                v = v.next;
                            }
                        }
                        if (min != decimal.MaxValue)
                        {
                            j = 0;
                            while (j < GTree.Count && RetPos(GTree[j].pos) != m1)
                            {
                                j++;
                            }
                            v = GTree[j];
                            while (v.next != null)
                                v = v.next;
                            v.next = new Vertice(vertices[m2], min);
                            GTree.Add(new Vertice(vertices[m2], 0));            
                        }
                      
                    }
                    tree = new OstTree(GTree, (SolidBrush)brush, (SolidBrush)StringColor, sz,OstTree.Algorithm.OstTree);
                    tree.Show();
                    return;
                 
                }
            }
            MessageBox.Show("Неможливо побудувати мінімальне остовне дерево для цього графу!", "Остовне дерево", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //Чи всі чтепені вершин є парними
        bool IsEvenVertices()
        {
            int i;
            int count;
            Vertice v;
            for(i = 0; i< vertices.Count; i++)
            {
                count = 0;
                v = vertices[i].next;
                while (v != null) {
                    count++;
                    v = v.next;
                }
                if (count % 2 == 1)
                    return false;
            }
            return true;
        }
        private bool ContainEdge(List<Vertice> v, int pos1, int pos2)
        {
            Vertice v1;
            for(int i = 0; i< v.Count; i++)
            {
                if(v[i].pos == pos1 || v[i].pos == pos2)
                {
                    v1 = v[i].next;
                    while (v1 != null && v1.pos != pos2 && v1.pos != pos1)
                        v1 = v1.next;
                    if(v1 != null)
                        return true;
                }
            }
            return false;
        }
        public int AmountEdges(List<Vertice> V)
        {
            int amount = 0;
            for(int i = 0; i< V.Count; i++)
            {
                Vertice v = V[i].next;
                while (v != null)
                {
                    v = v.next;
                    amount++;
                }
            }
            return amount/2;
        }
        public bool IsBridgeEdge(int V,int V1, int V2, List<Vertice> Edges, bool[] arr)
        {

            Vertice v = vertices[RetPos(V)].next;
            arr[RetPos(V)] = true;
            if (V == V2)
                return false;

            while(v != null)
            {
                if (V == V1 && v.pos == V2)
                    v = v.next;
                else
                if (!arr[RetPos(v.pos)] && !ContainEdge(Edges, V, v.pos) && !IsBridgeEdge(v.pos, V1, V2, Edges,arr))
                    return false;
                else
                v = v.next;
            }
            return true;
        }
        public int AdjVertices(int V, List<Vertice> edges)
        {
            Vertice v = vertices[RetPos(V)].next;
            int count = 0;
            while(v != null)
            {
                if (!ContainEdge(edges, V, v.pos))
                    count++;
                v = v.next;
            }
            return count;


        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (vertices.Count != 0)
            {
                bool[] arr = new bool[vertices.Count];
                arr = DepthFirst(arr, vertices[0].pos);
                int i = 0;
                while (i < arr.Length && arr[i])
                    i++;
                if(i == arr.Length && IsEvenVertices())
                {
                    List<Vertice> edges = new List<Vertice>();
                    Vertice v1, v2;
                    int V = vertices[pos].pos;
                    int n = AmountEdges(vertices);
                    int number = 0;
                    do
                    {
                    
                        v1 = vertices[RetPos(V)];
                        edges.Add(new Vertice(v1, v1.Weight));
                        
                        v1 = v1.next;
                       
                        int p = AdjVertices(V, edges);
                        if (number != n - 1 && p > 1)
                        {
                           
                            while (v1 != null && (ContainEdge(edges, V, v1.pos) || IsBridgeEdge(V, V, v1.pos, edges, new bool[vertices.Count()])))
                            {
                                v1 = v1.next;
                            }
                        }
                        else
                        {
                            while (v1 != null && ContainEdge(edges, V, v1.pos))
                            {
                                v1 = v1.next;
                            }
                        }
                            

                        if(v1!= null)
                        {
                            V = v1.pos;
                            v2 = edges[edges.Count - 1];
                            while(v2.next != null)
                                v2 = v2.next;
                            v2.next = new Vertice(v1, v1.Weight);
                            number++;
                        }
                        
                    } while (number != n);

                    OstTree ECycle = new OstTree(edges, (SolidBrush)brush, (SolidBrush)StringColor,sz, OstTree.Algorithm.EllerCycle);
                    ECycle.Show();
                    return;
                }
              
            }
            MessageBox.Show("Неможливо побудувати ейлерів цикл для заданого графу", default, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public bool FindGamiltonCycle(int V, List<Vertice> edges, bool[] arr, int n = 1)
        {
            Vertice v1 = vertices[V].next;
            arr[V] = true;
            while (v1 != null)
            {
                if (!arr[RetPos(v1.pos)] && FindGamiltonCycle(RetPos(v1.pos), edges, arr, n+1))
                {
                    
                    edges.Insert(0,new Vertice(vertices[V],vertices[V].Weight));
                    edges[0].next = new Vertice(v1, v1.Weight);
                    return true;
                  
                }  
                v1 = v1.next;
            }

            if(n == vertices.Count)
            {
                if (ContainEdge(vertices, vertices[pos].pos, vertices[V].pos))
                {
                    edges.Insert(0,new Vertice(vertices[V], vertices[V].Weight));
                    edges[0].next = new Vertice(vertices[pos], vertices[pos].Weight);

                    return true;
                }
            }
            arr[V] = false;
            return false;
            
            
        }
        private void button4_Click_1(object sender, EventArgs e)
        {
            if (vertices.Count > 2)
            {
                List<Vertice> edges = new List<Vertice>();
                bool[] arr = new bool[vertices.Count];
                if (FindGamiltonCycle(pos, edges, arr))
                {
                    OstTree GCycle = new OstTree(edges, (SolidBrush)brush, (SolidBrush)StringColor, sz, OstTree.Algorithm.GamiltonCycle);
                    GCycle.Show();
                    return;
                }
            }
            MessageBox.Show("Неможливо побудувати гамільтонів цикл для заданого графу", default, MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void вершиниToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string s = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).FilePath;
            Color c = colorDialog1.Color;
            brush = new SolidBrush(c);
            XmlDocument d = new XmlDocument();
            d.Load(s);        
            XmlNode node = d.SelectSingleNode("//appSettings");
            node = node.FirstChild;
            node.Attributes[1].Value = c.R.ToString();
            node = node.NextSibling;
            node.Attributes[1].Value = c.G.ToString();
            node = node.NextSibling;
            node.Attributes[1].Value = c.B.ToString();
            d.Save(s);
            DrawVertices();
        }

        private void текстToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string s = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).FilePath;
            Color c = colorDialog1.Color;
            StringColor = new SolidBrush(c);
            XmlDocument d = new XmlDocument();
            d.Load(s);
            XmlNode node = d.SelectSingleNode("//appSettings");
           node =  node.SelectSingleNode("//add[@key='R2']");
            MessageBox.Show(node.Attributes.Count.ToString());
            node.Attributes[1].Value = c.R.ToString();
            node = node.NextSibling;
            node.Attributes[1].Value = c.G.ToString();
            node = node.NextSibling;
            node.Attributes[1].Value = c.B.ToString();
            d.Save(s);
            DrawVertices();
        }

        private void HighlightVertice(object sender, MouseEventArgs e)
        {
            if (CheckBound(e.X-sz/2, e.Y-sz/2, sz/2) != -1)
                this.Cursor = Cursors.Hand;
            else
                this.Cursor = Cursors.Default;
          
        }
    }
}