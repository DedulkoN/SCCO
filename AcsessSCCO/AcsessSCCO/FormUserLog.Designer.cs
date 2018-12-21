namespace AcsessSCCO
{
    partial class FormUserLog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUserLog));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBoxUser = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButtonOk = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDelFiltr = new System.Windows.Forms.ToolStripButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.toolStripComboBoxUser,
            this.toolStripButtonOk,
            this.toolStripButtonDelFiltr});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::AcsessSCCO.Properties.Resources.gtk_refresh_6515;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.ToolTipText = "Обновить";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(115, 22);
            this.toolStripLabel1.Text = "Логи пользователя:";
            // 
            // toolStripComboBoxUser
            // 
            this.toolStripComboBoxUser.Name = "toolStripComboBoxUser";
            this.toolStripComboBoxUser.Size = new System.Drawing.Size(121, 25);
            // 
            // toolStripButtonOk
            // 
            this.toolStripButtonOk.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonOk.Image = global::AcsessSCCO.Properties.Resources.accept;
            this.toolStripButtonOk.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOk.Name = "toolStripButtonOk";
            this.toolStripButtonOk.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonOk.Text = "toolStripButton2";
            this.toolStripButtonOk.ToolTipText = "Применить фильтр";
            this.toolStripButtonOk.Click += new System.EventHandler(this.toolStripButtonOk_Click);
            // 
            // toolStripButtonDelFiltr
            // 
            this.toolStripButtonDelFiltr.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDelFiltr.Image = global::AcsessSCCO.Properties.Resources.close;
            this.toolStripButtonDelFiltr.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDelFiltr.Name = "toolStripButtonDelFiltr";
            this.toolStripButtonDelFiltr.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonDelFiltr.Text = "toolStripButton3";
            this.toolStripButtonDelFiltr.ToolTipText = "Сбросить фильтр";
            this.toolStripButtonDelFiltr.Click += new System.EventHandler(this.toolStripButtonDelFiltr_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 25);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(800, 425);
            this.dataGridView1.TabIndex = 1;
            // 
            // FormUserLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormUserLog";
            this.Text = "Просмотр логов";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxUser;
        private System.Windows.Forms.ToolStripButton toolStripButtonOk;
        private System.Windows.Forms.ToolStripButton toolStripButtonDelFiltr;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}