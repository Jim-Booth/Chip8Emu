namespace Chip8Emu
{
    partial class mainForm
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
            videoPictureBox = new PictureBox();
            videoBackPanel = new Panel();
            debugTextBox = new TextBox();
            stackTextBox = new TextBox();
            showDebugCheckBox = new CheckBox();
            startInDebugModeCheckBox = new CheckBox();
            shiftQuirkCheckBox = new CheckBox();
            jumpQuirkCheckBox = new CheckBox();
            vfQuirkCheckBox = new CheckBox();
            memQuirkCheckBox = new CheckBox();
            resetButton = new Button();
            pauseButton = new Button();
            loadButton = new Button();
            stepButton = new Button();
            label1 = new Label();
            romComboBox = new ComboBox();
            reloadButton = new Button();
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
            label3 = new Label();
            label2 = new Label();
            trackBar = new TrackBar();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)videoPictureBox).BeginInit();
            videoBackPanel.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar).BeginInit();
            SuspendLayout();
            // 
            // videoPictureBox
            // 
            videoPictureBox.BackColor = Color.FromArgb(0, 16, 0);
            videoPictureBox.Location = new Point(3, 3);
            videoPictureBox.Name = "videoPictureBox";
            videoPictureBox.Size = new Size(640, 320);
            videoPictureBox.TabIndex = 0;
            videoPictureBox.TabStop = false;
            // 
            // videoBackPanel
            // 
            videoBackPanel.BorderStyle = BorderStyle.Fixed3D;
            videoBackPanel.Controls.Add(videoPictureBox);
            videoBackPanel.Location = new Point(3, 3);
            videoBackPanel.Name = "videoBackPanel";
            videoBackPanel.Size = new Size(650, 330);
            videoBackPanel.TabIndex = 1;
            // 
            // debugTextBox
            // 
            debugTextBox.BackColor = Color.Black;
            debugTextBox.BorderStyle = BorderStyle.FixedSingle;
            debugTextBox.Font = new Font("Courier New", 8.25F);
            debugTextBox.ForeColor = Color.White;
            debugTextBox.Location = new Point(710, 3);
            debugTextBox.Multiline = true;
            debugTextBox.Name = "debugTextBox";
            debugTextBox.ReadOnly = true;
            debugTextBox.Size = new Size(342, 160);
            debugTextBox.TabIndex = 2;
            // 
            // stackTextBox
            // 
            stackTextBox.BackColor = Color.Black;
            stackTextBox.BorderStyle = BorderStyle.FixedSingle;
            stackTextBox.Font = new Font("Courier New", 8.25F);
            stackTextBox.ForeColor = Color.White;
            stackTextBox.Location = new Point(659, 3);
            stackTextBox.Multiline = true;
            stackTextBox.Name = "stackTextBox";
            stackTextBox.ReadOnly = true;
            stackTextBox.Size = new Size(45, 160);
            stackTextBox.TabIndex = 3;
            // 
            // showDebugCheckBox
            // 
            showDebugCheckBox.AutoSize = true;
            showDebugCheckBox.Checked = true;
            showDebugCheckBox.CheckState = CheckState.Checked;
            showDebugCheckBox.Location = new Point(942, 169);
            showDebugCheckBox.Name = "showDebugCheckBox";
            showDebugCheckBox.Size = new Size(117, 19);
            showDebugCheckBox.TabIndex = 4;
            showDebugCheckBox.Text = "Show Debug Info";
            showDebugCheckBox.UseVisualStyleBackColor = true;
            // 
            // startInDebugModeCheckBox
            // 
            startInDebugModeCheckBox.AutoSize = true;
            startInDebugModeCheckBox.Location = new Point(801, 169);
            startInDebugModeCheckBox.Name = "startInDebugModeCheckBox";
            startInDebugModeCheckBox.Size = new Size(135, 19);
            startInDebugModeCheckBox.TabIndex = 5;
            startInDebugModeCheckBox.Text = "Start in Debug Mode";
            startInDebugModeCheckBox.UseVisualStyleBackColor = true;
            // 
            // shiftQuirkCheckBox
            // 
            shiftQuirkCheckBox.AutoSize = true;
            shiftQuirkCheckBox.Location = new Point(762, 314);
            shiftQuirkCheckBox.Name = "shiftQuirkCheckBox";
            shiftQuirkCheckBox.Size = new Size(82, 19);
            shiftQuirkCheckBox.TabIndex = 6;
            shiftQuirkCheckBox.Text = "Shift Quirk";
            shiftQuirkCheckBox.UseVisualStyleBackColor = true;
            shiftQuirkCheckBox.CheckedChanged += checkBox3_CheckedChanged;
            // 
            // jumpQuirkCheckBox
            // 
            jumpQuirkCheckBox.AutoSize = true;
            jumpQuirkCheckBox.Location = new Point(659, 314);
            jumpQuirkCheckBox.Name = "jumpQuirkCheckBox";
            jumpQuirkCheckBox.Size = new Size(87, 19);
            jumpQuirkCheckBox.TabIndex = 7;
            jumpQuirkCheckBox.Text = "Jump Quirk";
            jumpQuirkCheckBox.UseVisualStyleBackColor = true;
            jumpQuirkCheckBox.CheckedChanged += checkBox4_CheckedChanged;
            // 
            // vfQuirkCheckBox
            // 
            vfQuirkCheckBox.AutoSize = true;
            vfQuirkCheckBox.Location = new Point(869, 314);
            vfQuirkCheckBox.Name = "vfQuirkCheckBox";
            vfQuirkCheckBox.Size = new Size(71, 19);
            vfQuirkCheckBox.TabIndex = 8;
            vfQuirkCheckBox.Text = "VF Quirk";
            vfQuirkCheckBox.UseVisualStyleBackColor = true;
            vfQuirkCheckBox.CheckedChanged += checkBox5_CheckedChanged;
            // 
            // memQuirkCheckBox
            // 
            memQuirkCheckBox.AutoSize = true;
            memQuirkCheckBox.Location = new Point(969, 314);
            memQuirkCheckBox.Name = "memQuirkCheckBox";
            memQuirkCheckBox.Size = new Size(86, 19);
            memQuirkCheckBox.TabIndex = 9;
            memQuirkCheckBox.Text = "Mem Quirk";
            memQuirkCheckBox.UseVisualStyleBackColor = true;
            memQuirkCheckBox.CheckedChanged += checkBox6_CheckedChanged;
            // 
            // resetButton
            // 
            resetButton.Location = new Point(800, 203);
            resetButton.Name = "resetButton";
            resetButton.Size = new Size(63, 23);
            resetButton.TabIndex = 10;
            resetButton.Text = "Reset";
            resetButton.UseVisualStyleBackColor = true;
            resetButton.Click += button1_Click;
            // 
            // pauseButton
            // 
            pauseButton.Location = new Point(863, 203);
            pauseButton.Name = "pauseButton";
            pauseButton.Size = new Size(63, 23);
            pauseButton.TabIndex = 11;
            pauseButton.Text = "Pause";
            pauseButton.UseVisualStyleBackColor = true;
            pauseButton.Click += button2_Click;
            // 
            // loadButton
            // 
            loadButton.Location = new Point(989, 203);
            loadButton.Name = "loadButton";
            loadButton.Size = new Size(63, 23);
            loadButton.TabIndex = 12;
            loadButton.Text = "Load";
            loadButton.UseVisualStyleBackColor = true;
            loadButton.Click += button3_Click;
            // 
            // stepButton
            // 
            stepButton.Location = new Point(926, 203);
            stepButton.Name = "stepButton";
            stepButton.Size = new Size(63, 23);
            stepButton.TabIndex = 13;
            stepButton.Text = "Step";
            stepButton.UseVisualStyleBackColor = true;
            stepButton.Click += button4_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(798, 239);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 14;
            label1.Text = "Select";
            // 
            // romComboBox
            // 
            romComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            romComboBox.FormattingEnabled = true;
            romComboBox.Location = new Point(839, 235);
            romComboBox.Name = "romComboBox";
            romComboBox.Size = new Size(179, 23);
            romComboBox.TabIndex = 15;
            romComboBox.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            romComboBox.KeyPress += comboBox_KeyPress;
            // 
            // reloadButton
            // 
            reloadButton.Font = new Font("Webdings", 12F, FontStyle.Regular, GraphicsUnit.Point, 2);
            reloadButton.Location = new Point(1021, 234);
            reloadButton.Name = "reloadButton";
            reloadButton.Size = new Size(31, 25);
            reloadButton.TabIndex = 16;
            reloadButton.Text = "q";
            reloadButton.UseVisualStyleBackColor = true;
            reloadButton.Click += button5_Click;
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
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1018, 268);
            label3.Name = "label3";
            label3.Size = new Size(31, 15);
            label3.TabIndex = 19;
            label3.Text = "1000";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Location = new Point(812, 269);
            label2.Name = "label2";
            label2.Size = new Size(19, 15);
            label2.TabIndex = 18;
            label2.Text = "10";
            // 
            // trackBar
            // 
            trackBar.LargeChange = 10;
            trackBar.Location = new Point(808, 279);
            trackBar.Maximum = 1000;
            trackBar.Minimum = 10;
            trackBar.Name = "trackBar";
            trackBar.Size = new Size(240, 45);
            trackBar.SmallChange = 10;
            trackBar.TabIndex = 17;
            trackBar.TickFrequency = 100;
            trackBar.TickStyle = TickStyle.TopLeft;
            trackBar.Value = 10;
            trackBar.ValueChanged += trackBar_ValueChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Location = new Point(893, 271);
            label4.Name = "label4";
            label4.Size = new Size(75, 15);
            label4.TabIndex = 39;
            label4.Text = "cycles/frame";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1056, 336);
            Controls.Add(label4);
            Controls.Add(panel2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(reloadButton);
            Controls.Add(romComboBox);
            Controls.Add(label1);
            Controls.Add(stepButton);
            Controls.Add(loadButton);
            Controls.Add(pauseButton);
            Controls.Add(resetButton);
            Controls.Add(memQuirkCheckBox);
            Controls.Add(vfQuirkCheckBox);
            Controls.Add(jumpQuirkCheckBox);
            Controls.Add(shiftQuirkCheckBox);
            Controls.Add(startInDebugModeCheckBox);
            Controls.Add(showDebugCheckBox);
            Controls.Add(stackTextBox);
            Controls.Add(debugTextBox);
            Controls.Add(videoBackPanel);
            Controls.Add(trackBar);
            DoubleBuffered = true;
            KeyPreview = true;
            Name = "Form1";
            Text = " ";
            FormClosing += Form1_FormClosing;
            Shown += Form1_Shown;
            KeyDown += Form1_KeyDown;
            KeyUp += Form1_KeyUp;
            ((System.ComponentModel.ISupportInitialize)videoPictureBox).EndInit();
            videoBackPanel.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)trackBar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox videoPictureBox;
        private Panel videoBackPanel;
        private TextBox debugTextBox;
        private TextBox stackTextBox;
        private CheckBox showDebugCheckBox;
        private CheckBox startInDebugModeCheckBox;
        private CheckBox shiftQuirkCheckBox;
        private CheckBox jumpQuirkCheckBox;
        private CheckBox vfQuirkCheckBox;
        private CheckBox memQuirkCheckBox;
        private Button resetButton;
        private Button pauseButton;
        private Button loadButton;
        private Button stepButton;
        private Label label1;
        private ComboBox romComboBox;
        private Button reloadButton;
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
        private Label label3;
        private Label label2;
        public TrackBar trackBar;
        private Label label4;
    }
}
