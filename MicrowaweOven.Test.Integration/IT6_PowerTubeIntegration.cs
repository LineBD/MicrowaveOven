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
    //class IT6_PowerTubeIntegration
    //{
    //    private IUserInterface _userinterface;
    //    private IButton _startcancelButton;
    //    private IButton _powerButton;
    //    private IButton _timerButton;
    //    private IDoor _door;
    //    private ILight _light;
    //    private IDisplay _display;
    //    private ICookController _controller;
    //    private IOutput _output;
    //    private ITimer _timer;
    //    private IPowerTube _powerTube;


    //    [SetUp]
    //    public void SetUp()
    //    {
    //        _door = new Door();
    //        _output = Substitute.For<IOutput>();
    //        _light = new Light(_output);
    //        _display = new Display(_output);
    //        _timer = new Timer();
    //        _powerTube = new PowerTube(_output);
    //        _controller = new CookController(_timer, _display, _powerTube);
    //        _startcancelButton = new Button();
    //        _powerButton = new Button();
    //        _timerButton = new Button();
    //        _userinterface = new UserInterface(_powerButton, _timerButton, _startcancelButton, _door, _display, _light, _controller);
    //    }

    //    //Vælger vi ikke at teste på. Da vi tester på outputtet i UIIntegrationstest.
    //}
}
