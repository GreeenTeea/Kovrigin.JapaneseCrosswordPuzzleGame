using Kovrigin.JapaneseCrosswordPuzzleGame.Classes;
using System;
using System.Windows.Forms;

namespace Kovrigin.JapaneseCrosswordPuzzleGame
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ApplicationManager.Context.MainForm = new LoginForm();
            Application.Run(ApplicationManager.Context);
        }
    }
}
