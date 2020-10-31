using exercice1.Controllers;
using exercice1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Enumeration;
using System.Linq;
using System.Reflection;

namespace exercice1
{
    class Program
    {
        static void Main(string[] args)
        {
            //no user input : Let the controller start and do the tests
            new StationController().Start();
        }
    }
}
