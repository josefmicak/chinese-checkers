
namespace ChineseCheckers.Forms
{
    partial class GameParametersForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.sixPlayersPanel = new System.Windows.Forms.Panel();
            this.sixPlayersLabel = new System.Windows.Forms.Label();
            this.sixPlayersPB = new System.Windows.Forms.PictureBox();
            this.fourPlayersPanel = new System.Windows.Forms.Panel();
            this.fourPlayersLabel = new System.Windows.Forms.Label();
            this.fourPlayersPB = new System.Windows.Forms.PictureBox();
            this.threePlayersPanel = new System.Windows.Forms.Panel();
            this.threePlayersLabel = new System.Windows.Forms.Label();
            this.threePlayersPB = new System.Windows.Forms.PictureBox();
            this.twoPlayersPanel = new System.Windows.Forms.Panel();
            this.twoPlayersLabel = new System.Windows.Forms.Label();
            this.twoPlayersPB = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chooseRandomlyPanel = new System.Windows.Forms.Panel();
            this.chooseRandomlyLabel = new System.Windows.Forms.Label();
            this.computerFirstPanel = new System.Windows.Forms.Panel();
            this.computerFirstLabel = new System.Windows.Forms.Label();
            this.playerFirstPanel = new System.Windows.Forms.Panel();
            this.playerFirstLabel = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.difficultyTB = new System.Windows.Forms.TrackBar();
            this.beginGameButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.sixPlayersPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sixPlayersPB)).BeginInit();
            this.fourPlayersPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fourPlayersPB)).BeginInit();
            this.threePlayersPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.threePlayersPB)).BeginInit();
            this.twoPlayersPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.twoPlayersPB)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.chooseRandomlyPanel.SuspendLayout();
            this.computerFirstPanel.SuspendLayout();
            this.playerFirstPanel.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.difficultyTB)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.sixPlayersPanel);
            this.groupBox1.Controls.Add(this.fourPlayersPanel);
            this.groupBox1.Controls.Add(this.threePlayersPanel);
            this.groupBox1.Controls.Add(this.twoPlayersPanel);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 563);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Amount of players";
            // 
            // sixPlayersPanel
            // 
            this.sixPlayersPanel.BackColor = System.Drawing.Color.White;
            this.sixPlayersPanel.Controls.Add(this.sixPlayersLabel);
            this.sixPlayersPanel.Controls.Add(this.sixPlayersPB);
            this.sixPlayersPanel.Location = new System.Drawing.Point(209, 290);
            this.sixPlayersPanel.Name = "sixPlayersPanel";
            this.sixPlayersPanel.Size = new System.Drawing.Size(185, 254);
            this.sixPlayersPanel.TabIndex = 4;
            this.sixPlayersPanel.Click += new System.EventHandler(this.sixPlayersPanel_Click);
            this.sixPlayersPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.sixPlayersPanel_Paint);
            // 
            // sixPlayersLabel
            // 
            this.sixPlayersLabel.AutoSize = true;
            this.sixPlayersLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.sixPlayersLabel.Location = new System.Drawing.Point(47, 211);
            this.sixPlayersLabel.Name = "sixPlayersLabel";
            this.sixPlayersLabel.Size = new System.Drawing.Size(91, 25);
            this.sixPlayersLabel.TabIndex = 1;
            this.sixPlayersLabel.Text = "6 players";
            this.sixPlayersLabel.Click += new System.EventHandler(this.sixPlayersLabel_Click);
            // 
            // sixPlayersPB
            // 
            this.sixPlayersPB.Image = global::ChineseCheckers.Properties.Resources._6Players;
            this.sixPlayersPB.Location = new System.Drawing.Point(23, 13);
            this.sixPlayersPB.Name = "sixPlayersPB";
            this.sixPlayersPB.Size = new System.Drawing.Size(140, 185);
            this.sixPlayersPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.sixPlayersPB.TabIndex = 0;
            this.sixPlayersPB.TabStop = false;
            this.sixPlayersPB.Click += new System.EventHandler(this.sixPlayersPB_Click);
            // 
            // fourPlayersPanel
            // 
            this.fourPlayersPanel.BackColor = System.Drawing.Color.White;
            this.fourPlayersPanel.Controls.Add(this.fourPlayersLabel);
            this.fourPlayersPanel.Controls.Add(this.fourPlayersPB);
            this.fourPlayersPanel.Location = new System.Drawing.Point(6, 290);
            this.fourPlayersPanel.Name = "fourPlayersPanel";
            this.fourPlayersPanel.Size = new System.Drawing.Size(185, 254);
            this.fourPlayersPanel.TabIndex = 3;
            this.fourPlayersPanel.Click += new System.EventHandler(this.fourPlayersPanel_Click);
            this.fourPlayersPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.fourPlayersPanel_Paint);
            // 
            // fourPlayersLabel
            // 
            this.fourPlayersLabel.AutoSize = true;
            this.fourPlayersLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.fourPlayersLabel.Location = new System.Drawing.Point(47, 211);
            this.fourPlayersLabel.Name = "fourPlayersLabel";
            this.fourPlayersLabel.Size = new System.Drawing.Size(91, 25);
            this.fourPlayersLabel.TabIndex = 1;
            this.fourPlayersLabel.Text = "4 players";
            this.fourPlayersLabel.Click += new System.EventHandler(this.fourPlayersLabel_Click);
            // 
            // fourPlayersPB
            // 
            this.fourPlayersPB.Image = global::ChineseCheckers.Properties.Resources._4Players;
            this.fourPlayersPB.Location = new System.Drawing.Point(23, 13);
            this.fourPlayersPB.Name = "fourPlayersPB";
            this.fourPlayersPB.Size = new System.Drawing.Size(140, 185);
            this.fourPlayersPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.fourPlayersPB.TabIndex = 0;
            this.fourPlayersPB.TabStop = false;
            this.fourPlayersPB.Click += new System.EventHandler(this.fourPlayersPB_Click);
            // 
            // threePlayersPanel
            // 
            this.threePlayersPanel.BackColor = System.Drawing.Color.White;
            this.threePlayersPanel.Controls.Add(this.threePlayersLabel);
            this.threePlayersPanel.Controls.Add(this.threePlayersPB);
            this.threePlayersPanel.Location = new System.Drawing.Point(209, 19);
            this.threePlayersPanel.Name = "threePlayersPanel";
            this.threePlayersPanel.Size = new System.Drawing.Size(185, 254);
            this.threePlayersPanel.TabIndex = 2;
            this.threePlayersPanel.Click += new System.EventHandler(this.threePlayersPanel_Click);
            this.threePlayersPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.threePlayersPanel_Paint);
            // 
            // threePlayersLabel
            // 
            this.threePlayersLabel.AutoSize = true;
            this.threePlayersLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.threePlayersLabel.Location = new System.Drawing.Point(47, 211);
            this.threePlayersLabel.Name = "threePlayersLabel";
            this.threePlayersLabel.Size = new System.Drawing.Size(91, 25);
            this.threePlayersLabel.TabIndex = 1;
            this.threePlayersLabel.Text = "3 players";
            this.threePlayersLabel.Click += new System.EventHandler(this.threePlayersLabel_Click);
            // 
            // threePlayersPB
            // 
            this.threePlayersPB.Image = global::ChineseCheckers.Properties.Resources._3Players;
            this.threePlayersPB.Location = new System.Drawing.Point(23, 13);
            this.threePlayersPB.Name = "threePlayersPB";
            this.threePlayersPB.Size = new System.Drawing.Size(140, 185);
            this.threePlayersPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.threePlayersPB.TabIndex = 0;
            this.threePlayersPB.TabStop = false;
            this.threePlayersPB.Click += new System.EventHandler(this.threePlayersPB_Click);
            // 
            // twoPlayersPanel
            // 
            this.twoPlayersPanel.BackColor = System.Drawing.Color.White;
            this.twoPlayersPanel.Controls.Add(this.twoPlayersLabel);
            this.twoPlayersPanel.Controls.Add(this.twoPlayersPB);
            this.twoPlayersPanel.Location = new System.Drawing.Point(6, 19);
            this.twoPlayersPanel.Name = "twoPlayersPanel";
            this.twoPlayersPanel.Size = new System.Drawing.Size(185, 254);
            this.twoPlayersPanel.TabIndex = 0;
            this.twoPlayersPanel.Click += new System.EventHandler(this.twoPlayersPanel_Click);
            this.twoPlayersPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.twoPlayersPanel_Paint);
            // 
            // twoPlayersLabel
            // 
            this.twoPlayersLabel.AutoSize = true;
            this.twoPlayersLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.twoPlayersLabel.Location = new System.Drawing.Point(47, 211);
            this.twoPlayersLabel.Name = "twoPlayersLabel";
            this.twoPlayersLabel.Size = new System.Drawing.Size(91, 25);
            this.twoPlayersLabel.TabIndex = 1;
            this.twoPlayersLabel.Text = "2 players";
            this.twoPlayersLabel.Click += new System.EventHandler(this.twoPlayersLabel_Click);
            // 
            // twoPlayersPB
            // 
            this.twoPlayersPB.Image = global::ChineseCheckers.Properties.Resources._2Players;
            this.twoPlayersPB.Location = new System.Drawing.Point(23, 13);
            this.twoPlayersPB.Name = "twoPlayersPB";
            this.twoPlayersPB.Size = new System.Drawing.Size(140, 185);
            this.twoPlayersPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.twoPlayersPB.TabIndex = 0;
            this.twoPlayersPB.TabStop = false;
            this.twoPlayersPB.Click += new System.EventHandler(this.twoPlayersPB_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chooseRandomlyPanel);
            this.groupBox2.Controls.Add(this.computerFirstPanel);
            this.groupBox2.Controls.Add(this.playerFirstPanel);
            this.groupBox2.Location = new System.Drawing.Point(418, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(353, 351);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "First move";
            // 
            // chooseRandomlyPanel
            // 
            this.chooseRandomlyPanel.BackColor = System.Drawing.Color.White;
            this.chooseRandomlyPanel.Controls.Add(this.chooseRandomlyLabel);
            this.chooseRandomlyPanel.Location = new System.Drawing.Point(47, 248);
            this.chooseRandomlyPanel.Name = "chooseRandomlyPanel";
            this.chooseRandomlyPanel.Size = new System.Drawing.Size(249, 50);
            this.chooseRandomlyPanel.TabIndex = 4;
            this.chooseRandomlyPanel.Click += new System.EventHandler(this.chooseRandomlyPanel_Click);
            this.chooseRandomlyPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.chooseRandomlyPanel_Paint);
            // 
            // chooseRandomlyLabel
            // 
            this.chooseRandomlyLabel.AutoSize = true;
            this.chooseRandomlyLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.chooseRandomlyLabel.Location = new System.Drawing.Point(42, 11);
            this.chooseRandomlyLabel.Name = "chooseRandomlyLabel";
            this.chooseRandomlyLabel.Size = new System.Drawing.Size(168, 25);
            this.chooseRandomlyLabel.TabIndex = 2;
            this.chooseRandomlyLabel.Text = "Choose randomly";
            this.chooseRandomlyLabel.Click += new System.EventHandler(this.chooseRandomlyLabel_Click);
            // 
            // computerFirstPanel
            // 
            this.computerFirstPanel.BackColor = System.Drawing.Color.White;
            this.computerFirstPanel.Controls.Add(this.computerFirstLabel);
            this.computerFirstPanel.Location = new System.Drawing.Point(47, 152);
            this.computerFirstPanel.Name = "computerFirstPanel";
            this.computerFirstPanel.Size = new System.Drawing.Size(249, 50);
            this.computerFirstPanel.TabIndex = 3;
            this.computerFirstPanel.Click += new System.EventHandler(this.computerFirstPanel_Click);
            this.computerFirstPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.computerFirstPanel_Paint);
            // 
            // computerFirstLabel
            // 
            this.computerFirstLabel.AutoSize = true;
            this.computerFirstLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.computerFirstLabel.Location = new System.Drawing.Point(5, 12);
            this.computerFirstLabel.Name = "computerFirstLabel";
            this.computerFirstLabel.Size = new System.Drawing.Size(238, 25);
            this.computerFirstLabel.TabIndex = 2;
            this.computerFirstLabel.Text = "The computer moves first";
            this.computerFirstLabel.Click += new System.EventHandler(this.computerFirstLabel_Click);
            // 
            // playerFirstPanel
            // 
            this.playerFirstPanel.BackColor = System.Drawing.Color.White;
            this.playerFirstPanel.Controls.Add(this.playerFirstLabel);
            this.playerFirstPanel.Location = new System.Drawing.Point(47, 53);
            this.playerFirstPanel.Name = "playerFirstPanel";
            this.playerFirstPanel.Size = new System.Drawing.Size(249, 50);
            this.playerFirstPanel.TabIndex = 0;
            this.playerFirstPanel.Click += new System.EventHandler(this.playerFirstPanel_Click);
            this.playerFirstPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.playerFirstPanel_Paint);
            // 
            // playerFirstLabel
            // 
            this.playerFirstLabel.AutoSize = true;
            this.playerFirstLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.playerFirstLabel.Location = new System.Drawing.Point(20, 12);
            this.playerFirstLabel.Name = "playerFirstLabel";
            this.playerFirstLabel.Size = new System.Drawing.Size(206, 25);
            this.playerFirstLabel.TabIndex = 2;
            this.playerFirstLabel.Text = "The player moves first";
            this.playerFirstLabel.Click += new System.EventHandler(this.playerFirstLabel_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.difficultyTB);
            this.groupBox3.Location = new System.Drawing.Point(418, 370);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(353, 205);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Difficulty";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(232, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Hard";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(136, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Medium";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Easy";
            // 
            // difficultyTB
            // 
            this.difficultyTB.Location = new System.Drawing.Point(60, 85);
            this.difficultyTB.Maximum = 3;
            this.difficultyTB.Minimum = 1;
            this.difficultyTB.Name = "difficultyTB";
            this.difficultyTB.Size = new System.Drawing.Size(205, 45);
            this.difficultyTB.TabIndex = 0;
            this.difficultyTB.Value = 3;
            // 
            // beginGameButton
            // 
            this.beginGameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.beginGameButton.Location = new System.Drawing.Point(345, 594);
            this.beginGameButton.Name = "beginGameButton";
            this.beginGameButton.Size = new System.Drawing.Size(134, 38);
            this.beginGameButton.TabIndex = 3;
            this.beginGameButton.Text = "Begin game";
            this.beginGameButton.UseVisualStyleBackColor = true;
            this.beginGameButton.Click += new System.EventHandler(this.beginGameButton_Click);
            // 
            // GameParametersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 644);
            this.Controls.Add(this.beginGameButton);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "GameParametersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chinese Checkers - Set parameters of the game";
            this.groupBox1.ResumeLayout(false);
            this.sixPlayersPanel.ResumeLayout(false);
            this.sixPlayersPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sixPlayersPB)).EndInit();
            this.fourPlayersPanel.ResumeLayout(false);
            this.fourPlayersPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fourPlayersPB)).EndInit();
            this.threePlayersPanel.ResumeLayout(false);
            this.threePlayersPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.threePlayersPB)).EndInit();
            this.twoPlayersPanel.ResumeLayout(false);
            this.twoPlayersPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.twoPlayersPB)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.chooseRandomlyPanel.ResumeLayout(false);
            this.chooseRandomlyPanel.PerformLayout();
            this.computerFirstPanel.ResumeLayout(false);
            this.computerFirstPanel.PerformLayout();
            this.playerFirstPanel.ResumeLayout(false);
            this.playerFirstPanel.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.difficultyTB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel sixPlayersPanel;
        private System.Windows.Forms.Label sixPlayersLabel;
        private System.Windows.Forms.PictureBox sixPlayersPB;
        private System.Windows.Forms.Panel fourPlayersPanel;
        private System.Windows.Forms.Label fourPlayersLabel;
        private System.Windows.Forms.PictureBox fourPlayersPB;
        private System.Windows.Forms.Panel threePlayersPanel;
        private System.Windows.Forms.Label threePlayersLabel;
        private System.Windows.Forms.PictureBox threePlayersPB;
        private System.Windows.Forms.Panel twoPlayersPanel;
        private System.Windows.Forms.Label twoPlayersLabel;
        private System.Windows.Forms.PictureBox twoPlayersPB;
        private System.Windows.Forms.Panel chooseRandomlyPanel;
        private System.Windows.Forms.Label chooseRandomlyLabel;
        private System.Windows.Forms.Panel computerFirstPanel;
        private System.Windows.Forms.Label computerFirstLabel;
        private System.Windows.Forms.Panel playerFirstPanel;
        private System.Windows.Forms.Label playerFirstLabel;
        private System.Windows.Forms.TrackBar difficultyTB;
        private System.Windows.Forms.Button beginGameButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}