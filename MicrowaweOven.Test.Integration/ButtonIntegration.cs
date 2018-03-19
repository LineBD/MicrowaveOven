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
    class ButtonIntegration
    {
        private IUserInterface _userinterface;
        private IButton _startcancelButton;
        private IButton _powerButton;
        private IButton _timerButton;
        private IDoor _door;
        private ILight _light;
        private IDisplay _display;
        private ICookController _controller;

        [SetUp]
        public void SetUp()
        {
            _door=new Door();
            _light = Substitute.For<ILight>();
            _display = Substitute.For<IDisplay>();
            _controller = Substitute.For<ICookController>();
            _startcancelButton=new Button();
            _powerButton=new Button();
            _timerButton=new Button();
            _userinterface=new UserInterface(_powerButton,_timerButton,_startcancelButton,_door,_display,_light,_controller);
        }

        [Test]
        public void PowerOn_PowerOnPressed_ShowPowerOnDisplay()
        {
            _powerButton.Press();
            _display.Received(1).ShowPower(50);
            
        }

        [Test]
        public void TimerOn_TimerPressed_ShowTime()
        {
            _timerButton.Press();

            _display.Received(1).ShowTime(01,00);

            //Hvorfor fungerer den ikke, når det kører over?
        }
    }
}
