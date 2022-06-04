using System.ComponentModel;
using System.Windows.Forms;

namespace RouletteBot.Views
{
    partial class UiMappingConfigurator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UiMappingConfigurator));
            this.GridLeftTopCornerX = new System.Windows.Forms.TextBox();
            this.GridLeftTopCornerY = new System.Windows.Forms.TextBox();
            this.GridRightBottomCornerX = new System.Windows.Forms.TextBox();
            this.RedBetX = new System.Windows.Forms.TextBox();
            this.GridRightBottomCornerY = new System.Windows.Forms.TextBox();
            this.RedBetY = new System.Windows.Forms.TextBox();
            this.BlackBetX = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.BlackBetY = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ConfirmBetY = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.ConfirmBetX = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.SpinReadyCheckX = new System.Windows.Forms.TextBox();
            this.SpinReadyCheckY = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.saveMapping = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.SixLineBetY = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.ForResolutionY = new System.Windows.Forms.TextBox();
            this.ForResolutionX = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.RecalculateForY = new System.Windows.Forms.TextBox();
            this.RecalculateForX = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.NumberCheckOffsetY = new System.Windows.Forms.TextBox();
            this.NumberCheckOffsetX = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.IsMulti = new System.Windows.Forms.CheckBox();
            this.IsDemo = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // GridLeftTopCornerX
            // 
            this.GridLeftTopCornerX.Location = new System.Drawing.Point(205, 12);
            this.GridLeftTopCornerX.Name = "GridLeftTopCornerX";
            this.GridLeftTopCornerX.Size = new System.Drawing.Size(42, 20);
            this.GridLeftTopCornerX.TabIndex = 0;
            // 
            // GridLeftTopCornerY
            // 
            this.GridLeftTopCornerY.Location = new System.Drawing.Point(274, 12);
            this.GridLeftTopCornerY.Name = "GridLeftTopCornerY";
            this.GridLeftTopCornerY.Size = new System.Drawing.Size(42, 20);
            this.GridLeftTopCornerY.TabIndex = 1;
            // 
            // GridRightBottomCornerX
            // 
            this.GridRightBottomCornerX.Location = new System.Drawing.Point(205, 38);
            this.GridRightBottomCornerX.Name = "GridRightBottomCornerX";
            this.GridRightBottomCornerX.Size = new System.Drawing.Size(42, 20);
            this.GridRightBottomCornerX.TabIndex = 2;
            // 
            // RedBetX
            // 
            this.RedBetX.Location = new System.Drawing.Point(205, 64);
            this.RedBetX.Name = "RedBetX";
            this.RedBetX.Size = new System.Drawing.Size(42, 20);
            this.RedBetX.TabIndex = 3;
            // 
            // GridRightBottomCornerY
            // 
            this.GridRightBottomCornerY.Location = new System.Drawing.Point(274, 38);
            this.GridRightBottomCornerY.Name = "GridRightBottomCornerY";
            this.GridRightBottomCornerY.Size = new System.Drawing.Size(42, 20);
            this.GridRightBottomCornerY.TabIndex = 4;
            // 
            // RedBetY
            // 
            this.RedBetY.Location = new System.Drawing.Point(274, 64);
            this.RedBetY.Name = "RedBetY";
            this.RedBetY.Size = new System.Drawing.Size(42, 20);
            this.RedBetY.TabIndex = 5;
            // 
            // BlackBetX
            // 
            this.BlackBetX.Location = new System.Drawing.Point(205, 90);
            this.BlackBetX.Name = "BlackBetX";
            this.BlackBetX.Size = new System.Drawing.Size(42, 20);
            this.BlackBetX.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Levý horní roh čísla 3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Pravý dolní roh čísla 34";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Střed tlačítka pro červenou sázku";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Střed tlačítka pro černou sázku";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(188, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "X";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(188, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "X";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(188, 67);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "X";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(188, 41);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(14, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "X";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(253, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(14, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "Y";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(254, 41);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(14, 13);
            this.label12.TabIndex = 20;
            this.label12.Text = "Y";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(253, 67);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(14, 13);
            this.label13.TabIndex = 21;
            this.label13.Text = "Y";
            // 
            // BlackBetY
            // 
            this.BlackBetY.Location = new System.Drawing.Point(274, 90);
            this.BlackBetY.Name = "BlackBetY";
            this.BlackBetY.Size = new System.Drawing.Size(42, 20);
            this.BlackBetY.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(253, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Y";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(254, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "Y";
            // 
            // ConfirmBetY
            // 
            this.ConfirmBetY.Location = new System.Drawing.Point(274, 116);
            this.ConfirmBetY.Name = "ConfirmBetY";
            this.ConfirmBetY.Size = new System.Drawing.Size(42, 20);
            this.ConfirmBetY.TabIndex = 27;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(188, 119);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(14, 13);
            this.label14.TabIndex = 26;
            this.label14.Text = "X";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 119);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(157, 13);
            this.label15.TabIndex = 25;
            this.label15.Text = "Střed tlačítka spin / confirm bet";
            // 
            // ConfirmBetX
            // 
            this.ConfirmBetX.Location = new System.Drawing.Point(206, 116);
            this.ConfirmBetX.Name = "ConfirmBetX";
            this.ConfirmBetX.Size = new System.Drawing.Size(42, 20);
            this.ConfirmBetX.TabIndex = 24;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(15, 272);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(129, 111);
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(12, 145);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(88, 13);
            this.label16.TabIndex = 30;
            this.label16.Text = "Pozice z obrázku";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(188, 145);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(14, 13);
            this.label17.TabIndex = 31;
            this.label17.Text = "X";
            // 
            // SpinReadyCheckX
            // 
            this.SpinReadyCheckX.Location = new System.Drawing.Point(206, 142);
            this.SpinReadyCheckX.Name = "SpinReadyCheckX";
            this.SpinReadyCheckX.Size = new System.Drawing.Size(42, 20);
            this.SpinReadyCheckX.TabIndex = 32;
            // 
            // SpinReadyCheckY
            // 
            this.SpinReadyCheckY.Location = new System.Drawing.Point(274, 142);
            this.SpinReadyCheckY.Name = "SpinReadyCheckY";
            this.SpinReadyCheckY.Size = new System.Drawing.Size(42, 20);
            this.SpinReadyCheckY.TabIndex = 33;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(254, 145);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(14, 13);
            this.label18.TabIndex = 34;
            this.label18.Text = "Y";
            // 
            // saveMapping
            // 
            this.saveMapping.Location = new System.Drawing.Point(241, 333);
            this.saveMapping.Name = "saveMapping";
            this.saveMapping.Size = new System.Drawing.Size(75, 23);
            this.saveMapping.TabIndex = 35;
            this.saveMapping.Text = "Uložit";
            this.saveMapping.UseVisualStyleBackColor = true;
            this.saveMapping.Click += new System.EventHandler(this.SaveClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(160, 333);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 36;
            this.button1.Text = "Zavřít";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.CloseClick);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(12, 171);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(100, 13);
            this.label19.TabIndex = 37;
            this.label19.Text = "Pozice SixLine sázky";
            // 
            // SixLineBetY
            // 
            this.SixLineBetY.Location = new System.Drawing.Point(274, 168);
            this.SixLineBetY.Name = "SixLineBetY";
            this.SixLineBetY.Size = new System.Drawing.Size(42, 20);
            this.SixLineBetY.TabIndex = 38;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(254, 171);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(14, 13);
            this.label20.TabIndex = 39;
            this.label20.Text = "Y";
            // 
            // ForResolutionY
            // 
            this.ForResolutionY.Location = new System.Drawing.Point(274, 220);
            this.ForResolutionY.Name = "ForResolutionY";
            this.ForResolutionY.Size = new System.Drawing.Size(42, 20);
            this.ForResolutionY.TabIndex = 41;
            // 
            // ForResolutionX
            // 
            this.ForResolutionX.Location = new System.Drawing.Point(206, 220);
            this.ForResolutionX.Name = "ForResolutionX";
            this.ForResolutionX.Size = new System.Drawing.Size(42, 20);
            this.ForResolutionX.TabIndex = 40;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(254, 223);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(14, 13);
            this.label21.TabIndex = 42;
            this.label21.Text = "Y";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(188, 223);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(14, 13);
            this.label22.TabIndex = 43;
            this.label22.Text = "X";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(12, 223);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(136, 13);
            this.label23.TabIndex = 44;
            this.label23.Text = "Konfigurováno pro rozlišení";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(12, 249);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(118, 13);
            this.label24.TabIndex = 47;
            this.label24.Text = "Přepočítat pro rozlišení";
            // 
            // RecalculateForY
            // 
            this.RecalculateForY.Location = new System.Drawing.Point(274, 246);
            this.RecalculateForY.Name = "RecalculateForY";
            this.RecalculateForY.Size = new System.Drawing.Size(42, 20);
            this.RecalculateForY.TabIndex = 46;
            // 
            // RecalculateForX
            // 
            this.RecalculateForX.Location = new System.Drawing.Point(206, 246);
            this.RecalculateForX.Name = "RecalculateForX";
            this.RecalculateForX.Size = new System.Drawing.Size(42, 20);
            this.RecalculateForX.TabIndex = 45;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(188, 249);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(14, 13);
            this.label25.TabIndex = 48;
            this.label25.Text = "X";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(253, 249);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(14, 13);
            this.label26.TabIndex = 49;
            this.label26.Text = "Y";
            // 
            // NumberCheckOffsetY
            // 
            this.NumberCheckOffsetY.Location = new System.Drawing.Point(274, 194);
            this.NumberCheckOffsetY.Name = "NumberCheckOffsetY";
            this.NumberCheckOffsetY.Size = new System.Drawing.Size(42, 20);
            this.NumberCheckOffsetY.TabIndex = 52;
            // 
            // NumberCheckOffsetX
            // 
            this.NumberCheckOffsetX.Location = new System.Drawing.Point(206, 194);
            this.NumberCheckOffsetX.Name = "NumberCheckOffsetX";
            this.NumberCheckOffsetX.Size = new System.Drawing.Size(42, 20);
            this.NumberCheckOffsetX.TabIndex = 51;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(12, 197);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(181, 13);
            this.label27.TabIndex = 50;
            this.label27.Text = "Ofset pro zjišťování posledního čísla";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(188, 197);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(14, 13);
            this.label28.TabIndex = 54;
            this.label28.Text = "X";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(254, 197);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(14, 13);
            this.label29.TabIndex = 53;
            this.label29.Text = "Y";
            // 
            // IsMulti
            // 
            this.IsMulti.AutoSize = true;
            this.IsMulti.Location = new System.Drawing.Point(191, 272);
            this.IsMulti.Name = "IsMulti";
            this.IsMulti.Size = new System.Drawing.Size(64, 17);
            this.IsMulti.TabIndex = 55;
            this.IsMulti.Text = "Is multi?";
            this.IsMulti.UseVisualStyleBackColor = true;
            // 
            // IsDemo
            // 
            this.IsDemo.AutoSize = true;
            this.IsDemo.Checked = true;
            this.IsDemo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IsDemo.Location = new System.Drawing.Point(191, 295);
            this.IsDemo.Name = "IsDemo";
            this.IsDemo.Size = new System.Drawing.Size(69, 17);
            this.IsDemo.TabIndex = 56;
            this.IsDemo.Text = "Is demo?";
            this.IsDemo.UseVisualStyleBackColor = true;
            // 
            // UIMappingConfigurator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 368);
            this.Controls.Add(this.IsDemo);
            this.Controls.Add(this.IsMulti);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.NumberCheckOffsetY);
            this.Controls.Add(this.NumberCheckOffsetX);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.RecalculateForY);
            this.Controls.Add(this.RecalculateForX);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.ForResolutionY);
            this.Controls.Add(this.ForResolutionX);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.SixLineBetY);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.saveMapping);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.SpinReadyCheckY);
            this.Controls.Add(this.SpinReadyCheckX);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ConfirmBetY);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.ConfirmBetX);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.BlackBetY);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BlackBetX);
            this.Controls.Add(this.RedBetY);
            this.Controls.Add(this.GridRightBottomCornerY);
            this.Controls.Add(this.RedBetX);
            this.Controls.Add(this.GridRightBottomCornerX);
            this.Controls.Add(this.GridLeftTopCornerY);
            this.Controls.Add(this.GridLeftTopCornerX);
            this.Name = "UiMappingConfigurator";
            this.Text = "Konfigurace mapování UI";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion



        private TextBox GridLeftTopCornerX;
        private TextBox GridLeftTopCornerY;
        private TextBox GridRightBottomCornerX;
        private TextBox RedBetX;
        private TextBox GridRightBottomCornerY;
        private TextBox RedBetY;
        private TextBox BlackBetX;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label6;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private TextBox BlackBetY;
        private Label label5;
        private Label label7;
        private TextBox ConfirmBetY;
        private Label label14;
        private Label label15;
        private TextBox ConfirmBetX;
        private PictureBox pictureBox1;
        private Label label16;
        private Label label17;
        private TextBox SpinReadyCheckX;
        private TextBox SpinReadyCheckY;
        private Label label18;
        private Button saveMapping;
        private Button button1;
        private Label label19;
        private TextBox SixLineBetY;
        private Label label20;
        private TextBox ForResolutionY;
        private TextBox ForResolutionX;
        private Label label21;
        private Label label22;
        private Label label23;
        private Label label24;
        private TextBox RecalculateForY;
        private TextBox RecalculateForX;
        private Label label25;
        private Label label26;
        private TextBox NumberCheckOffsetY;
        private TextBox NumberCheckOffsetX;
        private Label label27;
        private Label label28;
        private Label label29;
        private CheckBox IsMulti;
        private CheckBox IsDemo;
    }
}