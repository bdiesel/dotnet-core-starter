using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace TestApp.Controllers
{
    [Route("[controller]")]
    public class AboutController
    {
        [Route("[action]")]
        public string Phone()
        {
            return "555-555-555";
        }

        [Route("[action]")]
        public string Address()
        {
            return "USA";
        }
    }
}
