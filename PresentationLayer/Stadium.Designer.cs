namespace PresentationLayer
{
    partial class StadiumsForm
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
            townNametb = new TextBox();
            countryCodetb = new TextBox();
            capacitytb = new TextBox();
            nametb = new TextBox();
            idtb = new TextBox();
            delete = new Button();
            update = new Button();
            readAll = new Button();
            create = new Button();
            stadiumsDataGrid = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)stadiumsDataGrid).BeginInit();
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
            // townNametb
            // 
            townNametb.Location = new Point(144, 232);
            townNametb.Name = "townNametb";
            townNametb.Size = new Size(125, 27);
            townNametb.TabIndex = 10;
            // 
            // countryCodetb
            // 
            countryCodetb.Location = new Point(144, 185);
            countryCodetb.Name = "countryCodetb";
            countryCodetb.Size = new Size(125, 27);
            countryCodetb.TabIndex = 11;
            // 
            // capacitytb
            // 
            capacitytb.Location = new Point(144, 143);
            capacitytb.Name = "capacitytb";
            capacitytb.Size = new Size(125, 27);
            capacitytb.TabIndex = 12;
            // 
            // nametb
            // 
            nametb.Location = new Point(144, 106);
            nametb.Name = "nametb";
            nametb.Size = new Size(125, 27);
            nametb.TabIndex = 13;
            // 
            // idtb
            // 
            idtb.Location = new Point(144, 62);
            idtb.Name = "idtb";
            idtb.Size = new Size(125, 27);
            idtb.TabIndex = 14;
            // 
            // delete
            // 
            delete.Location = new Point(521, 343);
            delete.Name = "delete";
            delete.Size = new Size(140, 60);
            delete.TabIndex = 18;
            delete.Text = "Delete";
            delete.UseVisualStyleBackColor = true;
            delete.Click += delete_Click;
            // 
            // update
            // 
            update.Location = new Point(364, 343);
            update.Name = "update";
            update.Size = new Size(140, 60);
            update.TabIndex = 19;
            update.Text = "Update";
            update.UseVisualStyleBackColor = true;
            update.Click += update_Click;
            // 
            // readAll
            // 
            readAll.Location = new Point(206, 343);
            readAll.Name = "readAll";
            readAll.Size = new Size(140, 60);
            readAll.TabIndex = 20;
            readAll.Text = "Read All";
            readAll.UseVisualStyleBackColor = true;
            readAll.Click += readAll_Click;
            // 
            // create
            // 
            create.Location = new Point(49, 343);
            create.Name = "create";
            create.Size = new Size(140, 60);
            create.TabIndex = 21;
            create.Text = "Create";
            create.UseVisualStyleBackColor = true;
            create.Click += create_Click;
            // 
            // stadiumsDataGrid
            // 
            stadiumsDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            stadiumsDataGrid.Location = new Point(412, 71);
            stadiumsDataGrid.Name = "stadiumsDataGrid";
            stadiumsDataGrid.RowHeadersWidth = 51;
            stadiumsDataGrid.Size = new Size(300, 188);
            stadiumsDataGrid.TabIndex = 23;
            // 
            // StadiumsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(stadiumsDataGrid);
            Controls.Add(create);
            Controls.Add(readAll);
            Controls.Add(update);
            Controls.Add(delete);
            Controls.Add(idtb);
            Controls.Add(nametb);
            Controls.Add(capacitytb);
            Controls.Add(countryCodetb);
            Controls.Add(townNametb);
            Controls.Add(countryCode);
            Controls.Add(townName);
            Controls.Add(id);
            Controls.Add(name);
            Controls.Add(capacity);
            Name = "StadiumsForm";
            Text = "Stadium";
            Load += StadiumForm_Load;
            ((System.ComponentModel.ISupportInitialize)stadiumsDataGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label capacity;
        private Label name;
        private Label id;
        private Label townName;
        private Label countryCode;
        private TextBox townNametb;
        private TextBox countryCodetb;
        private TextBox capacitytb;
        private TextBox nametb;
        private TextBox idtb;
        private Button delete;
        private Button update;
        private Button readAll;
        private Button create;
        private DataGridView stadiumsDataGrid;
    }
}