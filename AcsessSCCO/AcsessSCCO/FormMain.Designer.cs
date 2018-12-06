namespace AcsessSCCO
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonMov = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonToExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonToWord = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.TypeFilter = new System.Windows.Forms.ToolStripComboBox();
            this.Filter = new System.Windows.Forms.ToolStripComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.типыАктивовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.местоположенияАктивовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.статусыАктивовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.действияСАктивамиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.панельАдминистратораToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAdd,
            this.toolStripButtonDel,
            this.toolStripSeparator1,
            this.toolStripButtonRefresh,
            this.toolStripSeparator2,
            this.toolStripButtonMov,
            this.toolStripSeparator3,
            this.toolStripButtonToExcel,
            this.toolStripButtonToWord,
            this.toolStripSeparator4,
            this.toolStripLabel1,
            this.TypeFilter,
            this.Filter});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(732, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonAdd
            // 
            this.toolStripButtonAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAdd.Image = global::AcsessSCCO.Properties.Resources.add1;
            this.toolStripButtonAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAdd.Name = "toolStripButtonAdd";
            this.toolStripButtonAdd.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonAdd.Text = "Добавить запись";
            this.toolStripButtonAdd.Click += new System.EventHandler(this.toolStripButtonAdd_Click);
            // 
            // toolStripButtonDel
            // 
            this.toolStripButtonDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDel.Image = global::AcsessSCCO.Properties.Resources.close;
            this.toolStripButtonDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDel.Name = "toolStripButtonDel";
            this.toolStripButtonDel.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonDel.Text = "Удалить запись";
            this.toolStripButtonDel.Click += new System.EventHandler(this.toolStripButtonDel_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonRefresh
            // 
            this.toolStripButtonRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRefresh.Image = global::AcsessSCCO.Properties.Resources.gtk_refresh_6515;
            this.toolStripButtonRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRefresh.Name = "toolStripButtonRefresh";
            this.toolStripButtonRefresh.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonRefresh.Text = "Обновить";
            this.toolStripButtonRefresh.Click += new System.EventHandler(this.toolStripButtonRefresh_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonMov
            // 
            this.toolStripButtonMov.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonMov.Image = global::AcsessSCCO.Properties.Resources.checklist_25365;
            this.toolStripButtonMov.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonMov.Name = "toolStripButtonMov";
            this.toolStripButtonMov.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonMov.Text = "Движение актива";
            this.toolStripButtonMov.Click += new System.EventHandler(this.toolStripButtonMov_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonToExcel
            // 
            this.toolStripButtonToExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonToExcel.Image = global::AcsessSCCO.Properties.Resources.Excel;
            this.toolStripButtonToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonToExcel.Name = "toolStripButtonToExcel";
            this.toolStripButtonToExcel.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonToExcel.Text = "toolStripButton1";
            this.toolStripButtonToExcel.Click += new System.EventHandler(this.toolStripButtonToExcel_Click);
            // 
            // toolStripButtonToWord
            // 
            this.toolStripButtonToWord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonToWord.Image = global::AcsessSCCO.Properties.Resources.word;
            this.toolStripButtonToWord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonToWord.Name = "toolStripButtonToWord";
            this.toolStripButtonToWord.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonToWord.Text = "toolStripButton1";
            this.toolStripButtonToWord.Click += new System.EventHandler(this.toolStripButtonToWord_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(48, 22);
            this.toolStripLabel1.Text = "Фильтр";
            // 
            // TypeFilter
            // 
            this.TypeFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypeFilter.Items.AddRange(new object[] {
            "Нет",
            "Тип актива",
            "Местоположение",
            "Статус",
            "Инвентарный номер"});
            this.TypeFilter.Name = "TypeFilter";
            this.TypeFilter.Size = new System.Drawing.Size(121, 25);
            this.TypeFilter.SelectedIndexChanged += new System.EventHandler(this.TypeFilter_SelectedIndexChanged);
            // 
            // Filter
            // 
            this.Filter.Name = "Filter";
            this.Filter.Size = new System.Drawing.Size(200, 25);
            this.Filter.Visible = false;
            this.Filter.SelectedIndexChanged += new System.EventHandler(this.Filter_SelectedIndexChanged);
            this.Filter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Filter_KeyPress);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem,
            this.панельАдминистратораToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(732, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.типыАктивовToolStripMenuItem,
            this.местоположенияАктивовToolStripMenuItem,
            this.статусыАктивовToolStripMenuItem,
            this.действияСАктивамиToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // типыАктивовToolStripMenuItem
            // 
            this.типыАктивовToolStripMenuItem.Name = "типыАктивовToolStripMenuItem";
            this.типыАктивовToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.типыАктивовToolStripMenuItem.Text = "Типы активов";
            // 
            // местоположенияАктивовToolStripMenuItem
            // 
            this.местоположенияАктивовToolStripMenuItem.Name = "местоположенияАктивовToolStripMenuItem";
            this.местоположенияАктивовToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.местоположенияАктивовToolStripMenuItem.Text = "Местоположения активов";
            // 
            // статусыАктивовToolStripMenuItem
            // 
            this.статусыАктивовToolStripMenuItem.Name = "статусыАктивовToolStripMenuItem";
            this.статусыАктивовToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.статусыАктивовToolStripMenuItem.Text = "Статусы активов";
            // 
            // действияСАктивамиToolStripMenuItem
            // 
            this.действияСАктивамиToolStripMenuItem.Name = "действияСАктивамиToolStripMenuItem";
            this.действияСАктивамиToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.действияСАктивамиToolStripMenuItem.Text = "Действия с активами";
            // 
            // панельАдминистратораToolStripMenuItem
            // 
            this.панельАдминистратораToolStripMenuItem.Name = "панельАдминистратораToolStripMenuItem";
            this.панельАдминистратораToolStripMenuItem.Size = new System.Drawing.Size(154, 20);
            this.панельАдминистратораToolStripMenuItem.Text = "Панель администратора";
            this.панельАдминистратораToolStripMenuItem.Click += new System.EventHandler(this.панельАдминистратораToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(24, 20);
            this.toolStripMenuItem1.Text = "?";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 49);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(732, 318);
            this.dataGridView1.TabIndex = 2;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 367);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Учет и управление активов ЦССО";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonAdd;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonDel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonMov;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButtonToExcel;
        private System.Windows.Forms.ToolStripButton toolStripButtonToWord;
        private System.Windows.Forms.ToolStripMenuItem типыАктивовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem местоположенияАктивовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem статусыАктивовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem действияСАктивамиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem панельАдминистратораToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox TypeFilter;
        private System.Windows.Forms.ToolStripComboBox Filter;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}

