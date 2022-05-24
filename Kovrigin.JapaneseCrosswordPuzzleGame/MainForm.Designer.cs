namespace Kovrigin.JapaneseCrosswordPuzzleGame
{
    partial class MainForm
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
            this.BtnBack = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.BtnBack)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnBack
            // 
            this.BtnBack.Image = global::Kovrigin.JapaneseCrosswordPuzzleGame.Properties.Resources.arrow_left;
            this.BtnBack.Location = new System.Drawing.Point(12, 12);
            this.BtnBack.Name = "BtnBack";
            this.BtnBack.Size = new System.Drawing.Size(40, 40);
            this.BtnBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BtnBack.TabIndex = 3;
            this.BtnBack.TabStop = false;
            this.BtnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(161)))), ((int)(((byte)(232)))));
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.BtnBack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.BtnBack)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox BtnBack;
    }
}