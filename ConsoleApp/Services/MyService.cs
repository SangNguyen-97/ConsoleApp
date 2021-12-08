using ConsoleApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Services
{
    internal class MyService : 
    ITransient,
    IScoped,
    ISingleton
    {
        public string ServiceId { get; set; } = Guid.NewGuid().ToString()[^4..];
    }
}
