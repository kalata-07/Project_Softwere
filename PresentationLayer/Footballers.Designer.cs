namespace PresentationLayer
{
    partial class FootballersForm
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
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            fnametb = new TextBox();
            lnametb = new TextBox();
            agetb = new TextBox();
            shirtnumbertb = new TextBox();
            teampositiontb = new TextBox();
            countrycodetb = new TextBox();
            pricetb = new TextBox();
            salarytb = new TextBox();
            createbtn = new Button();
            readallbtn = new Button();
            updatebtn = new Button();
            deletebtn = new Button();
            footballersread = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)footballersread).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 27);
            label1.Name = "label1";
            label1.Size = new Size(77, 20);
            label1.TabIndex = 0;
            label1.Text = "First name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 64);
            label2.Name = "label2";
            label2.Size = new Size(76, 20);
            label2.TabIndex = 1;
            label2.Text = "Last name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 131);
            label3.Name = "label3";
            label3.Size = new Size(94, 20);
            label3.TabIndex = 2;
            label3.Text = "Shirt number";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(70, 98);
            label4.Name = "label4";
            label4.Size = new Size(36, 20);
            label4.TabIndex = 3;
            label4.Text = "Age";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(4, 167);
            label5.Name = "label5";
            label5.Size = new Size(103, 20);
            label5.TabIndex = 4;
            label5.Text = "Team position";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(9, 208);
            label6.Name = "label6";
            label6.Size = new Size(97, 20);
            label6.TabIndex = 5;
            label6.Text = "Country code";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(56, 246);
            label7.Name = "label7";
            label7.Size = new Size(0, 20);
            label7.TabIndex = 6;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(62, 246);
            label8.Name = "label8";
            label8.Size = new Size(41, 20);
            label8.TabIndex = 7;
            label8.Text = "Price";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(57, 279);
            label9.Name = "label9";
            label9.Size = new Size(49, 20);
            label9.TabIndex = 8;
            label9.Text = "Salary";
            // 
            // fnametb
            // 
            fnametb.Location = new Point(112, 24);
            fnametb.Name = "fnametb";
            fnametb.Size = new Size(125, 27);
            fnametb.TabIndex = 9;
            // 
            // lnametb
            // 
            lnametb.Location = new Point(112, 61);
            lnametb.Name = "lnametb";
            lnametb.Size = new Size(125, 27);
            lnametb.TabIndex = 10;
            // 
            // agetb
            // 
            agetb.Location = new Point(112, 95);
            agetb.Name = "agetb";
            agetb.Size = new Size(125, 27);
            agetb.TabIndex = 11;
            // 
            // shirtnumbertb
            // 
            shirtnumbertb.Location = new Point(112, 128);
            shirtnumbertb.Name = "shirtnumbertb";
            shirtnumbertb.Size = new Size(125, 27);
            shirtnumbertb.TabIndex = 12;
            // 
            // teampositiontb
            // 
            teampositiontb.Location = new Point(112, 164);
            teampositiontb.Name = "teampositiontb";
            teampositiontb.Size = new Size(125, 27);
            teampositiontb.TabIndex = 13;
            // 
            // countrycodetb
            // 
            countrycodetb.Location = new Point(112, 205);
            countrycodetb.Name = "countrycodetb";
            countrycodetb.Size = new Size(125, 27);
            countrycodetb.TabIndex = 14;
            // 
            // pricetb
            // 
            pricetb.Location = new Point(112, 243);
            pricetb.Name = "pricetb";
            pricetb.Size = new Size(125, 27);
            pricetb.TabIndex = 15;
            // 
            // salarytb
            // 
            salarytb.Location = new Point(112, 276);
            salarytb.Name = "salarytb";
            salarytb.Size = new Size(125, 27);
            salarytb.TabIndex = 16;
            // 
            // createbtn
            // 
            createbtn.Location = new Point(30, 342);
            createbtn.Name = "createbtn";
            createbtn.Size = new Size(140, 60);
            createbtn.TabIndex = 17;
            createbtn.Text = "Create";
            createbtn.UseVisualStyleBackColor = true;
            createbtn.Click += createbtn_Click;
            // 
            // readallbtn
            // 
            readallbtn.Location = new Point(190, 342);
            readallbtn.Name = "readallbtn";
            readallbtn.Size = new Size(140, 60);
            readallbtn.TabIndex = 18;
            readallbtn.Text = "Read All";
            readallbtn.UseVisualStyleBackColor = true;
            readallbtn.Click += readallbtn_Click;
            // 
            // updatebtn
            // 
            updatebtn.Location = new Point(352, 342);
            updatebtn.Name = "updatebtn";
            updatebtn.Size = new Size(140, 60);
            updatebtn.TabIndex = 19;
            updatebtn.Text = "Update";
            updatebtn.UseVisualStyleBackColor = true;
            // 
            // deletebtn
            // 
            deletebtn.Location = new Point(512, 342);
            deletebtn.Name = "deletebtn";
            deletebtn.Size = new Size(140, 60);
            deletebtn.TabIndex = 20;
            deletebtn.Text = "Delete";
            deletebtn.UseVisualStyleBackColor = true;
            // 
            // footballersread
            // 
            footballersread.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            footballersread.Location = new Point(307, 24);
            footballersread.Name = "footballersread";
            footballersread.RowHeadersWidth = 51;
            footballersread.Size = new Size(449, 279);
            footballersread.TabIndex = 21;
            footballersread.CellContentClick += footballersread_CellContentClick;
            // 
            // FootballersForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(footballersread);
            Controls.Add(deletebtn);
            Controls.Add(updatebtn);
            Controls.Add(readallbtn);
            Controls.Add(createbtn);
            Controls.Add(salarytb);
            Controls.Add(pricetb);
            Controls.Add(countrycodetb);
            Controls.Add(teampositiontb);
            Controls.Add(shirtnumbertb);
            Controls.Add(agetb);
            Controls.Add(lnametb);
            Controls.Add(fnametb);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FootballersForm";
            Text = "Footballers";
            Load += FootballersForm_Load;
            ((System.ComponentModel.ISupportInitialize)footballersread).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private TextBox fnametb;
        private TextBox lnametb;
        private TextBox agetb;
        private TextBox shirtnumbertb;
        private TextBox teampositiontb;
        private TextBox countrycodetb;
        private TextBox pricetb;
        private TextBox salarytb;
        private Button createbtn;
        private Button readallbtn;
        private Button updatebtn;
        private Button deletebtn;
        private DataGridView footballersread;
    }
}