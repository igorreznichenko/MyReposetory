namespace Cursova
{
    partial class Editor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.AddVertice = new System.Windows.Forms.Button();
            this.DeleteVertice = new System.Windows.Forms.Button();
            this.Tethered = new System.Windows.Forms.Button();
            this.Rejection = new System.Windows.Forms.Button();
            this.MoveVertices = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.DeleteEdge = new System.Windows.Forms.Button();
            this.ShowVertices = new System.Windows.Forms.Button();
            this.FindLength = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.ChangeEdge = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button3 = new System.Windows.Forms.Button();
            this.GraphTree = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.FindEillerCycle = new System.Windows.Forms.Button();
            this.GamiltonCycle = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.зберегтиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.малюнокToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.зберегтиЯкToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.відкритиГрафToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.видToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.клірВершинToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вершиниToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.текстToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.panel3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Info;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(12, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(875, 539);
            this.panel1.TabIndex = 0;
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.HighlightVertice);
            // 
            // AddVertice
            // 
            this.AddVertice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddVertice.Location = new System.Drawing.Point(4, 134);
            this.AddVertice.Name = "AddVertice";
            this.AddVertice.Size = new System.Drawing.Size(122, 23);
            this.AddVertice.TabIndex = 1;
            this.AddVertice.Text = "Добавити вершину";
            this.AddVertice.UseVisualStyleBackColor = true;
            this.AddVertice.Click += new System.EventHandler(this.button1_Click);
            // 
            // DeleteVertice
            // 
            this.DeleteVertice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DeleteVertice.Enabled = false;
            this.DeleteVertice.Location = new System.Drawing.Point(144, 134);
            this.DeleteVertice.Name = "DeleteVertice";
            this.DeleteVertice.Size = new System.Drawing.Size(122, 23);
            this.DeleteVertice.TabIndex = 2;
            this.DeleteVertice.Text = "Видалити вершину";
            this.DeleteVertice.UseVisualStyleBackColor = true;
            this.DeleteVertice.Click += new System.EventHandler(this.DeleteVertice_Click);
            // 
            // Tethered
            // 
            this.Tethered.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Tethered.Enabled = false;
            this.Tethered.Location = new System.Drawing.Point(4, 79);
            this.Tethered.Name = "Tethered";
            this.Tethered.Size = new System.Drawing.Size(122, 23);
            this.Tethered.TabIndex = 3;
            this.Tethered.Text = "Звязати з";
            this.Tethered.UseVisualStyleBackColor = true;
            this.Tethered.Click += new System.EventHandler(this.Tethered_Click);
            // 
            // Rejection
            // 
            this.Rejection.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Rejection.Enabled = false;
            this.Rejection.Location = new System.Drawing.Point(1049, 523);
            this.Rejection.Name = "Rejection";
            this.Rejection.Size = new System.Drawing.Size(120, 41);
            this.Rejection.TabIndex = 4;
            this.Rejection.Text = "Відміна";
            this.Rejection.UseVisualStyleBackColor = true;
            // 
            // MoveVertices
            // 
            this.MoveVertices.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MoveVertices.Enabled = false;
            this.MoveVertices.Location = new System.Drawing.Point(4, 105);
            this.MoveVertices.Name = "MoveVertices";
            this.MoveVertices.Size = new System.Drawing.Size(122, 23);
            this.MoveVertices.TabIndex = 5;
            this.MoveVertices.Text = "Перемістити вершину";
            this.MoveVertices.UseVisualStyleBackColor = true;
            this.MoveVertices.Click += new System.EventHandler(this.MoveVertices_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(975, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Повідомлення";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.DarkKhaki;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(924, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(225, 91);
            this.label2.TabIndex = 9;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Enabled = false;
            this.numericUpDown1.Location = new System.Drawing.Point(1026, 187);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(41, 20);
            this.numericUpDown1.TabIndex = 10;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(921, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 18);
            this.label3.TabIndex = 11;
            this.label3.Text = "Вага ребра";
            // 
            // DeleteEdge
            // 
            this.DeleteEdge.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DeleteEdge.Enabled = false;
            this.DeleteEdge.Location = new System.Drawing.Point(143, 76);
            this.DeleteEdge.Name = "DeleteEdge";
            this.DeleteEdge.Size = new System.Drawing.Size(122, 23);
            this.DeleteEdge.TabIndex = 12;
            this.DeleteEdge.Text = "Видалити ребро";
            this.DeleteEdge.UseVisualStyleBackColor = true;
            this.DeleteEdge.Click += new System.EventHandler(this.DeleteEdge_Click);
            // 
            // ShowVertices
            // 
            this.ShowVertices.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ShowVertices.Enabled = false;
            this.ShowVertices.Location = new System.Drawing.Point(3, 50);
            this.ShowVertices.Name = "ShowVertices";
            this.ShowVertices.Size = new System.Drawing.Size(122, 23);
            this.ShowVertices.TabIndex = 13;
            this.ShowVertices.Text = "Суміжні вершини";
            this.ShowVertices.UseVisualStyleBackColor = true;
            this.ShowVertices.Click += new System.EventHandler(this.ShowVertices_Click);
            // 
            // FindLength
            // 
            this.FindLength.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FindLength.Enabled = false;
            this.FindLength.Location = new System.Drawing.Point(1037, 279);
            this.FindLength.Name = "FindLength";
            this.FindLength.Size = new System.Drawing.Size(122, 23);
            this.FindLength.TabIndex = 14;
            this.FindLength.Text = "Знайти відстані";
            this.FindLength.UseVisualStyleBackColor = true;
            this.FindLength.Click += new System.EventHandler(this.FindLength_Click);
            // 
            // ChangeEdge
            // 
            this.ChangeEdge.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ChangeEdge.Enabled = false;
            this.ChangeEdge.Location = new System.Drawing.Point(144, 105);
            this.ChangeEdge.Name = "ChangeEdge";
            this.ChangeEdge.Size = new System.Drawing.Size(122, 23);
            this.ChangeEdge.TabIndex = 17;
            this.ChangeEdge.Text = "Змінити вагу";
            this.ChangeEdge.UseVisualStyleBackColor = true;
            this.ChangeEdge.Click += new System.EventHandler(this.ChangeEdge_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Text File(*.txt)|*.txt";
            // 
            // button3
            // 
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.Location = new System.Drawing.Point(143, 50);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(122, 23);
            this.button3.TabIndex = 20;
            this.button3.Text = "Довжини ребер";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // GraphTree
            // 
            this.GraphTree.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GraphTree.Location = new System.Drawing.Point(897, 279);
            this.GraphTree.Name = "GraphTree";
            this.GraphTree.Size = new System.Drawing.Size(121, 23);
            this.GraphTree.TabIndex = 23;
            this.GraphTree.Text = "Остовне дерево";
            this.GraphTree.UseVisualStyleBackColor = true;
            this.GraphTree.Click += new System.EventHandler(this.GraphTree_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.button3);
            this.panel3.Controls.Add(this.ShowVertices);
            this.panel3.Controls.Add(this.ChangeEdge);
            this.panel3.Controls.Add(this.Tethered);
            this.panel3.Controls.Add(this.MoveVertices);
            this.panel3.Controls.Add(this.DeleteEdge);
            this.panel3.Controls.Add(this.AddVertice);
            this.panel3.Controls.Add(this.DeleteVertice);
            this.panel3.Location = new System.Drawing.Point(893, 326);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(276, 178);
            this.panel3.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label6.Location = new System.Drawing.Point(48, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(198, 24);
            this.label6.TabIndex = 0;
            this.label6.Text = "Робота з вершинами";
            // 
            // FindEillerCycle
            // 
            this.FindEillerCycle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FindEillerCycle.Enabled = false;
            this.FindEillerCycle.Location = new System.Drawing.Point(897, 235);
            this.FindEillerCycle.Name = "FindEillerCycle";
            this.FindEillerCycle.Size = new System.Drawing.Size(121, 23);
            this.FindEillerCycle.TabIndex = 26;
            this.FindEillerCycle.Text = "Ейлерів цикл";
            this.FindEillerCycle.UseVisualStyleBackColor = true;
            this.FindEillerCycle.Click += new System.EventHandler(this.button4_Click);
            // 
            // GamiltonCycle
            // 
            this.GamiltonCycle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GamiltonCycle.Enabled = false;
            this.GamiltonCycle.Location = new System.Drawing.Point(1037, 235);
            this.GamiltonCycle.Name = "GamiltonCycle";
            this.GamiltonCycle.Size = new System.Drawing.Size(121, 23);
            this.GamiltonCycle.TabIndex = 27;
            this.GamiltonCycle.Text = "Гамільтонів цикл";
            this.GamiltonCycle.UseVisualStyleBackColor = true;
            this.GamiltonCycle.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.видToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1178, 24);
            this.menuStrip1.TabIndex = 28;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.зберегтиToolStripMenuItem,
            this.малюнокToolStripMenuItem,
            this.зберегтиЯкToolStripMenuItem,
            this.відкритиГрафToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // зберегтиToolStripMenuItem
            // 
            this.зберегтиToolStripMenuItem.Name = "зберегтиToolStripMenuItem";
            this.зберегтиToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.зберегтиToolStripMenuItem.Text = "Зберегти";
            this.зберегтиToolStripMenuItem.Click += new System.EventHandler(this.button3_Click);
            // 
            // малюнокToolStripMenuItem
            // 
            this.малюнокToolStripMenuItem.Name = "малюнокToolStripMenuItem";
            this.малюнокToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.малюнокToolStripMenuItem.Text = "Малюнок";
            this.малюнокToolStripMenuItem.Click += new System.EventHandler(this.button2_Click);
            // 
            // зберегтиЯкToolStripMenuItem
            // 
            this.зберегтиЯкToolStripMenuItem.Name = "зберегтиЯкToolStripMenuItem";
            this.зберегтиЯкToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.зберегтиЯкToolStripMenuItem.Text = "Зберегти як";
            this.зберегтиЯкToolStripMenuItem.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // відкритиГрафToolStripMenuItem
            // 
            this.відкритиГрафToolStripMenuItem.Name = "відкритиГрафToolStripMenuItem";
            this.відкритиГрафToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.відкритиГрафToolStripMenuItem.Text = "Відкрити граф";
            this.відкритиГрафToolStripMenuItem.Click += new System.EventHandler(this.OpenGraph_Click);
            // 
            // видToolStripMenuItem
            // 
            this.видToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.клірВершинToolStripMenuItem});
            this.видToolStripMenuItem.Name = "видToolStripMenuItem";
            this.видToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.видToolStripMenuItem.Text = "Вид";
            // 
            // клірВершинToolStripMenuItem
            // 
            this.клірВершинToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.вершиниToolStripMenuItem,
            this.текстToolStripMenuItem});
            this.клірВершинToolStripMenuItem.Name = "клірВершинToolStripMenuItem";
            this.клірВершинToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.клірВершинToolStripMenuItem.Text = "Колір графу";
            // 
            // вершиниToolStripMenuItem
            // 
            this.вершиниToolStripMenuItem.Name = "вершиниToolStripMenuItem";
            this.вершиниToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.вершиниToolStripMenuItem.Text = "Вершини";
            this.вершиниToolStripMenuItem.Click += new System.EventHandler(this.вершиниToolStripMenuItem_Click);
            // 
            // текстToolStripMenuItem
            // 
            this.текстToolStripMenuItem.Name = "текстToolStripMenuItem";
            this.текстToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.текстToolStripMenuItem.Text = "Текст";
            this.текстToolStripMenuItem.Click += new System.EventHandler(this.текстToolStripMenuItem_Click);
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(1178, 576);
            this.Controls.Add(this.GamiltonCycle);
            this.Controls.Add(this.FindEillerCycle);
            this.Controls.Add(this.GraphTree);
            this.Controls.Add(this.FindLength);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Rejection);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Editor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Editor_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Editor_FormClosed);
            this.Load += new System.EventHandler(this.Editor_Load);
            this.LocationChanged += new System.EventHandler(this.Editor_LocationChanged);
            this.SizeChanged += new System.EventHandler(this.Editor_SizeChanged);
            this.Move += new System.EventHandler(this.Editor_Move);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button AddVertice;
        private System.Windows.Forms.Button DeleteVertice;
        private System.Windows.Forms.Button Tethered;
        private System.Windows.Forms.Button Rejection;
        private System.Windows.Forms.Button MoveVertices;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button DeleteEdge;
        private System.Windows.Forms.Button ShowVertices;
        private System.Windows.Forms.Button FindLength;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button ChangeEdge;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button GraphTree;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button FindEillerCycle;
        private System.Windows.Forms.Button GamiltonCycle;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem зберегтиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem зберегтиЯкToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem малюнокToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem відкритиГрафToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem видToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem клірВершинToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вершиниToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem текстToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}