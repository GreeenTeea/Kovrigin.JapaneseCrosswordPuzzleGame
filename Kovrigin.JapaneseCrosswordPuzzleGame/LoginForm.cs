using Kovrigin.JapaneseCrosswordPuzzleGame.Classes;
using System.Drawing;
using System.Windows.Forms;

namespace Kovrigin.JapaneseCrosswordPuzzleGame
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.Size = new Size(400, 200);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void BtnStart_Click(object sender, System.EventArgs e)
        {
            ApplicationManager.ShowForm(new MenuForm());
        }
    }
}
