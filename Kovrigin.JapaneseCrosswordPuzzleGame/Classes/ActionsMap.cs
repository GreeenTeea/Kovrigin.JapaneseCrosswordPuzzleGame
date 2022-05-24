using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Kovrigin.JapaneseCrosswordPuzzleGame.Classes
{
	internal class ActionsMap
	{
		private static int _levelwight;

		private static int _levelheight;

		private static string _levelInString;

		private static char _whtitSpace;

		private static string[] _levelInChar;

		private List<Label> _allLabels = new List<Label>();

		private List<Label> _allDignits = new List<Label>();

		private List<string> _saveDigitValues = new List<string>();

		public static string LevelInString
		{
			get
			{
				_levelInString = _levelInChar[0];
				for (int i = 1; i < _levelInChar.Length; i++)
				{
					_levelInString = String.Concat(_levelInString, " " + _levelInChar[i]);
				}
				return _levelInString;
			}
			set
			{
				_levelInString = value;
			}
		}
		//
		// Конструктор 1
		//
		public ActionsMap(string levleInString)
		{
			_whtitSpace = ' ';
			_levelInChar = levleInString.Split(_whtitSpace);
			_levelwight = Convert.ToInt32(_levelInChar[0]);
			_levelheight = Convert.ToInt32(_levelInChar[1]);
		}
		//
		// Конструктор 2
		//
		public ActionsMap(int wight, int height)
		{
			_levelwight = wight;
			_levelheight = height;
			_whtitSpace = ' ';

			if(MenuForm.NamePage == "PaintNewLevel" && CreateNewLevel.LevelInString != null)
			{
				_levelInString = CreateNewLevel.LevelInString;
			}
			else
			{
				_levelInString = String.Format($"{wight} {height}");
				for (int numberLabel = 0; numberLabel < wight * height; numberLabel++)
				{
					_levelInString = String.Concat(_levelInString, " 1");
				}
			}
			_levelInChar = _levelInString.Split(_whtitSpace);
		}
		//
		// Создание игрового поля
		//
		public void CreateMap(Form form)
		{
			Label lbl;
			int levelWight, levelHeight;
			if (MenuForm.NamePage == "PlayInGame")
			{
				levelWight = _levelwight + Check();
				levelHeight = _levelheight + Check();
			}
			else
			{
				levelWight = _levelwight;
				levelHeight = _levelheight;
			}

			for (int numberLabel = 0; numberLabel < _levelheight * _levelwight; numberLabel++)
			{
				lbl = new Label();
				if (levelHeight > levelWight)
				{
					lbl.Size = new Size((form.Width - 150) / levelHeight, (form.Height - 150) / levelHeight);
					lbl.Location = new Point(50 + lbl.Width * (CheckX() + (_levelheight - _levelwight) / 2) + lbl.Width * (numberLabel % _levelwight), 50 + lbl.Height * CheckY() + lbl.Height * (numberLabel / _levelwight));
				}
				else
				{
					lbl.Size = new Size((form.Width - 150) / levelWight, (form.Height - 150) / levelWight);
					lbl.Location = new Point(50 + lbl.Width * CheckX() + lbl.Width * (numberLabel % _levelwight), 50 + lbl.Height * (CheckY() + (_levelwight - _levelheight) / 2) + lbl.Height * (numberLabel / _levelwight));
				}
				lbl.BorderStyle = BorderStyle.FixedSingle;
				if (_levelInChar[numberLabel + 2] == "0")
				{
					if (MenuForm.NamePage == "PlayInGame" && !GameOptions.ShowAnswer)
					{
						lbl.BackColor = Color.White;
					}
					else
					{
						lbl.BackColor = Color.Black;
					}
				}
				else
				{
					lbl.BackColor = Color.White;
				}
				lbl.Name = (numberLabel + 2).ToString();
				lbl.MouseDown += Lbl_MouseDown;

				_allLabels.Add(lbl);
				form.Controls.Add(lbl);
			}
		}
		//
		// Клик по клетке на игровом поле
		//
		private void Lbl_MouseDown(object sender, MouseEventArgs e)
		{
			Label lbl = (Label)sender;

			if (MenuForm.NamePage == "PaintNewLevel")
			{
				if (e.Button == MouseButtons.Left)
				{
					lbl.BackColor = Color.Black;
					_levelInChar[int.Parse(lbl.Name)] = "0";
				}
				else
				{
					lbl.BackColor = Color.White;
					_levelInChar[int.Parse(lbl.Name)] = "1";
				}
			}
			else
			{
				switch (PlayInGame.CurrentColor)
				{
					case 0:
						lbl.Image = null;
						lbl.BackColor = Color.Black;
						_levelInChar[int.Parse(lbl.Name)] = "0";
						CheckDignits(lbl);
						break;
					case 1:
						lbl.Image = null;
						lbl.BackColor = Color.White;
						_levelInChar[int.Parse(lbl.Name)] = "1";
						CheckDignits(lbl);
						break;
					case 2:
						lbl.BackColor = Color.Transparent;
						lbl.Image = Properties.Resources.question1;
						_levelInChar[int.Parse(lbl.Name)] = "2";
						break;
					default:
						break;
				}
			}
		}
		//
		// Проверка чисел, чтобы автоматически их отмечать
		//
		private void CheckDignits(Label lbl)
		{
			if (GameOptions.AdditionalHelpSetting)
			{
				if (lbl.BackColor == Color.Black)
				{
					foreach (var item in _allDignits)
					{
						if (item.Name.Contains("_" + lbl.Name + "_"))
						{
							item.Name = item.Name.Replace("_" + lbl.Name + "_", "");
						}
						if (item.Name == String.Empty)
						{
							item.ForeColor = Color.FromArgb(116, 180, 232);
						}
					}
				}
				else if (lbl.BackColor == Color.White)
				{
					foreach(var item in _saveDigitValues)
					{
						if (item.Contains("_" + lbl.Name + "_"))
						{
							_allDignits[_saveDigitValues.IndexOf(item)].Name += "_" + lbl.Name + "_";
							_allDignits[_saveDigitValues.IndexOf(item)].ForeColor = Color.LemonChiffon;
						}
					}
				}
			}
		}
		//
		// Очищение игрового поля
		//
		public void RestatrMap()
		{
			for (int numberLabel = 0; numberLabel < _levelwight * _levelheight; numberLabel++)
			{
				if (_levelInChar[numberLabel + 2].Equals("0") || _levelInChar[numberLabel + 2].Equals("2"))
				{
					_levelInChar[numberLabel + 2] = "1";
					_allLabels[numberLabel].Image = null;
					_allLabels[numberLabel].BackColor = Color.White;
				}
			}

			foreach(var item in _allDignits)
			{
				if(item.ForeColor == Color.FromArgb(116, 180, 232))
				{
					item.ForeColor = Color.LemonChiffon;
				}
			}

			if (GameOptions.AdditionalHelpSetting)
			{
				foreach(var item in _saveDigitValues)
				{
					_allDignits[_saveDigitValues.IndexOf(item)].Name = item;
				}
			}

			if (GameOptions.LifeLimitSetting)
			{
				for (int i = 0; i < 3; i++)
				{
					PlayInGame.allPicHeart[i].Image = Properties.Resources.heart;
				}
			}

		}
		//
		// Создание чисел на поле
		//
		public void CreateDignits(Form form)
		{
			int counterBlackLbl = 0, counterDignit = 0;
			string dignitName = "";
			Label dignit;
			float sizeDignit = _allLabels[0].Width/2;

			for (int counterHeight = 1; counterHeight < _levelheight + 1; counterHeight++) 
			{
				for (int counterWight = 1; counterWight < _levelwight + 1; counterWight++)
				{
					if (_levelInChar[_levelwight * counterHeight - counterWight + 2] == "0")
					{
						counterBlackLbl++;
						dignitName = String.Concat(dignitName, "_" + (_levelwight * counterHeight - counterWight + 2) + "_");
					}

					if ((_levelInChar[_levelwight * counterHeight - counterWight + 2] == "1" && counterBlackLbl != 0) || (counterWight == _levelwight && counterBlackLbl != 0)) 
					{
						counterDignit++;

						dignit = new Label();
						dignit.Size = _allLabels[0].Size;
						dignit.Font = new Font("Yu Gothic", sizeDignit, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
						dignit.ForeColor = Color.LemonChiffon;
						dignit.Text = counterBlackLbl.ToString();
						if (GameOptions.AdditionalHelpSetting)
						{
							dignit.Name = dignitName;
						}
						dignit.Location = new Point(_allLabels[(counterHeight - 1) * _levelwight].Location.X - dignit.Width * counterDignit, _allLabels[(counterHeight - 1) * _levelwight].Location.Y);
						dignit.Click += Dignit_Click;

						_allDignits.Add(dignit);
						form.Controls.Add(dignit);
						_saveDigitValues.Add(dignitName);

						dignitName = "";
						counterBlackLbl = 0;
					}
				}
				counterDignit = 0;
			}

			for (int counterWight = 0; counterWight < _levelwight; counterWight++)
			{
				for (int counterHeight = 1; counterHeight < _levelheight + 1; counterHeight++)
				{
					if (_levelInChar[(_levelheight- counterHeight)*_levelwight + counterWight + 2] == "0")
					{
						counterBlackLbl++;
						dignitName = String.Concat(dignitName, "_" + ((_levelheight - counterHeight) * _levelwight + counterWight + 2)+ "_");
					}
					if ((_levelInChar[(_levelheight - counterHeight) * _levelwight + counterWight + 2] == "1" && counterBlackLbl != 0) || (counterHeight == _levelheight && counterBlackLbl != 0))
					{
						counterDignit++;

						dignit = new Label();
						dignit.Size = _allLabels[0].Size;
						dignit.Font = new Font("Yu Gothic", sizeDignit, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
						dignit.ForeColor = Color.LemonChiffon;
						dignit.Text = counterBlackLbl.ToString();
						if (GameOptions.AdditionalHelpSetting)
						{
							dignit.Name = dignitName;
						}
						dignit.Location = new Point(_allLabels[counterWight].Location.X, _allLabels[counterWight].Location.Y - dignit.Height * counterDignit);
						dignit.Click += Dignit_Click1;

						_allDignits.Add(dignit);
						form.Controls.Add(dignit);
						_saveDigitValues.Add(dignitName);

						dignitName = "";
						counterBlackLbl = 0;
					}
				}
				counterDignit = 0;
			}

			if (MenuForm.NamePage == "PlayInGame" && !GameOptions.ShowAnswer)
			{
				for (int i = 2; i < _levelInChar.Length; i++)
				{
					_levelInChar[i] = "1";
				}
			}
		}
		//
		// Клик по горизонатльным цифрам около поля
		//
		private void Dignit_Click1(object sender, EventArgs e)
		{
			Label lbl = (Label)sender;
			if (!GameOptions.AdditionalHelpSetting)
			{
				if(lbl.ForeColor == Color.LemonChiffon)
				{
					lbl.ForeColor = Color.FromArgb(116, 180, 232);
				}
				else
				{
					lbl.ForeColor = Color.LemonChiffon;
				}
			}
		}
		//
		// Клик по вертикальным цифрам около поля
		//
		private void Dignit_Click(object sender, EventArgs e)
		{
			Label lbl = (Label)sender;
			if (!GameOptions.AdditionalHelpSetting)
			{
				if (lbl.ForeColor == Color.LemonChiffon)
				{
					lbl.ForeColor = Color.FromArgb(116, 180, 232);
				}
				else
				{
					lbl.ForeColor = Color.LemonChiffon;
				}
			}
		}
		//
		// Проверка на максимальное количесто вспомогательных цифр по горизонатли или по вертикали
		//
		private int Check()
		{
			int counterBlackLbl = 0, counterDignit = 0, max = 0;

			for (int counterHeight = 1; counterHeight < _levelheight + 1; counterHeight++)
			{
				for (int counterWight = 1; counterWight < _levelwight + 1; counterWight++)
				{
					if (_levelInChar[_levelwight * counterHeight - counterWight + 2] == "0")
					{
						counterBlackLbl++;
					}
					if ((_levelInChar[_levelwight * counterHeight - counterWight + 2] == "1" && counterBlackLbl != 0) || (counterWight == _levelwight && counterBlackLbl != 0))
					{
						counterDignit++;
						counterBlackLbl = 0;
					}
				}
				if (max < counterDignit)
				{
					max = counterDignit;
				}
				counterDignit = 0;
			}

			for (int counterWight = 0; counterWight < _levelwight; counterWight++)
			{
				for (int counterHeight = 1; counterHeight < _levelheight + 1; counterHeight++)
				{
					if (_levelInChar[(_levelheight - counterHeight) * _levelwight + counterWight + 2] == "0")
					{
						counterBlackLbl++;
					}
					if ((_levelInChar[(_levelheight - counterHeight) * _levelwight + counterWight + 2] == "1" && counterBlackLbl != 0) || (counterHeight == _levelheight && counterBlackLbl != 0))
					{
						counterDignit++;
						counterBlackLbl = 0;
					}
				}
				if(max < counterDignit)
				{
					max = counterDignit;
				}
				counterDignit = 0;
			}
			return max;
		}
		//
		// Проверка на максимальное число вспомогательных цифра по горизонали
		//
		private int CheckX()
		{
			if(MenuForm.NamePage == "PaintNewLevel")
			{
				return 0;
			}

			int counterBlackLbl = 0, counterDignit = 0, max = 0;

			for (int counterHeight = 1; counterHeight < _levelheight + 1; counterHeight++)
			{
				for (int counterWight = 1; counterWight < _levelwight + 1; counterWight++)
				{
					if (_levelInChar[_levelwight * counterHeight - counterWight + 2] == "0")
					{
						counterBlackLbl++;
					}
					if ((_levelInChar[_levelwight * counterHeight - counterWight + 2] == "1" && counterBlackLbl != 0) || (counterWight == _levelwight && counterBlackLbl != 0))
					{
						counterDignit++;
						counterBlackLbl = 0;
					}
				}
				if (max < counterDignit)
				{
					max = counterDignit;
				}
				counterDignit = 0;
			}
			return max;
		}
		//
		// Проверка на максимальное число вспомогательных цифра по вертикали
		//
		private int CheckY()
		{
			if (MenuForm.NamePage == "PaintNewLevel")
			{
				return 0;
			}

			int counterBlackLbl = 0, counterDignit = 0, max = 0;

			for (int counterWight = 0; counterWight < _levelwight; counterWight++)
			{
				for (int counterHeight = 1; counterHeight < _levelheight + 1; counterHeight++)
				{
					if (_levelInChar[(_levelheight - counterHeight) * _levelwight + counterWight + 2] == "0")
					{
						counterBlackLbl++;
					}
					if ((_levelInChar[(_levelheight - counterHeight) * _levelwight + counterWight + 2] == "1" && counterBlackLbl != 0) || (counterHeight == _levelheight && counterBlackLbl != 0))
					{
						counterDignit++;
						counterBlackLbl = 0;
					}
				}
				if (max < counterDignit)
				{
					max = counterDignit;
				}
				counterDignit = 0;
			}
			return max;
		}
	}
}
