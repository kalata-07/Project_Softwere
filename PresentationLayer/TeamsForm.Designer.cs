namespace PresentationLayer
{
    partial class TeamsForm
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
            teamGridView = new DataGridView();
            create = new Button();
            readAll = new Button();
            update = new Button();
            delete = new Button();
            t3 = new TextBox();
            t4 = new TextBox();
            t5 = new TextBox();
            countryCode = new Label();
            colours = new Label();
            name = new Label();
            coach_name = new Label();
            t6 = new TextBox();
            t2 = new TextBox();
            founded = new Label();
            t7 = new TextBox();
            teamstadium = new Label();
            label1 = new Label();
            textBox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)teamGridView).BeginInit();
            SuspendLayout();
            // 
            // teamGridView
            // 
            teamGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            teamGridView.Location = new Point(374, 44);
            teamGridView.Name = "teamGridView";
            teamGridView.RowHeadersWidth = 51;
            teamGridView.Size = new Size(395, 256);
            teamGridView.TabIndex = 38;
            // 
            // create
            // 
            create.Location = new Point(73, 336);
            create.Name = "create";
            create.Size = new Size(140, 60);
            create.TabIndex = 37;
            create.Text = "Create";
            create.UseVisualStyleBackColor = true;
            create.Click += create_Click;
            // 
            // readAll
            // 
            readAll.Location = new Point(230, 336);
            readAll.Name = "readAll";
            readAll.Size = new Size(140, 60);
            readAll.TabIndex = 36;
            readAll.Text = "Read All";
            readAll.UseVisualStyleBackColor = true;
            // 
            // update
            // 
            update.Location = new Point(388, 336);
            update.Name = "update";
            update.Size = new Size(140, 60);
            update.TabIndex = 35;
            update.Text = "Update";
            update.UseVisualStyleBackColor = true;
            // 
            // delete
            // 
            delete.Location = new Point(545, 336);
            delete.Name = "delete";
            delete.Size = new Size(140, 60);
            delete.TabIndex = 34;
            delete.Text = "Delete";
            delete.UseVisualStyleBackColor = true;
            // 
            // t3
            // 
            t3.Location = new Point(165, 106);
            t3.Name = "t3";
            t3.Size = new Size(125, 27);
            t3.TabIndex = 32;
            // 
            // t4
            // 
            t4.Location = new Point(165, 152);
            t4.Name = "t4";
            t4.Size = new Size(125, 27);
            t4.TabIndex = 31;
            // 
            // t5
            // 
            t5.Location = new Point(165, 195);
            t5.Name = "t5";
            t5.Size = new Size(125, 27);
            t5.TabIndex = 30;
            // 
            // countryCode
            // 
            countryCode.AutoSize = true;
            countryCode.Location = new Point(62, 109);
            countryCode.Name = "countryCode";
            countryCode.Size = new Size(97, 20);
            countryCode.TabIndex = 28;
            countryCode.Text = "Country code";
            // 
            // colours
            // 
            colours.AutoSize = true;
            colours.Location = new Point(97, 195);
            colours.Name = "colours";
            colours.Size = new Size(59, 20);
            colours.TabIndex = 27;
            colours.Text = "Colours";
            // 
            // name
            // 
            name.AutoSize = true;
            name.Location = new Point(110, 64);
            name.Name = "name";
            name.Size = new Size(49, 20);
            name.TabIndex = 25;
            name.Text = "Name";
            // 
            // coach_name
            // 
            coach_name.AutoSize = true;
            coach_name.Location = new Point(62, 155);
            coach_name.Name = "coach_name";
            coach_name.Size = new Size(94, 20);
            coach_name.TabIndex = 24;
            coach_name.Text = "Coach Name";
            // 
            // t6
            // 
            t6.Location = new Point(165, 237);
            t6.Name = "t6";
            t6.Size = new Size(125, 27);
            t6.TabIndex = 39;
            // 
            // t2
            // 
            t2.Location = new Point(165, 57);
            t2.Name = "t2";
            t2.Size = new Size(125, 27);
            t2.TabIndex = 33;
            // 
            // founded
            // 
            founded.AutoSize = true;
            founded.Location = new Point(92, 240);
            founded.Name = "founded";
            founded.Size = new Size(67, 20);
            founded.TabIndex = 26;
            founded.Text = "Founded";
            // 
            // t7
            // 
            t7.Location = new Point(165, 277);
            t7.Name = "t7";
            t7.Size = new Size(125, 27);
            t7.TabIndex = 41;
            // 
            // teamstadium
            // 
            teamstadium.AutoSize = true;
            teamstadium.Location = new Point(55, 277);
            teamstadium.Name = "teamstadium";
            teamstadium.Size = new Size(104, 20);
            teamstadium.TabIndex = 42;
            teamstadium.Text = "Team Stadium";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(134, 23);
            label1.Name = "label1";
            label1.Size = new Size(22, 20);
            label1.TabIndex = 43;
            label1.Text = "Id";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(165, 20);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 44;
            // 
            // TeamsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(teamstadium);
            Controls.Add(t7);
            Controls.Add(t6);
            Controls.Add(teamGridView);
            Controls.Add(create);
            Controls.Add(readAll);
            Controls.Add(update);
            Controls.Add(delete);
            Controls.Add(t2);
            Controls.Add(t3);
            Controls.Add(t4);
            Controls.Add(t5);
            Controls.Add(countryCode);
            Controls.Add(colours);
            Controls.Add(founded);
            Controls.Add(name);
            Controls.Add(coach_name);
            Name = "TeamsForm";
            Text = "TeamsForm";
            Load += TeamsForm_Load;
            ((System.ComponentModel.ISupportInitialize)teamGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView teamGridView;
        private Button create;
        private Button readAll;
        private Button update;
        private Button delete;
        private TextBox t3;
        private TextBox t4;
        private TextBox t5;
        private Label countryCode;
        private Label colours;
        private Label name;
        private Label coach_name;
        private TextBox t6;
        private TextBox t2;
        private Label founded;
        private TextBox t7;
        private Label teamstadium;
        private Label label1;
        private TextBox textBox1;
    }
}