using System;
using System.IO;
using System.Windows.Forms;

namespace ChineseCheckers.Forms
{
    public partial class StatisticsForm : Form
    {
        public StatisticsForm()
        {
            InitializeComponent();
            infoLabel.Text = "Statistics are intended to record the results of simulations (matches between computer players only).\nMatches of human players won't be recorded there.";
            LoadStatistics();
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            new MenuForm().Show();
            Hide();
        }

        private void LoadStatistics()
        {
            string[] lines = File.ReadAllLines(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Statistics.txt");

            string difficultiesText = "";
            for (int i = 0; i < lines.Length; i++)
            {
                string winningPlayer = "";
                string[] splitSemicolon = lines[i].Split(';');
                switch (int.Parse(splitSemicolon[0]))
                {
                    case 2:
                        difficultiesText = "Red: " + GetDifficulty(int.Parse(splitSemicolon[3])) + ", blue: " + GetDifficulty(int.Parse(splitSemicolon[4]));
                        winningPlayer = GetColor(int.Parse(splitSemicolon[5]), int.Parse(splitSemicolon[2]));
                        break;
                    case 3:
                        difficultiesText = "Green: " + GetDifficulty(int.Parse(splitSemicolon[3])) + ", yellow: " + GetDifficulty(int.Parse(splitSemicolon[4])) + ", blue: " + GetDifficulty(int.Parse(splitSemicolon[5]));
                        winningPlayer = GetColor(int.Parse(splitSemicolon[6]), int.Parse(splitSemicolon[2]));
                        break;
                    case 4:
                        difficultiesText = "Green: " + GetDifficulty(int.Parse(splitSemicolon[3])) + ", yellow: " + GetDifficulty(int.Parse(splitSemicolon[4])) + ", purple: " + GetDifficulty(int.Parse(splitSemicolon[5])) + ", brown: " + GetDifficulty(int.Parse(splitSemicolon[6]));
                        winningPlayer = GetColor(int.Parse(splitSemicolon[7]), int.Parse(splitSemicolon[2]));
                        break;
                    case 6:
                        difficultiesText = "Red: " + GetDifficulty(int.Parse(splitSemicolon[3])) + ", green: " + GetDifficulty(int.Parse(splitSemicolon[4])) + ", yellow: " + GetDifficulty(int.Parse(splitSemicolon[5])) + ", purple: " + GetDifficulty(int.Parse(splitSemicolon[6])) + ", brown: " + GetDifficulty(int.Parse(splitSemicolon[7])) + ", blue: " + GetDifficulty(int.Parse(splitSemicolon[8]));
                        winningPlayer = GetColor(int.Parse(splitSemicolon[9]), int.Parse(splitSemicolon[2]));
                        break;
                }
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = splitSemicolon[0];
                dataGridView1.Rows[i].Cells[1].Value = splitSemicolon[1];
                dataGridView1.Rows[i].Cells[2].Value = difficultiesText;
                dataGridView1.Rows[i].Cells[3].Value = winningPlayer;
            }
        }

        private string GetColor(int playerId, int defaultWin)
        {
            string resultText;
            switch (playerId)
            {
                case 1:
                    resultText = "Blue";
                    break;
                case 2:
                    resultText = "Red";
                    break;
                case 3:
                    resultText = "Green";
                    break;
                case 4:
                    resultText = "Yellow";
                    break;
                case 5:
                    resultText = "Purple";
                    break;
                case 6:
                    resultText = "Brown";
                    break;
                case 7:
                    resultText = "Blue";
                    break;
                default:
                    resultText = "Error";
                    break;
            }
            if (defaultWin == 1)
            {
                resultText += " (default win)";
            }
            return resultText;
        }

        private string GetDifficulty(int id)
        {
            switch (id)
            {
                case 1:
                    return "easy";
                case 2:
                    return "medium";
                case 3:
                    return "hard";
            }
            return "Error";
        }
    }
}
