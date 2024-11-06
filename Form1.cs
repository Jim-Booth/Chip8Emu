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
        private FIXED_BYTE_ARRAY? video;
        private readonly int displayScale = 10;
        private int videoWidth = 0;
        private int videoHeight = 0;
        private readonly SolidBrush foreBrush = new SolidBrush(Color.LimeGreen);
        private string currentLoadedROM = @"Test.ROM";
        private object lockObject = new object();

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public class FIXED_BYTE_ARRAY
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 320)]
            public byte[]? @byte;
        }

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
            if (k == 0) label16.BackColor = c;
            if (k == 1) label6.BackColor = c;
            if (k == 2) label7.BackColor = c;
            if (k == 3) label8.BackColor = c;
            if (k == 4) label13.BackColor = c;
            if (k == 5) label12.BackColor = c;
            if (k == 6) label11.BackColor = c;
            if (k == 7) label21.BackColor = c;
            if (k == 8) label20.BackColor = c;
            if (k == 9) label19.BackColor = c;
            if (k == 10) label17.BackColor = c;
            if (k == 11) label15.BackColor = c;
            if (k == 12) label9.BackColor = c;
            if (k == 13) label10.BackColor = c;
            if (k == 14) label18.BackColor = c;
            if (k == 15) label14.BackColor = c;
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
            if (e.KeyCode == Keys.D1) return 1;
            if (e.KeyCode == Keys.D2) return 2;
            if (e.KeyCode == Keys.D3) return 3;
            if (e.KeyCode == Keys.D4) return 12;
            if (e.KeyCode == Keys.Q) return 4;
            if (e.KeyCode == Keys.W) return 5;
            if (e.KeyCode == Keys.E) return 6;
            if (e.KeyCode == Keys.R) return 13;
            if (e.KeyCode == Keys.A) return 7;
            if (e.KeyCode == Keys.S) return 8;
            if (e.KeyCode == Keys.D) return 9;
            if (e.KeyCode == Keys.F) return 14;
            if (e.KeyCode == Keys.Z) return 10;
            if (e.KeyCode == Keys.X) return 0;
            if (e.KeyCode == Keys.C) return 11;
            if (e.KeyCode == Keys.V) return 15;
            return 99;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Reset();
            currentLoadedROM = @"Test.ROM";
            Execute(currentLoadedROM);
            if (!String.IsNullOrEmpty(romComboBox.Text))
                romComboBox.Text = String.Empty;
            pauseButton.Text = "Pause";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            chip8!.Pause();
            if (!showDebugCheckBox.Checked)
            {
                debugTextBox.Text = "";
                stackTextBox.Text = "";
            }
            if (chip8.DebugMode)
                pauseButton.Text = "Run";
            else
                pauseButton.Text = "Pause";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                romComboBox.SelectedIndex = -1;
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
            while (displayThread is not null && displayThread!.IsAlive)
                displayThread = null;
            while (chip8_thread is not null && chip8_thread!.IsAlive)
                chip8_thread = null;
            videoBackPanel.BackColor = Color.Red;
            trackBar.Value = 20000;
        }

        private void Execute(string romPath)
        {
            if (startInDebugModeCheckBox.Checked)
                pauseButton.Text = "Run";
            trackBar.Value = 20000;

            // start Chip8 in it's own thread
            chip8 = new Chip8
            {
                ShiftQuirk = shiftQuirkCheckBox.Checked,
                VFReset = vfQuirkCheckBox.Checked,
                JumpQuirk = jumpQuirkCheckBox.Checked,
                MemoryQuirk = memQuirkCheckBox.Checked,
                DebugMode = startInDebugModeCheckBox.Checked
            };
            chip8_thread = new Thread(() => chip8.Start(romPath))
            {
                IsBackground = true
            };
            chip8_thread.Start();

            // create and update form display in it's own thread
            videoWidth = chip8.VideoWidth;
            videoHeight = chip8.VideoHeight;
            video = new FIXED_BYTE_ARRAY { @byte = new byte[videoWidth * videoHeight] };
            displayThread = new Thread(() => DisplayThreadLoop())
            {
                IsBackground = true
            };
            displayThread.Start();
        }

        private void DisplayThreadLoop()
        {
            while (!chip8!.Running) { }
            while (chip8.Running)
            {
                if (chip8.DisplayUpdated)
                    RenderScreen();
                RenderDebugInfo();               
            }
            videoBackPanel.BackColor = Color.Red;
        }

        private void RenderDebugInfo()
        {
            if (showDebugCheckBox.Checked && chip8!.Running)
            {
                debugTextBox.Invoke((MethodInvoker)(() => debugTextBox.Text = String.Join(Environment.NewLine, chip8!.DebugMainInfo())));
                stackTextBox.Invoke((MethodInvoker)(() => stackTextBox.Text = String.Join(Environment.NewLine, chip8!.DebugStackInfo())));
            }
        }
        private void RenderScreen()
        {
            video!.@byte = chip8!.Video!.@byte;
            Bitmap initalBitmap = new(videoWidth * displayScale, videoHeight * displayScale);
            int videoBytePointer = 0;
            using (Graphics graphics = Graphics.FromImage(initalBitmap))
                for (int y = 0; y < videoHeight * displayScale; y += displayScale)
                    for (int x = 0; x < videoWidth * displayScale; x += displayScale)
                        if (video!.@byte![videoBytePointer++] != 0)
                            try { graphics.FillRectangle(foreBrush, x, y, displayScale, displayScale); } catch { }
            videoPictureBox.Invoke((MethodInvoker)delegate { videoPictureBox.Image = initalBitmap; });
        }

        private void SearchForCH8Roms()
        {
            var myFiles = Directory.EnumerateFiles(Application.StartupPath, @"ROMS\*.*");
            foreach (var file in myFiles)
                romComboBox.Items.Add(Path.GetFileName(file));
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Reset();
            if (romComboBox.SelectedIndex > -1)
                if (!String.IsNullOrEmpty(romComboBox.SelectedItem!.ToString()))
                    Execute(@"ROMS\" + romComboBox.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            chip8!.Step();
            RenderDebugInfo();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            chip8!.JumpQuirk = jumpQuirkCheckBox.Checked;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            chip8!.ShiftQuirk = shiftQuirkCheckBox.Checked;
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            chip8!.VFReset = vfQuirkCheckBox.Checked;
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            chip8!.MemoryQuirk = memQuirkCheckBox.Checked;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            int val = trackBar.Maximum - trackBar.Value;
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
            if (romComboBox.Text.Length != 0)
                comboBox1_SelectedIndexChanged(this, e);
            else
                Form1_Shown(sender, e);
        }
    }
}