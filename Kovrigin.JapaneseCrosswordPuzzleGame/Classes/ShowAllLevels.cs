using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Kovrigin.JapaneseCrosswordPuzzleGame.Classes
{
	internal class ShowAllLevels
	{
		public static int NumberLevels { get; set; }

		public static List<string> NamesLevels { get; set; }

		public static int CurrentPage { get; set; }

		public static int MaxNumberLevelsOnPage { get; set; }

		private static int _controlVariable { get; set; }

		private static List<Button> _allButtons = new List<Button>();

		private static PictureBox _btnNext, _btnBack;
		//
		// Конструктор
		//
		public ShowAllLevels(int numberLevels, List<string> namesLevels, int currentPage)
		{
			NumberLevels = numberLevels;
			NamesLevels = namesLevels;
			CurrentPage = currentPage;
		}
		//
		// Создание страницы с выбором уровней
		//
		public static void CreatePage(Form form)
		{
			Button btn;
			float foreSize = 0;
			for(int counterLevels = 0; counterLevels < MaxNumberLevelsOnPage; counterLevels++)
			{
				if(NumberLevels - CurrentPage * MaxNumberLevelsOnPage == counterLevels)
				{
					break;
				}

				btn = new Button();
				btn.Size = new Size((form.Width - 150)/(int)Math.Sqrt(MaxNumberLevelsOnPage), (form.Height - 150)/ (int)Math.Sqrt(MaxNumberLevelsOnPage));
				btn.Location = new Point(50 + (btn.Width + 50 / (int)Math.Sqrt(MaxNumberLevelsOnPage)) *(counterLevels% (int)Math.Sqrt(MaxNumberLevelsOnPage)), 50 + (btn.Height + 50 / (int)Math.Sqrt(MaxNumberLevelsOnPage)) * (counterLevels / (int)Math.Sqrt(MaxNumberLevelsOnPage)));
				btn.FlatAppearance.BorderColor = Color.LemonChiffon;
				btn.FlatAppearance.BorderSize = 2;
				btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(140)))), ((int)(((byte)(230)))));
				btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(161)))), ((int)(((byte)(232)))));
				btn.FlatStyle = FlatStyle.Flat;
				foreSize = btn.Height / 8;
				btn.Font = new Font("Comic Sans MS", foreSize, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
				btn.ForeColor = Color.LemonChiffon;
				btn.Text = NamesLevels[counterLevels + CurrentPage*MaxNumberLevelsOnPage];
				btn.Tag = (counterLevels + CurrentPage * MaxNumberLevelsOnPage);
                btn.MouseUp += Btn_MouseUp1;

				form.Controls.Add(btn);
				_allButtons.Add(btn);
			}

			if(NumberLevels  - CurrentPage * MaxNumberLevelsOnPage > MaxNumberLevelsOnPage)
			{
				_btnNext = new PictureBox();
				_btnNext.Size = new Size(40, 40);
				_btnNext.Location = new Point(form.Width - _btnNext.Width - 28, form.Height/2 - 34);
				_btnNext.Image = Properties.Resources.arrow_right;
				_btnNext.SizeMode = PictureBoxSizeMode.Zoom;
				_btnNext.BackColor = Color.Transparent;
                _btnNext.MouseDown += _btnNext_MouseDown;
                _btnNext.MouseUp += _btnNext_MouseUp;

				form.Controls.Add(_btnNext);
			}

			if(CurrentPage > 0)
			{
				_btnBack = new PictureBox();
				_btnBack.Size = new Size(40, 40);
				_btnBack.Location = new Point(_btnBack.Width - 38, form.Height / 2 - 34);
				_btnBack.Image = Properties.Resources.arrow_right;
				_btnBack.Image.RotateFlip(RotateFlipType.Rotate180FlipY);
				_btnBack.SizeMode = PictureBoxSizeMode.Zoom;
				_btnBack.BackColor = Color.Transparent;
                _btnBack.MouseDown += _btnBack_MouseDown;
                _btnBack.MouseUp += _btnBack_MouseUp;

				form.Controls.Add(_btnBack);
			}
		}
		//
		// Нажатие на кнопку выбора уровня
		//
		private static void Btn_MouseUp1(object sender, MouseEventArgs e)
        {
			Button btn = (Button)sender;
			MainForm.CurrentLevel = (int)btn.Tag;

			if (e.Button == MouseButtons.Left)
			{
				MenuForm.NamePage = "PlayInGame";
				ApplicationManager.ShowForm(new MainForm());
			}
			else if (e.Button == MouseButtons.Right)
			{
				Application.OpenForms[0].Focus();
				ActionsLevel newForm = new ActionsLevel(btn.PointToScreen(new Point(btn.Width, 0)));
				newForm.Show();
			}
		}
        //
        // Кнопка прокрутки вперёд
        //
        private static void _btnNext_MouseDown(object sender, MouseEventArgs e)
        {
			PictureBox btn = (PictureBox)sender;
			btn.BackColor = Color.FromArgb(83, 140, 230);
		}
		//
		// Кнопка прокрутки вперёд
		//
		private static void _btnNext_MouseUp(object sender, MouseEventArgs e)
        {
			MainForm.CurrentPageShowLevels++;
			ApplicationManager.ShowForm(new MainForm());
		}
		//
		// Кнопка прокрутки назад
		//
		private static void _btnBack_MouseDown(object sender, MouseEventArgs e)
        {
			PictureBox btn = (PictureBox)sender;
			btn.BackColor = Color.FromArgb(83, 140, 230);
		}
		//
		// Кнопка прокрутки назад
		//
		private static void _btnBack_MouseUp(object sender, MouseEventArgs e)
        {
			MainForm.CurrentPageShowLevels--;
			ApplicationManager.ShowForm(new MainForm());
		}
	}
}
