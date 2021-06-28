
namespace ChineseCheckers.Forms
{
    partial class InformationForm
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
            this.rulesGB = new System.Windows.Forms.GroupBox();
            this.rulesTB = new System.Windows.Forms.TextBox();
            this.controlGB = new System.Windows.Forms.GroupBox();
            this.controlTB = new System.Windows.Forms.TextBox();
            this.aboutGB = new System.Windows.Forms.GroupBox();
            this.aboutTB = new System.Windows.Forms.TextBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.rulesGB.SuspendLayout();
            this.controlGB.SuspendLayout();
            this.aboutGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // rulesGB
            // 
            this.rulesGB.Controls.Add(this.rulesTB);
            this.rulesGB.Location = new System.Drawing.Point(12, 13);
            this.rulesGB.Name = "rulesGB";
            this.rulesGB.Size = new System.Drawing.Size(723, 210);
            this.rulesGB.TabIndex = 4;
            this.rulesGB.TabStop = false;
            this.rulesGB.Text = "Rules";
            // 
            // rulesTB
            // 
            this.rulesTB.Location = new System.Drawing.Point(17, 29);
            this.rulesTB.Multiline = true;
            this.rulesTB.Name = "rulesTB";
            this.rulesTB.ReadOnly = true;
            this.rulesTB.Size = new System.Drawing.Size(688, 164);
            this.rulesTB.TabIndex = 0;
            // 
            // controlGB
            // 
            this.controlGB.Controls.Add(this.controlTB);
            this.controlGB.Location = new System.Drawing.Point(12, 229);
            this.controlGB.Name = "controlGB";
            this.controlGB.Size = new System.Drawing.Size(723, 145);
            this.controlGB.TabIndex = 5;
            this.controlGB.TabStop = false;
            this.controlGB.Text = "Control";
            // 
            // controlTB
            // 
            this.controlTB.Location = new System.Drawing.Point(17, 29);
            this.controlTB.Multiline = true;
            this.controlTB.Name = "controlTB";
            this.controlTB.ReadOnly = true;
            this.controlTB.Size = new System.Drawing.Size(688, 102);
            this.controlTB.TabIndex = 0;
            // 
            // aboutGB
            // 
            this.aboutGB.Controls.Add(this.aboutTB);
            this.aboutGB.Location = new System.Drawing.Point(12, 380);
            this.aboutGB.Name = "aboutGB";
            this.aboutGB.Size = new System.Drawing.Size(723, 141);
            this.aboutGB.TabIndex = 5;
            this.aboutGB.TabStop = false;
            this.aboutGB.Text = "About the application";
            // 
            // aboutTB
            // 
            this.aboutTB.Location = new System.Drawing.Point(17, 29);
            this.aboutTB.Multiline = true;
            this.aboutTB.Name = "aboutTB";
            this.aboutTB.ReadOnly = true;
            this.aboutTB.Size = new System.Drawing.Size(688, 102);
            this.aboutTB.TabIndex = 0;
            // 
            // closeButton
            // 
            this.closeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.closeButton.Location = new System.Drawing.Point(313, 543);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(115, 38);
            this.closeButton.TabIndex = 3;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // InformationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 584);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.aboutGB);
            this.Controls.Add(this.controlGB);
            this.Controls.Add(this.rulesGB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "InformationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chinese Checkers - About the game";
            this.rulesGB.ResumeLayout(false);
            this.rulesGB.PerformLayout();
            this.controlGB.ResumeLayout(false);
            this.controlGB.PerformLayout();
            this.aboutGB.ResumeLayout(false);
            this.aboutGB.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox rulesGB;
        private System.Windows.Forms.TextBox rulesTB;
        private System.Windows.Forms.GroupBox controlGB;
        private System.Windows.Forms.TextBox controlTB;
        private System.Windows.Forms.GroupBox aboutGB;
        private System.Windows.Forms.TextBox aboutTB;
        private System.Windows.Forms.Button closeButton;
    }
}