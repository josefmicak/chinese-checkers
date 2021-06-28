
namespace ChineseCheckers.Forms
{
    partial class StatisticsForm
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
            this.infoLabel = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuButton = new System.Windows.Forms.Button();
            this.amountOfPlayers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountOfMoves = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.difficulties = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.winner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.infoLabel.Location = new System.Drawing.Point(20, 28);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(39, 20);
            this.infoLabel.TabIndex = 0;
            this.infoLabel.Text = "text";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.amountOfPlayers,
            this.amountOfMoves,
            this.difficulties,
            this.winner});
            this.dataGridView1.Location = new System.Drawing.Point(24, 78);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(1037, 650);
            this.dataGridView1.TabIndex = 0;
            // 
            // menuButton
            // 
            this.menuButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.menuButton.Location = new System.Drawing.Point(480, 757);
            this.menuButton.Name = "menuButton";
            this.menuButton.Size = new System.Drawing.Size(172, 61);
            this.menuButton.TabIndex = 2;
            this.menuButton.Text = "Return to menu";
            this.menuButton.UseVisualStyleBackColor = true;
            this.menuButton.Click += new System.EventHandler(this.menuButton_Click);
            // 
            // amountOfPlayers
            // 
            this.amountOfPlayers.HeaderText = "Amout of players";
            this.amountOfPlayers.Name = "amountOfPlayers";
            this.amountOfPlayers.ReadOnly = true;
            this.amountOfPlayers.Width = 130;
            // 
            // amountOfMoves
            // 
            this.amountOfMoves.FillWeight = 130F;
            this.amountOfMoves.HeaderText = "Amount of moves";
            this.amountOfMoves.Name = "amountOfMoves";
            this.amountOfMoves.ReadOnly = true;
            this.amountOfMoves.Width = 130;
            // 
            // difficulties
            // 
            this.difficulties.HeaderText = "Difficulties";
            this.difficulties.Name = "difficulties";
            this.difficulties.ReadOnly = true;
            this.difficulties.Width = 560;
            // 
            // winner
            // 
            this.winner.HeaderText = "Winner";
            this.winner.Name = "winner";
            this.winner.ReadOnly = true;
            this.winner.Width = 150;
            // 
            // StatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 861);
            this.Controls.Add(this.menuButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.infoLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "StatisticsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chinese Checkers - Statistics";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button menuButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountOfPlayers;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountOfMoves;
        private System.Windows.Forms.DataGridViewTextBoxColumn difficulties;
        private System.Windows.Forms.DataGridViewTextBoxColumn winner;
    }
}