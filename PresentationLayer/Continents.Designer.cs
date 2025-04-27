namespace PresentationLayer
{
    partial class Continents
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
            continentCode = new Label();
            continentName = new Label();
            t1 = new TextBox();
            t2 = new TextBox();
            delete = new Button();
            update = new Button();
            readAll = new Button();
            create = new Button();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // continentCode
            // 
            continentCode.AutoSize = true;
            continentCode.Location = new Point(22, 75);
            continentCode.Name = "continentCode";
            continentCode.Size = new Size(110, 20);
            continentCode.TabIndex = 0;
            continentCode.Text = "Continent code";
            continentCode.Click += label1_Click;
            // 
            // continentName
            // 
            continentName.AutoSize = true;
            continentName.Location = new Point(22, 132);
            continentName.Name = "continentName";
            continentName.Size = new Size(114, 20);
            continentName.TabIndex = 1;
            continentName.Text = "Continent name";
            // 
            // t1
            // 
            t1.Location = new Point(145, 68);
            t1.Name = "t1";
            t1.Size = new Size(125, 27);
            t1.TabIndex = 10;
            // 
            // t2
            // 
            t2.Location = new Point(145, 129);
            t2.Name = "t2";
            t2.Size = new Size(125, 27);
            t2.TabIndex = 11;
            // 
            // delete
            // 
            delete.Location = new Point(540, 350);
            delete.Name = "delete";
            delete.Size = new Size(140, 60);
            delete.TabIndex = 18;
            delete.Text = "Delete";
            delete.UseVisualStyleBackColor = true;
            // 
            // update
            // 
            update.Location = new Point(372, 350);
            update.Name = "update";
            update.Size = new Size(140, 60);
            update.TabIndex = 19;
            update.Text = "Update";
            update.UseVisualStyleBackColor = true;
            // 
            // readAll
            // 
            readAll.Location = new Point(203, 350);
            readAll.Name = "readAll";
            readAll.Size = new Size(140, 60);
            readAll.TabIndex = 20;
            readAll.Text = "Read All";
            readAll.UseVisualStyleBackColor = true;
            // 
            // create
            // 
            create.Location = new Point(31, 350);
            create.Name = "create";
            create.Size = new Size(140, 60);
            create.TabIndex = 21;
            create.Text = "Create";
            create.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(428, 97);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(300, 188);
            dataGridView1.TabIndex = 22;
            // 
            // Continents
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Controls.Add(create);
            Controls.Add(readAll);
            Controls.Add(update);
            Controls.Add(delete);
            Controls.Add(t2);
            Controls.Add(t1);
            Controls.Add(continentName);
            Controls.Add(continentCode);
            Name = "Continents";
            Text = "Continents";
            Load += Continents_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label continentCode;
        private Label continentName;
        private TextBox t1;
        private TextBox t2;
        private Button delete;
        private Button update;
        private Button readAll;
        private Button create;
        private DataGridView dataGridView1;
    }
}