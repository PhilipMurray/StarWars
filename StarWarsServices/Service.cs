using System;
using System.Collections.Generic;
using System.Text;

namespace StarWarsServices
{
    public class Service : IService
    {
        public string SayHello()
        {
            return "Hello from IService Implementation";
        }
    }
}
