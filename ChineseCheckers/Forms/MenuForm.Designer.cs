
namespace ChineseCheckers.Forms
{
    partial class MenuForm
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
            this.menuPicturePB = new System.Windows.Forms.PictureBox();
            this.newGameButton = new System.Windows.Forms.Button();
            this.simulatorButton = new System.Windows.Forms.Button();
            this.statisticsButton = new System.Windows.Forms.Button();
            this.aboutButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.menuPicturePB)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuPicturePB
            // 
            this.menuPicturePB.Image = global::ChineseCheckers.Properties.Resources.MenuPicture;
            this.menuPicturePB.Location = new System.Drawing.Point(227, 37);
            this.menuPicturePB.Name = "menuPicturePB";
            this.menuPicturePB.Size = new System.Drawing.Size(344, 316);
            this.menuPicturePB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.menuPicturePB.TabIndex = 0;
            this.menuPicturePB.TabStop = false;
            this.menuPicturePB.Paint += new System.Windows.Forms.PaintEventHandler(this.menuPicturePB_Paint);
            // 
            // newGameButton
            // 
            this.newGameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.newGameButton.Location = new System.Drawing.Point(340, 375);
            this.newGameButton.Name = "newGameButton";
            this.newGameButton.Size = new System.Drawing.Size(121, 38);
            this.newGameButton.TabIndex = 1;
            this.newGameButton.Text = "New game";
            this.newGameButton.UseVisualStyleBackColor = true;
            this.newGameButton.Click += new System.EventHandler(this.newGameButton_Click);
            // 
            // simulatorButton
            // 
            this.simulatorButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.simulatorButton.Location = new System.Drawing.Point(340, 425);
            this.simulatorButton.Name = "simulatorButton";
            this.simulatorButton.Size = new System.Drawing.Size(121, 38);
            this.simulatorButton.TabIndex = 2;
            this.simulatorButton.Text = "Simulator";
            this.simulatorButton.UseVisualStyleBackColor = true;
            this.simulatorButton.Click += new System.EventHandler(this.simulatorButton_Click);
            // 
            // statisticsButton
            // 
            this.statisticsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.statisticsButton.Location = new System.Drawing.Point(340, 475);
            this.statisticsButton.Name = "statisticsButton";
            this.statisticsButton.Size = new System.Drawing.Size(121, 38);
            this.statisticsButton.TabIndex = 3;
            this.statisticsButton.Text = "Statistics";
            this.statisticsButton.UseVisualStyleBackColor = true;
            this.statisticsButton.Click += new System.EventHandler(this.statisticsButton_Click);
            // 
            // aboutButton
            // 
            this.aboutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.aboutButton.Location = new System.Drawing.Point(340, 525);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(121, 38);
            this.aboutButton.TabIndex = 4;
            this.aboutButton.Text = "About";
            this.aboutButton.UseVisualStyleBackColor = true;
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.exitButton.Location = new System.Drawing.Point(340, 575);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(121, 38);
            this.exitButton.TabIndex = 5;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newGameToolStripMenuItem.Text = "New game";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 617);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.aboutButton);
            this.Controls.Add(this.statisticsButton);
            this.Controls.Add(this.simulatorButton);
            this.Controls.Add(this.newGameButton);
            this.Controls.Add(this.menuPicturePB);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chinese Checkers - Menu";
            ((System.ComponentModel.ISupportInitialize)(this.menuPicturePB)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox menuPicturePB;
        private System.Windows.Forms.Button newGameButton;
        private System.Windows.Forms.Button simulatorButton;
        private System.Windows.Forms.Button statisticsButton;
        private System.Windows.Forms.Button aboutButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}