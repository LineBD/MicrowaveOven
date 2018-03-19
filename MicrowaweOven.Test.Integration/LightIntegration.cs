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

namespace MicrowaweOven.Test.Integration
{
    [TestFixture]
    class LightIntegration
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

        [SetUp]
        public void SetUp()
        {
            _door = new Door();
            _output = Substitute.For<IOutput>();
            _light = new Light(_output);
            _display = Substitute.For<IDisplay>();
            _controller = Substitute.For<ICookController>();
            _startcancelButton = new Button();
            _powerButton = new Button();
            _timerButton = new Button();
            _userinterface = new UserInterface(_powerButton, _timerButton, _startcancelButton, _door, _display, _light,
                _controller);
        }

        [Test]
        public void TurnOn_LightIsOn_OutputIsCorrect()
        {
            _light.TurnOn();
            _output.OutputLine("Light is turned on");
        }

        [Test]
        public void TurnOff_LightIsOff_OutputIsCorrect()
        {
            _light.TurnOn();
            _light.TurnOff();
            _output.OutputLine("Light is turned off");
        }
    }
}
