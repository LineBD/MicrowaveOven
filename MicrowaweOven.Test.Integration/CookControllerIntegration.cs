using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MicrowaveOvenClasses.Boundary;
using MicrowaveOvenClasses.Controllers;
using MicrowaveOvenClasses.Interfaces;
using NUnit.Framework;
using NUnit.Framework.Internal;
using NSubstitute;
using Timer = MicrowaveOvenClasses.Boundary.Timer;

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
       [TestCase(60,10)]
        public void CookControllerStart_StartCooking_PowertubeOn(int power, int time)
        {
            _controller.StartCooking(power,time);

            _output.Received(1).OutputLine($"PowerTube works with {power} %");
        }


        [Test]
        public void CookControllerStop_CookControllerStop_PowerTubeOff()
        {
            _controller.StartCooking(60,10);
            _controller.Stop();

            _output.Received(1).OutputLine("PowerTube turned off");
        }

        [Test]
        [TestCase(50,10000)]
        public void CookControllerStart_CookControllerStart_UntilTimeExpires(int power, int time)
        {
            _controller.StartCooking(50, 10000);
            Thread.Sleep(1000);
            _output.ClearReceivedCalls();
            Thread.Sleep(9000);

            _display.Received(1).ShowTime(0,9);
            
        }

        [Test]
        public void CookControllerStart_CookControllerStart_OnTimerExpired()
        {
            _powerButton.Press();
            _timerButton.Press();
            _startcancelButton.Press();
            _output.ClearReceivedCalls();

            //ManualResetEvent pause = new ManualResetEvent(false);
            //pause.WaitOne(60000);
            Thread.Sleep(61000);

            _output.Received(1).OutputLine("Display cleared");
        }

        [Test]
        [TestCase(50, 10000)]
        public void CookControllerStart_CookControllerStart_CookingIsNOTDone()
        {
            _controller.StartCooking(50, 10000);

            Thread.Sleep(9900);

            _display.DidNotReceive().Clear();
        }


    }
}
