using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChineseCheckers.Game_control;
using ChineseCheckers.Game_entities;
using System.Windows.Forms;
using System.Media;

namespace ChineseCheckers.Forms
{
    public partial class GameForm : Form
    {
        private int playersAmount;//amount of players including the human player
        private int firstMove;
        private int difficulty;
        private bool simulationMode;
        private int[] simulationDifficulty = new int[2];
        private bool collectiveSimulation;
        private int amountOfSimulations;
        private static int consoleMessage = 2;
        private static int winningComputerPlayer;
        private bool defaultWin;
        private static int moveCalculation;
        private int seconds = 0, minutes = 0;

        private static bool playSounds = true;

        private static Game game;

        private void GameForm_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Black, 5);
            e.Graphics.DrawRectangle(pen, consolePanel.Location.X - 4, consolePanel.Location.Y - 4, consolePanel.Width + 7, consolePanel.Height + 7);
            e.Graphics.DrawRectangle(pen, gamePanel.Location.X - 4, gamePanel.Location.Y - 4, gamePanel.Width + 7, gamePanel.Height + 7);
            e.Graphics.DrawRectangle(pen, controlPanel.Location.X - 4, controlPanel.Location.Y - 4, controlPanel.Width + 7, controlPanel.Height + 7);
        }

        public GameForm(int playersAmount, int firstMove, int difficulty, bool simulationMode, int[] simulationDifficulty, bool collectiveSimulation, int amountOfSimulations)
        {
            this.playersAmount = playersAmount;
            this.firstMove = firstMove;
            this.difficulty = difficulty;
            this.simulationMode = simulationMode;
            this.simulationDifficulty = simulationDifficulty;
            this.collectiveSimulation = collectiveSimulation;
            this.amountOfSimulations = amountOfSimulations;
            if(!collectiveSimulation)
            {
                game = new Game(playersAmount, firstMove, difficulty, simulationMode, simulationDifficulty);
            }

            InitializeComponent();

            if (collectiveSimulation)
            {
                for (int i = 0; i < amountOfSimulations; i++)
                {
                    game = new Game(playersAmount, firstMove, difficulty, true, simulationDifficulty);
                    game.NewGame(gamePanel.Width, this);
                    for (int j = 0; ; j++)
                    {
                        game.ComputerPlayerMove(this);
                        if (consoleMessage == 7)
                        {
                            consoleMessage = 2;
                            break;
                        }
                    }
                }
                MessageBox.Show("The collective simulation has been successfully executed.", "Collective simulation executed", MessageBoxButtons.OK);
                new MenuForm().Show();
                Close();
            }

            if (simulationMode)
            {
                pausePB.Visible = false;
                restartPB.Visible = false;
                endPB.Visible = false;
                endMovePB.Visible = false;
                soundPB.Visible = false;
                timeLabel.Visible = false;
                beginSimulationButton.Visible = true;
            }
            if (!collectiveSimulation)
            {
                game.NewGame(gamePanel.Width, this);
            }
            if (consoleMessage == 7)
            {
                consoleMessage = 2;
            }
        }

        private void DrawCoordinates(PaintEventArgs e, List<Field> gameFields)
        {
            int posX, posY, xc, yc;
            Font drawFont = new Font("Arial", 8);
            SolidBrush br2 = new SolidBrush(Color.Black);
            for (int i = 0; i < gameFields.Count; i++)
            {
                Field field = (Field)gameFields[i];
                posX = field.Get_pos_X_F();
                posY = field.Get_pos_Y_F();
                xc = posX + (35 / 2);
                yc = posY + (35 / 2);

                e.Graphics.DrawString(posX.ToString(), drawFont, br2, (float)posX + 7, (float)posY + 5);
                e.Graphics.DrawString(posY.ToString(), drawFont, br2, (float)posX + 7, (float)posY + 15);

            //            e.Graphics.DrawString(xc.ToString(), drawFont, br2, (float)posX + 7, (float)posY + 5);
              //        e.Graphics.DrawString(yc.ToString(), drawFont, br2, (float)posX + 7, (float)posY + 15);
            }
            drawFont.Dispose();
            br2.Dispose();
        }

        private void gamePanel_Paint(object sender, PaintEventArgs e)
        {
            moveAmountLabel.Text = "Moves: " + game.GetAmountOfMoves();

            (List<Field> gameFields, List<HumanPlayer> humanPlayerFields, List<ComputerPlayer> computerPlayerFields, List<PossibleMoveOfHumanPlayer> possibleMovesOfHumanPlayer, HighlightedFieldOfHumanPlayer highlightedFieldOfHumanPlayer, List<HighlightedFieldOfComputerPlayer> highlightedFieldsOfComputerPlayer, List<PreviousFieldOfComputerPlayer> previousFielsdOfComputerPlayer) = game.GameElements();

            foreach (Field f in gameFields)
            {
                f.DrawField(e);
            }

            for (int i = 0; i < previousFielsdOfComputerPlayer.Count; i++)
            {
                PreviousFieldOfComputerPlayer pfc = previousFielsdOfComputerPlayer[i];
                int computerPlayerId = pfc.Get_computerPlayerId();
                pfc.DrawPreviousFieldOfComputerPlayer(e, computerPlayerId);
            }

            foreach (HumanPlayer h in humanPlayerFields)
            {
                h.DrawHumanPlayer(e);
            }

            for (int i = 0; i < computerPlayerFields.Count; i++)
            {
                ComputerPlayer c = computerPlayerFields[i];
                int computerPlayerId = c.Get_computerPlayerId();
                c.DrawComputerPlayer(e, computerPlayerId);
            }

            foreach (PossibleMoveOfHumanPlayer pmh in possibleMovesOfHumanPlayer)
            {
                pmh.DrawPossibleMoveOfHumanPlayer(e);
            }

            if (highlightedFieldOfHumanPlayer != null)
            {
                highlightedFieldOfHumanPlayer.DrawHighlightedFieldOfHumanPlayer(e);
            }

            foreach (HighlightedFieldOfComputerPlayer hfc in highlightedFieldsOfComputerPlayer)
            {
                hfc.DrawHighlightedFieldOfComputerPlayer(e);
            }

            //DrawCoordinates(e, gameFields); //not intended for the user, this function is intended for the purposes of developing and is not included in the final version of the game
        }

        private void gamePanel_MouseClick(object sender, MouseEventArgs e)
        {
            timer.Enabled = true;
            consolePanel.Refresh();
            game.PanelClick(e.X, e.Y, this);
            ConsoleRefresh(moveCalculation);
            gamePanel.Refresh();
            consolePanel.Refresh();
        }

        public void ConsoleRefresh(int mc)
        {
            moveCalculation = mc;
            (consoleMessage, winningComputerPlayer, defaultWin) = game.GetConsoleMessage();
            consolePanel.Refresh();
        }

        private void pausePB_Click(object sender, EventArgs e)
        {
            timer.Enabled = !timer.Enabled;
            switch (consoleMessage)
            {
                case 0:
                    pausePB.Image = Properties.Resources.play;
                    gamePanel.MouseClick -= gamePanel_MouseClick;
                    consoleMessage = 3;
                    break;
                case 3:
                    pausePB.Image = Properties.Resources.pause;
                    gamePanel.MouseClick += gamePanel_MouseClick;
                    consoleMessage = 0;
                    break;
            }
            consolePanel.Refresh();
        }

        private void consolePanel_Paint(object sender, PaintEventArgs e)
        {
            Font drawFont = new Font("Arial", 16);
            SolidBrush brBlack = new SolidBrush(Color.Black);

            switch (consoleMessage)
            {
                case 1:
                    switch (moveCalculation)
                    {
                        case 2:
                            e.Graphics.DrawString("The red player's move is being calculated. ", drawFont, brBlack, 75, 15);
                            break;
                        case 3:
                            e.Graphics.DrawString("The green player's move is being calculated.", drawFont, brBlack, 75, 15);
                            break;
                        case 4:
                            e.Graphics.DrawString("The yellow player's move is being calculated.", drawFont, brBlack, 75, 15);
                            break;
                        case 5:
                            e.Graphics.DrawString("The purple player's move is being calculated.", drawFont, brBlack, 75, 15);
                            break;
                        case 6:
                            e.Graphics.DrawString("The brown player's move is being calculated.", drawFont, brBlack, 75, 15);
                            break;
                    }
                    break;
                case 2:
                    if (simulationMode)
                    {
                        e.Graphics.DrawString("You can launch the simulation by clicking the button.", drawFont, brBlack, 45, 15);
                    }
                    else
                    {
                        if (firstMove == 1)
                        {
                            e.Graphics.DrawString("Game created. The human player has the first move.", drawFont, brBlack, 40, 15);
                        }
                        else
                        {
                            e.Graphics.DrawString("Game created. The computer players have the first move.", drawFont, brBlack, 23, 15);
                        }
                    }
                    break;
                case 3:
                    e.Graphics.DrawString("Game is paused.", drawFont, brBlack, 220, 15);
                    break;
                case 4:
                    gamePanel.MouseClick -= gamePanel_MouseClick;
                    pausePB.Enabled = false;
                    timer.Enabled = false;
                    PlaySound(3);
                    if (!defaultWin)
                    {
                        e.Graphics.DrawString("Congratulations, you win.", drawFont, brBlack, 170, 15);
                    }
                    else
                    {
                        e.Graphics.DrawString("Congratulations, you win (a default win).", drawFont, brBlack, 105, 15);
                    }
                    break;
                case 5:
                    gamePanel.MouseClick -= gamePanel_MouseClick;
                    pausePB.Enabled = false;
                    timer.Enabled = false;
                    PlaySound(4);
                    switch (winningComputerPlayer)
                    {
                        case 2:
                            e.Graphics.DrawString("Unfortunately you lost. The winner is the red player.", drawFont, brBlack, 35, 15);
                            break;
                        case 3:
                            e.Graphics.DrawString("Unfortunately you lost. The winner is the green player.", drawFont, brBlack, 35, 15);
                            break;
                        case 4:
                            e.Graphics.DrawString("Unfortunately you lost. The winner is the yellow player.", drawFont, brBlack, 35, 15);
                            break;
                        case 5:
                            e.Graphics.DrawString("Unfortunately you lost. The winner is the purple player.", drawFont, brBlack, 35, 15);
                            break;
                        case 6:
                            e.Graphics.DrawString("Unfortunately you lost. The winner is the brown player.", drawFont, brBlack, 35, 15);
                            break;
                    }
                    break;
                case 6:
                    gamePanel.MouseClick -= gamePanel_MouseClick;
                    pausePB.Enabled = false;
                    timer.Enabled = false;
                    PlaySound(5);
                    e.Graphics.DrawString("The game ended in a draw.", drawFont, brBlack, 165, 15);
                    break;
                case 7:
                    gamePanel.Refresh();
                    string winningComputerPlayerText = "";
                    switch (winningComputerPlayer)
                    {
                        case 0:
                            winningComputerPlayerText = "blue";
                            break;
                        case 2:
                            winningComputerPlayerText = "red";
                            break;
                        case 3:
                            winningComputerPlayerText = "green";
                            break;
                        case 4:
                            winningComputerPlayerText = "yellow";
                            break;
                        case 5:
                            winningComputerPlayerText = "purple";
                            break;
                        case 6:
                            winningComputerPlayerText = "brown";
                            break;
                        case 7:
                            winningComputerPlayerText = "blue";
                            break;
                    }
                    string resultText = "The simulation has finished, the game has been won by the " + winningComputerPlayerText + " player";
                    if (defaultWin)
                    {
                        resultText += "\nThe player won by a default win.";
                    }
                    e.Graphics.DrawString("The simulation has finished, the winner is the " + winningComputerPlayerText + " player", drawFont, brBlack, 15, 15);
                    DialogResult result = MessageBox.Show(resultText, "Simulation finished", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        new MenuForm().Show();
                        Close();
                    }
                    break;
            }
        }

        private void restartPB_Click(object sender, EventArgs e)
        {
            int[] difficulties = new int[] { 0, 0 };
            if (consoleMessage < 4)
            {
                DialogResult result = MessageBox.Show("By creating a new game the old one will be lost. Continue?", "New game", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    new GameForm(playersAmount, firstMove, difficulty, false, difficulties, false, 0).Show();
                    Close();
                }
            }
            else
            {
                new GameForm(playersAmount, firstMove, difficulty, false, difficulties, false, 0).Show();
                Close();
            }
        }

        private void endPB_Click(object sender, EventArgs e)
        {
            if (consoleMessage < 3)
            {
                DialogResult result = MessageBox.Show("By ending the game and returning to the main menu the game will be lost. Continue?", "Close the application", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    new MenuForm().Show();
                    Close();
                }
            }
            else
            {
                new MenuForm().Show();
                Close();
            }
        }

        private void endMovePB_Click(object sender, EventArgs e)
        {
            game.EndMove(this);
            gamePanel.Refresh();
        }

        private void endMovePB_EnabledChanged(object sender, EventArgs e)
        {
            if (endMovePB.Enabled)
            {
                endMovePB.Image = Properties.Resources.endMoveEnabled;
            }
            else
            {
                endMovePB.Image = Properties.Resources.endMoveDisabled;
            }
        }

        private void soundPB_Click(object sender, EventArgs e)
        {
            if (playSounds)
            {
                playSounds = false;
                soundPB.Image = Properties.Resources.soundOff;
            }
            else
            {
                playSounds = true;
                soundPB.Image = Properties.Resources.soundOn;
            }
        }

        public static void PlaySound(int soundId)
        {
            if (playSounds)
            {
                switch (soundId)
                {
                    case 1:
                        SoundPlayer click = new SoundPlayer(Properties.Resources.click);
                        click.Play();
                        break;
                    case 2:
                        SoundPlayer hracPohyb = new SoundPlayer(Properties.Resources.playerMove);
                        hracPohyb.Play();
                        break;
                    case 3:
                        SoundPlayer vyhra = new SoundPlayer(Properties.Resources.win);
                        vyhra.Play();
                        break;
                    case 4:
                        SoundPlayer prohra = new SoundPlayer(Properties.Resources.lose);
                        prohra.Play();
                        break;
                    case 5:
                        SoundPlayer remiza = new SoundPlayer(Properties.Resources.draw);
                        remiza.Play();
                        break;
                }
            }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("By creating a new game the old one will be lost. Continue?", "New game", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                new GameParametersForm().Show();
                Close();
            }
        }

        private void restartGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            restartPB_Click(restartPB, null);
        }

        private void returnToMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            endPB_Click(endPB, null);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("By closing the application the game will be lost. Continue?", "Close the application", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
        }

        private void pauseunpauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pausePB_Click(pausePB, null);
        }

        private void endMoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (endMovePB.Enabled)
            {
                endMovePB_Click(endMovePB, null);
            }
        }

        private void soundsOnoffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            soundPB_Click(soundPB, null);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new InformationForm().Show();
        }

        private void beginSimulationButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; ; i++)
            {
                game.ComputerPlayerMove(this);
                gamePanel.Refresh();
                if (consoleMessage == 7)
                {
                    break;
                }
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            seconds++;
            if (seconds == 60)
            {
                minutes++;
                seconds = 0;
            }
            timeLabel.Text = minutes.ToString("D2") + ":" + seconds.ToString("D2");
        }

        public void EndMoveButton()
        {
            endMovePB.Enabled = !endMovePB.Enabled;
        }
    }
}
