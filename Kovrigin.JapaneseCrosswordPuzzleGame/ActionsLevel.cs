using Kovrigin.JapaneseCrosswordPuzzleGame.Classes;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Kovrigin.JapaneseCrosswordPuzzleGame
{
	public partial class ActionsLevel : Form
	{
		private static int _controlVariabel = 0;
		//
		// Конструктор
		//
		public ActionsLevel(Point location)
		{
			InitializeComponent();

			this.Location = location;
			this.Size = new Size(200, 250);

			Timer.Start();
		}
		//
		// Делаем фокус на главной форме, чтобы закрылась эта при закрытии
		//
		private void ActionsLevel_FormClosing(object sender, FormClosingEventArgs e)
		{
			Application.OpenForms[0].Focus();
		}
		//
		// Таймер чтобы закрыть эту форму, как только станет активна главная форма
		//
		private void Timer_Tick(object sender, EventArgs e)
		{
			if (Form.ActiveForm == Application.OpenForms[0])
			{
				Timer.Stop();
				this.Close();
				if(_controlVariabel != 0)
                {
					ApplicationManager.ShowForm(new MainForm());
				}
				this.Dispose();
			}
		}
		//
		// Кнопка показа ответа для уровня
		//
		private void BtnShowAnswer_Click(object sender, EventArgs e)
		{
			GameOptions.ShowAnswer = true;
			MenuForm.NamePage = "PlayInGame";
			_controlVariabel++;
			Application.OpenForms[0].Focus();
		}
		//
		// Кнопка изменеия имени для уровня
		//
		private void BtnChangeName_Click(object sender, EventArgs e)
		{
			if (String.IsNullOrWhiteSpace(txtNewName.Text))
			{
				var message = MessageBox.Show("Введите корректное имя", ":)", MessageBoxButtons.OK);
				return;
			}
			else
			{
				MainForm.LevelsNamesInString[MainForm.CurrentLevel] = txtNewName.Text;
				_controlVariabel++;
				Application.OpenForms[0].Focus();
			}
		}
		//
		// Кнопка удаления выбранного уровня
		//
		private void BtnRemoveLevel_Click(object sender, EventArgs e)
		{
			var removeMessage = MessageBox.Show("Вы уверены что хотите удалить уровень", "Осторожно", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
			if (removeMessage == DialogResult.Yes)
			{
				MainForm.LevelsInString.RemoveAt(MainForm.CurrentLevel);
				MainForm.LevelsNamesInString.RemoveAt(MainForm.CurrentLevel);
				_controlVariabel++;
				Application.OpenForms[0].Focus();
			}
			else
			{
				return;
			}
		}
	}
}
