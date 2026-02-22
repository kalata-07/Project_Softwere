namespace PresentationLayer
{
    partial class TrophiesForm
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
            trophydatagrid = new DataGridView();
            deletebtn = new Button();
            updatebtn = new Button();
            readallbtn = new Button();
            createbtn = new Button();
            t5 = new TextBox();
            t4 = new TextBox();
            t3 = new TextBox();
            t2 = new TextBox();
            label7 = new Label();
            countrycode = new Label();
            label5 = new Label();
            continentcode = new Label();
            name = new Label();
            label1 = new Label();
            t1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)trophydatagrid).BeginInit();
            SuspendLayout();
            // 
            // trophydatagrid
            // 
            trophydatagrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            trophydatagrid.Location = new Point(327, 36);
            trophydatagrid.Name = "trophydatagrid";
            trophydatagrid.RowHeadersWidth = 51;
            trophydatagrid.Size = new Size(449, 279);
            trophydatagrid.TabIndex = 43;
            // 
            // deletebtn
            // 
            deletebtn.Location = new Point(532, 354);
            deletebtn.Name = "deletebtn";
            deletebtn.Size = new Size(140, 60);
            deletebtn.TabIndex = 42;
            deletebtn.Text = "Delete";
            deletebtn.UseVisualStyleBackColor = true;
            deletebtn.Click += deletebtn_Click;
            // 
            // updatebtn
            // 
            updatebtn.Location = new Point(372, 354);
            updatebtn.Name = "updatebtn";
            updatebtn.Size = new Size(140, 60);
            updatebtn.TabIndex = 41;
            updatebtn.Text = "Update";
            updatebtn.UseVisualStyleBackColor = true;
            updatebtn.Click += updatebtn_Click;
            // 
            // readallbtn
            // 
            readallbtn.Location = new Point(210, 354);
            readallbtn.Name = "readallbtn";
            readallbtn.Size = new Size(140, 60);
            readallbtn.TabIndex = 40;
            readallbtn.Text = "Read All";
            readallbtn.UseVisualStyleBackColor = true;
            readallbtn.Click += readallbtn_Click;
            // 
            // createbtn
            // 
            createbtn.Location = new Point(50, 354);
            createbtn.Name = "createbtn";
            createbtn.Size = new Size(140, 60);
            createbtn.TabIndex = 39;
            createbtn.Text = "Create";
            createbtn.UseVisualStyleBackColor = true;
            createbtn.Click += createbtn_Click;
            // 
            // t5
            // 
            t5.Location = new Point(131, 221);
            t5.Name = "t5";
            t5.Size = new Size(125, 27);
            t5.TabIndex = 34;
            // 
            // t4
            // 
            t4.Location = new Point(131, 170);
            t4.Name = "t4";
            t4.Size = new Size(125, 27);
            t4.TabIndex = 33;
            // 
            // t3
            // 
            t3.Location = new Point(132, 119);
            t3.Name = "t3";
            t3.Size = new Size(125, 27);
            t3.TabIndex = 32;
            // 
            // t2
            // 
            t2.Location = new Point(131, 69);
            t2.Name = "t2";
            t2.Size = new Size(125, 27);
            t2.TabIndex = 31;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(76, 258);
            label7.Name = "label7";
            label7.Size = new Size(0, 20);
            label7.TabIndex = 28;
            // 
            // countrycode
            // 
            countrycode.AutoSize = true;
            countrycode.Location = new Point(27, 122);
            countrycode.Name = "countrycode";
            countrycode.Size = new Size(99, 20);
            countrycode.TabIndex = 27;
            countrycode.Text = "Country Code";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(8, 224);
            label5.Name = "label5";
            label5.Size = new Size(117, 20);
            label5.TabIndex = 26;
            label5.Text = "Footballers Won";
            // 
            // continentcode
            // 
            continentcode.AutoSize = true;
            continentcode.Location = new Point(13, 173);
            continentcode.Name = "continentcode";
            continentcode.Size = new Size(112, 20);
            continentcode.TabIndex = 25;
            continentcode.Text = "Continent Code";
            // 
            // name
            // 
            name.AutoSize = true;
            name.Location = new Point(76, 76);
            name.Name = "name";
            name.Size = new Size(49, 20);
            name.TabIndex = 22;
            name.Text = "Name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(76, 32);
            label1.Name = "label1";
            label1.Size = new Size(22, 20);
            label1.TabIndex = 44;
            label1.Text = "Id";
            // 
            // t1
            // 
            t1.Location = new Point(132, 29);
            t1.Name = "t1";
            t1.Size = new Size(125, 27);
            t1.TabIndex = 45;
            // 
            // TrophiesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(t1);
            Controls.Add(label1);
            Controls.Add(trophydatagrid);
            Controls.Add(deletebtn);
            Controls.Add(updatebtn);
            Controls.Add(readallbtn);
            Controls.Add(createbtn);
            Controls.Add(t5);
            Controls.Add(t4);
            Controls.Add(t3);
            Controls.Add(t2);
            Controls.Add(label7);
            Controls.Add(countrycode);
            Controls.Add(label5);
            Controls.Add(continentcode);
            Controls.Add(name);
            Name = "TrophiesForm";
            Text = "TrophiesForm";
            Load += TrophiesForm_Load;
            ((System.ComponentModel.ISupportInitialize)trophydatagrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView trophydatagrid;
        private Button deletebtn;
        private Button updatebtn;
        private Button readallbtn;
        private Button createbtn;
        private TextBox salarytb;
        private TextBox pricetb;
        private TextBox countrycodetb;
        private TextBox teampositiontb;
        private TextBox t5;
        private TextBox t4;
        private TextBox t3;
        private TextBox t2;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label countrycode;
        private Label label5;
        private Label continentcode;
        private Label label3;
        private Label label2;
        private Label name;
        private Label label1;
        private TextBox t1;
    }
}