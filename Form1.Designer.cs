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
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Black;
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
            textBox1.Font = new Font("Courier New", 8.25F);
            textBox1.ForeColor = Color.White;
            textBox1.Location = new Point(710, 3);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(342, 160);
            textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.Black;
            textBox2.Font = new Font("Courier New", 8.25F);
            textBox2.ForeColor = Color.White;
            textBox2.Location = new Point(659, 3);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(45, 160);
            textBox2.TabIndex = 3;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Checked = true;
            checkBox1.CheckState = CheckState.Checked;
            checkBox1.Location = new Point(931, 169);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(126, 19);
            checkBox1.TabIndex = 4;
            checkBox1.Text = "Display Debug Info";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(785, 169);
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
            label1.Location = new Point(793, 247);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 14;
            label1.Text = "Select";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(838, 243);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(171, 23);
            comboBox1.TabIndex = 15;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
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
            trackBar1.Location = new Point(830, 275);
            trackBar1.Maximum = 40000;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(187, 45);
            trackBar1.TabIndex = 17;
            trackBar1.TickFrequency = 1000;
            trackBar1.Value = 20000;
            trackBar1.ValueChanged += trackBar1_ValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(794, 282);
            label2.Name = "label2";
            label2.Size = new Size(41, 15);
            label2.TabIndex = 18;
            label2.Text = "slower";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1010, 284);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 19;
            label3.Text = "faster";
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1056, 336);
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
            Name = "Form1";
            Text = "Form1";
            Shown += Form1_Shown;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
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
    }
}
