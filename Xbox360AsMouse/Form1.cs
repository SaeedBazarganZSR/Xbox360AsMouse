using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using WindowsInput;
using SharpDX.XInput;
using System.Threading;

namespace Xbox360AsMouse
{
    public partial class Form1 : Form
    {
        private Controller _controller;
        private IMouseSimulator _mouseSimulator;
        private System.Threading.Timer _timer;
        private bool _wasAdown;
        private bool _wasBdown;

        public Form1()
        {
            InitializeComponent();
            _controller = new Controller(UserIndex.One);
            _mouseSimulator = new InputSimulator().Mouse;
            _timer = new System.Threading.Timer(obj => Update());
            //_timer = new Timer(object => Update);
        }
        public void Start()
        {
            _timer.Change(0, 1000 / 60);
        }
        private void Update()
        {
            _controller.GetState(out var _state);
            Movement(_state);
            scroll(_state);
            LeftButton(_state);
            RightButton(_state);
        }
        private void Movement(State state)
        {
            var x = state.Gamepad.LeftThumbX / 2_000;
            var y = state.Gamepad.LeftThumbY / 2_000;
            _mouseSimulator.MoveMouseBy(x, -y);
        }
        private void scroll(State state)
        {
            var x = state.Gamepad.RightThumbX / 10_000;
            var y = state.Gamepad.RightThumbY / 10_000;
            _mouseSimulator.HorizontalScroll(x);
            _mouseSimulator.VerticalScroll(y);
        }
        private void LeftButton(State state)
        {
            var isAdown = state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.A);
            if (isAdown && !_wasAdown) _mouseSimulator.LeftButtonDown();
            if (isAdown && _wasAdown) _mouseSimulator.LeftButtonUp();
            _wasAdown = isAdown;
        }
        private void RightButton(State state)
        {
            var isBdown = state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.B);
            if (isBdown && !_wasBdown) _mouseSimulator.RightButtonDown();
            if (isBdown && _wasBdown) _mouseSimulator.RightButtonUp();
            _wasAdown = isBdown;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Start();
            Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxx");
            Console.ReadLine();
        }
    }
}
