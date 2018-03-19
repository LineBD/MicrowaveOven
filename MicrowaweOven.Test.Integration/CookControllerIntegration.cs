using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicrowaveOvenClasses.Boundary;
using MicrowaveOvenClasses.Controllers;
using MicrowaveOvenClasses.Interfaces;
using NUnit.Framework;
using NUnit.Framework.Internal;
using NSubstitute;

namespace MicrowaweOven.Test.Integration
{
    [TestFixture()]
    class CookControllerIntegration
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
        private ITimer _timer;
        private IPowerTube _powerTube;

        [SetUp]
        public void SetUp()
        {
            _door = new Door();
            _output = Substitute.For<IOutput>();
            _light = Substitute.For<ILight>();
            _display = Substitute.For<IDisplay>();
            _timer = new Timer();
            _powerTube = new PowerTube(_output);
            _controller = new CookController(_timer,_display,_powerTube);
            _startcancelButton = new Button();
            _powerButton = new Button();
            _timerButton = new Button();
            _userinterface = new UserInterface(_powerButton, _timerButton, _startcancelButton, _door, _display, _light, _controller);
        }

        [Test]
        public void CookControllerStart_StartButtonPressed_Started()
        {
            _startcancelButton.Press();

            _output.Received(1).OutputLine("1000");
        }

    }
}
