namespace DB_course.View
{
    partial class WorkerForm
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
            if(disposing && (components != null))
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Products = new System.Windows.Forms.TabPage();
            this.Addbtn = new System.Windows.Forms.Button();
            this.Searchbtn = new System.Windows.Forms.Button();
            this.SearchText = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Using = new System.Windows.Forms.TabPage();
            this.Delitebtn = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.LKS = new System.Windows.Forms.TabPage();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.Products.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.Using.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.LKS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Products);
            this.tabControl1.Controls.Add(this.Using);
            this.tabControl1.Controls.Add(this.LKS);
            this.tabControl1.Location = new System.Drawing.Point(8, 7);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(543, 256);
            this.tabControl1.TabIndex = 0;
            // 
            // Products
            // 
            this.Products.Controls.Add(this.Addbtn);
            this.Products.Controls.Add(this.Searchbtn);
            this.Products.Controls.Add(this.SearchText);
            this.Products.Controls.Add(this.dataGridView1);
            this.Products.Location = new System.Drawing.Point(4, 24);
            this.Products.Margin = new System.Windows.Forms.Padding(2);
            this.Products.Name = "Products";
            this.Products.Padding = new System.Windows.Forms.Padding(2);
            this.Products.Size = new System.Drawing.Size(535, 228);
            this.Products.TabIndex = 0;
            this.Products.Text = "Products";
            this.Products.UseVisualStyleBackColor = true;
            // 
            // Addbtn
            // 
            this.Addbtn.Location = new System.Drawing.Point(455, 26);
            this.Addbtn.Margin = new System.Windows.Forms.Padding(2);
            this.Addbtn.Name = "Addbtn";
            this.Addbtn.Size = new System.Drawing.Size(78, 20);
            this.Addbtn.TabIndex = 3;
            this.Addbtn.Text = "Add";
            this.Addbtn.UseVisualStyleBackColor = true;
            // 
            // Searchbtn
            // 
            this.Searchbtn.Location = new System.Drawing.Point(455, 4);
            this.Searchbtn.Margin = new System.Windows.Forms.Padding(2);
            this.Searchbtn.Name = "Searchbtn";
            this.Searchbtn.Size = new System.Drawing.Size(78, 20);
            this.Searchbtn.TabIndex = 2;
            this.Searchbtn.Text = "Search";
            this.Searchbtn.UseVisualStyleBackColor = true;
            this.Searchbtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // SearchText
            // 
            this.SearchText.Location = new System.Drawing.Point(4, 4);
            this.SearchText.Margin = new System.Windows.Forms.Padding(2);
            this.SearchText.Name = "SearchText";
            this.SearchText.Size = new System.Drawing.Size(448, 23);
            this.SearchText.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(4, 26);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(447, 181);
            this.dataGridView1.TabIndex = 0;
            // 
            // Using
            // 
            this.Using.Controls.Add(this.Delitebtn);
            this.Using.Controls.Add(this.dataGridView2);
            this.Using.Location = new System.Drawing.Point(4, 24);
            this.Using.Margin = new System.Windows.Forms.Padding(2);
            this.Using.Name = "Using";
            this.Using.Padding = new System.Windows.Forms.Padding(2);
            this.Using.Size = new System.Drawing.Size(535, 228);
            this.Using.TabIndex = 1;
            this.Using.Text = "Using";
            this.Using.UseVisualStyleBackColor = true;
            // 
            // Delitebtn
            // 
            this.Delitebtn.Location = new System.Drawing.Point(455, 4);
            this.Delitebtn.Margin = new System.Windows.Forms.Padding(2);
            this.Delitebtn.Name = "Delitebtn";
            this.Delitebtn.Size = new System.Drawing.Size(78, 20);
            this.Delitebtn.TabIndex = 1;
            this.Delitebtn.Text = "Delit";
            this.Delitebtn.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(5, 4);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 62;
            this.dataGridView2.RowTemplate.Height = 33;
            this.dataGridView2.Size = new System.Drawing.Size(447, 220);
            this.dataGridView2.TabIndex = 0;
            // 
            // LKS
            // 
            this.LKS.Controls.Add(this.dataGridView3);
            this.LKS.Location = new System.Drawing.Point(4, 24);
            this.LKS.Margin = new System.Windows.Forms.Padding(2);
            this.LKS.Name = "LKS";
            this.LKS.Size = new System.Drawing.Size(535, 228);
            this.LKS.TabIndex = 2;
            this.LKS.Text = "History";
            this.LKS.UseVisualStyleBackColor = true;
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(3, 3);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowTemplate.Height = 25;
            this.dataGridView3.Size = new System.Drawing.Size(529, 222);
            this.dataGridView3.TabIndex = 0;
            // 
            // WorkerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 270);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "WorkerForm";
            this.Text = "WorkerForm";
            this.Load += new System.EventHandler(this.WorkerForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.Products.ResumeLayout(false);
            this.Products.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.Using.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.LKS.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl1;
        private TabPage Products;
        private TabPage Using;
        private DataGridView dataGridView1;
        private Button Searchbtn;
        private TextBox SearchText;
        private Button Addbtn;
        private Button Delitebtn;
        private DataGridView dataGridView2;
        private TabPage LKS;
        private DataGridView dataGridView3;
    }
}