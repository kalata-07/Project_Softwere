namespace PresentationLayer
{
    partial class Stadium
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
            capacity = new Label();
            name = new Label();
            id = new Label();
            townName = new Label();
            countryCode = new Label();
            t5 = new TextBox();
            t4 = new TextBox();
            t3 = new TextBox();
            t2 = new TextBox();
            t1 = new TextBox();
            delete = new Button();
            update = new Button();
            readAll = new Button();
            create = new Button();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // capacity
            // 
            capacity.AutoSize = true;
            capacity.Location = new Point(72, 146);
            capacity.Name = "capacity";
            capacity.Size = new Size(66, 20);
            capacity.TabIndex = 1;
            capacity.Text = "Capacity";
            // 
            // name
            // 
            name.AutoSize = true;
            name.Location = new Point(85, 106);
            name.Name = "name";
            name.Size = new Size(49, 20);
            name.TabIndex = 2;
            name.Text = "Name";
            // 
            // id
            // 
            id.AutoSize = true;
            id.Location = new Point(112, 65);
            id.Name = "id";
            id.Size = new Size(22, 20);
            id.TabIndex = 3;
            id.Text = "Id";
            // 
            // townName
            // 
            townName.AutoSize = true;
            townName.Location = new Point(49, 232);
            townName.Name = "townName";
            townName.Size = new Size(85, 20);
            townName.TabIndex = 4;
            townName.Text = "Town name";
            townName.Click += ContinentCode_Click;
            // 
            // countryCode
            // 
            countryCode.AutoSize = true;
            countryCode.Location = new Point(41, 188);
            countryCode.Name = "countryCode";
            countryCode.Size = new Size(97, 20);
            countryCode.TabIndex = 5;
            countryCode.Text = "Country code";
            // 
            // t5
            // 
            t5.Location = new Point(144, 232);
            t5.Name = "t5";
            t5.Size = new Size(125, 27);
            t5.TabIndex = 10;
            // 
            // t4
            // 
            t4.Location = new Point(144, 185);
            t4.Name = "t4";
            t4.Size = new Size(125, 27);
            t4.TabIndex = 11;
            // 
            // t3
            // 
            t3.Location = new Point(144, 143);
            t3.Name = "t3";
            t3.Size = new Size(125, 27);
            t3.TabIndex = 12;
            // 
            // t2
            // 
            t2.Location = new Point(144, 106);
            t2.Name = "t2";
            t2.Size = new Size(125, 27);
            t2.TabIndex = 13;
            // 
            // t1
            // 
            t1.Location = new Point(144, 62);
            t1.Name = "t1";
            t1.Size = new Size(125, 27);
            t1.TabIndex = 14;
            // 
            // delete
            // 
            delete.Location = new Point(521, 343);
            delete.Name = "delete";
            delete.Size = new Size(140, 60);
            delete.TabIndex = 18;
            delete.Text = "Delete";
            delete.UseVisualStyleBackColor = true;
            // 
            // update
            // 
            update.Location = new Point(364, 343);
            update.Name = "update";
            update.Size = new Size(140, 60);
            update.TabIndex = 19;
            update.Text = "Update";
            update.UseVisualStyleBackColor = true;
            // 
            // readAll
            // 
            readAll.Location = new Point(206, 343);
            readAll.Name = "readAll";
            readAll.Size = new Size(140, 60);
            readAll.TabIndex = 20;
            readAll.Text = "Read All";
            readAll.UseVisualStyleBackColor = true;
            // 
            // create
            // 
            create.Location = new Point(49, 343);
            create.Name = "create";
            create.Size = new Size(140, 60);
            create.TabIndex = 21;
            create.Text = "Create";
            create.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(412, 71);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(300, 188);
            dataGridView1.TabIndex = 23;
            // 
            // Stadium
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Controls.Add(create);
            Controls.Add(readAll);
            Controls.Add(update);
            Controls.Add(delete);
            Controls.Add(t1);
            Controls.Add(t2);
            Controls.Add(t3);
            Controls.Add(t4);
            Controls.Add(t5);
            Controls.Add(countryCode);
            Controls.Add(townName);
            Controls.Add(id);
            Controls.Add(name);
            Controls.Add(capacity);
            Name = "Stadium";
            Text = "Stadium";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label capacity;
        private Label name;
        private Label id;
        private Label townName;
        private Label countryCode;
        private TextBox t5;
        private TextBox t4;
        private TextBox t3;
        private TextBox t2;
        private TextBox t1;
        private Button delete;
        private Button update;
        private Button readAll;
        private Button create;
        private DataGridView dataGridView1;
    }
}