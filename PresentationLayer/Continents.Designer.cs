namespace PresentationLayer
{
    partial class ContinentsForm
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
            continentCodetb = new TextBox();
            continentNametb = new TextBox();
            delete = new Button();
            update = new Button();
            readAll = new Button();
            create = new Button();
            continentsDataGrid = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)continentsDataGrid).BeginInit();
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
            // continentCodetb
            // 
            continentCodetb.Location = new Point(145, 68);
            continentCodetb.Name = "continentCodetb";
            continentCodetb.Size = new Size(125, 27);
            continentCodetb.TabIndex = 10;
            // 
            // continentNametb
            // 
            continentNametb.Location = new Point(145, 129);
            continentNametb.Name = "continentNametb";
            continentNametb.Size = new Size(125, 27);
            continentNametb.TabIndex = 11;
            // 
            // delete
            // 
            delete.Location = new Point(540, 350);
            delete.Name = "delete";
            delete.Size = new Size(140, 60);
            delete.TabIndex = 18;
            delete.Text = "Delete";
            delete.UseVisualStyleBackColor = true;
            delete.Click += delete_Click;
            // 
            // update
            // 
            update.Location = new Point(372, 350);
            update.Name = "update";
            update.Size = new Size(140, 60);
            update.TabIndex = 19;
            update.Text = "Update";
            update.UseVisualStyleBackColor = true;
            update.Click += update_Click;
            // 
            // readAll
            // 
            readAll.Location = new Point(203, 350);
            readAll.Name = "readAll";
            readAll.Size = new Size(140, 60);
            readAll.TabIndex = 20;
            readAll.Text = "Read All";
            readAll.UseVisualStyleBackColor = true;
            readAll.Click += readAll_Click;
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
            // continentsDataGrid
            // 
            continentsDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            continentsDataGrid.Location = new Point(428, 97);
            continentsDataGrid.Name = "continentsDataGrid";
            continentsDataGrid.RowHeadersWidth = 51;
            continentsDataGrid.Size = new Size(300, 188);
            continentsDataGrid.TabIndex = 22;
            // 
            // ContinentsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(continentsDataGrid);
            Controls.Add(create);
            Controls.Add(readAll);
            Controls.Add(update);
            Controls.Add(delete);
            Controls.Add(continentNametb);
            Controls.Add(continentCodetb);
            Controls.Add(continentName);
            Controls.Add(continentCode);
            Name = "ContinentsForm";
            Text = "Continents";
            Load += ContinentForm_Load;
            ((System.ComponentModel.ISupportInitialize)continentsDataGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label continentCode;
        private Label continentName;
        private TextBox continentCodetb;
        private TextBox continentNametb;
        private Button delete;
        private Button update;
        private Button readAll;
        private Button create;
        private DataGridView continentsDataGrid;
    }
}