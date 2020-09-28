using System;
using System.Collections.Generic;
using System.Text;

namespace StarWarsServices
{
    public class ApplicationService 
    {
        private readonly IService _service;

        public ApplicationService(IService service)
        {
            _service = service;
        }

        public string Run()
        {
            return _service.SayHello();
        }
    }
}
