namespace DB_course.View
{
    partial class WarehouseAdminForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.productsPage = new System.Windows.Forms.TabPage();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textSearch = new System.Windows.Forms.TextBox();
            this.addProductPage = new System.Windows.Forms.TabPage();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textPlaceId = new System.Windows.Forms.TextBox();
            this.textInventoryNumber = new System.Windows.Forms.TextBox();
            this.textDateProduction = new System.Windows.Forms.TextBox();
            this.textDateCome = new System.Windows.Forms.TextBox();
            this.textProductName = new System.Windows.Forms.TextBox();
            this.textProductId = new System.Windows.Forms.TextBox();
            this.PlacePage = new System.Windows.Forms.TabPage();
            this.deletePlaceBtn = new System.Windows.Forms.Button();
            this.updatePlaceBtn = new System.Windows.Forms.Button();
            this.addPlaceBtn = new System.Windows.Forms.Button();
            this.searchPlaceBtn = new System.Windows.Forms.Button();
            this.searchPlaceTextBox = new System.Windows.Forms.TextBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.PlaceComponent = new System.Windows.Forms.TabPage();
            this.Stay = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cancelPlaceBtn = new System.Windows.Forms.Button();
            this.savePlaceBtn = new System.Windows.Forms.Button();
            this.StayPlaceText = new System.Windows.Forms.TextBox();
            this.sizePlaceText = new System.Windows.Forms.TextBox();
            this.laerPlaceText = new System.Windows.Forms.TextBox();
            this.placeIdText = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.productsPage.SuspendLayout();
            this.addProductPage.SuspendLayout();
            this.PlacePage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.PlaceComponent.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(5, 32);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(568, 269);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView1_RowsAdded);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDelete.Location = new System.Drawing.Point(579, 33);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 27);
            this.buttonDelete.TabIndex = 1;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.productsPage);
            this.tabControl1.Controls.Add(this.addProductPage);
            this.tabControl1.Controls.Add(this.PlacePage);
            this.tabControl1.Controls.Add(this.PlaceComponent);
            this.tabControl1.Location = new System.Drawing.Point(6, 15);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(673, 365);
            this.tabControl1.TabIndex = 2;
            // 
            // productsPage
            // 
            this.productsPage.Controls.Add(this.buttonAdd);
            this.productsPage.Controls.Add(this.buttonSearch);
            this.productsPage.Controls.Add(this.textSearch);
            this.productsPage.Controls.Add(this.dataGridView1);
            this.productsPage.Controls.Add(this.buttonDelete);
            this.productsPage.Location = new System.Drawing.Point(4, 24);
            this.productsPage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.productsPage.Name = "productsPage";
            this.productsPage.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.productsPage.Size = new System.Drawing.Size(665, 337);
            this.productsPage.TabIndex = 0;
            this.productsPage.Text = "productsPage";
            this.productsPage.UseVisualStyleBackColor = true;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.Location = new System.Drawing.Point(579, 65);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 4;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSearch.Location = new System.Drawing.Point(579, 5);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 3;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            // 
            // textSearch
            // 
            this.textSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textSearch.Location = new System.Drawing.Point(5, 4);
            this.textSearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textSearch.Name = "textSearch";
            this.textSearch.Size = new System.Drawing.Size(568, 23);
            this.textSearch.TabIndex = 2;
            // 
            // addProductPage
            // 
            this.addProductPage.Controls.Add(this.buttonCancel);
            this.addProductPage.Controls.Add(this.buttonSave);
            this.addProductPage.Controls.Add(this.label6);
            this.addProductPage.Controls.Add(this.label5);
            this.addProductPage.Controls.Add(this.label4);
            this.addProductPage.Controls.Add(this.label3);
            this.addProductPage.Controls.Add(this.label2);
            this.addProductPage.Controls.Add(this.label1);
            this.addProductPage.Controls.Add(this.textPlaceId);
            this.addProductPage.Controls.Add(this.textInventoryNumber);
            this.addProductPage.Controls.Add(this.textDateProduction);
            this.addProductPage.Controls.Add(this.textDateCome);
            this.addProductPage.Controls.Add(this.textProductName);
            this.addProductPage.Controls.Add(this.textProductId);
            this.addProductPage.Location = new System.Drawing.Point(4, 24);
            this.addProductPage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.addProductPage.Name = "addProductPage";
            this.addProductPage.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.addProductPage.Size = new System.Drawing.Size(665, 337);
            this.addProductPage.TabIndex = 1;
            this.addProductPage.Text = "addProductPage";
            this.addProductPage.UseVisualStyleBackColor = true;
            this.addProductPage.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(314, 257);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 13;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(182, 257);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 12;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(196, 157);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "PlaceId";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(140, 130);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "InventoryNumber";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(178, 76);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "DateCome";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(151, 103);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "DateProduction";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(160, 49);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "ProductName";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(182, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "ProductId";
            // 
            // textPlaceId
            // 
            this.textPlaceId.Location = new System.Drawing.Point(245, 149);
            this.textPlaceId.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textPlaceId.Name = "textPlaceId";
            this.textPlaceId.Size = new System.Drawing.Size(106, 23);
            this.textPlaceId.TabIndex = 5;
            // 
            // textInventoryNumber
            // 
            this.textInventoryNumber.Location = new System.Drawing.Point(245, 122);
            this.textInventoryNumber.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textInventoryNumber.Name = "textInventoryNumber";
            this.textInventoryNumber.Size = new System.Drawing.Size(106, 23);
            this.textInventoryNumber.TabIndex = 4;
            // 
            // textDateProduction
            // 
            this.textDateProduction.Location = new System.Drawing.Point(245, 95);
            this.textDateProduction.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textDateProduction.Name = "textDateProduction";
            this.textDateProduction.Size = new System.Drawing.Size(106, 23);
            this.textDateProduction.TabIndex = 3;
            // 
            // textDateCome
            // 
            this.textDateCome.Location = new System.Drawing.Point(245, 68);
            this.textDateCome.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textDateCome.Name = "textDateCome";
            this.textDateCome.Size = new System.Drawing.Size(106, 23);
            this.textDateCome.TabIndex = 2;
            // 
            // textProductName
            // 
            this.textProductName.Location = new System.Drawing.Point(245, 41);
            this.textProductName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textProductName.Name = "textProductName";
            this.textProductName.Size = new System.Drawing.Size(106, 23);
            this.textProductName.TabIndex = 1;
            // 
            // textProductId
            // 
            this.textProductId.Location = new System.Drawing.Point(245, 14);
            this.textProductId.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textProductId.Name = "textProductId";
            this.textProductId.Size = new System.Drawing.Size(106, 23);
            this.textProductId.TabIndex = 0;
            // 
            // PlacePage
            // 
            this.PlacePage.Controls.Add(this.deletePlaceBtn);
            this.PlacePage.Controls.Add(this.updatePlaceBtn);
            this.PlacePage.Controls.Add(this.addPlaceBtn);
            this.PlacePage.Controls.Add(this.searchPlaceBtn);
            this.PlacePage.Controls.Add(this.searchPlaceTextBox);
            this.PlacePage.Controls.Add(this.dataGridView2);
            this.PlacePage.Location = new System.Drawing.Point(4, 24);
            this.PlacePage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PlacePage.Name = "PlacePage";
            this.PlacePage.Size = new System.Drawing.Size(665, 337);
            this.PlacePage.TabIndex = 2;
            this.PlacePage.Text = "PlacePage";
            this.PlacePage.UseVisualStyleBackColor = true;
            // 
            // deletePlaceBtn
            // 
            this.deletePlaceBtn.Location = new System.Drawing.Point(515, 74);
            this.deletePlaceBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.deletePlaceBtn.Name = "deletePlaceBtn";
            this.deletePlaceBtn.Size = new System.Drawing.Size(78, 20);
            this.deletePlaceBtn.TabIndex = 5;
            this.deletePlaceBtn.Text = "Delete";
            this.deletePlaceBtn.UseVisualStyleBackColor = true;
            // 
            // updatePlaceBtn
            // 
            this.updatePlaceBtn.Location = new System.Drawing.Point(515, 50);
            this.updatePlaceBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.updatePlaceBtn.Name = "updatePlaceBtn";
            this.updatePlaceBtn.Size = new System.Drawing.Size(78, 20);
            this.updatePlaceBtn.TabIndex = 4;
            this.updatePlaceBtn.Text = "Update";
            this.updatePlaceBtn.UseVisualStyleBackColor = true;
            // 
            // addPlaceBtn
            // 
            this.addPlaceBtn.Location = new System.Drawing.Point(515, 26);
            this.addPlaceBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.addPlaceBtn.Name = "addPlaceBtn";
            this.addPlaceBtn.Size = new System.Drawing.Size(78, 20);
            this.addPlaceBtn.TabIndex = 3;
            this.addPlaceBtn.Text = "Add";
            this.addPlaceBtn.UseVisualStyleBackColor = true;
            // 
            // searchPlaceBtn
            // 
            this.searchPlaceBtn.Location = new System.Drawing.Point(515, 2);
            this.searchPlaceBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.searchPlaceBtn.Name = "searchPlaceBtn";
            this.searchPlaceBtn.Size = new System.Drawing.Size(78, 20);
            this.searchPlaceBtn.TabIndex = 2;
            this.searchPlaceBtn.Text = "Search";
            this.searchPlaceBtn.UseVisualStyleBackColor = true;
            // 
            // searchPlaceTextBox
            // 
            this.searchPlaceTextBox.Location = new System.Drawing.Point(2, 2);
            this.searchPlaceTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.searchPlaceTextBox.Name = "searchPlaceTextBox";
            this.searchPlaceTextBox.Size = new System.Drawing.Size(510, 23);
            this.searchPlaceTextBox.TabIndex = 1;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(2, 24);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 62;
            this.dataGridView2.RowTemplate.Height = 33;
            this.dataGridView2.Size = new System.Drawing.Size(509, 316);
            this.dataGridView2.TabIndex = 0;
            // 
            // PlaceComponent
            // 
            this.PlaceComponent.Controls.Add(this.Stay);
            this.PlaceComponent.Controls.Add(this.label9);
            this.PlaceComponent.Controls.Add(this.label8);
            this.PlaceComponent.Controls.Add(this.label7);
            this.PlaceComponent.Controls.Add(this.cancelPlaceBtn);
            this.PlaceComponent.Controls.Add(this.savePlaceBtn);
            this.PlaceComponent.Controls.Add(this.StayPlaceText);
            this.PlaceComponent.Controls.Add(this.sizePlaceText);
            this.PlaceComponent.Controls.Add(this.laerPlaceText);
            this.PlaceComponent.Controls.Add(this.placeIdText);
            this.PlaceComponent.Location = new System.Drawing.Point(4, 24);
            this.PlaceComponent.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PlaceComponent.Name = "PlaceComponent";
            this.PlaceComponent.Size = new System.Drawing.Size(665, 337);
            this.PlaceComponent.TabIndex = 3;
            this.PlaceComponent.Text = "PlaceComponent";
            this.PlaceComponent.UseVisualStyleBackColor = true;
            this.PlaceComponent.Click += new System.EventHandler(this.PlaceComponent_Click);
            // 
            // Stay
            // 
            this.Stay.AutoSize = true;
            this.Stay.Location = new System.Drawing.Point(309, 164);
            this.Stay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Stay.Name = "Stay";
            this.Stay.Size = new System.Drawing.Size(29, 15);
            this.Stay.TabIndex = 9;
            this.Stay.Text = "Stay";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(309, 95);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 15);
            this.label9.TabIndex = 8;
            this.label9.Text = "Layer";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(77, 155);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 15);
            this.label8.TabIndex = 7;
            this.label8.Text = "Size";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(66, 90);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "Id";
            // 
            // cancelPlaceBtn
            // 
            this.cancelPlaceBtn.Location = new System.Drawing.Point(324, 227);
            this.cancelPlaceBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cancelPlaceBtn.Name = "cancelPlaceBtn";
            this.cancelPlaceBtn.Size = new System.Drawing.Size(78, 20);
            this.cancelPlaceBtn.TabIndex = 5;
            this.cancelPlaceBtn.Text = "Cancel";
            this.cancelPlaceBtn.UseVisualStyleBackColor = true;
            // 
            // savePlaceBtn
            // 
            this.savePlaceBtn.Location = new System.Drawing.Point(172, 227);
            this.savePlaceBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.savePlaceBtn.Name = "savePlaceBtn";
            this.savePlaceBtn.Size = new System.Drawing.Size(78, 20);
            this.savePlaceBtn.TabIndex = 4;
            this.savePlaceBtn.Text = "Save";
            this.savePlaceBtn.UseVisualStyleBackColor = true;
            // 
            // StayPlaceText
            // 
            this.StayPlaceText.Location = new System.Drawing.Point(362, 164);
            this.StayPlaceText.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.StayPlaceText.Name = "StayPlaceText";
            this.StayPlaceText.Size = new System.Drawing.Size(106, 23);
            this.StayPlaceText.TabIndex = 3;
            // 
            // sizePlaceText
            // 
            this.sizePlaceText.Location = new System.Drawing.Point(147, 155);
            this.sizePlaceText.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.sizePlaceText.Name = "sizePlaceText";
            this.sizePlaceText.Size = new System.Drawing.Size(106, 23);
            this.sizePlaceText.TabIndex = 2;
            // 
            // laerPlaceText
            // 
            this.laerPlaceText.Location = new System.Drawing.Point(362, 94);
            this.laerPlaceText.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.laerPlaceText.Name = "laerPlaceText";
            this.laerPlaceText.Size = new System.Drawing.Size(106, 23);
            this.laerPlaceText.TabIndex = 1;
            // 
            // placeIdText
            // 
            this.placeIdText.Location = new System.Drawing.Point(150, 89);
            this.placeIdText.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.placeIdText.Name = "placeIdText";
            this.placeIdText.Size = new System.Drawing.Size(106, 23);
            this.placeIdText.TabIndex = 0;
            // 
            // WarehouseAdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 382);
            this.Controls.Add(this.tabControl1);
            this.Name = "WarehouseAdminForm";
            this.Text = "WarehouseAdminModel";
            this.Load += new System.EventHandler(this.WarehouseAdminForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.productsPage.ResumeLayout(false);
            this.productsPage.PerformLayout();
            this.addProductPage.ResumeLayout(false);
            this.addProductPage.PerformLayout();
            this.PlacePage.ResumeLayout(false);
            this.PlacePage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.PlaceComponent.ResumeLayout(false);
            this.PlaceComponent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dataGridView1;
        private Button buttonDelete;
        private TabControl tabControl1;
        private TabPage productsPage;
        private TextBox textSearch;
        private TabPage addProductPage;
        private Label label1;
        private TextBox textPlaceId;
        private TextBox textInventoryNumber;
        private TextBox textDateProduction;
        private TextBox textDateCome;
        private TextBox textProductName;
        private TextBox textProductId;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Button buttonCancel;
        private Button buttonSave;
        private Button buttonAdd;
        private Button buttonSearch;
        private TabPage PlacePage;
        private TabPage PlaceComponent;
        private Button searchPlaceBtn;
        private TextBox searchPlaceTextBox;
        private DataGridView dataGridView2;
        private Button deletePlaceBtn;
        private Button updatePlaceBtn;
        private Button addPlaceBtn;
        private TextBox StayPlaceText;
        private TextBox sizePlaceText;
        private TextBox laerPlaceText;
        private TextBox placeIdText;
        private Button cancelPlaceBtn;
        private Button savePlaceBtn;
        private Label Stay;
        private Label label9;
        private Label label8;
        private Label label7;
    }
}