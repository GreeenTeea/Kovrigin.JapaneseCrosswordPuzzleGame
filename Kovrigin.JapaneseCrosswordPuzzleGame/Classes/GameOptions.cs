using System;
using System.Drawing;
using System.Windows.Forms;

namespace Kovrigin.JapaneseCrosswordPuzzleGame.Classes
{
    internal class GameOptions
    {
        private Label _lblTrackMaxSize { get; set; }

        public static bool LifeLimitSetting { get; set; }

        public static bool AdditionalHelpSetting { get; set; }

        public static bool ShowAnswer { get; set; }
        //
        // Создание страницы настроек для игры
        //
        public void CreatePage(Form form)
        {
            var lbllifelimit = new Label();
            lbllifelimit.BorderStyle = BorderStyle.FixedSingle;
            lbllifelimit.Font = new Font("Comic Sans MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
            lbllifelimit.ForeColor = Color.LemonChiffon;
            lbllifelimit.Location = new Point(50, 75);
            lbllifelimit.Size = new Size(400, 50);
            lbllifelimit.Text = "Ограничние попыток";
            lbllifelimit.TextAlign = ContentAlignment.MiddleLeft;

            var lblAdditionalHelp = new Label();
            lblAdditionalHelp.BorderStyle = BorderStyle.FixedSingle;
            lblAdditionalHelp.Font = new Font("Comic Sans MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
            lblAdditionalHelp.ForeColor = Color.LemonChiffon;
            lblAdditionalHelp.Location = new Point(50, 150);
            lblAdditionalHelp.Size = new Size(400, 50);
            lblAdditionalHelp.Text = "Вспомогательные цыфры";
            lblAdditionalHelp.TextAlign = ContentAlignment.MiddleLeft;

            var lblChoiseMaxSize = new Label();
            lblChoiseMaxSize.BorderStyle = BorderStyle.FixedSingle;
            lblChoiseMaxSize.Font = new Font("Comic Sans MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
            lblChoiseMaxSize.ForeColor = Color.LemonChiffon;
            lblChoiseMaxSize.Location = new Point(50, 225);
            lblChoiseMaxSize.Size = new Size(400, 50);
            lblChoiseMaxSize.Text = "Количество уровней на форме";
            lblChoiseMaxSize.TextAlign = ContentAlignment.MiddleLeft;

            var piclifelimit = new PictureBox();
            if (LifeLimitSetting)
            {
                piclifelimit.Image = Properties.Resources.on;
            }
            else
            {
                piclifelimit.Image = Properties.Resources.off;
            }
            piclifelimit.Location = new Point(450, 75);
            piclifelimit.Size = new Size(50, 50);
            piclifelimit.Cursor = Cursors.Hand;
            piclifelimit.SizeMode = PictureBoxSizeMode.Zoom;
            piclifelimit.Click += Piclifelimit_Click;

            var picAdditionalHelp = new PictureBox();
            if (AdditionalHelpSetting)
            {
                picAdditionalHelp.Image = Properties.Resources.on;
            }
            else
            {
                picAdditionalHelp.Image = Properties.Resources.off;
            }
            picAdditionalHelp.Location = new Point(450, 150);
            picAdditionalHelp.Size = new Size(50, 50);
            picAdditionalHelp.Cursor = Cursors.Hand;
            picAdditionalHelp.SizeMode = PictureBoxSizeMode.Zoom;
            picAdditionalHelp.Click += PicAdditionalHelp_Click;

            var trackMaxSizeShowLevel = new TrackBar();
            trackMaxSizeShowLevel.Cursor = Cursors.Hand;
            trackMaxSizeShowLevel.LargeChange = 1;
            trackMaxSizeShowLevel.Location = new Point(450, 225);
            trackMaxSizeShowLevel.Minimum = 2;
            trackMaxSizeShowLevel.Maximum = 5;
            trackMaxSizeShowLevel.Size = new Size(80, 50);
            trackMaxSizeShowLevel.TickStyle = TickStyle.None;
            trackMaxSizeShowLevel.Value = (int)Math.Sqrt(ShowAllLevels.MaxNumberLevelsOnPage);
            trackMaxSizeShowLevel.Scroll += TrackMaxSizeShowLevel_Scroll;

            _lblTrackMaxSize = new Label();
            _lblTrackMaxSize.Font = new Font("Comic Sans MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
            _lblTrackMaxSize.ForeColor = Color.LemonChiffon;
            _lblTrackMaxSize.Location = new Point(530, 225);
            _lblTrackMaxSize.Size = new Size(70, 50);
            _lblTrackMaxSize.TextAlign = ContentAlignment.MiddleCenter;
            _lblTrackMaxSize.Text = ShowAllLevels.MaxNumberLevelsOnPage.ToString();

            form.Controls.AddRange(new Control[] {lbllifelimit, lblAdditionalHelp, lblChoiseMaxSize, piclifelimit, picAdditionalHelp, trackMaxSizeShowLevel, _lblTrackMaxSize });
        }
        //
        // Кнопка установки лимита жизней
        //
        private void Piclifelimit_Click(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            if (LifeLimitSetting)
            {
                LifeLimitSetting = false;
                pic.Image = Properties.Resources.off;
            }
            else
            {
                LifeLimitSetting = true;
                pic.Image = Properties.Resources.on;
            }
        }
        //
        // Кнопка установки дополнительной помощи при игре
        //
        private void PicAdditionalHelp_Click(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            if (AdditionalHelpSetting)
            {
                AdditionalHelpSetting = false;
                pic.Image = Properties.Resources.off;
            }
            else
            {
                AdditionalHelpSetting = true;
                pic.Image = Properties.Resources.on;
            }
        }
        //
        // Установка максимального количества уровней на странице выбора уровней
        //
        private void TrackMaxSizeShowLevel_Scroll(object sender, EventArgs e)
        {
            TrackBar track = (TrackBar)sender;
            ShowAllLevels.MaxNumberLevelsOnPage = track.Value*track.Value;
            _lblTrackMaxSize.Text = (track.Value * track.Value).ToString();
        }
    }
}
