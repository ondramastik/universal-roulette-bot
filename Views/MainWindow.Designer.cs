namespace RouletteBot
{
    partial class MainWindow
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
            this.playRound = new System.Windows.Forms.Button();
            this.numbersView = new System.Windows.Forms.Label();
            this.doubleSixLineBets = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // playRound
            // 
            this.playRound.Location = new System.Drawing.Point(163, 70);
            this.playRound.Name = "playRound";
            this.playRound.Size = new System.Drawing.Size(75, 23);
            this.playRound.TabIndex = 0;
            this.playRound.Text = "Play round";
            this.playRound.UseVisualStyleBackColor = true;
            this.playRound.Click += new System.EventHandler(this.playRoundClick);
            // 
            // numbersView
            // 
            this.numbersView.AutoSize = true;
            this.numbersView.Location = new System.Drawing.Point(13, 13);
            this.numbersView.Name = "numbersView";
            this.numbersView.Size = new System.Drawing.Size(0, 13);
            this.numbersView.TabIndex = 1;
            // 
            // doubleSixLineBets
            // 
            this.doubleSixLineBets.AutoSize = true;
            this.doubleSixLineBets.Checked = true;
            this.doubleSixLineBets.CheckState = System.Windows.Forms.CheckState.Checked;
            this.doubleSixLineBets.Location = new System.Drawing.Point(12, 70);
            this.doubleSixLineBets.Name = "doubleSixLineBets";
            this.doubleSixLineBets.Size = new System.Drawing.Size(141, 17);
            this.doubleSixLineBets.TabIndex = 2;
            this.doubleSixLineBets.Text = "Násobit sázky na six line";
            this.doubleSixLineBets.UseVisualStyleBackColor = true;
            this.doubleSixLineBets.Click += new System.EventHandler(this.doubleSixLineBetsChanged);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 105);
            this.Controls.Add(this.doubleSixLineBets);
            this.Controls.Add(this.numbersView);
            this.Controls.Add(this.playRound);
            this.Name = "MainWindow";
            this.Text = "Form1";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button playRound;
        private System.Windows.Forms.Label numbersView;
        private System.Windows.Forms.CheckBox doubleSixLineBets;
    }
}

