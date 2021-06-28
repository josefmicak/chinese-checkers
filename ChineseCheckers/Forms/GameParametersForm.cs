using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChineseCheckers.Forms
{
    public partial class GameParametersForm : Form
    {
        private int firstMove = 0;
        private int playersAmount = 0;
        private Pen pen = new Pen(Color.Black, 5);
        public GameParametersForm()
        {
            InitializeComponent();
        }

        private void playerFirstPanel_Click(object sender, EventArgs e)
        {
            firstMove = 1;
            playerFirstPanel.BackColor = Color.Cyan;
            computerFirstPanel.BackColor = Color.White;
            chooseRandomlyPanel.BackColor = Color.White;
        }

        private void computerFirstPanel_Click(object sender, EventArgs e)
        {
            firstMove = 2;
            playerFirstPanel.BackColor = Color.White;
            computerFirstPanel.BackColor = Color.Cyan;
            chooseRandomlyPanel.BackColor = Color.White;
        }

        private void chooseRandomlyPanel_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            firstMove = random.Next(1, 3);
            playerFirstPanel.BackColor = Color.White;
            computerFirstPanel.BackColor = Color.White;
            chooseRandomlyPanel.BackColor = Color.Cyan;
        }

        private void playerFirstLabel_Click(object sender, EventArgs e)
        {
            playerFirstPanel_Click(playerFirstPanel, EventArgs.Empty);
        }

        private void computerFirstLabel_Click(object sender, EventArgs e)
        {
            computerFirstPanel_Click(computerFirstPanel, EventArgs.Empty);
        }

        private void chooseRandomlyLabel_Click(object sender, EventArgs e)
        {
            chooseRandomlyPanel_Click(chooseRandomlyPanel, EventArgs.Empty);
        }

        private void twoPlayersPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(pen, 0, 0, twoPlayersPanel.Width - 1, twoPlayersPanel.Height - 1);
        }

        private void threePlayersPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(pen, 0, 0, threePlayersPanel.Width - 1, threePlayersPanel.Height - 1);
        }

        private void fourPlayersPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(pen, 0, 0, fourPlayersPanel.Width - 1, fourPlayersPanel.Height - 1);
        }

        private void sixPlayersPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(pen, 0, 0, sixPlayersPanel.Width - 1, sixPlayersPanel.Height - 1);
        }

        private void twoPlayersPanel_Click(object sender, EventArgs e)
        {
            playersAmount = 2;
            twoPlayersPanel.BackColor = Color.Cyan;
            threePlayersPanel.BackColor = Color.White;
            fourPlayersPanel.BackColor = Color.White;
            sixPlayersPanel.BackColor = Color.White;
        }

        private void twoPlayersPB_Click(object sender, EventArgs e)
        {
            twoPlayersPanel_Click(twoPlayersPanel, EventArgs.Empty);
        }

        private void twoPlayersLabel_Click(object sender, EventArgs e)
        {
            twoPlayersPanel_Click(twoPlayersPanel, EventArgs.Empty);
        }

        private void threePlayersPanel_Click(object sender, EventArgs e)
        {
            playersAmount = 3;
            twoPlayersPanel.BackColor = Color.White;
            threePlayersPanel.BackColor = Color.Cyan;
            fourPlayersPanel.BackColor = Color.White;
            sixPlayersPanel.BackColor = Color.White;
        }

        private void threePlayersPB_Click(object sender, EventArgs e)
        {
            threePlayersPanel_Click(threePlayersPanel, EventArgs.Empty);
        }

        private void threePlayersLabel_Click(object sender, EventArgs e)
        {
            threePlayersPanel_Click(threePlayersPanel, EventArgs.Empty);
        }

        private void fourPlayersPanel_Click(object sender, EventArgs e)
        {
            playersAmount = 4;
            twoPlayersPanel.BackColor = Color.White;
            threePlayersPanel.BackColor = Color.White;
            fourPlayersPanel.BackColor = Color.Cyan;
            sixPlayersPanel.BackColor = Color.White;
        }

        private void fourPlayersPB_Click(object sender, EventArgs e)
        {
            fourPlayersPanel_Click(fourPlayersPanel, EventArgs.Empty);
        }

        private void fourPlayersLabel_Click(object sender, EventArgs e)
        {
            fourPlayersPanel_Click(fourPlayersPanel, EventArgs.Empty);
        }

        private void sixPlayersPanel_Click(object sender, EventArgs e)
        {
            playersAmount = 6;
            twoPlayersPanel.BackColor = Color.White;
            threePlayersPanel.BackColor = Color.White;
            fourPlayersPanel.BackColor = Color.White;
            sixPlayersPanel.BackColor = Color.Cyan;
        }

        private void sixPlayersPB_Click(object sender, EventArgs e)
        {
            sixPlayersPanel_Click(sixPlayersPanel, EventArgs.Empty);
        }

        private void sixPlayersLabel_Click(object sender, EventArgs e)
        {
            sixPlayersPanel_Click(sixPlayersPanel, EventArgs.Empty);
        }

        private void beginGameButton_Click(object sender, EventArgs e)
        {
            if (playersAmount == 0 || firstMove == 0)
            {
                MessageBox.Show("You either haven't chosen the amount of players of the first player to move\nPlease select game parameters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int[] difficulties = new int[] { 0, 0 };
                new GameForm(playersAmount, firstMove, difficultyTB.Value, false, difficulties, false, 0).Show();
                Close();
            }
        }

        private void playerFirstPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(pen, 0, 0, playerFirstPanel.Width - 1, playerFirstPanel.Height - 1);
        }

        private void computerFirstPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(pen, 0, 0, computerFirstPanel.Width - 1, computerFirstPanel.Height - 1);
        }

        private void chooseRandomlyPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(pen, 0, 0, chooseRandomlyPanel.Width - 1, chooseRandomlyPanel.Height - 1);
        }
    }
}
