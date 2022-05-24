using Kovrigin.JapaneseCrosswordPuzzleGame.Classes;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Kovrigin.JapaneseCrosswordPuzzleGame
{
    public partial class MenuForm : Form
    {
        public static string NamePage { get; set; }

        public MenuForm()
        {
            InitializeComponent();
            this.Size = new Size(600, 600);
            this.StartPosition = FormStartPosition.Manual;
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            ApplicationManager.ShowForm(new LoginForm());
        }

        private void BtnAllLevels_Click(object sender, EventArgs e)
        {
            NamePage = "ShowAllLevels";
            ApplicationManager.ShowForm(new MainForm());
        }

        private void BtnOptions_Click(object sender, EventArgs e)
        {
            NamePage = "GameOptions";
            ApplicationManager.ShowForm(new MainForm());
        }

        private void BtnCreateNewLevel_Click(object sender, EventArgs e)
        {
            NamePage = "ChoiceSizeLevel";
            ApplicationManager.ShowForm(new MainForm());
        }
    }
}
