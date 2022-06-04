using System.ComponentModel;
using System.Windows.Forms;

namespace RouletteBot.Views
{
    public partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.playRound = new System.Windows.Forms.Button();
            this.numbersView = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.highlightMapping = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // playRound
            // 
            this.playRound.Location = new System.Drawing.Point(225, 66);
            this.playRound.Name = "playRound";
            this.playRound.Size = new System.Drawing.Size(101, 23);
            this.playRound.TabIndex = 0;
            this.playRound.Text = "Start";
            this.playRound.UseVisualStyleBackColor = true;
            this.playRound.Click += new System.EventHandler(this.PlayRoundClick);
            // 
            // numbersView
            // 
            this.numbersView.AutoSize = true;
            this.numbersView.Location = new System.Drawing.Point(12, 4);
            this.numbersView.Name = "numbersView";
            this.numbersView.Size = new System.Drawing.Size(0, 16);
            this.numbersView.TabIndex = 1;
            this.numbersView.UseCompatibleTextRendering = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(225, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Upravit mapování";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.showEditMappingForm);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(225, 8);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(101, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Upravit sázení";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.showEditBettingForm);
            // 
            // highlightMapping
            // 
            this.highlightMapping.Location = new System.Drawing.Point(225, 95);
            this.highlightMapping.Name = "highlightMapping";
            this.highlightMapping.Size = new System.Drawing.Size(101, 23);
            this.highlightMapping.TabIndex = 7;
            this.highlightMapping.Text = "Vykreslit mapping";
            this.highlightMapping.UseVisualStyleBackColor = true;
            this.highlightMapping.Click += new System.EventHandler(this.highlightConfiguredMapping);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 123);
            this.Controls.Add(this.highlightMapping);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.numbersView);
            this.Controls.Add(this.playRound);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWindow";
            this.Opacity = 0.7D;
            this.Text = "Roulette bot";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button playRound;
        private Label numbersView;
        private Button button1;
        private Button button2;
        private Button highlightMapping;
    }
}

