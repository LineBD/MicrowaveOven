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
        private IButton _button1;
        private IButton _button2;
        private IButton _button3;
        private IDoor _door;
        private ILight _light;
        private IDisplay _display;
        private ICookController _controller;
        
        [SetUp]

        public void Setup ()
        {
            _button1 = Substitute.For<IButton>();
            _button2 = Substitute.For<IButton>();
            _button3 = Substitute.For<IButton>();
            _door = new Door();
            _light = Substitute.For<ILight>();
            _display = Substitute.For<IDisplay>();
            _controller = Substitute.For<ICookController>();
            _userinterface = new UserInterface(_button1,_button2,_button3,_door,_display,_light,_controller);
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

    }
}
