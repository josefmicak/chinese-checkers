
namespace ChineseCheckers.Forms
{
    partial class SimulatorParametersForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.sixPlayersRB = new System.Windows.Forms.RadioButton();
            this.fourPlayersRB = new System.Windows.Forms.RadioButton();
            this.threePlayersRB = new System.Windows.Forms.RadioButton();
            this.twoPlayersRB = new System.Windows.Forms.RadioButton();
            this.illustrationPB = new System.Windows.Forms.PictureBox();
            this.difficulty1TB = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.difficulty2TB = new System.Windows.Forms.TrackBar();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.difficulty3TB = new System.Windows.Forms.TrackBar();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.difficulty4TB = new System.Windows.Forms.TrackBar();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.difficulty5TB = new System.Windows.Forms.TrackBar();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.difficulty6TB = new System.Windows.Forms.TrackBar();
            this.label20 = new System.Windows.Forms.Label();
            this.amountOfSimulationsTB = new System.Windows.Forms.TextBox();
            this.beginSimulationButton = new System.Windows.Forms.Button();
            this.beginCollectiveSimulationButton = new System.Windows.Forms.Button();
            this.collectiveSimulationLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.illustrationPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.difficulty1TB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.difficulty2TB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.difficulty3TB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.difficulty4TB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.difficulty5TB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.difficulty6TB)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(432, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select the difficulties of the computer players:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.sixPlayersRB);
            this.groupBox1.Controls.Add(this.fourPlayersRB);
            this.groupBox1.Controls.Add(this.threePlayersRB);
            this.groupBox1.Controls.Add(this.twoPlayersRB);
            this.groupBox1.Location = new System.Drawing.Point(43, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(242, 253);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Amout of players";
            // 
            // sixPlayersRB
            // 
            this.sixPlayersRB.AutoSize = true;
            this.sixPlayersRB.Location = new System.Drawing.Point(21, 165);
            this.sixPlayersRB.Name = "sixPlayersRB";
            this.sixPlayersRB.Size = new System.Drawing.Size(80, 19);
            this.sixPlayersRB.TabIndex = 3;
            this.sixPlayersRB.Text = "Six players";
            this.sixPlayersRB.UseVisualStyleBackColor = true;
            this.sixPlayersRB.CheckedChanged += new System.EventHandler(this.sixPlayersRB_CheckedChanged);
            // 
            // fourPlayersRB
            // 
            this.fourPlayersRB.AutoSize = true;
            this.fourPlayersRB.Location = new System.Drawing.Point(21, 124);
            this.fourPlayersRB.Name = "fourPlayersRB";
            this.fourPlayersRB.Size = new System.Drawing.Size(89, 19);
            this.fourPlayersRB.TabIndex = 2;
            this.fourPlayersRB.Text = "Four players";
            this.fourPlayersRB.UseVisualStyleBackColor = true;
            this.fourPlayersRB.CheckedChanged += new System.EventHandler(this.fourPlayersRB_CheckedChanged);
            // 
            // threePlayersRB
            // 
            this.threePlayersRB.AutoSize = true;
            this.threePlayersRB.Location = new System.Drawing.Point(21, 82);
            this.threePlayersRB.Name = "threePlayersRB";
            this.threePlayersRB.Size = new System.Drawing.Size(94, 19);
            this.threePlayersRB.TabIndex = 1;
            this.threePlayersRB.Text = "Three players";
            this.threePlayersRB.UseVisualStyleBackColor = true;
            this.threePlayersRB.CheckedChanged += new System.EventHandler(this.threePlayersRB_CheckedChanged);
            // 
            // twoPlayersRB
            // 
            this.twoPlayersRB.AutoSize = true;
            this.twoPlayersRB.Checked = true;
            this.twoPlayersRB.Location = new System.Drawing.Point(21, 44);
            this.twoPlayersRB.Name = "twoPlayersRB";
            this.twoPlayersRB.Size = new System.Drawing.Size(86, 19);
            this.twoPlayersRB.TabIndex = 0;
            this.twoPlayersRB.TabStop = true;
            this.twoPlayersRB.Text = "Two players";
            this.twoPlayersRB.UseVisualStyleBackColor = true;
            this.twoPlayersRB.CheckedChanged += new System.EventHandler(this.twoPlayersRB_CheckedChanged);
            // 
            // illustrationPB
            // 
            this.illustrationPB.Image = global::ChineseCheckers.Properties.Resources._2Players;
            this.illustrationPB.Location = new System.Drawing.Point(536, 112);
            this.illustrationPB.Name = "illustrationPB";
            this.illustrationPB.Size = new System.Drawing.Size(205, 258);
            this.illustrationPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.illustrationPB.TabIndex = 2;
            this.illustrationPB.TabStop = false;
            // 
            // difficulty1TB
            // 
            this.difficulty1TB.Location = new System.Drawing.Point(536, 52);
            this.difficulty1TB.Maximum = 3;
            this.difficulty1TB.Minimum = 1;
            this.difficulty1TB.Name = "difficulty1TB";
            this.difficulty1TB.Size = new System.Drawing.Size(205, 45);
            this.difficulty1TB.TabIndex = 3;
            this.difficulty1TB.Value = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(533, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Easy";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(613, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Medium";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(706, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Hard";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(486, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Hard";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(393, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 15);
            this.label6.TabIndex = 9;
            this.label6.Text = "Medium";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(313, 187);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 15);
            this.label7.TabIndex = 8;
            this.label7.Text = "Easy";
            // 
            // difficulty2TB
            // 
            this.difficulty2TB.Location = new System.Drawing.Point(316, 155);
            this.difficulty2TB.Maximum = 3;
            this.difficulty2TB.Minimum = 1;
            this.difficulty2TB.Name = "difficulty2TB";
            this.difficulty2TB.Size = new System.Drawing.Size(205, 45);
            this.difficulty2TB.TabIndex = 7;
            this.difficulty2TB.Value = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(928, 187);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 15);
            this.label8.TabIndex = 14;
            this.label8.Text = "Hard";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(835, 187);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 15);
            this.label9.TabIndex = 13;
            this.label9.Text = "Medium";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(755, 187);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 15);
            this.label10.TabIndex = 12;
            this.label10.Text = "Easy";
            // 
            // difficulty3TB
            // 
            this.difficulty3TB.Location = new System.Drawing.Point(758, 155);
            this.difficulty3TB.Maximum = 3;
            this.difficulty3TB.Minimum = 1;
            this.difficulty3TB.Name = "difficulty3TB";
            this.difficulty3TB.Size = new System.Drawing.Size(205, 45);
            this.difficulty3TB.TabIndex = 11;
            this.difficulty3TB.Value = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(486, 313);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 15);
            this.label11.TabIndex = 18;
            this.label11.Text = "Hard";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(393, 313);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 15);
            this.label12.TabIndex = 17;
            this.label12.Text = "Medium";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(313, 313);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(30, 15);
            this.label13.TabIndex = 16;
            this.label13.Text = "Easy";
            // 
            // difficulty4TB
            // 
            this.difficulty4TB.Location = new System.Drawing.Point(316, 281);
            this.difficulty4TB.Maximum = 3;
            this.difficulty4TB.Minimum = 1;
            this.difficulty4TB.Name = "difficulty4TB";
            this.difficulty4TB.Size = new System.Drawing.Size(205, 45);
            this.difficulty4TB.TabIndex = 15;
            this.difficulty4TB.Value = 2;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(928, 313);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(33, 15);
            this.label14.TabIndex = 22;
            this.label14.Text = "Hard";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(835, 313);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(52, 15);
            this.label15.TabIndex = 21;
            this.label15.Text = "Medium";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(755, 313);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(30, 15);
            this.label16.TabIndex = 20;
            this.label16.Text = "Easy";
            // 
            // difficulty5TB
            // 
            this.difficulty5TB.Location = new System.Drawing.Point(758, 281);
            this.difficulty5TB.Maximum = 3;
            this.difficulty5TB.Minimum = 1;
            this.difficulty5TB.Name = "difficulty5TB";
            this.difficulty5TB.Size = new System.Drawing.Size(205, 45);
            this.difficulty5TB.TabIndex = 19;
            this.difficulty5TB.Value = 2;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(706, 419);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(33, 15);
            this.label17.TabIndex = 26;
            this.label17.Text = "Hard";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(616, 419);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(52, 15);
            this.label18.TabIndex = 25;
            this.label18.Text = "Medium";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(533, 419);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(30, 15);
            this.label19.TabIndex = 24;
            this.label19.Text = "Easy";
            // 
            // difficulty6TB
            // 
            this.difficulty6TB.Location = new System.Drawing.Point(536, 387);
            this.difficulty6TB.Maximum = 3;
            this.difficulty6TB.Minimum = 1;
            this.difficulty6TB.Name = "difficulty6TB";
            this.difficulty6TB.Size = new System.Drawing.Size(205, 45);
            this.difficulty6TB.TabIndex = 23;
            this.difficulty6TB.Value = 2;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(659, 483);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(132, 15);
            this.label20.TabIndex = 27;
            this.label20.Text = "Amount of simulations:";
            // 
            // amountOfSimulationsTB
            // 
            this.amountOfSimulationsTB.Location = new System.Drawing.Point(798, 480);
            this.amountOfSimulationsTB.Name = "amountOfSimulationsTB";
            this.amountOfSimulationsTB.Size = new System.Drawing.Size(70, 23);
            this.amountOfSimulationsTB.TabIndex = 28;
            // 
            // beginSimulationButton
            // 
            this.beginSimulationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.beginSimulationButton.Location = new System.Drawing.Point(417, 530);
            this.beginSimulationButton.Name = "beginSimulationButton";
            this.beginSimulationButton.Size = new System.Drawing.Size(166, 60);
            this.beginSimulationButton.TabIndex = 29;
            this.beginSimulationButton.Text = "Execute one simulation";
            this.beginSimulationButton.UseVisualStyleBackColor = true;
            this.beginSimulationButton.Click += new System.EventHandler(this.beginSimulationButton_Click);
            // 
            // beginCollectiveSimulationButton
            // 
            this.beginCollectiveSimulationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.beginCollectiveSimulationButton.Location = new System.Drawing.Point(659, 530);
            this.beginCollectiveSimulationButton.Name = "beginCollectiveSimulationButton";
            this.beginCollectiveSimulationButton.Size = new System.Drawing.Size(190, 60);
            this.beginCollectiveSimulationButton.TabIndex = 30;
            this.beginCollectiveSimulationButton.Text = "Begin collective simulation";
            this.beginCollectiveSimulationButton.UseVisualStyleBackColor = true;
            this.beginCollectiveSimulationButton.Click += new System.EventHandler(this.beginCollectiveSimulationButton_Click);
            // 
            // collectiveSimulationLabel
            // 
            this.collectiveSimulationLabel.AutoSize = true;
            this.collectiveSimulationLabel.Location = new System.Drawing.Point(659, 603);
            this.collectiveSimulationLabel.Name = "collectiveSimulationLabel";
            this.collectiveSimulationLabel.Size = new System.Drawing.Size(28, 15);
            this.collectiveSimulationLabel.TabIndex = 31;
            this.collectiveSimulationLabel.Text = "Info";
            // 
            // SimulatorParametersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 630);
            this.Controls.Add(this.collectiveSimulationLabel);
            this.Controls.Add(this.beginCollectiveSimulationButton);
            this.Controls.Add(this.beginSimulationButton);
            this.Controls.Add(this.amountOfSimulationsTB);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.difficulty6TB);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.difficulty5TB);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.difficulty4TB);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.difficulty3TB);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.difficulty2TB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.difficulty1TB);
            this.Controls.Add(this.illustrationPB);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SimulatorParametersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chinese Checkers - Select the parameters of the simulator";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.illustrationPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.difficulty1TB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.difficulty2TB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.difficulty3TB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.difficulty4TB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.difficulty5TB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.difficulty6TB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton sixPlayersRB;
        private System.Windows.Forms.RadioButton fourPlayersRB;
        private System.Windows.Forms.RadioButton threePlayersRB;
        private System.Windows.Forms.RadioButton twoPlayersRB;
        private System.Windows.Forms.PictureBox illustrationPB;
        private System.Windows.Forms.TrackBar difficulty1TB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TrackBar difficulty2TB;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TrackBar difficulty3TB;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TrackBar difficulty4TB;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TrackBar difficulty5TB;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TrackBar difficulty6TB;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox amountOfSimulationsTB;
        private System.Windows.Forms.Button beginSimulationButton;
        private System.Windows.Forms.Button beginCollectiveSimulationButton;
        private System.Windows.Forms.Label collectiveSimulationLabel;
    }
}