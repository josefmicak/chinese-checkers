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
    public partial class SimulatorParametersForm : Form
    {
        public SimulatorParametersForm()
        {
            InitializeComponent();
            AmountOfPlayers();
        }

        private void beginSimulationButton_Click(object sender, EventArgs e)
        {
            int[] difficulties = new int[] { difficulty1TB.Value, difficulty2TB.Value, difficulty3TB.Value, difficulty4TB.Value, difficulty5TB.Value, difficulty6TB.Value };
            int amountOfPlayers;
            if (twoPlayersRB.Checked)
            {
                amountOfPlayers = 2;
            }
            else if (threePlayersRB.Checked)
            {
                amountOfPlayers = 3;
            }
            else if (fourPlayersRB.Checked)
            {
                amountOfPlayers = 4;
            }
            else
            {
                amountOfPlayers = 6;
            }
            new GameForm(amountOfPlayers, 1, 1, true, difficulties, false, 1).Show();
            Close();
        }

        private void twoPlayersRB_CheckedChanged(object sender, EventArgs e)
        {
            AmountOfPlayers();
        }

        private void threePlayersRB_CheckedChanged(object sender, EventArgs e)
        {
            AmountOfPlayers();
        }

        private void fourPlayersRB_CheckedChanged(object sender, EventArgs e)
        {
            AmountOfPlayers();
        }

        private void sixPlayersRB_CheckedChanged(object sender, EventArgs e)
        {
            AmountOfPlayers();
        }

        private void AmountOfPlayers()
        {
            foreach (Control C in this.Controls)
            {
                if (C.GetType() == typeof(TrackBar))
                {
                    C.Enabled = false;
                }
            }
            if (twoPlayersRB.Checked)
            {
                illustrationPB.Image = ChineseCheckers.Properties.Resources._2Players;
                difficulty1TB.Enabled = true;
                difficulty6TB.Enabled = true;
            }
            else if (threePlayersRB.Checked)
            {
                illustrationPB.Image = ChineseCheckers.Properties.Resources._3Players;
                difficulty2TB.Enabled = true;
                difficulty3TB.Enabled = true;
                difficulty6TB.Enabled = true;
            }
            else if (fourPlayersRB.Checked)
            {
                illustrationPB.Image = ChineseCheckers.Properties.Resources._4Players_Simulator;
                difficulty2TB.Enabled = true;
                difficulty3TB.Enabled = true;
                difficulty4TB.Enabled = true;
                difficulty5TB.Enabled = true;
            }
            else
            {
                illustrationPB.Image = ChineseCheckers.Properties.Resources._6Players;
                foreach (Control C in this.Controls)
                {
                    if (C.GetType() == typeof(TrackBar))
                    {
                        C.Enabled = true;
                    }
                }
            }
        }

        private void beginCollectiveSimulationButton_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(amountOfSimulationsTB.Text, out _))
            {
                MessageBox.Show("Error - the amount of simulations has been entered with an incorrect format ", "Incorrect amount of simulations", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                collectiveSimulationLabel.Text = "The simulations are being executed. This may take a while.";
                collectiveSimulationLabel.Visible = true;
                this.Refresh();
                int[] difficulties = new int[] { difficulty1TB.Value, difficulty2TB.Value, difficulty3TB.Value, difficulty4TB.Value, difficulty5TB.Value, difficulty6TB.Value };
                int amountOfPlayers;
                if (twoPlayersRB.Checked)
                {
                    amountOfPlayers = 2;
                }
                else if (threePlayersRB.Checked)
                {
                    amountOfPlayers = 3;
                }
                else if (fourPlayersRB.Checked)
                {
                    amountOfPlayers = 4;
                }
                else
                {
                    amountOfPlayers = 6;
                }
                new GameForm(amountOfPlayers, 1, 1, true, difficulties, true, int.Parse(amountOfSimulationsTB.Text));
                Close();
            }
        }
    }
}
