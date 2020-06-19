using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace WorkWithFiles
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ChooceButton_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            CreateDirectories.Enabled = true;
            else
                CreateDirectories.Enabled = false;
        }

        private void CreateDirectories_Click(object sender, EventArgs e)
        {
            string path = textBox1.Text;
           
            if (!Directory.Exists(path))
            {
                MessageBox.Show("Directory not found !", default, MessageBoxButtons.OK, MessageBoxIcon.Error);
                CreateDirectories.Enabled = false;
                return;
            }
            int n = (int)numericUpDown1.Value;
            for(int i = 0; i< n; i++)
            {
                Directory.CreateDirectory(path + "Folder_" + i);
            }
            MessageBox.Show("Directories Created", default, MessageBoxButtons.OK, MessageBoxIcon.Information);
            numericUpDown1.Enabled = false;
            CreateDirectories.Enabled = false;
            textBox1.Enabled = false;
            Delete.Enabled = true;

        }

        private void Delete_Click(object sender, EventArgs e)
        {
            string path = textBox1.Text;
            int n = (int)numericUpDown1.Value;
            for(int i = 0; i< n; i++)
            {
                Directory.Delete(path + "Folder_" + i);
            }
            MessageBox.Show("Directories deleted", default, MessageBoxButtons.OK, MessageBoxIcon.Information);
            Delete.Enabled = false;
            textBox1.Enabled = true;
            numericUpDown1.Enabled = true;
            CreateDirectories.Enabled = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
                CreateFolders.Enabled = true;
            else
                CreateFolders.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = textBox2.Text;

            if (!Directory.Exists(path))
            {
                MessageBox.Show("Папку не знайдено !", default, MessageBoxButtons.OK, MessageBoxIcon.Error);
                CreateDirectories.Enabled = false;
                return;
            }
            int n = (int)numericUpDown2.Value;
            int m = (int)numericUpDown3.Value;
            for (int i = 0; i < n; i++)
            {
                Directory.CreateDirectory(path + "Folder_" + i);
                for(int j = 0; j< m; j++)
                {
                    Directory.CreateDirectory(path + "Folder_" + i+ "\\Folder_"+i.ToString()+j.ToString());
                }

            }
            MessageBox.Show($"Папки створено\n Кількість вложених папок : {n * m}", default, MessageBoxButtons.OK, MessageBoxIcon.Information);
            numericUpDown2.Enabled = false;
            numericUpDown3.Enabled = false;

            CreateFolders.Enabled = false;
            textBox2.Enabled = false;
            Delete1.Enabled = true;
           
        }

        private void Delete1_Click(object sender, EventArgs e)
        {
            string path = textBox2.Text;
            int n = (int)numericUpDown2.Value;
            for(int i = 0; i<n; i++)
            {
                Directory.Delete(path + "Folder_" + i,true);
            }
            numericUpDown2.Enabled = true;
            numericUpDown3.Enabled = true;

            CreateFolders.Enabled = true;
            textBox2.Enabled = true;
            Delete1.Enabled = false;

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
                Find.Enabled = true;
            else
                Find.Enabled = false;
        }

        private void Find_Click(object sender, EventArgs e)
        {
            string path = textBox3.Text;

            if (!Directory.Exists(path))
            {
                MessageBox.Show("Папку не знайдено !", default, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Find.Enabled = false;
                return;
            }

            DirectoryInfo d = new DirectoryInfo(path);
            string s = GetLength(d);
            string[] s1 = s.Split(' ');
            if(s1.Length == 1)
            {
                MessageBox.Show("Каталог не має вкладених папок !");

            }
            string max= "";
            for(int i = 0; i< s1.Length; i++)
            {
                if (max.Length < s1[i].Length)
                    max = s1[i];
            }
            MessageBox.Show("Назва папки з найбільшою довжиною : " + max);
            

        }
        //Функція обходу папок
        private string GetLength(DirectoryInfo d)
        {
            string s = "";
            DirectoryInfo[] direct = d.GetDirectories();
            if (direct.Length == 0)
                return "";
            foreach(DirectoryInfo dir in direct)
            {
                s += dir.Name + " ";
                s += GetLength(dir);
            }
            return s;

            
        }
    }
}
