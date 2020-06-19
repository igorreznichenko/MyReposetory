using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cursova
{
    public partial class OstTree : Form
    {
        int size;
        List<Vertice> vertices = new List<Vertice>();
        Brush back;
        Brush StringColor;
        Graphics g;
        string path;
        bool ShowWeight = true;
        public enum Algorithm { OstTree, EllerCycle, GamiltonCycle};
        public Algorithm Alg;

        public OstTree(List<Vertice> v, SolidBrush b, SolidBrush s, int sz, Algorithm alg)
        {
            InitializeComponent();
            vertices = v;
            back = b;
            StringColor = s;
            g = panel1.CreateGraphics();
            size = sz;
            Alg = alg;
        }
       

        public void DrawGraph()
        {
            for(int i = 0; i< vertices.Count; i++)
            {
                Vertice node = vertices[i].next;
                while(node!= null)
                {
                    if (ShowWeight)
                    {
                        int mx, my;
                        mx = (vertices[i].x + node.x) / 2;
                        my = (vertices[i].y + node.y) / 2;
                        g.DrawString(node.Weight.ToString(), new Font(FontFamily.GenericSansSerif, 18, FontStyle.Bold), new SolidBrush(Color.Red), mx, my + 30);
                    }
                    g.DrawLine(new Pen(Color.Black,2), vertices[i].x + 10, vertices[i].y + 10, node.x+10, node.y+10);
                    node = node.next;
                }

            }
            for (int i = 0; i < vertices.Count; i++)
            {

                g.FillEllipse(back, vertices[i].x, vertices[i].y, size, size);
                g.DrawString(vertices[i].pos.ToString(), DefaultFont, StringColor, vertices[i].x + 10, vertices[i].y + 10);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void DrawPath()
        {
            int mx, my;
            int i, n = 0;
            for(i = 0; i< vertices.Count; i++)
            {
                mx = (vertices[i].x + vertices[i].next.x) / 2;
                my = (vertices[i].y + vertices[i].next.y) / 2;
                g.DrawString((n++).ToString(), new Font(FontFamily.GenericSansSerif, 18, FontStyle.Bold), new SolidBrush(Color.Red), mx, my + 30);

            }
            
        }
       
        private void OstTree_Shown(object sender, EventArgs e)
        {
            
            if(Alg == Algorithm.EllerCycle || Alg == Algorithm.GamiltonCycle)
            {
                DrawPath();
                ShowWeight = false;
            }
            DrawGraph();
        }
    }
}
