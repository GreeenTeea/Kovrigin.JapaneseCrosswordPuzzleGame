namespace Kovrigin.JapaneseCrosswordPuzzleGame
{
    partial class ActionsLevel
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
            this.components = new System.ComponentModel.Container();
            this.BtnShowAnswer = new System.Windows.Forms.Button();
            this.BtnChangeName = new System.Windows.Forms.Button();
            this.BtnRemoveLevel = new System.Windows.Forms.Button();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.txtNewName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BtnShowAnswer
            // 
            this.BtnShowAnswer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(129)))), ((int)(((byte)(52)))));
            this.BtnShowAnswer.FlatAppearance.BorderColor = System.Drawing.Color.LemonChiffon;
            this.BtnShowAnswer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(89)))), ((int)(((byte)(12)))));
            this.BtnShowAnswer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(129)))), ((int)(((byte)(52)))));
            this.BtnShowAnswer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnShowAnswer.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnShowAnswer.ForeColor = System.Drawing.Color.LemonChiffon;
            this.BtnShowAnswer.Location = new System.Drawing.Point(15, 10);
            this.BtnShowAnswer.Name = "BtnShowAnswer";
            this.BtnShowAnswer.Size = new System.Drawing.Size(150, 40);
            this.BtnShowAnswer.TabIndex = 4;
            this.BtnShowAnswer.Text = "Показать ответ";
            this.BtnShowAnswer.UseVisualStyleBackColor = false;
            this.BtnShowAnswer.Click += new System.EventHandler(this.BtnShowAnswer_Click);
            // 
            // BtnChangeName
            // 
            this.BtnChangeName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(129)))), ((int)(((byte)(52)))));
            this.BtnChangeName.FlatAppearance.BorderColor = System.Drawing.Color.LemonChiffon;
            this.BtnChangeName.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(89)))), ((int)(((byte)(12)))));
            this.BtnChangeName.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(129)))), ((int)(((byte)(52)))));
            this.BtnChangeName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnChangeName.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnChangeName.ForeColor = System.Drawing.Color.LemonChiffon;
            this.BtnChangeName.Location = new System.Drawing.Point(15, 101);
            this.BtnChangeName.Name = "BtnChangeName";
            this.BtnChangeName.Size = new System.Drawing.Size(150, 40);
            this.BtnChangeName.TabIndex = 5;
            this.BtnChangeName.Text = "Поменять название";
            this.BtnChangeName.UseVisualStyleBackColor = false;
            this.BtnChangeName.Click += new System.EventHandler(this.BtnChangeName_Click);
            // 
            // BtnRemoveLevel
            // 
            this.BtnRemoveLevel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(129)))), ((int)(((byte)(52)))));
            this.BtnRemoveLevel.FlatAppearance.BorderColor = System.Drawing.Color.LemonChiffon;
            this.BtnRemoveLevel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(89)))), ((int)(((byte)(12)))));
            this.BtnRemoveLevel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(129)))), ((int)(((byte)(52)))));
            this.BtnRemoveLevel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRemoveLevel.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnRemoveLevel.ForeColor = System.Drawing.Color.LemonChiffon;
            this.BtnRemoveLevel.Location = new System.Drawing.Point(15, 159);
            this.BtnRemoveLevel.Name = "BtnRemoveLevel";
            this.BtnRemoveLevel.Size = new System.Drawing.Size(150, 40);
            this.BtnRemoveLevel.TabIndex = 6;
            this.BtnRemoveLevel.Text = "Удалить уровень";
            this.BtnRemoveLevel.UseVisualStyleBackColor = false;
            this.BtnRemoveLevel.Click += new System.EventHandler(this.BtnRemoveLevel_Click);
            // 
            // Timer
            // 
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // txtNewName
            // 
            this.txtNewName.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtNewName.Location = new System.Drawing.Point(15, 68);
            this.txtNewName.Name = "txtNewName";
            this.txtNewName.Size = new System.Drawing.Size(150, 30);
            this.txtNewName.TabIndex = 7;
            this.txtNewName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ActionsLevel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(129)))), ((int)(((byte)(52)))));
            this.ClientSize = new System.Drawing.Size(184, 211);
            this.Controls.Add(this.txtNewName);
            this.Controls.Add(this.BtnRemoveLevel);
            this.Controls.Add(this.BtnChangeName);
            this.Controls.Add(this.BtnShowAnswer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ActionsLevel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ActionsLevel_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BtnShowAnswer;
        private System.Windows.Forms.Button BtnChangeName;
        private System.Windows.Forms.Button BtnRemoveLevel;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.TextBox txtNewName;
    }
}