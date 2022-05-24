using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Kovrigin.JapaneseCrosswordPuzzleGame.Classes
{
    internal class PlayInGame
    {
        public static int WrongClick { get; set; }

        private static ActionsMap _map;

        public static List<PictureBox> allPicHeart = new List<PictureBox>();

        public static int CurrentColor { get; set; }

        public PlayInGame(string level, Form form)
        {
            _map = new ActionsMap(level);
            _map.CreateMap(form);
            _map.CreateDignits(form);
            CurrentColor = 100;
            allPicHeart.Clear();
        }

        public void CreateLevel(Form form)
        {
            //
            //lblNameLevel
            //
            Label lblNameLevel = new Label();
            lblNameLevel.Font = new Font("Yu Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
            lblNameLevel.ForeColor = Color.LemonChiffon;
            lblNameLevel.Location = new Point(200, 12);
            lblNameLevel.Size = new Size(200, 40);
            lblNameLevel.TextAlign = ContentAlignment.MiddleCenter;
            lblNameLevel.Text = MainForm.LevelsNamesInString[MainForm.CurrentLevel];
            // 
            // BtnBlack
            //
            Button btnBlack = new Button();
            btnBlack.BackColor = Color.Black;
            btnBlack.FlatAppearance.BorderSize = 0;
            btnBlack.FlatAppearance.MouseDownBackColor = Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            btnBlack.FlatAppearance.MouseOverBackColor = Color.Black;
            btnBlack.FlatStyle = FlatStyle.Flat;
            btnBlack.Location = new Point(532, 86);
            btnBlack.Size = new Size(40, 40);
            btnBlack.Click += BtnBlack_Click;
            // 
            // BtnWhite
            // 
            Button btnWhite = new Button();
            btnWhite.BackColor = Color.White;
            btnWhite.FlatAppearance.BorderSize = 0;
            btnWhite.FlatAppearance.MouseDownBackColor = Color.Silver;
            btnWhite.FlatAppearance.MouseOverBackColor = Color.White;
            btnWhite.FlatStyle = FlatStyle.Flat;
            btnWhite.Location = new Point(532, 132);
            btnWhite.Size = new Size(40, 40);
            btnWhite.Click += BtnWhite_Click;
            // 
            // BtnQestion
            // 
            var btnQestion = new PictureBox();
            btnQestion.Image = Properties.Resources.question;
            btnQestion.Location = new Point(532, 178);
            btnQestion.Size = new Size(40, 40);
            btnQestion.SizeMode = PictureBoxSizeMode.Zoom;
            btnQestion.MouseUp += BtnQestion_MouseUp;
            btnQestion.MouseDown += BtnQestion_MouseDown;
            // 
            // BtnRestart
            // 
            var btnRestart = new PictureBox();
            btnRestart.Image = Properties.Resources.restart;
            btnRestart.Location = new Point(532, 224);
            btnRestart.Size = new Size(40, 40);
            btnRestart.SizeMode = PictureBoxSizeMode.Zoom;
            btnRestart.MouseDown += BtnRestart_MouseDown;
            btnRestart.MouseUp += BtnRestart_MouseUp;
            // 
            // BtnCheck
            // 
            Button btnCheck = new Button();
            btnCheck.FlatAppearance.BorderColor = Color.LemonChiffon;
            btnCheck.FlatAppearance.BorderSize = 2;
            btnCheck.FlatAppearance.MouseDownBackColor = Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(140)))), ((int)(((byte)(230)))));
            btnCheck.FlatAppearance.MouseOverBackColor = Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(161)))), ((int)(((byte)(232)))));
            btnCheck.FlatStyle = FlatStyle.Flat;
            btnCheck.Font = new Font("Yu Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
            btnCheck.ForeColor = Color.LemonChiffon;
            btnCheck.Location = new Point(532, 270);
            btnCheck.Size = new Size(40, 246);
            btnCheck.Text = "Проверить";
            btnCheck.Click += BtnCheck_Click;

            PictureBox pic;
            if (GameOptions.LifeLimitSetting)
            {
                for(int i = 0; i < 3; i++)
                {
                    pic = new PictureBox();
                    pic.Image = Properties.Resources.heart;
                    pic.Location = new Point(440 + i*46, 12);
                    pic.Size = new Size(40, 40);
                    pic.SizeMode = PictureBoxSizeMode.Zoom;

                    allPicHeart.Add(pic);
                    form.Controls.Add(pic);
                }
            }

            form.Controls.AddRange(new Control[] { lblNameLevel, btnBlack , btnWhite , btnQestion , btnRestart, btnCheck });
        }

        private void BtnCheck_Click(object sender, EventArgs e)
        {
            if (String.Compare(ActionsMap.LevelInString, MainForm.LevelsInString[MainForm.CurrentLevel]) == 0)
            {
                MessageBox.Show("Молодец");
                _map.RestatrMap();
                if (GameOptions.LifeLimitSetting)
                {
                    WrongClick = 0;
                }
            }
            else
            {
                if (GameOptions.LifeLimitSetting)
                {
                    WrongClick++;
                    allPicHeart[3 - WrongClick].Image = Properties.Resources.died_heart;
                    if (WrongClick == 3)
                    {
                        MessageBox.Show("Вы проиграли");
                        WrongClick = 0;
                        _map.RestatrMap();
                    }
                }
                else
                {
                    MessageBox.Show("Не верно");
                }
            }
        }

        private void BtnWhite_Click(object sender, EventArgs e)
        {
            CurrentColor = 1;
        }

        private void BtnBlack_Click(object sender, EventArgs e)
        {
            CurrentColor = 0;
        }

        private void BtnQestion_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox btn = (PictureBox)sender;
            btn.BackColor = Color.FromArgb(83, 140, 230);
        }

        private void BtnQestion_MouseUp(object sender, MouseEventArgs e)
        {
            PictureBox btn = (PictureBox)sender;
            btn.BackColor = Color.FromArgb(116, 161, 232);
            CurrentColor = 2;
        }

        private void BtnRestart_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox btn = (PictureBox)sender;
            btn.BackColor = Color.FromArgb(83, 140, 230);
        }

        private void BtnRestart_MouseUp(object sender, MouseEventArgs e)
        {
            PictureBox btn = (PictureBox)sender;
            btn.BackColor = Color.FromArgb(116, 161, 232);
            WrongClick = 0;
            _map.RestatrMap();
        }
    }
}
