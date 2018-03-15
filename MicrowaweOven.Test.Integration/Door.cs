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
    public class Door
    {
        private UserInterface _userinterface;

        public void Setup ()
        {
            _userinterface = new UserInterface(new IButton(),new IButton(),  );
        }

    }
}
