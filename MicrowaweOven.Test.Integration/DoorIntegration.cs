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
        private IButton _button;
        private IDoor _door;
        private ILight _light;
        private IDisplay _display;
        private ICookController _controller;
        


        public void Setup ()
        {
            _button = Substitute.For<IButton>();
            _door = new Door();
            _light = Substitute.For<Light>();
            _display = Substitute.For<Display>();
            _controller = Substitute.For<CookController>();
            _userinterface = new UserInterface(_button,_button,_button,_door,_display,_light,_controller);
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
        public void ClodeDoor_DoorClosed_LightIsoff()
        {
            _door.Open();
            _door.Close();

            _light.Received(2).TurnOff();
        }

    }
}
