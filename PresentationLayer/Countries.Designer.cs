namespace PresentationLayer
{
    partial class CountriesForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            countrynametb = new TextBox();
            countrycodetb = new TextBox();
            continentcodetb = new TextBox();
            createbtn = new Button();
            readallbtn = new Button();
            updatebtn = new Button();
            deletebtn = new Button();
            countriesDataGrid = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)countriesDataGrid).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 25);
            label1.Name = "label1";
            label1.Size = new Size(101, 20);
            label1.TabIndex = 0;
            label1.Text = "Country name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 58);
            label2.Name = "label2";
            label2.Size = new Size(97, 20);
            label2.TabIndex = 1;
            label2.Text = "Country code";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 88);
            label3.Name = "label3";
            label3.Size = new Size(110, 20);
            label3.TabIndex = 2;
            label3.Text = "Continent code";
            // 
            // countrynametb
            // 
            countrynametb.Location = new Point(143, 18);
            countrynametb.Name = "countrynametb";
            countrynametb.Size = new Size(125, 27);
            countrynametb.TabIndex = 3;
            // 
            // countrycodetb
            // 
            countrycodetb.Location = new Point(143, 51);
            countrycodetb.Name = "countrycodetb";
            countrycodetb.Size = new Size(125, 27);
            countrycodetb.TabIndex = 4;
            // 
            // continentcodetb
            // 
            continentcodetb.Location = new Point(143, 85);
            continentcodetb.Name = "continentcodetb";
            continentcodetb.Size = new Size(125, 27);
            continentcodetb.TabIndex = 5;
            // 
            // createbtn
            // 
            createbtn.Location = new Point(27, 341);
            createbtn.Name = "createbtn";
            createbtn.Size = new Size(140, 60);
            createbtn.TabIndex = 18;
            createbtn.Text = "Create";
            createbtn.UseVisualStyleBackColor = true;
            createbtn.Click += createbtn_Click;
            // 
            // readallbtn
            // 
            readallbtn.Location = new Point(183, 341);
            readallbtn.Name = "readallbtn";
            readallbtn.Size = new Size(140, 60);
            readallbtn.TabIndex = 19;
            readallbtn.Text = "Read All";
            readallbtn.UseVisualStyleBackColor = true;
            readallbtn.Click += readallbtn_Click;
            // 
            // updatebtn
            // 
            updatebtn.Location = new Point(340, 341);
            updatebtn.Name = "updatebtn";
            updatebtn.Size = new Size(140, 60);
            updatebtn.TabIndex = 20;
            updatebtn.Text = "Update";
            updatebtn.UseVisualStyleBackColor = true;
            updatebtn.Click += updatebtn_Click;
            // 
            // deletebtn
            // 
            deletebtn.Location = new Point(502, 341);
            deletebtn.Name = "deletebtn";
            deletebtn.Size = new Size(140, 60);
            deletebtn.TabIndex = 21;
            deletebtn.Text = "Delete";
            deletebtn.UseVisualStyleBackColor = true;
            deletebtn.Click += deletebtn_Click;
            // 
            // countriesDataGrid
            // 
            countriesDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            countriesDataGrid.Location = new Point(312, 18);
            countriesDataGrid.Name = "countriesDataGrid";
            countriesDataGrid.RowHeadersWidth = 51;
            countriesDataGrid.Size = new Size(444, 285);
            countriesDataGrid.TabIndex = 22;
            // 
            // CountriesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(countriesDataGrid);
            Controls.Add(deletebtn);
            Controls.Add(updatebtn);
            Controls.Add(readallbtn);
            Controls.Add(createbtn);
            Controls.Add(continentcodetb);
            Controls.Add(countrycodetb);
            Controls.Add(countrynametb);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "CountriesForm";
            Text = "Countries";
            ((System.ComponentModel.ISupportInitialize)countriesDataGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox countrynametb;
        private TextBox countrycodetb;
        private TextBox continentcodetb;
        private Button createbtn;
        private Button readallbtn;
        private Button updatebtn;
        private Button deletebtn;
        private DataGridView countriesDataGrid;
    }
}