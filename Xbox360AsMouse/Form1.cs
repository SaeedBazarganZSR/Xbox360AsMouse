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
        //private IMouseSimulator _mouseSimulator;
        private System.Threading.Timer _timer;

        public Form1()
        {
            InitializeComponent();
            _controller = new Controller(UserIndex.One);
            //_mouseSimulator = new InputSimulator().Mouse;
            _timer = new System.Threading.Timer(obj => Update());
        }
        public void Start()
        {
            _timer.Change(0, 1000 / 60);
        }
        private void Update()
        {
            _controller.GetState(out var _state);

            //Movement(_state);
            //scroll(_state);

            Button_A(_state);
            Button_B(_state);
            Button_Y(_state);
            Button_X(_state);

            Button_Start(_state);
            Button_Back(_state);

            Button_DPadDown(_state);
            Button_DPadUp(_state);
            Button_DPadLeft(_state);
            Button_DPadRight(_state);
        }
        private void Movement(State state)
        {
            //var x = state.Gamepad.LeftThumbX / 2_000;
            //var y = state.Gamepad.LeftThumbY / 2_000;
            //_mouseSimulator.MoveMouseBy(x, -y);
        }
        private void scroll(State state)
        {
            //var x = state.Gamepad.RightThumbX / 10_000;
            //var y = state.Gamepad.RightThumbY / 10_000;
            //_mouseSimulator.HorizontalScroll(x);
            //_mouseSimulator.VerticalScroll(y);
        }
        //////////////////////////////////
        private void Button_A(State state)
        {
            var isAdown = state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.A);
            if (isAdown) Console.WriteLine("AAAAA: {0}", isAdown);
        }
        private void Button_B(State state)
        {
            var isBdown = state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.B);
            if (isBdown) Console.WriteLine("BBBB: {0}", isBdown);
        }
        private void Button_Y(State state)
        {
            var isYdown = state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Y);
            if (isYdown) Console.WriteLine("YYYY: {0}", isYdown);
        }
        private void Button_X(State state)
        {
            var isXdown = state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.X);
            if (isXdown) Console.WriteLine("XXXX: {0}", isXdown);
        }
        private void Button_Start(State state)
        {
            var isStartdown = state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Start);
            if (isStartdown) Console.WriteLine("Start: {0}", isStartdown);
        }
        private void Button_Back(State state)
        {
            var isBackdown = state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Back);
            if (isBackdown) Console.WriteLine("Back: {0}", isBackdown);
        }
        //////////////////////////////////
        private void Button_DPadDown(State state)
        {
            var isDPadDowndown = state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadDown);
            if (isDPadDowndown) Console.WriteLine("DPadDown: {0}", isDPadDowndown);
        }
        private void Button_DPadUp(State state)
        {
            var isDPadUpdown = state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadUp);
            if (isDPadUpdown) Console.WriteLine("DPadUp: {0}", isDPadUpdown);
        }
        private void Button_DPadLeft(State state)
        {
            var isDPadLeftdown = state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadLeft);
            if (isDPadLeftdown) Console.WriteLine("DPadLeft: {0}", isDPadLeftdown);
        }
        private void Button_DPadRight(State state)
        {
            var isDPadRightdown = state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadRight);
            if (isDPadRightdown) Console.WriteLine("DPadRight: {0}", isDPadRightdown);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Update();
            Start();
        }
    }
}
