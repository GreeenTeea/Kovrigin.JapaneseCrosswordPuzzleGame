using Kovrigin.JapaneseCrosswordPuzzleGame.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Kovrigin.JapaneseCrosswordPuzzleGame
{
	public partial class MainForm : Form
	{
		public static int NumberLevels
		{
			get
			{
				return LevelsInString.Count;
			}
		}

		public static List<string> LevelsInString = new List<string>();

		public static List<string> LevelsNamesInString = new List<string>();

		public static int CurrentPageShowLevels { get; set; }

		public static int LevelWight { get; set; }

		public static int LevelHeight { get; set; }

		public static int CurrentLevel { get; set; }
		//
		// Конструктор 1
		//
		public MainForm()
		{
			InitializeComponent();
			this.Size = new Size(600, 600);
			this.StartPosition = FormStartPosition.Manual;

			if(NumberLevels == 0)
			{
				LevelsInString.AddRange(new List<string> { "11 12 0 0 0 0 1 1 1 0 0 0 0 0 0 0 1 1 1 1 1 0 0 0 0 1 1 0 0 1 0 0 1 1 0 1 1 1 1 0 0 0 1 1 1 1 0 1 1 0 0 1 0 0 1 1 0 0 0 0 1 1 1 1 1 0 0 0 0 0 0 0 1 1 1 0 0 0 0 1 1 0 0 0 0 0 0 0 1 1 1 1 1 0 0 1 0 0 1 1 1 0 1 1 1 0 1 0 1 1 1 0 0 0 1 1 0 1 0 1 1 0 0 0 0 0 1 1 1 1 1 0 0 0",
					"13 20 1 1 1 1 1 1 0 0 1 1 1 1 1 1 1 1 1 1 0 0 0 0 1 1 1 1 1 1 1 1 0 0 1 1 0 0 1 1 1 1 1 1 1 0 0 0 1 0 0 1 1 1 1 1 1 1 1 0 1 0 0 1 1 1 1 1 1 1 1 1 1 0 0 1 1 1 1 1 1 1 1 1 0 0 0 0 0 1 1 1 1 1 1 1 1 1 0 0 1 1 1 1 1 1 1 1 1 1 0 0 1 1 0 1 1 1 1 1 1 0 0 0 1 1 0 0 1 0 1 1 1 0 0 0 1 1 0 0 0 1 0 0 1 0 0 1 1 0 0 0 1 1 0 0 1 1 0 1 0 0 0 0 1 1 0 0 0 1 0 1 0 0 0 1 1 0 0 0 1 1 0 0 0 0 0 1 1 0 0 0 1 1 0 0 0 0 0 1 1 0 0 0 1 1 0 0 0 1 1 1 0 0 0 0 1 0 0 0 0 1 1 1 1 1 1 0 0 1 0 0 1 1 1 1 1 1 1 1 1 0 0 0 1 1 1 1 1 1 1 1 0 0 0 0 0 0 0 1 1 1",
					"9 15 1 0 1 1 0 1 1 1 1 1 1 1 0 1 0 0 1 1 1 1 1 0 1 0 1 0 1 1 0 0 0 1 1 1 0 1 1 0 1 0 1 0 0 1 1 1 0 1 1 1 0 1 1 1 1 1 0 0 1 0 1 0 0 1 1 1 0 1 0 0 1 0 0 0 1 0 1 0 1 1 0 0 1 0 0 1 1 1 0 1 0 1 1 0 1 0 0 1 1 1 0 1 1 1 0 1 1 1 1 1 0 0 1 0 1 1 1 0 1 1 0 1 0 1 0 0 1 0 0 0 0 0 0 1 1"});
				LevelsNamesInString.AddRange(new List<string> { "Цветочек", "Флакон духов", "Кактус"});
				CurrentPageShowLevels = 0;
				ShowAllLevels.MaxNumberLevelsOnPage = 4;
			}

			switch (MenuForm.NamePage)
			{
				case "ShowAllLevels":
					var page = new ShowAllLevels(NumberLevels, LevelsNamesInString, CurrentPageShowLevels);
					ShowAllLevels.CreatePage(this);
					break;
				case "GameOptions":
					var page1 = new GameOptions();
					page1.CreatePage(this);
					break;
				case "ChoiceSizeLevel":
					var page2 = new CreateNewLevel(5, 5, this);
					page2.CreateChoiceSizePage(this);
					break;
				case "PlayInGame":
					var page4 = new PlayInGame(LevelsInString[CurrentLevel], this);
					page4.CreateLevel(this);
					break;
				default:
					break;
			}
		}
		//
		// Конструктор 2
		//
		public MainForm(int wight, int height)
		{
			InitializeComponent();
			this.Size = new Size(600, 600);
			this.StartPosition = FormStartPosition.Manual;

			switch (MenuForm.NamePage)
			{
				case "ChoiceSizeLevel":
					var page2 = new CreateNewLevel(wight, height, this);
					page2.CreateChoiceSizePage(this);
					break;
				case "PaintNewLevel":
					var page3 = new CreateNewLevel(wight, height, this);
					page3.CreateDrawPage(this);
					break;
				default:
					break;
			}
		}
		//
		// Конструктор 3
		//
		public MainForm(int wight, int height, string level)
		{
			InitializeComponent();
			this.Size = new Size(600, 600);
			this.StartPosition = FormStartPosition.Manual;

			switch (MenuForm.NamePage)
			{
				case "PaintNewLevel":
					var page3 = new CreateNewLevel(wight, height, level, this);
					page3.CreateDrawPage(this);
					break;
				case "ChoiceNameLevel":
					var page4 = new CreateNewLevel(wight, height, level);
					page4.CreateChoiceNamePage(this);
					break;
				default:
					break;
			}
		}
		//
		// Кнопка назад
		//
		private void BtnBack_Click(object sender, EventArgs e)
		{
			switch (MenuForm.NamePage)
			{
				case "ShowAllLevels":
					CurrentPageShowLevels = 0;
					ApplicationManager.ShowForm(new MenuForm());
					break;
				case "GameOptions":
					ApplicationManager.ShowForm(new MenuForm());
					break;
				case "ChoiceSizeLevel":
					ApplicationManager.ShowForm(new MenuForm());
					break;
				case "PaintNewLevel":
					CreateNewLevel.LevelInString = null;
					MenuForm.NamePage = "ChoiceSizeLevel";
					ApplicationManager.ShowForm(new MainForm(CreateNewLevel.LevelWight, CreateNewLevel.LevelHeight));
					break;
				case "ChoiceNameLevel":
					MenuForm.NamePage = "PaintNewLevel";
					ApplicationManager.ShowForm(new MainForm(CreateNewLevel.LevelWight, CreateNewLevel.LevelHeight, CreateNewLevel.LevelInString));
					break;
				case"PlayInGame":
                    if (GameOptions.ShowAnswer)
                    {
						GameOptions.ShowAnswer = false;
                    }
					MenuForm.NamePage = "ShowAllLevels";
					PlayInGame.WrongClick = 0;
					ApplicationManager.ShowForm(new MainForm());
					break;
				default:
					break;
			}
		}
    }
}
