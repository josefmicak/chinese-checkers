using System;
using System.Drawing;
using System.Windows.Forms;

namespace ChineseCheckers.Forms
{
    public partial class MenuForm : Form
    {
        private Pen pen = new Pen(Color.Black, 5);
        public MenuForm()
        {
            InitializeComponent();
        }

        private void menuPicturePB_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(pen, 0, 0, menuPicturePB.Width - 1, menuPicturePB.Height - 1);
        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
            new GameParametersForm().Show();
            Hide();
        }

        private void simulatorButton_Click(object sender, EventArgs e)
        {
            new SimulatorParametersForm().Show();
            Hide();
        }

        private void statisticsButton_Click(object sender, EventArgs e)
        {
            new StatisticsForm().Show();
            Hide();
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            new InformationForm().Show();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new GameParametersForm().Show();
            Hide();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new InformationForm().Show();
        }
    }
}
