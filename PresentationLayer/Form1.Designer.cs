namespace PresentationLayer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            continentsbtn = new Button();
            countriesbtn = new Button();
            footballersbtn = new Button();
            stadiumsbtn = new Button();
            teamsbtn = new Button();
            trophiesbtn = new Button();
            SuspendLayout();
            // 
            // continentsbtn
            // 
            continentsbtn.Location = new Point(52, 49);
            continentsbtn.Name = "continentsbtn";
            continentsbtn.Size = new Size(129, 62);
            continentsbtn.TabIndex = 0;
            continentsbtn.Text = "Continents";
            continentsbtn.UseVisualStyleBackColor = true;
            // 
            // countriesbtn
            // 
            countriesbtn.Location = new Point(205, 49);
            countriesbtn.Name = "countriesbtn";
            countriesbtn.Size = new Size(119, 62);
            countriesbtn.TabIndex = 1;
            countriesbtn.Text = "Countries";
            countriesbtn.UseVisualStyleBackColor = true;
            // 
            // footballersbtn
            // 
            footballersbtn.Location = new Point(356, 49);
            footballersbtn.Name = "footballersbtn";
            footballersbtn.Size = new Size(115, 62);
            footballersbtn.TabIndex = 2;
            footballersbtn.Text = "Footballers";
            footballersbtn.UseVisualStyleBackColor = true;
            footballersbtn.Click += footballersbtn_Click;
            // 
            // stadiumsbtn
            // 
            stadiumsbtn.Location = new Point(52, 145);
            stadiumsbtn.Name = "stadiumsbtn";
            stadiumsbtn.Size = new Size(129, 62);
            stadiumsbtn.TabIndex = 3;
            stadiumsbtn.Text = "Stadiums";
            stadiumsbtn.UseVisualStyleBackColor = true;
            // 
            // teamsbtn
            // 
            teamsbtn.Location = new Point(205, 145);
            teamsbtn.Name = "teamsbtn";
            teamsbtn.Size = new Size(119, 62);
            teamsbtn.TabIndex = 4;
            teamsbtn.Text = "Teams";
            teamsbtn.UseVisualStyleBackColor = true;
            // 
            // trophiesbtn
            // 
            trophiesbtn.Location = new Point(356, 145);
            trophiesbtn.Name = "trophiesbtn";
            trophiesbtn.Size = new Size(115, 62);
            trophiesbtn.TabIndex = 5;
            trophiesbtn.Text = "Trophies";
            trophiesbtn.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(trophiesbtn);
            Controls.Add(teamsbtn);
            Controls.Add(stadiumsbtn);
            Controls.Add(footballersbtn);
            Controls.Add(countriesbtn);
            Controls.Add(continentsbtn);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button continentsbtn;
        private Button countriesbtn;
        private Button footballersbtn;
        private Button stadiumsbtn;
        private Button teamsbtn;
        private Button trophiesbtn;
    }
}
