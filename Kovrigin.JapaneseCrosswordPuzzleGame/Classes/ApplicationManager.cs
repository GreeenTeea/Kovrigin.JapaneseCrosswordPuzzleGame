using System.Drawing;
using System.Windows.Forms;

namespace Kovrigin.JapaneseCrosswordPuzzleGame.Classes
{
    internal class ApplicationManager
    {
        private static ApplicationContext _context;

        public static ApplicationContext Context
        {
            get
            {
                if(_context == null)
                {
                    _context = new ApplicationContext();
                }

                return _context;
            }
        }

        public static void ShowForm(Form form)
        {
            Form prev = Context.MainForm;
            Context.MainForm = form;
            form.Location = new Point(prev.Location.X - (form.Width - prev.Width)/2, prev.Location.Y - (form.Height - prev.Height)/2);

            prev.Close();
            form.Show();
        }
    }
}
