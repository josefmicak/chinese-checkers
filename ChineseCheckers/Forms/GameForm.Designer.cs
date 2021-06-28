
namespace ChineseCheckers.Forms
{
    partial class GameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.returnToMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseunpauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.endMoveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.soundsOnoffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consolePanel = new System.Windows.Forms.Panel();
            this.controlPanel = new System.Windows.Forms.Panel();
            this.beginSimulationButton = new System.Windows.Forms.Button();
            this.soundPB = new System.Windows.Forms.PictureBox();
            this.endMovePB = new System.Windows.Forms.PictureBox();
            this.endPB = new System.Windows.Forms.PictureBox();
            this.restartPB = new System.Windows.Forms.PictureBox();
            this.pausePB = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.gamePanel = new ChineseCheckers.Forms.DoubleBufferedPanel();
            this.timeLabel = new System.Windows.Forms.Label();
            this.moveAmountLabel = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.controlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.soundPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endMovePB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.restartPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pausePB)).BeginInit();
            this.gamePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.gameToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(884, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.restartGameToolStripMenuItem,
            this.returnToMenuToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.newGameToolStripMenuItem.Text = "New game";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // restartGameToolStripMenuItem
            // 
            this.restartGameToolStripMenuItem.Name = "restartGameToolStripMenuItem";
            this.restartGameToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.restartGameToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.restartGameToolStripMenuItem.Text = "Restart game";
            this.restartGameToolStripMenuItem.Click += new System.EventHandler(this.restartGameToolStripMenuItem_Click);
            // 
            // returnToMenuToolStripMenuItem
            // 
            this.returnToMenuToolStripMenuItem.Name = "returnToMenuToolStripMenuItem";
            this.returnToMenuToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.returnToMenuToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.returnToMenuToolStripMenuItem.Text = "Return to menu";
            this.returnToMenuToolStripMenuItem.Click += new System.EventHandler(this.returnToMenuToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(199, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pauseunpauseToolStripMenuItem,
            this.endMoveToolStripMenuItem,
            this.soundsOnoffToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // pauseunpauseToolStripMenuItem
            // 
            this.pauseunpauseToolStripMenuItem.Name = "pauseunpauseToolStripMenuItem";
            this.pauseunpauseToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.pauseunpauseToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.pauseunpauseToolStripMenuItem.Text = "Pause/unpause";
            this.pauseunpauseToolStripMenuItem.Click += new System.EventHandler(this.pauseunpauseToolStripMenuItem_Click);
            // 
            // endMoveToolStripMenuItem
            // 
            this.endMoveToolStripMenuItem.Name = "endMoveToolStripMenuItem";
            this.endMoveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.endMoveToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.endMoveToolStripMenuItem.Text = "End move";
            this.endMoveToolStripMenuItem.Click += new System.EventHandler(this.endMoveToolStripMenuItem_Click);
            // 
            // soundsOnoffToolStripMenuItem
            // 
            this.soundsOnoffToolStripMenuItem.Name = "soundsOnoffToolStripMenuItem";
            this.soundsOnoffToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.soundsOnoffToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.soundsOnoffToolStripMenuItem.Text = "Sounds on/off";
            this.soundsOnoffToolStripMenuItem.Click += new System.EventHandler(this.soundsOnoffToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // consolePanel
            // 
            this.consolePanel.BackColor = System.Drawing.Color.White;
            this.consolePanel.Location = new System.Drawing.Point(143, 39);
            this.consolePanel.Name = "consolePanel";
            this.consolePanel.Size = new System.Drawing.Size(600, 55);
            this.consolePanel.TabIndex = 1;
            this.consolePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.consolePanel_Paint);
            // 
            // controlPanel
            // 
            this.controlPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.controlPanel.Controls.Add(this.beginSimulationButton);
            this.controlPanel.Controls.Add(this.soundPB);
            this.controlPanel.Controls.Add(this.endMovePB);
            this.controlPanel.Controls.Add(this.endPB);
            this.controlPanel.Controls.Add(this.restartPB);
            this.controlPanel.Controls.Add(this.pausePB);
            this.controlPanel.Location = new System.Drawing.Point(225, 839);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(443, 86);
            this.controlPanel.TabIndex = 3;
            // 
            // beginSimulationButton
            // 
            this.beginSimulationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.beginSimulationButton.Location = new System.Drawing.Point(128, 20);
            this.beginSimulationButton.Name = "beginSimulationButton";
            this.beginSimulationButton.Size = new System.Drawing.Size(194, 44);
            this.beginSimulationButton.TabIndex = 5;
            this.beginSimulationButton.Text = "Begin simulation";
            this.beginSimulationButton.UseVisualStyleBackColor = true;
            this.beginSimulationButton.Visible = false;
            this.beginSimulationButton.Click += new System.EventHandler(this.beginSimulationButton_Click);
            // 
            // soundPB
            // 
            this.soundPB.Image = global::ChineseCheckers.Properties.Resources.soundOn;
            this.soundPB.Location = new System.Drawing.Point(355, 7);
            this.soundPB.Name = "soundPB";
            this.soundPB.Size = new System.Drawing.Size(82, 72);
            this.soundPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.soundPB.TabIndex = 4;
            this.soundPB.TabStop = false;
            this.soundPB.Click += new System.EventHandler(this.soundPB_Click);
            // 
            // endMovePB
            // 
            this.endMovePB.Image = global::ChineseCheckers.Properties.Resources.endMoveDisabled;
            this.endMovePB.Location = new System.Drawing.Point(267, 7);
            this.endMovePB.Name = "endMovePB";
            this.endMovePB.Size = new System.Drawing.Size(82, 72);
            this.endMovePB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.endMovePB.TabIndex = 3;
            this.endMovePB.TabStop = false;
            this.endMovePB.EnabledChanged += new System.EventHandler(this.endMovePB_EnabledChanged);
            this.endMovePB.Click += new System.EventHandler(this.endMovePB_Click);
            // 
            // endPB
            // 
            this.endPB.Image = global::ChineseCheckers.Properties.Resources.end;
            this.endPB.Location = new System.Drawing.Point(179, 7);
            this.endPB.Name = "endPB";
            this.endPB.Size = new System.Drawing.Size(82, 72);
            this.endPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.endPB.TabIndex = 2;
            this.endPB.TabStop = false;
            this.endPB.Click += new System.EventHandler(this.endPB_Click);
            // 
            // restartPB
            // 
            this.restartPB.Image = global::ChineseCheckers.Properties.Resources.restart;
            this.restartPB.Location = new System.Drawing.Point(91, 7);
            this.restartPB.Name = "restartPB";
            this.restartPB.Size = new System.Drawing.Size(82, 72);
            this.restartPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.restartPB.TabIndex = 1;
            this.restartPB.TabStop = false;
            this.restartPB.Click += new System.EventHandler(this.restartPB_Click);
            // 
            // pausePB
            // 
            this.pausePB.Image = global::ChineseCheckers.Properties.Resources.pause;
            this.pausePB.Location = new System.Drawing.Point(3, 7);
            this.pausePB.Name = "pausePB";
            this.pausePB.Size = new System.Drawing.Size(82, 72);
            this.pausePB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pausePB.TabIndex = 0;
            this.pausePB.TabStop = false;
            this.pausePB.Click += new System.EventHandler(this.pausePB_Click);
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // gamePanel
            // 
            this.gamePanel.BackColor = System.Drawing.Color.Gainsboro;
            this.gamePanel.Controls.Add(this.timeLabel);
            this.gamePanel.Controls.Add(this.moveAmountLabel);
            this.gamePanel.Location = new System.Drawing.Point(143, 115);
            this.gamePanel.Name = "gamePanel";
            this.gamePanel.Size = new System.Drawing.Size(600, 702);
            this.gamePanel.TabIndex = 4;
            this.gamePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.gamePanel_Paint);
            this.gamePanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gamePanel_MouseClick);
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.timeLabel.Location = new System.Drawing.Point(517, 16);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(71, 25);
            this.timeLabel.TabIndex = 1;
            this.timeLabel.Text = "00:00";
            // 
            // moveAmountLabel
            // 
            this.moveAmountLabel.AutoSize = true;
            this.moveAmountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.moveAmountLabel.Location = new System.Drawing.Point(12, 16);
            this.moveAmountLabel.Name = "moveAmountLabel";
            this.moveAmountLabel.Size = new System.Drawing.Size(108, 25);
            this.moveAmountLabel.TabIndex = 0;
            this.moveAmountLabel.Text = "Moves: 0";
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(884, 960);
            this.Controls.Add(this.gamePanel);
            this.Controls.Add(this.controlPanel);
            this.Controls.Add(this.consolePanel);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "GameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chinese Checkers - Game";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameForm_Paint);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.controlPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.soundPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endMovePB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.restartPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pausePB)).EndInit();
            this.gamePanel.ResumeLayout(false);
            this.gamePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Panel consolePanel;
        private System.Windows.Forms.Panel controlPanel;
        private System.Windows.Forms.PictureBox soundPB;
        private System.Windows.Forms.PictureBox endMovePB;
        private System.Windows.Forms.PictureBox endPB;
        private System.Windows.Forms.PictureBox restartPB;
        private System.Windows.Forms.PictureBox pausePB;
        private System.Windows.Forms.Button beginSimulationButton;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem returnToMenuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem pauseunpauseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem endMoveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem soundsOnoffToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private DoubleBufferedPanel gamePanel;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Label moveAmountLabel;
    }
}