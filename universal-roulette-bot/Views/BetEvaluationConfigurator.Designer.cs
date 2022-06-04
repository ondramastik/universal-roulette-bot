using System.ComponentModel;
using System.Windows.Forms;

namespace RouletteBot.Views
{
    partial class BetEvaluationConfigurator
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
            this.SixLineBet = new System.Windows.Forms.CheckBox();
            this.SixLineBetAmount = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.SecondSixLineBet = new System.Windows.Forms.CheckBox();
            this.ThreeOfFour = new System.Windows.Forms.CheckBox();
            this.FirstFiveBlack = new System.Windows.Forms.CheckBox();
            this.ColorSwitching = new System.Windows.Forms.CheckBox();
            this.TwoColorsInRow = new System.Windows.Forms.CheckBox();
            this.ColorStreakAfterZero = new System.Windows.Forms.CheckBox();
            this.RedAfterZero = new System.Windows.Forms.CheckBox();
            this.SecondSixLineBetAmount = new System.Windows.Forms.NumericUpDown();
            this.ThreeOfFourAmount = new System.Windows.Forms.NumericUpDown();
            this.FirstFiveBlackAmount = new System.Windows.Forms.NumericUpDown();
            this.ColorSwitchingAmount = new System.Windows.Forms.NumericUpDown();
            this.TwoColorsInRowAmount = new System.Windows.Forms.NumericUpDown();
            this.ColorStreakAfterZeroAmount = new System.Windows.Forms.NumericUpDown();
            this.RedAfterZeroAmount = new System.Windows.Forms.NumericUpDown();
            this.SixLineBetNumberBeforeAmount = new System.Windows.Forms.NumericUpDown();
            this.SixLineBetNumberBefore = new System.Windows.Forms.CheckBox();
            this.SecondSixLineBetNumberBeforeAmount = new System.Windows.Forms.NumericUpDown();
            this.SecondSixLineBetNumberBefore = new System.Windows.Forms.CheckBox();
            this.save = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Button();
            this.LongTimeNoSeeAmount = new System.Windows.Forms.NumericUpDown();
            this.LongTimeNoSee = new System.Windows.Forms.CheckBox();
            this.LongTimeNoSeeFrom = new System.Windows.Forms.NumericUpDown();
            this.LongTimeNoSeeTo = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SixLineBetAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecondSixLineBetAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThreeOfFourAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FirstFiveBlackAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColorSwitchingAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TwoColorsInRowAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColorStreakAfterZeroAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedAfterZeroAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SixLineBetNumberBeforeAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecondSixLineBetNumberBeforeAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LongTimeNoSeeAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LongTimeNoSeeFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LongTimeNoSeeTo)).BeginInit();
            this.SuspendLayout();
            // 
            // SixLineBet
            // 
            this.SixLineBet.AutoSize = true;
            this.SixLineBet.Location = new System.Drawing.Point(12, 24);
            this.SixLineBet.Name = "SixLineBet";
            this.SixLineBet.Size = new System.Drawing.Size(87, 17);
            this.SixLineBet.TabIndex = 2;
            this.SixLineBet.Text = "SixLine sázka";
            this.SixLineBet.UseVisualStyleBackColor = true;
            // 
            // SixLineBetAmount
            // 
            this.SixLineBetAmount.Location = new System.Drawing.Point(135, 21);
            this.SixLineBetAmount.Name = "SixLineBetAmount";
            this.SixLineBetAmount.Size = new System.Drawing.Size(37, 20);
            this.SixLineBetAmount.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(132, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Počet kliknutí";
            // 
            // SecondSixLineBet
            // 
            this.SecondSixLineBet.AutoSize = true;
            this.SecondSixLineBet.Location = new System.Drawing.Point(12, 70);
            this.SecondSixLineBet.Name = "SecondSixLineBet";
            this.SecondSixLineBet.Size = new System.Drawing.Size(117, 17);
            this.SecondSixLineBet.TabIndex = 5;
            this.SecondSixLineBet.Text = "Druhá SixLine sázka";
            this.SecondSixLineBet.UseVisualStyleBackColor = true;
            // 
            // ThreeOfFour
            // 
            this.ThreeOfFour.AutoSize = true;
            this.ThreeOfFour.Location = new System.Drawing.Point(12, 116);
            this.ThreeOfFour.Name = "ThreeOfFour";
            this.ThreeOfFour.Size = new System.Drawing.Size(55, 17);
            this.ThreeOfFour.TabIndex = 6;
            this.ThreeOfFour.Text = "3 ze 4";
            this.ThreeOfFour.UseVisualStyleBackColor = true;
            // 
            // FirstFiveBlack
            // 
            this.FirstFiveBlack.AutoSize = true;
            this.FirstFiveBlack.Location = new System.Drawing.Point(12, 139);
            this.FirstFiveBlack.Name = "FirstFiveBlack";
            this.FirstFiveBlack.Size = new System.Drawing.Size(114, 17);
            this.FirstFiveBlack.TabIndex = 7;
            this.FirstFiveBlack.Text = "Prvních 5 černých";
            this.FirstFiveBlack.UseVisualStyleBackColor = true;
            // 
            // ColorSwitching
            // 
            this.ColorSwitching.AutoSize = true;
            this.ColorSwitching.Location = new System.Drawing.Point(12, 162);
            this.ColorSwitching.Name = "ColorSwitching";
            this.ColorSwitching.Size = new System.Drawing.Size(96, 17);
            this.ColorSwitching.TabIndex = 8;
            this.ColorSwitching.Text = "Střídání barev";
            this.ColorSwitching.UseVisualStyleBackColor = true;
            // 
            // TwoColorsInRow
            // 
            this.TwoColorsInRow.AutoSize = true;
            this.TwoColorsInRow.Location = new System.Drawing.Point(12, 185);
            this.TwoColorsInRow.Name = "TwoColorsInRow";
            this.TwoColorsInRow.Size = new System.Drawing.Size(109, 17);
            this.TwoColorsInRow.TabIndex = 9;
            this.TwoColorsInRow.Text = "Dvě barvy v řadě";
            this.TwoColorsInRow.UseVisualStyleBackColor = true;
            // 
            // ColorStreakAfterZero
            // 
            this.ColorStreakAfterZero.AutoSize = true;
            this.ColorStreakAfterZero.Location = new System.Drawing.Point(12, 208);
            this.ColorStreakAfterZero.Name = "ColorStreakAfterZero";
            this.ColorStreakAfterZero.Size = new System.Drawing.Size(109, 17);
            this.ColorStreakAfterZero.TabIndex = 10;
            this.ColorStreakAfterZero.Text = "Stejné barvy po 0";
            this.ColorStreakAfterZero.UseVisualStyleBackColor = true;
            // 
            // RedAfterZero
            // 
            this.RedAfterZero.AutoSize = true;
            this.RedAfterZero.Location = new System.Drawing.Point(12, 231);
            this.RedAfterZero.Name = "RedAfterZero";
            this.RedAfterZero.Size = new System.Drawing.Size(90, 17);
            this.RedAfterZero.TabIndex = 11;
            this.RedAfterZero.Text = "Červená po 0";
            this.RedAfterZero.UseVisualStyleBackColor = true;
            // 
            // SecondSixLineBetAmount
            // 
            this.SecondSixLineBetAmount.Location = new System.Drawing.Point(135, 67);
            this.SecondSixLineBetAmount.Name = "SecondSixLineBetAmount";
            this.SecondSixLineBetAmount.Size = new System.Drawing.Size(37, 20);
            this.SecondSixLineBetAmount.TabIndex = 12;
            // 
            // ThreeOfFourAmount
            // 
            this.ThreeOfFourAmount.Location = new System.Drawing.Point(135, 113);
            this.ThreeOfFourAmount.Name = "ThreeOfFourAmount";
            this.ThreeOfFourAmount.Size = new System.Drawing.Size(37, 20);
            this.ThreeOfFourAmount.TabIndex = 13;
            // 
            // FirstFiveBlackAmount
            // 
            this.FirstFiveBlackAmount.Location = new System.Drawing.Point(135, 136);
            this.FirstFiveBlackAmount.Name = "FirstFiveBlackAmount";
            this.FirstFiveBlackAmount.Size = new System.Drawing.Size(37, 20);
            this.FirstFiveBlackAmount.TabIndex = 14;
            // 
            // ColorSwitchingAmount
            // 
            this.ColorSwitchingAmount.Location = new System.Drawing.Point(135, 159);
            this.ColorSwitchingAmount.Name = "ColorSwitchingAmount";
            this.ColorSwitchingAmount.Size = new System.Drawing.Size(37, 20);
            this.ColorSwitchingAmount.TabIndex = 15;
            // 
            // TwoColorsInRowAmount
            // 
            this.TwoColorsInRowAmount.Location = new System.Drawing.Point(135, 182);
            this.TwoColorsInRowAmount.Name = "TwoColorsInRowAmount";
            this.TwoColorsInRowAmount.Size = new System.Drawing.Size(37, 20);
            this.TwoColorsInRowAmount.TabIndex = 16;
            // 
            // ColorStreakAfterZeroAmount
            // 
            this.ColorStreakAfterZeroAmount.Location = new System.Drawing.Point(135, 205);
            this.ColorStreakAfterZeroAmount.Name = "ColorStreakAfterZeroAmount";
            this.ColorStreakAfterZeroAmount.Size = new System.Drawing.Size(37, 20);
            this.ColorStreakAfterZeroAmount.TabIndex = 17;
            // 
            // RedAfterZeroAmount
            // 
            this.RedAfterZeroAmount.Location = new System.Drawing.Point(135, 228);
            this.RedAfterZeroAmount.Name = "RedAfterZeroAmount";
            this.RedAfterZeroAmount.Size = new System.Drawing.Size(37, 20);
            this.RedAfterZeroAmount.TabIndex = 18;
            // 
            // SixLineBetNumberBeforeAmount
            // 
            this.SixLineBetNumberBeforeAmount.Location = new System.Drawing.Point(135, 44);
            this.SixLineBetNumberBeforeAmount.Name = "SixLineBetNumberBeforeAmount";
            this.SixLineBetNumberBeforeAmount.Size = new System.Drawing.Size(37, 20);
            this.SixLineBetNumberBeforeAmount.TabIndex = 20;
            // 
            // SixLineBetNumberBefore
            // 
            this.SixLineBetNumberBefore.AutoSize = true;
            this.SixLineBetNumberBefore.Location = new System.Drawing.Point(12, 47);
            this.SixLineBetNumberBefore.Name = "SixLineBetNumberBefore";
            this.SixLineBetNumberBefore.Size = new System.Drawing.Size(65, 17);
            this.SixLineBetNumberBefore.TabIndex = 19;
            this.SixLineBetNumberBefore.Text = "Číslo ob";
            this.SixLineBetNumberBefore.UseVisualStyleBackColor = true;
            // 
            // SecondSixLineBetNumberBeforeAmount
            // 
            this.SecondSixLineBetNumberBeforeAmount.Location = new System.Drawing.Point(135, 90);
            this.SecondSixLineBetNumberBeforeAmount.Name = "SecondSixLineBetNumberBeforeAmount";
            this.SecondSixLineBetNumberBeforeAmount.Size = new System.Drawing.Size(37, 20);
            this.SecondSixLineBetNumberBeforeAmount.TabIndex = 22;
            // 
            // SecondSixLineBetNumberBefore
            // 
            this.SecondSixLineBetNumberBefore.AutoSize = true;
            this.SecondSixLineBetNumberBefore.Location = new System.Drawing.Point(12, 93);
            this.SecondSixLineBetNumberBefore.Name = "SecondSixLineBetNumberBefore";
            this.SecondSixLineBetNumberBefore.Size = new System.Drawing.Size(95, 17);
            this.SecondSixLineBetNumberBefore.TabIndex = 21;
            this.SecondSixLineBetNumberBefore.Text = "Číslo ob druhé";
            this.SecondSixLineBetNumberBefore.UseVisualStyleBackColor = true;
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(121, 304);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 23;
            this.save.Text = "Uložit";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.SaveClick);
            // 
            // close
            // 
            this.close.Location = new System.Drawing.Point(40, 304);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(75, 23);
            this.close.TabIndex = 24;
            this.close.Text = "Zrušit";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.CloseClick);
            // 
            // LongTimeNoSeeAmount
            // 
            this.LongTimeNoSeeAmount.Location = new System.Drawing.Point(135, 251);
            this.LongTimeNoSeeAmount.Name = "LongTimeNoSeeAmount";
            this.LongTimeNoSeeAmount.Size = new System.Drawing.Size(37, 20);
            this.LongTimeNoSeeAmount.TabIndex = 26;
            // 
            // LongTimeNoSee
            // 
            this.LongTimeNoSee.AutoSize = true;
            this.LongTimeNoSee.Location = new System.Drawing.Point(12, 254);
            this.LongTimeNoSee.Name = "LongTimeNoSee";
            this.LongTimeNoSee.Size = new System.Drawing.Size(101, 17);
            this.LongTimeNoSee.TabIndex = 25;
            this.LongTimeNoSee.Text = "Dlouho nepadlo";
            this.LongTimeNoSee.UseVisualStyleBackColor = true;
            // 
            // LongTimeNoSeeFrom
            // 
            this.LongTimeNoSeeFrom.Location = new System.Drawing.Point(71, 277);
            this.LongTimeNoSeeFrom.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.LongTimeNoSeeFrom.Name = "LongTimeNoSeeFrom";
            this.LongTimeNoSeeFrom.Size = new System.Drawing.Size(37, 20);
            this.LongTimeNoSeeFrom.TabIndex = 27;
            // 
            // LongTimeNoSeeTo
            // 
            this.LongTimeNoSeeTo.Location = new System.Drawing.Point(135, 277);
            this.LongTimeNoSeeTo.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.LongTimeNoSeeTo.Name = "LongTimeNoSeeTo";
            this.LongTimeNoSeeTo.Size = new System.Drawing.Size(37, 20);
            this.LongTimeNoSeeTo.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 279);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Od";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(108, 279);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Do";
            // 
            // BetEvaluationConfigurator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(208, 339);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LongTimeNoSeeTo);
            this.Controls.Add(this.LongTimeNoSeeFrom);
            this.Controls.Add(this.LongTimeNoSeeAmount);
            this.Controls.Add(this.LongTimeNoSee);
            this.Controls.Add(this.close);
            this.Controls.Add(this.save);
            this.Controls.Add(this.SecondSixLineBetNumberBeforeAmount);
            this.Controls.Add(this.SecondSixLineBetNumberBefore);
            this.Controls.Add(this.SixLineBetNumberBeforeAmount);
            this.Controls.Add(this.SixLineBetNumberBefore);
            this.Controls.Add(this.RedAfterZeroAmount);
            this.Controls.Add(this.ColorStreakAfterZeroAmount);
            this.Controls.Add(this.TwoColorsInRowAmount);
            this.Controls.Add(this.ColorSwitchingAmount);
            this.Controls.Add(this.FirstFiveBlackAmount);
            this.Controls.Add(this.ThreeOfFourAmount);
            this.Controls.Add(this.SecondSixLineBetAmount);
            this.Controls.Add(this.RedAfterZero);
            this.Controls.Add(this.ColorStreakAfterZero);
            this.Controls.Add(this.TwoColorsInRow);
            this.Controls.Add(this.ColorSwitching);
            this.Controls.Add(this.FirstFiveBlack);
            this.Controls.Add(this.ThreeOfFour);
            this.Controls.Add(this.SecondSixLineBet);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SixLineBetAmount);
            this.Controls.Add(this.SixLineBet);
            this.Name = "BetEvaluationConfigurator";
            this.Text = "Konfigurace sázek";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.BetEvaluationConfigurator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SixLineBetAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecondSixLineBetAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThreeOfFourAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FirstFiveBlackAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColorSwitchingAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TwoColorsInRowAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColorStreakAfterZeroAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedAfterZeroAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SixLineBetNumberBeforeAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SecondSixLineBetNumberBeforeAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LongTimeNoSeeAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LongTimeNoSeeFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LongTimeNoSeeTo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CheckBox SixLineBet;
        private NumericUpDown SixLineBetAmount;
        private Label label1;
        private CheckBox SecondSixLineBet;
        private CheckBox ThreeOfFour;
        private CheckBox FirstFiveBlack;
        private CheckBox ColorSwitching;
        private CheckBox TwoColorsInRow;
        private CheckBox ColorStreakAfterZero;
        private CheckBox RedAfterZero;
        private NumericUpDown SecondSixLineBetAmount;
        private NumericUpDown ThreeOfFourAmount;
        private NumericUpDown FirstFiveBlackAmount;
        private NumericUpDown ColorSwitchingAmount;
        private NumericUpDown TwoColorsInRowAmount;
        private NumericUpDown ColorStreakAfterZeroAmount;
        private NumericUpDown RedAfterZeroAmount;
        private NumericUpDown SixLineBetNumberBeforeAmount;
        private CheckBox SixLineBetNumberBefore;
        private NumericUpDown SecondSixLineBetNumberBeforeAmount;
        private CheckBox SecondSixLineBetNumberBefore;
        private Button save;
        private Button close;
        private NumericUpDown LongTimeNoSeeAmount;
        private CheckBox LongTimeNoSee;
        private NumericUpDown LongTimeNoSeeFrom;
        private NumericUpDown LongTimeNoSeeTo;
        private Label label2;
        private Label label3;
    }
}