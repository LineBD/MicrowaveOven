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
    public class DoorIntegration
    {
        private IUserInterface _userinterface;
        private IButton _powerButton;
        private IButton _timerButton;
        private IButton _startcancelButton;
        private IDoor _door;
        private ILight _light;
        private IDisplay _display;
        private ICookController _controller;
        
        [SetUp]

        public void Setup ()
        {
            _powerButton = new Button();
            _timerButton = new Button();
            _startcancelButton = new Button();
            _door = new Door();
            _light = Substitute.For<ILight>();
            _display = Substitute.For<IDisplay>();
            _controller = Substitute.For<ICookController>();
            _userinterface = new UserInterface(_powerButton,_timerButton,_startcancelButton,_door,_display,_light,_controller);
        }

        [Test]
        public void OpenDoor_DoorIsOpened_LightIsOn()
        {
            // act
            _door.Open();
            
            //assert
            _light.Received(1).TurnOn();
        }

        [Test]
        public void CloseDoor_DoorClosed_LightIsoff()
        {
            _door.Open();
            _door.Close();

            _light.Received(1).TurnOff();
        }

        [Test]
        public void OnDoorOpened_OpenDoorWhileCooking_Stop()
        {
            _powerButton.Press();
            _timerButton.Press();
            _startcancelButton.Press();
            _door.Open();

            _controller.Received(1).Stop();
        }

        [Test]
        public void OnDoorOpened_OpenDoorWhileCooking_ClearDisplay()
        {
            _powerButton.Press();
            _timerButton.Press();
            _startcancelButton.Press();
            _door.Open();

            _display.Received(2).Clear();
        }

    }
}
