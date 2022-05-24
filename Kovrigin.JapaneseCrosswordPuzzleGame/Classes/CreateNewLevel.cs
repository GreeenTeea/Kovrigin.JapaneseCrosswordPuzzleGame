using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Kovrigin.JapaneseCrosswordPuzzleGame.Classes
{
	internal class CreateNewLevel
	{
		private Label _lblWight, _lblHeight;

		private TextBox _txtName;

		private ActionsMap _map = new ActionsMap(LevelWight, LevelHeight);

		public static string LevelInString { get; set; }

		public static int LevelWight { get; set; }

		public static int LevelHeight { get; set; }
		//
		// Конструкор 1
		//
		public CreateNewLevel(int wight, int height, Form form)
		{
			LevelHeight = height;
			LevelWight = wight;
			if (MenuForm.NamePage == "PaintNewLevel")
			{
				_map.CreateMap(form);
			}
		}
		//
		// Конструкор 2
		//
		public CreateNewLevel(int wight, int height, string level, Form form)
		{
			LevelHeight = height;
			LevelWight = wight;
			LevelInString = level;
			if (MenuForm.NamePage == "PaintNewLevel")
			{
				_map.CreateMap(form);	
			}
		}
		//
		// Конструкор 3
		//
		public CreateNewLevel(int wight, int height, string level)
		{
			LevelWight = wight;
			LevelHeight = height;
			LevelInString = level;
		}
		//
		// Создание страницы вабора размера поля
		//
		public void CreateChoiceSizePage(Form form)
		{
			Button btnNext = new Button();
			btnNext.FlatAppearance.BorderColor = Color.LemonChiffon;
			btnNext.FlatAppearance.BorderSize = 2;
			btnNext.FlatAppearance.MouseDownBackColor = Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(140)))), ((int)(((byte)(230)))));
			btnNext.FlatAppearance.MouseOverBackColor = Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(161)))), ((int)(((byte)(232)))));
			btnNext.FlatStyle = FlatStyle.Flat;
			btnNext.Font = new Font("Comic Sans MS", 18.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
			btnNext.ForeColor = Color.LemonChiffon;
			btnNext.Location = new Point(200, 300);
			btnNext.Size = new Size(200, 50);
			btnNext.Text = "Продолжить";
			btnNext.Click += BtnNext_Click;

			var lblInform = new Label();
			lblInform.Font = new Font("Comic Sans MS", 18.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
			lblInform.ForeColor = Color.LemonChiffon;
			lblInform.Location = new Point(50, 100);
			lblInform.Size = new Size(500, 50);
			lblInform.Text = "Укажите размер игрового поля";
			lblInform.TextAlign = ContentAlignment.MiddleCenter;

			var trackWight = new TrackBar();
			trackWight.Cursor = Cursors.Hand;
			trackWight.LargeChange = 1;
			trackWight.Location = new Point(170, 200);
			trackWight.Minimum = 5;
			trackWight.Maximum = 20;
			trackWight.Size = new Size(350, 50);
			trackWight.TickStyle = TickStyle.None;
			trackWight.Value = LevelWight;
			trackWight.Scroll += TrackWight_Scroll;

			_lblWight = new Label();
			_lblWight.Font = new Font("Comic Sans MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
			_lblWight.ForeColor = Color.LemonChiffon;
			_lblWight.Location = new Point(70, 200);
			_lblWight.Size = new Size(100, 50);
			_lblWight.TextAlign = ContentAlignment.TopLeft;
			_lblWight.Text = String.Format($"X - {trackWight.Value}");

			var trackHeight = new TrackBar();
			trackHeight.Cursor = Cursors.Hand;
			trackHeight.LargeChange = 1;
			trackHeight.Location = new Point(170, 250);
			trackHeight.Minimum = 5;
			trackHeight.Maximum = 20;
			trackHeight.Size = new Size(350, 50);
			trackHeight.TickStyle = TickStyle.None;
			trackHeight.Value = LevelHeight;
			trackHeight.Scroll += TrackHeight_Scroll;

			_lblHeight = new Label();
			_lblHeight.Font = new Font("Comic Sans MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
			_lblHeight.ForeColor = Color.LemonChiffon;
			_lblHeight.Location = new Point(70, 250);
			_lblHeight.Size = new Size(100, 50);
			_lblHeight.TextAlign = ContentAlignment.TopLeft;
			_lblHeight.Text = String.Format($"Y - {trackHeight.Value}");

			form.Controls.AddRange(new Control[] { btnNext,lblInform, trackWight, _lblWight, trackHeight, _lblHeight });
		}
		//
		// Изменение трэкбара для высоты поля
		//
		private void TrackHeight_Scroll(object sender, EventArgs e)
		{
			TrackBar track = (TrackBar)sender;
			LevelHeight = track.Value;
			_lblHeight.Text = String.Format($"Y - {track.Value}");
		}
		//
		// Изменение траэкбара для ширины поля
		//
		private void TrackWight_Scroll(object sender, EventArgs e)
		{
			TrackBar track = (TrackBar)sender;
			LevelWight = track.Value;
			_lblWight.Text = String.Format($"X - {track.Value}");
		}
		//
		// Клик по кнопке вперёд, который загружает страницы рисования
		//
		private void BtnNext_Click(object sender, EventArgs e)
		{
			MenuForm.NamePage = "PaintNewLevel";
			ApplicationManager.ShowForm(new MainForm(LevelWight, LevelHeight));
		}
		//
		// Сознаие поля для рисования нового уровня
		//
		public void CreateDrawPage(Form form)
		{
			PictureBox btnNext = new PictureBox();
			btnNext.Size = new Size(40, 40);
			btnNext.Location = new Point(form.Width - btnNext.Width - 28, form.Height / 2 - 34);
			btnNext.Image = Properties.Resources.arrow_right;
			btnNext.SizeMode = PictureBoxSizeMode.Zoom;
			btnNext.BackColor = Color.Transparent;
			btnNext.MouseDown += BtnNext_MouseDown;
			btnNext.MouseUp += BtnNext_MouseUp;

			PictureBox btnRestart = new PictureBox();
			btnRestart.Size = new Size(40, 40);
			btnRestart.Location = new Point(form.Width - btnNext.Width - 28, form.Height / 2 + 46);
			btnRestart.Image = Properties.Resources.restart;
			btnRestart.SizeMode = PictureBoxSizeMode.Zoom;
			btnRestart.BackColor = Color.Transparent;
			btnRestart.MouseUp += BtnRestart_MouseUp;
			btnRestart.MouseDown += BtnRestart_MouseDown;

			form.Controls.AddRange(new Control[] { btnNext, btnRestart });
		}
		//
		// Клик по кнопке перезагрузки поля
		//
		private void BtnRestart_MouseDown(object sender, MouseEventArgs e)
		{
			PictureBox btn = (PictureBox)sender;
			btn.BackColor = Color.FromArgb(83, 140, 230);
		}
		//
		// Клик по кнопке перезагрузки поля
		//
		private void BtnRestart_MouseUp(object sender, MouseEventArgs e)
		{
			PictureBox btn = (PictureBox)sender;
			btn.BackColor = Color.FromArgb(116, 161, 232);
			_map.RestatrMap();
		}
		//
		// Клик по стрелочке вперёд для перехода на страницы выбора названия для нового уровня
		//
		private void BtnNext_MouseDown(object sender, MouseEventArgs e)
		{
			PictureBox btn = (PictureBox)sender;
			btn.BackColor = Color.FromArgb(83, 140, 230);
		}
		//
		// Клик по стрелочке вперёд для перехода на страницы выбора названия для нового уровня
		//
		private void BtnNext_MouseUp(object sender, MouseEventArgs e)
		{
			LevelInString = ActionsMap.LevelInString;
			MenuForm.NamePage = "ChoiceNameLevel";
			ApplicationManager.ShowForm(new MainForm(LevelWight, LevelHeight, LevelInString));
		}
		//
		// Создание страницы выбора имени для новго уровня
		//
		public void CreateChoiceNamePage(Form form)
		{
			Button btnNext = new Button();
			btnNext.FlatAppearance.BorderColor = Color.LemonChiffon;
			btnNext.FlatAppearance.BorderSize = 2;
			btnNext.FlatAppearance.MouseDownBackColor = Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(140)))), ((int)(((byte)(230)))));
			btnNext.FlatAppearance.MouseOverBackColor = Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(161)))), ((int)(((byte)(232)))));
			btnNext.FlatStyle = FlatStyle.Flat;
			btnNext.Font = new Font("Comic Sans MS", 18.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
			btnNext.ForeColor = Color.LemonChiffon;
			btnNext.Location = new Point(200, 300);
			btnNext.Size = new Size(200, 50);
			btnNext.Text = "Сохранить";
			btnNext.Click += BtnNext_Click1;

			var lblInform = new Label();
			lblInform.Font = new Font("Comic Sans MS", 18.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
			lblInform.ForeColor = Color.LemonChiffon;
			lblInform.Location = new Point(50, 100);
			lblInform.Size = new Size(500, 50);
			lblInform.Text = "Укажите имя уровня";
			lblInform.TextAlign = ContentAlignment.MiddleCenter;

			_txtName = new TextBox();
			_txtName.Font = new Font("Comic Sans MS", 18.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
			_txtName.Location = new Point(50, 200);
			_txtName.Size = new Size(500, 50);
			_txtName.TextAlign = HorizontalAlignment.Center;

			form.Controls.AddRange(new Control[] {btnNext, lblInform, _txtName});
		}
		//
		// Клик по кнопке вперёд для сохранение новго уровня и его имени в главные списки
		//
		private void BtnNext_Click1(object sender, EventArgs e)
		{
			MainForm.LevelsInString.Add(LevelInString);
			LevelInString = null;

			StreamWriter f = new StreamWriter("test.txt", false);
			f.WriteLine(LevelInString);
			f.Close();

			if (String.IsNullOrWhiteSpace(_txtName.Text))
			{
				MainForm.LevelsNamesInString.Add("Пусто");
			}
			else
			{
				MainForm.LevelsNamesInString.Add(_txtName.Text);
			}
			ApplicationManager.ShowForm(new MenuForm());
		}
	}
}
