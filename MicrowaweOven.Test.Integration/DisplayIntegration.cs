using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicrowaveOvenClasses.Boundary;
using MicrowaveOvenClasses.Controllers;
using MicrowaveOvenClasses.Interfaces;
using NUnit.Framework;
using NSubstitute;

namespace MicrowaweOven.Test.Integration
{
    [TestFixture]
    class DisplayIntegration
    {
        private IUserInterface _userinterface;
        private IButton _startcancelButton;
        private IButton _powerButton;
        private IButton _timerButton;
        private IDoor _door;
        private ILight _light;
        private IDisplay _display;
        private ICookController _controller;
        private IOutput _output;
        private int power;
        private int min;
        private int sec;

        [SetUp]
        public void SetUp()
        {
            _door = new Door();
            _light = new Light(_output);
            _display = new Display(_output);
            _controller = Substitute.For<ICookController>();
            _output = Substitute.For<IOutput>();
            _startcancelButton = new Button();
            _powerButton = new Button();
            _timerButton = new Button();
            _userinterface = new UserInterface(_powerButton, _timerButton, _startcancelButton, _door, _display, _light, _controller);
        }

        [Test]

        public void LogLine_OutPutLineIsCorrectPower_ShowOutput()
        {
            _powerButton.Press();
            _output.Received().OutputLine($"Display shows: {power} W");

        }
        [Test]

        public void LogLine_OutputLineIsCorrectTime_ShowOutput()
        {
            _timerButton.Press();

            _output.Received().OutputLine($"Display shows: 01:00");
        }
        

    }
}
