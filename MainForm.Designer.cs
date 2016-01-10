namespace PreSQL
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.подключитьБДToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьБДToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьБДToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отключитьБДToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.createTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dropTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.предыдущийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пследующийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.requestBtn = new System.Windows.Forms.ToolStripButton();
            this.noExecCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dbLabel = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.requestBox = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.resultBox = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.treeView = new System.Windows.Forms.TreeView();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.подключитьБДToolStripMenuItem,
            this.toolStripMenuItem3,
            this.AboutBtn});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1155, 24);
            this.menuStrip1.TabIndex = 27;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // подключитьБДToolStripMenuItem
            // 
            this.подключитьБДToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.создатьБДToolStripMenuItem,
            this.сохранитьБДToolStripMenuItem,
            this.отключитьБДToolStripMenuItem1,
            this.toolStripMenuItem1,
            this.выходToolStripMenuItem});
            this.подключитьБДToolStripMenuItem.Name = "подключитьБДToolStripMenuItem";
            this.подключитьБДToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.подключитьБДToolStripMenuItem.Text = "Файл";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem2.Image")));
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(191, 22);
            this.toolStripMenuItem2.Text = "Открыть БД";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // создатьБДToolStripMenuItem
            // 
            this.создатьБДToolStripMenuItem.Name = "создатьБДToolStripMenuItem";
            this.создатьБДToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.создатьБДToolStripMenuItem.Text = "Создать БД";
            this.создатьБДToolStripMenuItem.Click += new System.EventHandler(this.создатьБДToolStripMenuItem_Click);
            // 
            // сохранитьБДToolStripMenuItem
            // 
            this.сохранитьБДToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("сохранитьБДToolStripMenuItem.Image")));
            this.сохранитьБДToolStripMenuItem.Name = "сохранитьБДToolStripMenuItem";
            this.сохранитьБДToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.сохранитьБДToolStripMenuItem.Text = "Сохранить БД в файл";
            this.сохранитьБДToolStripMenuItem.Click += new System.EventHandler(this.отключитьБДToolStripMenuItem_Click);
            // 
            // отключитьБДToolStripMenuItem1
            // 
            this.отключитьБДToolStripMenuItem1.Name = "отключитьБДToolStripMenuItem1";
            this.отключитьБДToolStripMenuItem1.Size = new System.Drawing.Size(191, 22);
            this.отключитьБДToolStripMenuItem1.Text = "Закрыть БД";
            this.отключитьБДToolStripMenuItem1.Click += new System.EventHandler(this.отключитьБДToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(188, 6);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createTableToolStripMenuItem,
            this.dropTableToolStripMenuItem,
            this.selectToolStripMenuItem,
            this.insertToolStripMenuItem,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6,
            this.toolStripMenuItem4,
            this.предыдущийToolStripMenuItem,
            this.пследующийToolStripMenuItem});
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(59, 20);
            this.toolStripMenuItem3.Text = "Запрос";
            // 
            // createTableToolStripMenuItem
            // 
            this.createTableToolStripMenuItem.Name = "createTableToolStripMenuItem";
            this.createTableToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.createTableToolStripMenuItem.Text = "Create table";
            this.createTableToolStripMenuItem.Click += new System.EventHandler(this.createTableToolStripMenuItem_Click);
            // 
            // dropTableToolStripMenuItem
            // 
            this.dropTableToolStripMenuItem.Name = "dropTableToolStripMenuItem";
            this.dropTableToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.dropTableToolStripMenuItem.Text = "Drop table";
            this.dropTableToolStripMenuItem.Click += new System.EventHandler(this.dropTableToolStripMenuItem_Click);
            // 
            // selectToolStripMenuItem
            // 
            this.selectToolStripMenuItem.Name = "selectToolStripMenuItem";
            this.selectToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.selectToolStripMenuItem.Text = "Select";
            this.selectToolStripMenuItem.Click += new System.EventHandler(this.selectToolStripMenuItem_Click);
            // 
            // insertToolStripMenuItem
            // 
            this.insertToolStripMenuItem.Name = "insertToolStripMenuItem";
            this.insertToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.insertToolStripMenuItem.Text = "Insert";
            this.insertToolStripMenuItem.Click += new System.EventHandler(this.insertToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(169, 22);
            this.toolStripMenuItem5.Text = "Delete";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(169, 22);
            this.toolStripMenuItem6.Text = "Update";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(166, 6);
            // 
            // предыдущийToolStripMenuItem
            // 
            this.предыдущийToolStripMenuItem.Name = "предыдущийToolStripMenuItem";
            this.предыдущийToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.предыдущийToolStripMenuItem.Text = "<-Предыдущий";
            this.предыдущийToolStripMenuItem.Click += new System.EventHandler(this.предыдущийToolStripMenuItem_Click);
            // 
            // пследующийToolStripMenuItem
            // 
            this.пследующийToolStripMenuItem.Name = "пследующийToolStripMenuItem";
            this.пследующийToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.пследующийToolStripMenuItem.Text = "Последующий->";
            this.пследующийToolStripMenuItem.Click += new System.EventHandler(this.пследующийToolStripMenuItem_Click);
            // 
            // AboutBtn
            // 
            this.AboutBtn.Name = "AboutBtn";
            this.AboutBtn.Size = new System.Drawing.Size(102, 20);
            this.AboutBtn.Text = "О приложении";
            this.AboutBtn.Click += new System.EventHandler(this.AboutBtn_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton4,
            this.toolStripButton5,
            this.toolStripSeparator2,
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripSeparator1,
            this.requestBtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1155, 31);
            this.toolStrip1.TabIndex = 60;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(82, 28);
            this.toolStripButton4.Text = "Открыть";
            this.toolStripButton4.ToolTipText = "Открыть ЬД";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(93, 28);
            this.toolStripButton5.Text = "Сохранить";
            this.toolStripButton5.ToolTipText = "Сохранить БД ";
            this.toolStripButton5.Click += new System.EventHandler(this.отключитьБДToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(101, 28);
            this.toolStripButton1.Text = "<-Предыдущий ";
            this.toolStripButton1.ToolTipText = "<-Предыдущий запрос";
            this.toolStripButton1.Click += new System.EventHandler(this.предыдущийToolStripMenuItem_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(92, 28);
            this.toolStripButton2.Text = "Следующий->";
            this.toolStripButton2.ToolTipText = "Следующий запрос";
            this.toolStripButton2.Click += new System.EventHandler(this.пследующийToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // requestBtn
            // 
            this.requestBtn.Image = ((System.Drawing.Image)(resources.GetObject("requestBtn.Image")));
            this.requestBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.requestBtn.Name = "requestBtn";
            this.requestBtn.Size = new System.Drawing.Size(97, 28);
            this.requestBtn.Text = "Выполнить";
            this.requestBtn.Click += new System.EventHandler(this.requestBtn_Click);
            // 
            // noExecCheckBox
            // 
            this.noExecCheckBox.AutoSize = true;
            this.noExecCheckBox.Checked = true;
            this.noExecCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.noExecCheckBox.Location = new System.Drawing.Point(487, 32);
            this.noExecCheckBox.Name = "noExecCheckBox";
            this.noExecCheckBox.Size = new System.Drawing.Size(107, 17);
            this.noExecCheckBox.TabIndex = 79;
            this.noExecCheckBox.Text = "Только парсить";
            this.noExecCheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(600, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 80;
            this.label1.Text = "База данных:";
            // 
            // dbLabel
            // 
            this.dbLabel.AutoSize = true;
            this.dbLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.dbLabel.Location = new System.Drawing.Point(681, 33);
            this.dbLabel.Name = "dbLabel";
            this.dbLabel.Size = new System.Drawing.Size(95, 13);
            this.dbLabel.TabIndex = 81;
            this.dbLabel.Text = "<не подключено>";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 55);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.requestBox);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer2.Size = new System.Drawing.Size(1155, 610);
            this.splitContainer2.SplitterDistance = 163;
            this.splitContainer2.TabIndex = 82;
            // 
            // requestBox
            // 
            this.requestBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.requestBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.requestBox.Location = new System.Drawing.Point(0, 0);
            this.requestBox.Multiline = true;
            this.requestBox.Name = "requestBox";
            this.requestBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.requestBox.Size = new System.Drawing.Size(1155, 163);
            this.requestBox.TabIndex = 7;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1155, 443);
            this.tabControl1.TabIndex = 15;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.resultBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1147, 417);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Результат ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // resultBox
            // 
            this.resultBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resultBox.Location = new System.Drawing.Point(3, 3);
            this.resultBox.Multiline = true;
            this.resultBox.Name = "resultBox";
            this.resultBox.ReadOnly = true;
            this.resultBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.resultBox.Size = new System.Drawing.Size(1141, 411);
            this.resultBox.TabIndex = 2;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.treeView);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1147, 417);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "ParseTree";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // treeView
            // 
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.Location = new System.Drawing.Point(3, 3);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(1141, 411);
            this.treeView.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 665);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.dbLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.noExecCheckBox);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "PreSQL Manager";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem подключитьБДToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem создатьБДToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьБДToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отключитьБДToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem createTableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dropTableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem предыдущийToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пследующийToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutBtn;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton requestBtn;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        public System.Windows.Forms.CheckBox noExecCheckBox;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label dbLabel;
        private System.Windows.Forms.SplitContainer splitContainer2;
        public System.Windows.Forms.TextBox requestBox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.TextBox resultBox;
        private System.Windows.Forms.TabPage tabPage3;
        public System.Windows.Forms.TreeView treeView;
    }
}

