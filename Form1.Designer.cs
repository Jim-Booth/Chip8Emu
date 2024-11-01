namespace Chip8Emu
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox3 = new CheckBox();
            checkBox4 = new CheckBox();
            checkBox5 = new CheckBox();
            checkBox6 = new CheckBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            label1 = new Label();
            comboBox1 = new ComboBox();
            button5 = new Button();
            trackBar1 = new TrackBar();
            label2 = new Label();
            label3 = new Label();
            openFileDialog = new OpenFileDialog();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            label16 = new Label();
            label17 = new Label();
            label18 = new Label();
            label19 = new Label();
            label20 = new Label();
            label21 = new Label();
            panel2 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(0, 16, 0);
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(640, 320);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(650, 330);
            panel1.TabIndex = 1;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.Black;
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Font = new Font("Courier New", 8.25F);
            textBox1.ForeColor = Color.White;
            textBox1.Location = new Point(710, 3);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(342, 160);
            textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.Black;
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.Font = new Font("Courier New", 8.25F);
            textBox2.ForeColor = Color.White;
            textBox2.Location = new Point(659, 3);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(45, 160);
            textBox2.TabIndex = 3;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Checked = true;
            checkBox1.CheckState = CheckState.Checked;
            checkBox1.Location = new Point(942, 169);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(117, 19);
            checkBox1.TabIndex = 4;
            checkBox1.Text = "Show Debug Info";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(801, 169);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(135, 19);
            checkBox2.TabIndex = 5;
            checkBox2.Text = "Start in Debug Mode";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(762, 314);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(82, 19);
            checkBox3.TabIndex = 6;
            checkBox3.Text = "Shift Quirk";
            checkBox3.UseVisualStyleBackColor = true;
            checkBox3.CheckedChanged += checkBox3_CheckedChanged;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Location = new Point(659, 314);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(87, 19);
            checkBox4.TabIndex = 7;
            checkBox4.Text = "Jump Quirk";
            checkBox4.UseVisualStyleBackColor = true;
            checkBox4.CheckedChanged += checkBox4_CheckedChanged;
            // 
            // checkBox5
            // 
            checkBox5.AutoSize = true;
            checkBox5.Location = new Point(869, 314);
            checkBox5.Name = "checkBox5";
            checkBox5.Size = new Size(71, 19);
            checkBox5.TabIndex = 8;
            checkBox5.Text = "VF Quirk";
            checkBox5.UseVisualStyleBackColor = true;
            checkBox5.CheckedChanged += checkBox5_CheckedChanged;
            // 
            // checkBox6
            // 
            checkBox6.AutoSize = true;
            checkBox6.Location = new Point(969, 314);
            checkBox6.Name = "checkBox6";
            checkBox6.Size = new Size(86, 19);
            checkBox6.TabIndex = 9;
            checkBox6.Text = "Mem Quirk";
            checkBox6.UseVisualStyleBackColor = true;
            checkBox6.CheckedChanged += checkBox6_CheckedChanged;
            // 
            // button1
            // 
            button1.Location = new Point(800, 203);
            button1.Name = "button1";
            button1.Size = new Size(63, 23);
            button1.TabIndex = 10;
            button1.Text = "Reset";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(863, 203);
            button2.Name = "button2";
            button2.Size = new Size(63, 23);
            button2.TabIndex = 11;
            button2.Text = "Pause";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(989, 203);
            button3.Name = "button3";
            button3.Size = new Size(63, 23);
            button3.TabIndex = 12;
            button3.Text = "Load";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(926, 203);
            button4.Name = "button4";
            button4.Size = new Size(63, 23);
            button4.TabIndex = 13;
            button4.Text = "Step";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(797, 247);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 14;
            label1.Text = "Select";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(838, 243);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(171, 23);
            comboBox1.TabIndex = 15;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            comboBox1.KeyPress += comboBox_KeyPress;
            // 
            // button5
            // 
            button5.Font = new Font("Webdings", 12F, FontStyle.Regular, GraphicsUnit.Point, 2);
            button5.Location = new Point(1012, 242);
            button5.Name = "button5";
            button5.Size = new Size(31, 25);
            button5.TabIndex = 16;
            button5.Text = "q";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(812, 275);
            trackBar1.Maximum = 40000;
            trackBar1.Minimum = 20000;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(240, 45);
            trackBar1.TabIndex = 17;
            trackBar1.TickFrequency = 1001;
            trackBar1.TickStyle = TickStyle.None;
            trackBar1.Value = 20000;
            trackBar1.ValueChanged += trackBar1_ValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Location = new Point(816, 296);
            label2.Name = "label2";
            label2.Size = new Size(45, 15);
            label2.TabIndex = 18;
            label2.Text = "normal";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1013, 296);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 19;
            label3.Text = "faster";
            label3.Click += label3_Click;
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog";
            // 
            // label6
            // 
            label6.BackColor = Color.Silver;
            label6.Location = new Point(2, 2);
            label6.Name = "label6";
            label6.Size = new Size(30, 30);
            label6.TabIndex = 22;
            label6.Text = "1/1";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            label7.BackColor = Color.Silver;
            label7.Location = new Point(34, 2);
            label7.Name = "label7";
            label7.Size = new Size(30, 30);
            label7.TabIndex = 23;
            label7.Text = "2/2";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            label8.BackColor = Color.Silver;
            label8.Location = new Point(66, 2);
            label8.Name = "label8";
            label8.Size = new Size(30, 30);
            label8.TabIndex = 24;
            label8.Text = "3/3";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            label9.BackColor = Color.Silver;
            label9.Location = new Point(98, 2);
            label9.Name = "label9";
            label9.Size = new Size(30, 30);
            label9.TabIndex = 25;
            label9.Text = "4/C";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            label10.BackColor = Color.Silver;
            label10.Location = new Point(98, 34);
            label10.Name = "label10";
            label10.Size = new Size(30, 30);
            label10.TabIndex = 29;
            label10.Text = "R/D";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            label11.BackColor = Color.Silver;
            label11.Location = new Point(66, 34);
            label11.Name = "label11";
            label11.Size = new Size(30, 30);
            label11.TabIndex = 28;
            label11.Text = "E/6";
            label11.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            label12.BackColor = Color.Silver;
            label12.Location = new Point(34, 34);
            label12.Name = "label12";
            label12.Size = new Size(30, 30);
            label12.TabIndex = 27;
            label12.Text = "W/5";
            label12.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            label13.BackColor = Color.Silver;
            label13.Location = new Point(2, 34);
            label13.Name = "label13";
            label13.Size = new Size(30, 30);
            label13.TabIndex = 26;
            label13.Text = "Q/4";
            label13.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            label14.BackColor = Color.Silver;
            label14.Location = new Point(98, 98);
            label14.Name = "label14";
            label14.Size = new Size(30, 30);
            label14.TabIndex = 33;
            label14.Text = "V/F";
            label14.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            label15.BackColor = Color.Silver;
            label15.Location = new Point(66, 98);
            label15.Name = "label15";
            label15.Size = new Size(30, 30);
            label15.TabIndex = 32;
            label15.Text = "C/B";
            label15.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            label16.BackColor = Color.Silver;
            label16.Location = new Point(34, 98);
            label16.Name = "label16";
            label16.Size = new Size(30, 30);
            label16.TabIndex = 31;
            label16.Text = "X/0";
            label16.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            label17.BackColor = Color.Silver;
            label17.Location = new Point(2, 98);
            label17.Name = "label17";
            label17.Size = new Size(30, 30);
            label17.TabIndex = 30;
            label17.Text = "Z/A";
            label17.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            label18.BackColor = Color.Silver;
            label18.Location = new Point(98, 66);
            label18.Name = "label18";
            label18.Size = new Size(30, 30);
            label18.TabIndex = 37;
            label18.Text = "F/E";
            label18.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            label19.BackColor = Color.Silver;
            label19.Location = new Point(66, 66);
            label19.Name = "label19";
            label19.Size = new Size(30, 30);
            label19.TabIndex = 36;
            label19.Text = "D/9";
            label19.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            label20.BackColor = Color.Silver;
            label20.Location = new Point(34, 66);
            label20.Name = "label20";
            label20.Size = new Size(30, 30);
            label20.TabIndex = 35;
            label20.Text = "S/8";
            label20.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label21
            // 
            label21.BackColor = Color.Silver;
            label21.Location = new Point(2, 66);
            label21.Name = "label21";
            label21.Size = new Size(30, 30);
            label21.TabIndex = 34;
            label21.Text = "A/7";
            label21.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Black;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label18);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label19);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label20);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(label21);
            panel2.Controls.Add(label13);
            panel2.Controls.Add(label14);
            panel2.Controls.Add(label17);
            panel2.Controls.Add(label15);
            panel2.Controls.Add(label12);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(label16);
            panel2.Controls.Add(label11);
            panel2.Location = new Point(661, 173);
            panel2.Name = "panel2";
            panel2.Size = new Size(132, 132);
            panel2.TabIndex = 38;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1056, 336);
            Controls.Add(panel2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button5);
            Controls.Add(comboBox1);
            Controls.Add(label1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(checkBox6);
            Controls.Add(checkBox5);
            Controls.Add(checkBox4);
            Controls.Add(checkBox3);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(panel1);
            Controls.Add(trackBar1);
            DoubleBuffered = true;
            KeyPreview = true;
            Name = "Form1";
            Text = " ";
            FormClosing += Form1_FormClosing;
            Shown += Form1_Shown;
            KeyDown += Form1_KeyDown;
            KeyUp += Form1_KeyUp;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Panel panel1;
        private TextBox textBox1;
        private TextBox textBox2;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private CheckBox checkBox4;
        private CheckBox checkBox5;
        private CheckBox checkBox6;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Label label1;
        private ComboBox comboBox1;
        private Button button5;
        public TrackBar trackBar1;
        private Label label2;
        private Label label3;
        private OpenFileDialog openFileDialog;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
        private Label label18;
        private Label label19;
        private Label label20;
        private Label label21;
        private Panel panel2;
    }
}
