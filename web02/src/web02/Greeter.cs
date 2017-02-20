using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web02
{
    public interface IGreeter
    {
        string GetGreeting();
    }
    public class Greeter : IGreeter
    {
        private readonly IConfiguration _config;

        public Greeter(IConfiguration config)
        {
            _config = config;
        }

        public string GetGreeting()
        {
            return $"It' says '{_config["greeting"]}'.";
        }
    }
}
