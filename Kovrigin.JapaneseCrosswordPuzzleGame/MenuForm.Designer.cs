namespace Kovrigin.JapaneseCrosswordPuzzleGame
{
    partial class MenuForm
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
            this.BtnAllLevels = new System.Windows.Forms.Button();
            this.BtnOptions = new System.Windows.Forms.Button();
            this.BtnCreateNewLevel = new System.Windows.Forms.Button();
            this.BtnBack = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.BtnBack)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnAllLevels
            // 
            this.BtnAllLevels.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(161)))), ((int)(((byte)(232)))));
            this.BtnAllLevels.FlatAppearance.BorderColor = System.Drawing.Color.LemonChiffon;
            this.BtnAllLevels.FlatAppearance.BorderSize = 2;
            this.BtnAllLevels.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(140)))), ((int)(((byte)(230)))));
            this.BtnAllLevels.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(161)))), ((int)(((byte)(232)))));
            this.BtnAllLevels.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAllLevels.Font = new System.Drawing.Font("Yu Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnAllLevels.ForeColor = System.Drawing.Color.LemonChiffon;
            this.BtnAllLevels.Location = new System.Drawing.Point(100, 50);
            this.BtnAllLevels.Name = "BtnAllLevels";
            this.BtnAllLevels.Size = new System.Drawing.Size(400, 50);
            this.BtnAllLevels.TabIndex = 1;
            this.BtnAllLevels.Text = "Уровни";
            this.BtnAllLevels.UseVisualStyleBackColor = false;
            this.BtnAllLevels.Click += new System.EventHandler(this.BtnAllLevels_Click);
            // 
            // BtnOptions
            // 
            this.BtnOptions.FlatAppearance.BorderColor = System.Drawing.Color.LemonChiffon;
            this.BtnOptions.FlatAppearance.BorderSize = 2;
            this.BtnOptions.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(140)))), ((int)(((byte)(230)))));
            this.BtnOptions.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(161)))), ((int)(((byte)(232)))));
            this.BtnOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnOptions.Font = new System.Drawing.Font("Yu Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnOptions.ForeColor = System.Drawing.Color.LemonChiffon;
            this.BtnOptions.Location = new System.Drawing.Point(100, 191);
            this.BtnOptions.Name = "BtnOptions";
            this.BtnOptions.Size = new System.Drawing.Size(400, 50);
            this.BtnOptions.TabIndex = 3;
            this.BtnOptions.Text = "Настройки      игры";
            this.BtnOptions.UseVisualStyleBackColor = true;
            this.BtnOptions.Click += new System.EventHandler(this.BtnOptions_Click);
            // 
            // BtnCreateNewLevel
            // 
            this.BtnCreateNewLevel.FlatAppearance.BorderColor = System.Drawing.Color.LemonChiffon;
            this.BtnCreateNewLevel.FlatAppearance.BorderSize = 2;
            this.BtnCreateNewLevel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(140)))), ((int)(((byte)(230)))));
            this.BtnCreateNewLevel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(161)))), ((int)(((byte)(232)))));
            this.BtnCreateNewLevel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCreateNewLevel.Font = new System.Drawing.Font("Yu Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnCreateNewLevel.ForeColor = System.Drawing.Color.LemonChiffon;
            this.BtnCreateNewLevel.Location = new System.Drawing.Point(100, 119);
            this.BtnCreateNewLevel.Name = "BtnCreateNewLevel";
            this.BtnCreateNewLevel.Size = new System.Drawing.Size(400, 50);
            this.BtnCreateNewLevel.TabIndex = 4;
            this.BtnCreateNewLevel.Text = "Создание     уровня";
            this.BtnCreateNewLevel.UseVisualStyleBackColor = true;
            this.BtnCreateNewLevel.Click += new System.EventHandler(this.BtnCreateNewLevel_Click);
            // 
            // BtnBack
            // 
            this.BtnBack.Image = global::Kovrigin.JapaneseCrosswordPuzzleGame.Properties.Resources.arrow_left;
            this.BtnBack.Location = new System.Drawing.Point(12, 12);
            this.BtnBack.Name = "BtnBack";
            this.BtnBack.Size = new System.Drawing.Size(40, 40);
            this.BtnBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BtnBack.TabIndex = 2;
            this.BtnBack.TabStop = false;
            this.BtnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(161)))), ((int)(((byte)(232)))));
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.BtnCreateNewLevel);
            this.Controls.Add(this.BtnOptions);
            this.Controls.Add(this.BtnBack);
            this.Controls.Add(this.BtnAllLevels);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MenuForm";
            ((System.ComponentModel.ISupportInitialize)(this.BtnBack)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnAllLevels;
        private System.Windows.Forms.PictureBox BtnBack;
        private System.Windows.Forms.Button BtnOptions;
        private System.Windows.Forms.Button BtnCreateNewLevel;
    }
}