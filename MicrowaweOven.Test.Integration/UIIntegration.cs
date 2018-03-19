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
    class UIIntegration
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
        public void OnDoorClosed_DoorOpen_OutputIsCorrect()
        {
            _door.Open();
            _output.Received(1).OutputLine("Light is turned on");
        }

        [Test]
        public void OnDoorOpen_DoorClosed_OutputIsCorrect()
        {
            _door.Open();
            _door.Close();
            _output.Received(1).OutputLine("Light is turned off");
        }

        [Test]
        public void OnPowerPressed_showPower_OutputIsCorrect()
        {
            _powerButton.Press();
            _display.Received().ShowPower(50);
        }

        [Test]
        public void OnTimePressed_showTime_OutputIsCorrect()
        {
            _powerButton.Press();
            _timerButton.Press();
            _display.Received().ShowTime(1, 0);
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

        [Test]
        public void StartCooking_CookingStarted_OutputIsCorrect()
        {
            _powerButton.Press();
            _timerButton.Press();
            _startcancelButton.Press();
            _controller.Received().StartCooking(50,60);
        }

        //[Test]
        //public void StopCooking_CookingStoped_OutputIsCorrect()
        //{
        //    _door.Open();
        //    _door.Close();
        //    _powerButton.Press();
        //    _timerButton.Press();
        //    _startcancelButton.Press();
        //    _display.Received().Clear();
        //    _light.Received().TurnOff();
        //    _controller.Received().Stop();
        //}

        //[Test]
        //public void Clear_EmptyDisplay_OutputIsCorret()
        //{
        //    _door.Open();
        //    _door.Close();
        //    _powerButton.Press();
        //    _timerButton.Press();
        //    _display.Received().Clear();
        //}
    }
}

