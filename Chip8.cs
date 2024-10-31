using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Chip8Emulator
{
    internal class Chip8
    {
        private bool running = false;

        public bool Running
        {
            get { return running; }
            set { running = value; }
        }

        private bool debugMode = false;

        public bool DebugMode
        {
            get { return debugMode; }
            set { debugMode = value; }
        }

        private bool shiftQuirk = false;

        public bool ShiftQuirk
        {
            get { return shiftQuirk; }
            set { shiftQuirk = value; }
        }

        private bool jumpQuirk = false;

        public bool JumpQuirk
        {
            get { return jumpQuirk; }
            set { jumpQuirk = value; }
        }

        private bool vFReset = false;

        public bool VFReset
        {
            get { return vFReset; }
            set { vFReset = value; }
        }

        private bool memoryQuirk = false;

        public bool MemoryQuirk
        {
            get { return memoryQuirk; }
            set { memoryQuirk = value; }
        }

        private bool displayAvailable = true;

        public bool DisplayAvailable
        {
            get { return displayAvailable; }
        }

        private int simTick = 20000;

        public int SimTick
        {
            get { return simTick; }
            set { simTick = value; }
        }

        public uint KeyDown
        {
            set { Keypad!.@byte![value] = 1; }
        }

        public uint KeyUp
        {
            set { Keypad!.@byte![value] = 0; }
        }

        private int keyStage = 0;

        private bool step = true;

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public class FIXED_BYTE_ARRAY
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 320)]
            public byte[]? @byte;
        }

        private FIXED_BYTE_ARRAY video;

        public FIXED_BYTE_ARRAY Video
        {
            get { return video; }
            set { video = value; }
        }

        private Random RND = new(DateTime.Now.Millisecond);
        private FIXED_BYTE_ARRAY? Registers { get; } = new FIXED_BYTE_ARRAY { @byte = new byte[16] };
        private FIXED_BYTE_ARRAY? Memory { get; } = new FIXED_BYTE_ARRAY { @byte = new byte[4095] };
        private uint I;
        private uint PC;
        private string CurrentOpcodeDescription = String.Empty;
        private uint[] STACK = new uint[16];
        private byte SP = 0;// stack pointer
        private byte ST = 0;// sound timer
        private byte DT = 0;// delay timer
        private FIXED_BYTE_ARRAY Keypad { get; } = new FIXED_BYTE_ARRAY { @byte = new byte[16] };
        private const uint START_ADDRESS = 0x200;
        private const int FONTSET_SIZE = 80;
        private const uint FONTSET_START_ADDRESS = 0x50;
        private const uint VIDEO_WIDTH = 64;
        private const uint VIDEO_HEIGHT = 32;
        private bool PlayingSound;

        private byte[] FONTS { get; } = new byte[FONTSET_SIZE]
        {
            0xF0, 0x90, 0x90, 0x90, 0xF0, // 0
	        0x20, 0x60, 0x20, 0x20, 0x70, // 1
	        0xF0, 0x10, 0xF0, 0x80, 0xF0, // 2
	        0xF0, 0x10, 0xF0, 0x10, 0xF0, // 3
	        0x90, 0x90, 0xF0, 0x10, 0x10, // 4
	        0xF0, 0x80, 0xF0, 0x10, 0xF0, // 5
	        0xF0, 0x80, 0xF0, 0x90, 0xF0, // 6
	        0xF0, 0x10, 0x20, 0x40, 0x40, // 7
	        0xF0, 0x90, 0xF0, 0x90, 0xF0, // 8
	        0xF0, 0x90, 0xF0, 0x10, 0xF0, // 9
	        0xF0, 0x90, 0xF0, 0x90, 0x90, // A
	        0xE0, 0x90, 0xE0, 0x90, 0xE0, // B
	        0xF0, 0x80, 0x80, 0x80, 0xF0, // C
	        0xE0, 0x90, 0x90, 0x90, 0xE0, // D
	        0xF0, 0x80, 0xF0, 0x80, 0xF0, // E
	        0xF0, 0x80, 0xF0, 0x80, 0x80  // F
        };

        public Chip8()
        {
            PC = START_ADDRESS;
            video = new FIXED_BYTE_ARRAY { @byte = new byte[VIDEO_WIDTH * VIDEO_HEIGHT] };
            for (uint i = 0; i < FONTSET_SIZE; i++)
                Memory!.@byte![i] = FONTS[i];
        }

        public void LoadROM(string filePath)
        {
            using (FileStream fs = new(filePath, FileMode.Open, FileAccess.Read))
            {
                BinaryReader br = new(fs);
                long progSize = new FileInfo(filePath).Length;
                byte[] rom = br.ReadBytes((int)progSize);
                if (rom.Length <= Memory!.@byte!.Length)
                    for (long i = 0; i < rom.Length; i++)
                        Memory!.@byte![START_ADDRESS + i] = rom[i];
                else
                    throw new Exception("Memory Overflow");
            }
        }

        public void Start()
        {
            running = true;
            int beat = 0;
            double timerCounter = (DateTime.Now - DateTime.MinValue).TotalMilliseconds;
            while (running)
            {
                var watch = Stopwatch.StartNew();
                uint opcode = ((uint)Memory!.@byte![PC] << 8) | Memory!.@byte![PC + 1];
                uint p = PC;

                // Cycle the CPU
                if (!debugMode)
                    CPUCycle(opcode);
                else
                {
                    while (!step) { }
                    CPUCycle(opcode);
                }

                // update timers at 60hz
                var currentTime = (DateTime.Now - DateTime.MinValue).TotalMilliseconds;
                var milisecondsSinceLastUpdate = currentTime - timerCounter;
                if (milisecondsSinceLastUpdate > 16)
                {
                    UpdateTimers();
                    timerCounter = currentTime;
                }

                // Determine if the program has ended and set running flag to false or just awaiting a keypress
                beat++;
                string op = opcode.ToString("X4");
                bool awaitKey = (op[0] == 'F' && op[2] == '0' && op[3] == 'A');
                if (p != PC || awaitKey)
                    beat = 0;
                if (beat == 100)
                    running = false;

                // Ensures a max 500Hz CPU speed
                while (watch.ElapsedTicks < simTick)
                    if (!running)
                        break;
                watch.Stop();
            }
            running = false;
        }

        public void Pause()
        {
            debugMode = !debugMode;
            if (!debugMode) Step();
        }

        public void Step()
        {
            step = true;
        }

        public void Stop()
        {
            running = false;
        }

        public void CPUCycle(uint opcode)
        {
            PC += 2;
            CallOpcode(opcode);

            if (debugMode)
            {
                step = false;
                while (!step) { }
            }
        }

        private void UpdateTimers()
        {
            if (DT > 0)
                DT--;
            if (ST > 0)
            {
                if (!PlayingSound)
                    Beep(ST);
                ST--;
            }
        }

        public void Beep(uint st)
        {
            Task.Run(() =>
            {
                PlayingSound = true;
                Sound.PlaySound(500, (int)(st * (1000f / 60)));
                PlayingSound = false;
            });
        }

        private void OP_00E0(uint opcode)
        {
            video = new FIXED_BYTE_ARRAY { @byte = new byte[VIDEO_WIDTH * VIDEO_HEIGHT] };
            CurrentOpcodeDescription += " -  CLS";
        }

        private void OP_00EE(uint opcode)
        {
            SP--;
            PC = STACK[SP];
            STACK[SP] = 0x00;
            CurrentOpcodeDescription += " -  RET";
        }

        private void OP_1nnn(uint opcode)
        {
            uint address = (uint)(opcode & (uint)0x0FFF);
            PC = address;
            CurrentOpcodeDescription += " -  JMP   PC #" + PC.ToString("X");
        }

        private void OP_2nnn(uint opcode)
        {
            uint address = (uint)(opcode & (uint)0x0FFF);
            STACK[SP] = PC;
            SP++;
            PC = address;
            CurrentOpcodeDescription += " -  CALL  PC #" + PC.ToString("X");
        }

        private void OP_3xnn(uint opcode)
        {
            uint Vx = (opcode & (uint)0x0F00) >> 8;
            uint b = opcode & (uint)0x00FF;
            if (Registers!.@byte![Vx] == b)
                PC += 2;
            CurrentOpcodeDescription += " -  SNI   V" + Vx.ToString("X") + ", #" + b.ToString("X");
        }

        private void OP_4xnn(uint opcode)
        {
            uint Vx = (opcode & (uint)0x0F00) >> 8;
            uint b = opcode & (uint)0x00FF;
            if (Registers!.@byte![Vx] != b)
                PC += 2;
            CurrentOpcodeDescription += " -  SNI   V" + Vx.ToString("X") + ", #" + b.ToString("X");
        }

        private void OP_5xy0(uint opcode)
        {
            uint Vx = (opcode & (uint)0x0F00) >> 8;
            uint Vy = (opcode & (uint)0x00F0) >> 4;
            if (Registers!.@byte![Vx] == Registers!.@byte![Vy])
                PC += 2;
            CurrentOpcodeDescription += " -  SNI   V" + Vx.ToString("X") + ", V" + Vy.ToString("X");
        }

        private void OP_6xnn(uint opcode)
        {
            uint Vx = (opcode & (uint)0x0F00) >> 8;
            uint b = opcode & (uint)0x00FF;
            Registers!.@byte![Vx] = (byte)b;
            CurrentOpcodeDescription += " -  LD    V" + Vx.ToString("X") + ", #" + b.ToString("X");
        }

        private void OP_7xnn(uint opcode)
        {
            uint Vx = (opcode & (uint)0x0F00) >> 8;
            uint b = opcode & (uint)0x00FF;
            Registers!.@byte![Vx] = (byte)((Registers!.@byte![Vx] + (byte)b) & 0xFF);
            CurrentOpcodeDescription += " -  LD    V" + Vx.ToString("X") + ", #" + b.ToString("X");
        }

        private void OP_8xy0(uint opcode)
        {
            uint Vx = (opcode & (uint)0x0F00) >> 8;
            uint Vy = (opcode & (uint)0x00F0) >> 4;
            Registers!.@byte![Vx] = Registers!.@byte![Vy];
            CurrentOpcodeDescription += " -  LD    V" + Vx.ToString("X") + ", V" + Vy.ToString("X");
        }

        private void OP_8xy1(uint opcode)
        {
            uint Vx = (opcode & (uint)0x0F00) >> 8;
            uint Vy = (opcode & (uint)0x00F0) >> 4;
            Registers!.@byte![Vx] |= Registers!.@byte![Vy];
            if (!vFReset)
                Registers!.@byte![15] = 0;
            CurrentOpcodeDescription += " -  OR    V" + Vx.ToString("X") + ", V" + Vy.ToString("X");
        }

        private void OP_8xy2(uint opcode)
        {
            uint Vx = (opcode & (uint)0x0F00) >> 8;
            uint Vy = (opcode & (uint)0x00F0) >> 4;
            Registers!.@byte![Vx] &= Registers!.@byte![Vy];
            if (!vFReset)
                Registers!.@byte![15] = 0;
            CurrentOpcodeDescription += " -  AND   V" + Vx.ToString("X") + ", V" + Vy.ToString("X");
        }

        private void OP_8xy3(uint opcode)
        {
            uint Vx = (opcode & (uint)0x0F00) >> 8;
            uint Vy = (opcode & (uint)0x00F0) >> 4;
            Registers!.@byte![Vx] ^= Registers!.@byte![Vy];
            if (!vFReset)
                Registers!.@byte![15] = 0;
            CurrentOpcodeDescription += " -  XOR   V" + Vx.ToString("X") + ", V" + Vy.ToString("X");
        }

        private void OP_8xy4(uint opcode)
        {
            uint Vx = (opcode & (uint)0x0F00) >> 8;
            uint Vy = (opcode & (uint)0x00F0) >> 4;
            uint carry = 0;
            if (Registers!.@byte![Vy] > (0xFF - Registers!.@byte![Vx]))
                carry = 1;
            Registers!.@byte![Vx] += Registers!.@byte![Vy];
            Registers!.@byte![15] = (byte)carry;
            CurrentOpcodeDescription += " -  ADD   V" + Vx.ToString("X") + ", V" + Vy.ToString("X") + ", VF";
        }

        private void OP_8xy5(uint opcode)
        {
            uint Vx = (opcode & (uint)0x0F00) >> 8;
            uint Vy = (opcode & (uint)0x00F0) >> 4;
            uint carry = 0;
            if (Registers!.@byte![Vx] >= Registers!.@byte![Vy])
                carry = 1;
            Registers!.@byte![Vx] -= Registers!.@byte![Vy];
            Registers!.@byte![15] = (byte)carry;
            CurrentOpcodeDescription += " -  SUB   V" + Vx.ToString("X") + ", V" + Vy.ToString("X") + ", VF";
        }

        private void OP_8xy6(uint opcode)
        {
            uint Vx = (opcode & (uint)0x0F00) >> 8;
            uint Vy = (opcode & (uint)0x00F0) >> 4;
            uint vx = Registers!.@byte![Vx];
            Registers!.@byte![Vx] = Registers!.@byte![Vy];
            if (shiftQuirk)
                Registers!.@byte![Vx] = (byte)vx;
            Registers!.@byte![Vx] >>= (byte)0x1;
            Registers!.@byte![15] = (byte)(vx & 0x1);
            CurrentOpcodeDescription += " -  SHR   V" + Vx.ToString("X") + ", V" + Vy.ToString("X") + ", VF";
        }

        private void OP_8xy7(uint opcode)
        {
            uint Vx = (opcode & (uint)0x0F00) >> 8;
            uint Vy = (opcode & (uint)0x00F0) >> 4;
            uint sum = (uint)(Registers!.@byte![Vy] - Registers!.@byte![Vx]);
            uint carry = 0;
            if (Registers!.@byte![Vy] >= Registers!.@byte![Vx])
                carry = 1;
            Registers!.@byte![Vx] = (byte)(Registers!.@byte![Vy] - Registers!.@byte![Vx]);
            Registers!.@byte![15] = (byte)carry;
            CurrentOpcodeDescription += " -  SUBN  V" + Vx.ToString("X") + ", V" + Vy.ToString("X") + ", VF";
        }

        private void OP_8xyE(uint opcode)
        {
            uint Vx = (opcode & (uint)0x0F00) >> 8;
            uint Vy = (opcode & (uint)0x00F0) >> 4;
            uint vx = Registers!.@byte![Vx];
            Registers!.@byte![Vx] = Registers!.@byte![Vy];
            if (shiftQuirk)
                Registers!.@byte![Vx] = (byte)vx;
            Registers!.@byte![Vx] <<= (byte)0x1;
            Registers!.@byte![15] = (byte)((vx & 0x80) >> 7);
            CurrentOpcodeDescription += " -  SHL   V" + Vx.ToString("X") + ", V" + Vy.ToString("X") + ", VF";
        }

        private void OP_9xy0(uint opcode)
        {
            uint Vx = (opcode & (uint)0x0F00) >> 8;
            uint Vy = (opcode & (uint)0x00F0) >> 4;
            if (Registers!.@byte![Vx] != Registers!.@byte![Vy])
                PC += 2;
            CurrentOpcodeDescription += " -  SHR   V" + Vx.ToString("X") + ", V" + Vy.ToString("X");
        }

        private void OP_Annn(uint opcode)
        {
            uint address = (opcode & (uint)0x0FFF);
            I = (ushort)address;
            CurrentOpcodeDescription += " -  LD    I #" + I.ToString("X");
        }

        private void OP_Bnnn(uint opcode)
        {
            uint Vx = (opcode & (uint)0x0F00) >> 8;
            uint address = (uint)(opcode & (uint)0x0FFF);
            if (!jumpQuirk)
                PC = address + Registers!.@byte![0];
            else
                PC = address + Registers!.@byte![Vx];
            CurrentOpcodeDescription += " -  JMP   #" + PC.ToString("X");
        }

        private void OP_Cxnn(uint opcode)
        {
            uint Vx = (opcode & (uint)0x0F00) >> 8;
            uint b = (opcode & (uint)0x00FF);
            int r = new Random(DateTime.Now.Millisecond).Next(0, 255);
            Registers!.@byte![Vx] = (byte)(r & b);
            CurrentOpcodeDescription += " -  RND   V" + Vx.ToString("X") + ", #" + Registers!.@byte![Vx].ToString("X");
        }

        private void OP_Dxyn(uint opcode)
        {
            int Vx = (int)((opcode & (uint)0x0F00) >> 8);
            int Vy = (int)((opcode & (uint)0x00F0) >> 4);
            uint height = (uint)(opcode & (uint)0x000F);
            uint xPos = Registers!.@byte![Vx] % VIDEO_WIDTH;
            uint yPos = Registers!.@byte![Vy] % VIDEO_HEIGHT;
            Registers!.@byte![15] = 0;
            for (uint row = 0; row < height; row++)
            {
                uint spriteByte = Memory!.@byte![I + row];
                for (uint col = 0; col < 8; col++)
                {
                    uint vp = (yPos + row) % VIDEO_HEIGHT * VIDEO_WIDTH + (xPos + col) % VIDEO_WIDTH;
                    if ((spriteByte & ((int)0x80 >> (int)col)) != 0)
                    {
                        if (vp != 0 && video!.@byte![vp] == 1)
                            Registers!.@byte![15] = 1;
                        video!.@byte![vp] ^= 1;
                    }
                }
            }
            CurrentOpcodeDescription += " -  DRW   V" + Vx.ToString("X") + ", V" + Vy.ToString("X") + ", " + height;
        }

        private void OP_Ex9E(uint opcode)
        {
            uint Vx = (opcode & (uint)0x0F00) >> 8;
            uint key = (byte)(Registers!.@byte![Vx] & 0x0F);
            if (Keypad!.@byte![key] == 1)
                PC += 2;
            CurrentOpcodeDescription += " -  SKP   V" + Vx.ToString("X");
        }

        private void OP_ExA1(uint opcode)
        {
            uint Vx = (opcode & (uint)0x0F00) >> 8;
            uint key = (byte)(Registers!.@byte![Vx] & 0x0F);
            if (Keypad!.@byte![key] == 0)
                PC += 2;
            CurrentOpcodeDescription += " -  SKP   V" + Vx.ToString("X");
        }

        private void OP_Fx07(uint opcode)
        {
            uint Vx = (opcode & (uint)0x0F00) >> 8;
            Registers!.@byte![Vx] = DT;
            CurrentOpcodeDescription += " -  LD    V" + Vx.ToString("X") + ", DT" + DT;
        }

        private void OP_Fx0A(uint opcode)
        {
            uint Vx = (opcode & (uint)0x0F00) >> 8;
            PC -= 2;
            if(keyStage == 0)
                keyStage = 1;
            if (keyStage == 1)
                for (uint i = 0; i <= 15; i++)
                    if (Keypad!.@byte![i] != 0)
                    {
                        Registers!.@byte![Vx] = (byte)i;
                        keyStage = 2;
                        return;
                    }
            if (keyStage == 2)
                if(Keypad!.@byte![Registers!.@byte![Vx]] == 0)
                {
                    keyStage = 0;
                    PC += 2;
                }
            CurrentOpcodeDescription += " -  LD    V" + Vx.ToString("X");
        }

        private void OP_Fx15(uint opcode)
        {
            uint Vx = (opcode & (uint)0x0F00) >> 8;
            DT = Registers!.@byte![Vx];
            CurrentOpcodeDescription += " -  LD    DT" + DT + ", V" + Vx.ToString("X");
        }

        private void OP_Fx18(uint opcode)
        {
            uint Vx = (opcode & (uint)0x0F00) >> 8;
            ST = Registers!.@byte![Vx];
            CurrentOpcodeDescription += " -  LD    ST" + DT + ", V" + Vx.ToString("X");
        }

        private void OP_Fx1E(uint opcode)
        {
            uint Vx = (opcode & (uint)0x0F00) >> 8;
            I = (I + Registers!.@byte![Vx]) & 0xFFFF;
            CurrentOpcodeDescription += " -  ADD   V" + Vx.ToString("X") + ", [I]";
        }

        private void OP_Fx29(uint opcode)
        {
            uint Vx = (opcode & (uint)0x0F00) >> 8;
            uint digit = (byte)(Registers!.@byte![Vx] & 0x0F);
            I = (digit * 0x05) & 0xFFFF;
            CurrentOpcodeDescription += " -  LD    [I], V" + Vx.ToString("X");
        }

        private void OP_Fx33(uint opcode)
        {
            uint Vx = (opcode & (uint)0x0F00) >> 8;
            uint value = Registers!.@byte![Vx];
            var h = value / 100;
            var t = (value - h * 100) / 10;
            var u = value - h * 100 - t * 10;
            Memory!.@byte![I] = (byte)h;
            Memory!.@byte![I + 1] = (byte)t;
            Memory!.@byte![I + 2] = (byte)u;
            CurrentOpcodeDescription += " -  BCD   V" + Vx.ToString("X") + ", " + h + " " + t + " " + u;
        }

        private void OP_Fx55(uint opcode)
        {
            uint Vx = (opcode & (uint)0x0F00) >> 8;
            uint ii = I;
            for (uint i = 0; i <= Vx; i++)
                Memory!.@byte![I + i] = Registers!.@byte![i];
            if (!memoryQuirk)
                I = (I + Vx + 1) & 0xFFFF;
            CurrentOpcodeDescription += " -  LD    #" + ii + "+, V0-F";
        }

        private void OP_Fx65(uint opcode)
        {
            uint Vx = (opcode & (uint)0x0F00) >> 8;
            uint ii = I;
            for (uint i = 0; i <= Vx; i++)
                Registers!.@byte![i] = Memory!.@byte![I + i];
            if (!memoryQuirk)
                I = (I + Vx + 1) & 0xFFFF;
            CurrentOpcodeDescription += " -  LD    V0-F, #" + ii + "+";
        }

        private void CallOpcode(uint opcode)
        {
            string opHex = opcode.ToString("X4");
            CurrentOpcodeDescription = opHex + "  ";
            if (opHex == "00E0") { OP_00E0(opcode); return; }
            if (opHex == "00EE") { OP_00EE(opcode); return; }
            if (opHex[0] == '0') { return; }
            if (opHex[0] == '1') { OP_1nnn(opcode); return; }
            if (opHex[0] == '2') { OP_2nnn(opcode); return; }
            if (opHex[0] == '3') { OP_3xnn(opcode); return; }
            if (opHex[0] == '4') { OP_4xnn(opcode); return; }
            if (opHex[0] == '6') { OP_6xnn(opcode); return; }
            if (opHex[0] == '7') { OP_7xnn(opcode); return; }
            if (opHex[0] == 'A') { OP_Annn(opcode); return; }
            if (opHex[0] == 'B') { OP_Bnnn(opcode); return; }
            if (opHex[0] == 'C') { OP_Cxnn(opcode); return; }
            if (opHex[0] == 'D') { OP_Dxyn(opcode); return; }
            if (opHex[0] == '5' && opHex[3] == '0') { OP_5xy0(opcode); return; }
            if (opHex[0] == '8' && opHex[3] == '0') { OP_8xy0(opcode); return; }
            if (opHex[0] == '8' && opHex[3] == '1') { OP_8xy1(opcode); return; }
            if (opHex[0] == '8' && opHex[3] == '2') { OP_8xy2(opcode); return; }
            if (opHex[0] == '8' && opHex[3] == '3') { OP_8xy3(opcode); return; }
            if (opHex[0] == '8' && opHex[3] == '4') { OP_8xy4(opcode); return; }
            if (opHex[0] == '8' && opHex[3] == '5') { OP_8xy5(opcode); return; }
            if (opHex[0] == '8' && opHex[3] == '6') { OP_8xy6(opcode); return; }
            if (opHex[0] == '8' && opHex[3] == '7') { OP_8xy7(opcode); return; }
            if (opHex[0] == '8' && opHex[3] == 'E') { OP_8xyE(opcode); return; }
            if (opHex[0] == '9' && opHex[3] == '0') { OP_9xy0(opcode); return; }
            if (opHex[0] == 'E' && opHex[2] == '9' && opHex[3] == 'E') { OP_Ex9E(opcode); return; }
            if (opHex[0] == 'E' && opHex[2] == 'A' && opHex[3] == '1') { OP_ExA1(opcode); return; }
            if (opHex[0] == 'F' && opHex[2] == '0' && opHex[3] == '7') { OP_Fx07(opcode); return; }
            if (opHex[0] == 'F' && opHex[2] == '0' && opHex[3] == 'A') { OP_Fx0A(opcode); return; }
            if (opHex[0] == 'F' && opHex[2] == '1' && opHex[3] == '5') { OP_Fx15(opcode); return; }
            if (opHex[0] == 'F' && opHex[2] == '1' && opHex[3] == '8') { OP_Fx18(opcode); return; }
            if (opHex[0] == 'F' && opHex[2] == '1' && opHex[3] == 'E') { OP_Fx1E(opcode); return; }
            if (opHex[0] == 'F' && opHex[2] == '2' && opHex[3] == '9') { OP_Fx29(opcode); return; }
            if (opHex[0] == 'F' && opHex[2] == '3' && opHex[3] == '3') { OP_Fx33(opcode); return; }
            if (opHex[0] == 'F' && opHex[2] == '5' && opHex[3] == '5') { OP_Fx55(opcode); return; }
            if (opHex[0] == 'F' && opHex[2] == '6' && opHex[3] == '5') { OP_Fx65(opcode); return; }
            throw new Exception("Invalid Opcode");
        }

        public List<string> DebugStackInfo()
        {
            List<string> stak = new();
            stak.Add("STACK");
            for (uint i = 0; i < 15; i++)
                stak.Add(STACK[i].ToString("X"));
            return stak;
        }

        public List<string> DebugMainInfo()
        {
            List<string> info = new();

            info.Add("V0 V1 V2 V3 V4 V5 V6 V7 V8 V9 VA VB VC VD VE VF");
            string reg = "";
            for (uint i = 0; i < 16; i++)
            {
                if (Registers!.@byte![i] < 16) reg += "0";
                reg += Registers!.@byte![i].ToString("X");
                if (i < 15) reg += " ";
            }
            info.Add(reg);
            info.Add("OPCODE = " + CurrentOpcodeDescription);
            info.Add("PC = " + PC / 2);
            info.Add("DT = " + DT.ToString("X"));
            info.Add("ST = " + ST.ToString("X"));
            info.Add("SP = " + SP.ToString("X"));
            info.Add("I = " + I.ToString("X"));
            return info;
        }
    }
}