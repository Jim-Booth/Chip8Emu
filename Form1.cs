using Chip8Emulator;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Chip8Emu
{
    public partial class Form1 : Form
    {
        private Chip8? chip8;

        private Thread? chip8_thread;
        private Thread? displayThread;

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public class FIXED_BYTE_ARRAY
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 320)]
            public byte[]? @byte;
        }

        private FIXED_BYTE_ARRAY? video;

        private int displayScale = 10;

        private int videoWidth = 0;

        private int videoHeight = 0;

        private SolidBrush foreBrush = new SolidBrush(Color.LimeGreen);

        private Color backColor = Color.FromArgb(0, 16, 0);

        private string currentLoadedROM = @"Test.ROM";

        public Form1()
        {
            InitializeComponent();
            SearchForCH8Roms();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            chip8?.Pause();
        }

        private void SetKeyColor(bool down, uint k)
        {
            Color c = Color.White;
            if (!down)
                c = Color.Silver;
            switch (k)
            {
                case 0:
                    label16.BackColor = c;
                    break;

                case 1:
                    label6.BackColor = c;
                    break;

                case 2:
                    label7.BackColor = c;
                    break;

                case 3:
                    label8.BackColor = c;
                    break;

                case 4:
                    label13.BackColor = c;
                    break;

                case 5:
                    label12.BackColor = c;
                    break;

                case 6:
                    label11.BackColor = c;
                    break;

                case 7:
                    label21.BackColor = c;
                    break;

                case 8:
                    label20.BackColor = c;
                    break;

                case 9:
                    label19.BackColor = c;
                    break;

                case 10:
                    label17.BackColor = c;
                    break;

                case 11:
                    label15.BackColor = c;
                    break;

                case 12:
                    label9.BackColor = c;
                    break;

                case 13:
                    label10.BackColor = c;
                    break;

                case 14:
                    label18.BackColor = c;
                    break;

                case 15:
                    label14.BackColor = c;
                    break;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (chip8 != null)
            {
                uint k = GetKeyValue(e);
                if (k != 99)
                    chip8.KeyDown = k;
                SetKeyColor(true, k);
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (chip8 != null)
            {
                uint k = GetKeyValue(e);
                if (k != 99)
                    chip8.KeyUp = k;
                SetKeyColor(false, k);
            }
        }

        private uint GetKeyValue(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D1)
                return 1;
            if (e.KeyCode == Keys.D2)
                return 2;
            if (e.KeyCode == Keys.D3)
                return 3;
            if (e.KeyCode == Keys.D4)
                return 12;
            if (e.KeyCode == Keys.Q)
                return 4;
            if (e.KeyCode == Keys.W)
                return 5;
            if (e.KeyCode == Keys.E)
                return 6;
            if (e.KeyCode == Keys.R)
                return 13;
            if (e.KeyCode == Keys.A)
                return 7;
            if (e.KeyCode == Keys.S)
                return 8;
            if (e.KeyCode == Keys.D)
                return 9;
            if (e.KeyCode == Keys.F)
                return 14;
            if (e.KeyCode == Keys.Z)
                return 10;
            if (e.KeyCode == Keys.X)
                return 0;
            if (e.KeyCode == Keys.C)
                return 11;
            if (e.KeyCode == Keys.V)
                return 15;
            return 99;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Reset();
            currentLoadedROM = @"Test.ROM";
            Execute(currentLoadedROM);
            if (!String.IsNullOrEmpty(comboBox1.Text))
                comboBox1.Text = String.Empty;
            button2.Text = "Pause";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            chip8!.Pause();
            if (!checkBox1.Checked)
            {
                textBox1.Text = "";
                textBox2.Text = "";
            }
            if (chip8.DebugMode)
                button2.Text = "Run";
            else
                button2.Text = "Pause";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                comboBox1.SelectedIndex = -1;
                Reset();
                currentLoadedROM = openFileDialog.FileName;
                Execute(currentLoadedROM);
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Reset();
            Execute(currentLoadedROM);
        }

        private void Reset()
        {
            if (chip8 is not null)
            {
                chip8!.Running = false;
                chip8.Stop();
                while (chip8.Running)
                {
                    chip8.Stop();
                    chip8_thread = null;
                }
                while (chip8_thread is not null && chip8_thread!.IsAlive)
                    chip8_thread = null;
            }
            panel1.BackColor = Color.Red;
            trackBar1.Value = 20000;
        }

        private void Execute(string romPath)
        {
            if (checkBox2.Checked)
                button2.Text = "Run";
            trackBar1.Value = 20000;
            panel1.BackColor = Color.Black;

            // start Chip8 in it's own thread
            chip8 = new Chip8(romPath);
            chip8.ShiftQuirk = checkBox3.Checked;
            chip8.VFReset = checkBox5.Checked;
            chip8.JumpQuirk = checkBox4.Checked;
            chip8.MemoryQuirk = checkBox6.Checked;
            chip8.DebugMode = checkBox2.Checked;
            chip8_thread = new Thread(() => chip8.Start());
            chip8_thread.IsBackground = true;
            chip8_thread.Start();

            // create and update form display in it's own thread
            videoWidth = chip8.VideoWidth;
            videoHeight = chip8.VideoHeight;
            video = new FIXED_BYTE_ARRAY { @byte = new byte[videoWidth * videoHeight] };
            displayThread = new Thread(() => DisplayThreadLoop());
            displayThread.IsBackground = true;
            displayThread.Start();
        }

        private void DisplayThreadLoop()
        {
            while (!chip8!.Running) { }
            while (chip8.Running)
            {
                if (chip8!.DisplayUpdated)
                    RenderScreen();
                RenderDebugInfo();               
            }
            panel1.BackColor = Color.Red;
        }

        private void RenderDebugInfo()
        {
            if (checkBox1.Checked && chip8!.Running)
            {
                textBox1.Invoke((MethodInvoker)(() => textBox1.Text = String.Join(Environment.NewLine, chip8!.DebugMainInfo())));
                textBox2.Invoke((MethodInvoker)(() => textBox2.Text = String.Join(Environment.NewLine, chip8!.DebugStackInfo())));
            }
        }
        private void RenderScreen()
        {
            video!.@byte = chip8!.Video.@byte;
            Bitmap outputBitmap = new(videoWidth * displayScale, videoHeight * displayScale);
            int videoBytePointer = 0;
            using (Graphics graphics = Graphics.FromImage(outputBitmap))
                for (int y = 0; y < videoHeight * displayScale; y += displayScale)
                    for (int x = 0; x < videoWidth * displayScale; x += displayScale)
                        if (video!.@byte![videoBytePointer++] != 0)
                            graphics.FillRectangle(foreBrush, x, y, displayScale, displayScale);
            pictureBox1.Invoke((MethodInvoker)delegate { pictureBox1.Image = outputBitmap; });
        }

        private void SearchForCH8Roms()
        {
            var myFiles = Directory.EnumerateFiles(Application.StartupPath, @"ROMS\*.*");
            foreach (var file in myFiles)
                comboBox1.Items.Add(Path.GetFileName(file));
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Reset();
            if (comboBox1.SelectedIndex > -1)
                if (!String.IsNullOrEmpty(comboBox1.SelectedItem!.ToString()))
                    Execute(@"ROMS\" + comboBox1.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            chip8!.Step();
            textBox1.Invoke((MethodInvoker)(() => textBox1.Text = String.Join(Environment.NewLine, chip8.DebugMainInfo())));
            textBox2.Invoke((MethodInvoker)(() => textBox2.Text = String.Join(Environment.NewLine, chip8.DebugStackInfo())));
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            chip8!.JumpQuirk = checkBox4.Checked;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            chip8!.ShiftQuirk = checkBox3.Checked;
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            chip8!.VFReset = checkBox5.Checked;
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            chip8!.MemoryQuirk = checkBox6.Checked;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            int val = trackBar1.Maximum - trackBar1.Value;
            if (chip8 != null)
                if (val <= 20000)
                    chip8.SimTick = val;
                else
                {
                    var x = (val - 20000) * 50;
                    chip8.SimTick = x;
                }
        }

        private void comboBox_KeyPress(object sender, KeyPressEventArgs e)
        { e.KeyChar = (char)Keys.None; }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.Length != 0)
                comboBox1_SelectedIndexChanged(this, e);
            else
                Form1_Shown(sender, e);
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }
    }
}