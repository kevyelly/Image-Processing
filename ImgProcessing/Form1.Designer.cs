namespace ImgProcessing
{
    partial class Form1
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button12 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.backgroundBox = new System.Windows.Forms.PictureBox();
            this.subtractedBox = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.foregroundBox = new System.Windows.Forms.PictureBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button24 = new System.Windows.Forms.Button();
            this.button23 = new System.Windows.Forms.Button();
            this.button22 = new System.Windows.Forms.Button();
            this.button21 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.convulationResultPictureBox = new System.Windows.Forms.PictureBox();
            this.button13 = new System.Windows.Forms.Button();
            this.convulationPictureBox = new System.Windows.Forms.PictureBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.button31 = new System.Windows.Forms.Button();
            this.button30 = new System.Windows.Forms.Button();
            this.button28 = new System.Windows.Forms.Button();
            this.button27 = new System.Windows.Forms.Button();
            this.saveWebcam = new System.Windows.Forms.Button();
            this.webCamPictureBox = new System.Windows.Forms.PictureBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subtractedBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.foregroundBox)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.convulationResultPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.convulationPictureBox)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webCamPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Gainsboro;
            this.pictureBox1.Location = new System.Drawing.Point(98, 53);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(250, 200);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Gainsboro;
            this.pictureBox2.Location = new System.Drawing.Point(449, 53);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(250, 200);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(184, 273);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Load Image";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.loadImageClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(1, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(816, 487);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.button7);
            this.tabPage1.Controls.Add(this.button6);
            this.tabPage1.Controls.Add(this.button5);
            this.tabPage1.Controls.Add(this.button4);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.pictureBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(808, 461);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Basic Mode";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(350, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 13);
            this.textBox1.TabIndex = 9;
            this.textBox1.Text = "Basic Image Processing";
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Transparent;
            this.button7.Location = new System.Drawing.Point(624, 367);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 8;
            this.button7.Text = "Sepia";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.sepiaClick);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Transparent;
            this.button6.Location = new System.Drawing.Point(495, 367);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 7;
            this.button6.Text = "Histogram";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.histogramClicked);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Transparent;
            this.button5.Location = new System.Drawing.Point(357, 367);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(93, 23);
            this.button5.TabIndex = 6;
            this.button5.Text = "Color Inversion";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.inversionClick);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.Location = new System.Drawing.Point(231, 367);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "GreyScale";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.greyScaleClick);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.button3.Location = new System.Drawing.Point(98, 367);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "Basic Copy";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.basicCopyClick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(539, 273);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Save Image";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.saveImageClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.textBox2);
            this.tabPage2.Controls.Add(this.button12);
            this.tabPage2.Controls.Add(this.button11);
            this.tabPage2.Controls.Add(this.button10);
            this.tabPage2.Controls.Add(this.button9);
            this.tabPage2.Controls.Add(this.button8);
            this.tabPage2.Controls.Add(this.backgroundBox);
            this.tabPage2.Controls.Add(this.subtractedBox);
            this.tabPage2.Controls.Add(this.pictureBox5);
            this.tabPage2.Controls.Add(this.pictureBox4);
            this.tabPage2.Controls.Add(this.foregroundBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(808, 461);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Subtract Mode";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.White;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(361, 26);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(130, 13);
            this.textBox2.TabIndex = 10;
            this.textBox2.Text = "Subtract Image Processing";
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(492, 348);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(112, 23);
            this.button12.TabIndex = 9;
            this.button12.Text = "Clear Images";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.clearClicked);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(226, 348);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(112, 23);
            this.button11.TabIndex = 8;
            this.button11.Text = "Subtract Image";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.subtractClicked);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(352, 274);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(112, 23);
            this.button10.TabIndex = 7;
            this.button10.Text = "Save Image";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.saveSubtracted);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(621, 274);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(112, 23);
            this.button9.TabIndex = 6;
            this.button9.Text = "Load Background";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.loadBackground);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(85, 274);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(112, 23);
            this.button8.TabIndex = 5;
            this.button8.Text = "Load Foreground";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.loadForeground);
            // 
            // backgroundBox
            // 
            this.backgroundBox.BackColor = System.Drawing.Color.Gainsboro;
            this.backgroundBox.Location = new System.Drawing.Point(560, 68);
            this.backgroundBox.Name = "backgroundBox";
            this.backgroundBox.Size = new System.Drawing.Size(225, 200);
            this.backgroundBox.TabIndex = 4;
            this.backgroundBox.TabStop = false;
            // 
            // subtractedBox
            // 
            this.subtractedBox.BackColor = System.Drawing.Color.Gainsboro;
            this.subtractedBox.Location = new System.Drawing.Point(299, 68);
            this.subtractedBox.Name = "subtractedBox";
            this.subtractedBox.Size = new System.Drawing.Size(225, 200);
            this.subtractedBox.TabIndex = 3;
            this.subtractedBox.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Location = new System.Drawing.Point(560, 68);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(0, 0);
            this.pictureBox5.TabIndex = 2;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Location = new System.Drawing.Point(289, 68);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(0, 0);
            this.pictureBox4.TabIndex = 1;
            this.pictureBox4.TabStop = false;
            // 
            // foregroundBox
            // 
            this.foregroundBox.BackColor = System.Drawing.Color.Gainsboro;
            this.foregroundBox.Location = new System.Drawing.Point(36, 68);
            this.foregroundBox.Name = "foregroundBox";
            this.foregroundBox.Size = new System.Drawing.Size(225, 200);
            this.foregroundBox.TabIndex = 0;
            this.foregroundBox.TabStop = false;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.textBox3);
            this.tabPage3.Controls.Add(this.button24);
            this.tabPage3.Controls.Add(this.button23);
            this.tabPage3.Controls.Add(this.button22);
            this.tabPage3.Controls.Add(this.button21);
            this.tabPage3.Controls.Add(this.button20);
            this.tabPage3.Controls.Add(this.button19);
            this.tabPage3.Controls.Add(this.button18);
            this.tabPage3.Controls.Add(this.button17);
            this.tabPage3.Controls.Add(this.button16);
            this.tabPage3.Controls.Add(this.button15);
            this.tabPage3.Controls.Add(this.button14);
            this.tabPage3.Controls.Add(this.convulationResultPictureBox);
            this.tabPage3.Controls.Add(this.button13);
            this.tabPage3.Controls.Add(this.convulationPictureBox);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(808, 461);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Convulation Mode";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.White;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Location = new System.Drawing.Point(325, 19);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(180, 13);
            this.textBox3.TabIndex = 14;
            this.textBox3.Text = "Convulation Matrix Image Processing";
            // 
            // button24
            // 
            this.button24.Location = new System.Drawing.Point(532, 399);
            this.button24.Name = "button24";
            this.button24.Size = new System.Drawing.Size(82, 23);
            this.button24.TabIndex = 13;
            this.button24.Text = "Vertical Only";
            this.button24.UseVisualStyleBackColor = true;
            this.button24.Click += new System.EventHandler(this.verticalOnlyClicked);
            // 
            // button23
            // 
            this.button23.Location = new System.Drawing.Point(435, 399);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(91, 23);
            this.button23.TabIndex = 11;
            this.button23.Text = "Horizontal Only";
            this.button23.UseVisualStyleBackColor = true;
            this.button23.Click += new System.EventHandler(this.horizontalOnlyClicked);
            // 
            // button22
            // 
            this.button22.Location = new System.Drawing.Point(354, 399);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(75, 23);
            this.button22.TabIndex = 12;
            this.button22.Text = "Lossy";
            this.button22.UseVisualStyleBackColor = true;
            this.button22.Click += new System.EventHandler(this.lossyClicked);
            // 
            // button21
            // 
            this.button21.Location = new System.Drawing.Point(257, 399);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(91, 23);
            this.button21.TabIndex = 11;
            this.button21.Text = "All Directions";
            this.button21.UseVisualStyleBackColor = true;
            this.button21.Click += new System.EventHandler(this.allDirectionClick);
            // 
            // button20
            // 
            this.button20.Location = new System.Drawing.Point(143, 399);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(108, 23);
            this.button20.TabIndex = 10;
            this.button20.Text = "Horizontal Vertical";
            this.button20.UseVisualStyleBackColor = true;
            this.button20.Click += new System.EventHandler(this.horizontalVerticalClick);
            // 
            // button19
            // 
            this.button19.Location = new System.Drawing.Point(343, 337);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(106, 23);
            this.button19.TabIndex = 9;
            this.button19.Text = "Mean Removal";
            this.button19.UseVisualStyleBackColor = true;
            this.button19.Click += new System.EventHandler(this.meanRemovalClick);
            // 
            // button18
            // 
            this.button18.Location = new System.Drawing.Point(249, 337);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(75, 23);
            this.button18.TabIndex = 8;
            this.button18.Text = "Sharpen";
            this.button18.UseVisualStyleBackColor = true;
            this.button18.Click += new System.EventHandler(this.sharpenClick);
            // 
            // button17
            // 
            this.button17.Location = new System.Drawing.Point(56, 399);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(75, 23);
            this.button17.TabIndex = 8;
            this.button17.Text = "Laplascian";
            this.button17.UseVisualStyleBackColor = true;
            this.button17.Click += new System.EventHandler(this.LaplascianClick);
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(152, 337);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(75, 23);
            this.button16.TabIndex = 7;
            this.button16.Text = "Gaussian Blur";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.gaussianClick);
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(56, 337);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(75, 23);
            this.button15.TabIndex = 6;
            this.button15.Text = "Smooth";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.smoothClick);
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(569, 278);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(75, 23);
            this.button14.TabIndex = 5;
            this.button14.Text = "Save Image";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.saveConvulationPic);
            // 
            // convulationResultPictureBox
            // 
            this.convulationResultPictureBox.BackColor = System.Drawing.Color.Gainsboro;
            this.convulationResultPictureBox.Location = new System.Drawing.Point(478, 51);
            this.convulationResultPictureBox.Name = "convulationResultPictureBox";
            this.convulationResultPictureBox.Size = new System.Drawing.Size(250, 200);
            this.convulationResultPictureBox.TabIndex = 4;
            this.convulationResultPictureBox.TabStop = false;
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(176, 278);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(75, 23);
            this.button13.TabIndex = 3;
            this.button13.Text = "Load Image";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.loadConvulationPic);
            // 
            // convulationPictureBox
            // 
            this.convulationPictureBox.BackColor = System.Drawing.Color.Gainsboro;
            this.convulationPictureBox.Location = new System.Drawing.Point(98, 51);
            this.convulationPictureBox.Name = "convulationPictureBox";
            this.convulationPictureBox.Size = new System.Drawing.Size(250, 200);
            this.convulationPictureBox.TabIndex = 1;
            this.convulationPictureBox.TabStop = false;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.button31);
            this.tabPage4.Controls.Add(this.button30);
            this.tabPage4.Controls.Add(this.button28);
            this.tabPage4.Controls.Add(this.button27);
            this.tabPage4.Controls.Add(this.saveWebcam);
            this.tabPage4.Controls.Add(this.webCamPictureBox);
            this.tabPage4.Controls.Add(this.checkBox1);
            this.tabPage4.Controls.Add(this.comboBox1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(808, 461);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Webcam";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // button31
            // 
            this.button31.BackColor = System.Drawing.Color.Transparent;
            this.button31.Location = new System.Drawing.Point(596, 347);
            this.button31.Name = "button31";
            this.button31.Size = new System.Drawing.Size(93, 23);
            this.button31.TabIndex = 12;
            this.button31.Text = "Clear";
            this.button31.UseVisualStyleBackColor = false;
            this.button31.Click += new System.EventHandler(this.clearWebCamClicked);
            // 
            // button30
            // 
            this.button30.BackColor = System.Drawing.Color.Transparent;
            this.button30.Location = new System.Drawing.Point(465, 347);
            this.button30.Name = "button30";
            this.button30.Size = new System.Drawing.Size(75, 23);
            this.button30.TabIndex = 11;
            this.button30.Text = "Sepia";
            this.button30.UseVisualStyleBackColor = false;
            this.button30.Click += new System.EventHandler(this.sepiaWebcamClicked);
            // 
            // button28
            // 
            this.button28.BackColor = System.Drawing.Color.Transparent;
            this.button28.Location = new System.Drawing.Point(286, 347);
            this.button28.Name = "button28";
            this.button28.Size = new System.Drawing.Size(93, 23);
            this.button28.TabIndex = 9;
            this.button28.Text = "Color Inversion";
            this.button28.UseVisualStyleBackColor = false;
            this.button28.Click += new System.EventHandler(this.invertWebcamClicked);
            // 
            // button27
            // 
            this.button27.BackColor = System.Drawing.Color.Transparent;
            this.button27.Location = new System.Drawing.Point(131, 347);
            this.button27.Name = "button27";
            this.button27.Size = new System.Drawing.Size(75, 23);
            this.button27.TabIndex = 8;
            this.button27.Text = "GreyScale";
            this.button27.UseVisualStyleBackColor = false;
            this.button27.Click += new System.EventHandler(this.greyscaleWebcamClicked);
            // 
            // saveWebcam
            // 
            this.saveWebcam.Location = new System.Drawing.Point(392, 285);
            this.saveWebcam.Name = "saveWebcam";
            this.saveWebcam.Size = new System.Drawing.Size(75, 23);
            this.saveWebcam.TabIndex = 7;
            this.saveWebcam.Text = "Save Image";
            this.saveWebcam.UseVisualStyleBackColor = true;
            this.saveWebcam.UseWaitCursor = true;
            this.saveWebcam.Click += new System.EventHandler(this.saveWebcamClicked);
            // 
            // webCamPictureBox
            // 
            this.webCamPictureBox.BackColor = System.Drawing.Color.Gainsboro;
            this.webCamPictureBox.Location = new System.Drawing.Point(306, 29);
            this.webCamPictureBox.Name = "webCamPictureBox";
            this.webCamPictureBox.Size = new System.Drawing.Size(250, 200);
            this.webCamPictureBox.TabIndex = 4;
            this.webCamPictureBox.TabStop = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(375, 262);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(111, 17);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Activate Webcam";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(375, 235);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 483);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.backgroundBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subtractedBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.foregroundBox)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.convulationResultPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.convulationPictureBox)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webCamPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.PictureBox backgroundBox;
        private System.Windows.Forms.PictureBox subtractedBox;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox foregroundBox;
        public System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.PictureBox convulationResultPictureBox;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.PictureBox convulationPictureBox;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button23;
        private System.Windows.Forms.Button button22;
        private System.Windows.Forms.Button button21;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button24;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.PictureBox webCamPictureBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button30;
        private System.Windows.Forms.Button button28;
        private System.Windows.Forms.Button button27;
        private System.Windows.Forms.Button saveWebcam;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button31;
    }
}

