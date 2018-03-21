using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicrowaveOvenClasses.Boundary;
using MicrowaveOvenClasses.Controllers;

namespace MicrowaveOven.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            // Setup
            var door = new Door();
            var powerButton = new Button();
            var timeButton = new Button();
            var startCancelButton = new Button();
            var output = new Output();
            var display = new Display(output);
            var light = new Light(output);
            var powerTube = new PowerTube(output);
            var timer = new Timer();
            var cookController = new CookController(timer, display, powerTube);
            var userInterface = new UserInterface(powerButton, timeButton, startCancelButton, door, display, light, cookController);
            cookController.UI = userInterface;
      

            // User activities 
            door.Open();
            door.Close();
            powerButton.Press();
            timeButton.Press();
            startCancelButton.Press();

            System.Console.WriteLine("Tast enter når applikationen skal afsluttes");
            System.Console.ReadLine();



        }
    }
}
