using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicrowaveOvenClasses.Boundary;
using MicrowaveOvenClasses.Controllers;
using MicrowaveOvenClasses.Interfaces;
using NSubstitute;
using NUnit.Framework;
using System.Threading;
using Timer = MicrowaveOvenClasses.Boundary.Timer;

namespace MicrowaweOven.Test.Integration
{
    [TestFixture]
    class IT5_TimerIntegration
    {
        private IUserInterface _userinterface;
        private IButton _startcancelButton;
        private IButton _powerButton;
        private IButton _timerButton;
        private IDoor _door;
        private ILight _light;
        private IDisplay _display;
        private CookController _controller;
        private IOutput _output;
        private ITimer _timer;
        private IPowerTube _powertube;

        [SetUp]
        public void SetUp()
        {
            _door = new Door();
            _output = Substitute.For<IOutput>();
            _startcancelButton = new Button();
            _powerButton = new Button();
            _timerButton = new Button();

            _timer = new Timer();
            _light = new Light(_output);
            _display = new Display(_output);
            _powertube = Substitute.For<IPowerTube>();

            _controller = new CookController(_timer, _display, _powertube);
            _userinterface = new UserInterface(_powerButton, _timerButton, _startcancelButton, _door, _display, _light,
                _controller);
            _controller.UI = _userinterface;

        }

        [Test]
        public void OnTimerTick_TimerButtonPressedOnce_OutputIsCorrect()
        {
            _powerButton.Press();
            _timerButton.Press();
            _startcancelButton.Press();
            Thread.Sleep(1100);
            _output.Received().OutputLine("Display shows: 00:59");


        }

        [Test]
        public void OnTimerTick_TimerButtonPressedTwice_OutputIsCorrect()
        {
            _powerButton.Press();
            _timerButton.Press();
            _timerButton.Press();
            _startcancelButton.Press();
            Thread.Sleep(1050);
            _output.Received().OutputLine("Display shows: 01:59");

        }

        [Test]
        public void OnTimertick_PowerButtonPressedOnce_OutputIsCorrect()
        {
            _powerButton.Press();
            _timerButton.Press();
            _startcancelButton.Press();
            _output.Received().OutputLine("Display shows: 50 W");

        }
        [Test]
        public void OnTimerTick_TimeRunsOut_OutputIsCorrect()
        {
            _powerButton.Press();
            _timerButton.Press();
            _startcancelButton.Press();
            Thread.Sleep(60000);
            _output.Received().OutputLine("Display cleared");

        }
    }
}