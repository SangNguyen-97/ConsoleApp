using ConsoleApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Services
{
    internal class MyLogger
    {
        private readonly ITransient _tran;
        private readonly IScoped _scoped;
        private readonly ISingleton _sing;

        public MyLogger(ITransient tran, IScoped scoped, ISingleton sing)
        {
            _tran = tran;
            _scoped = scoped;
            _sing = sing;
        }

        public void CheckServicesId(string scope)
        {
            LogServiceId(_tran, scope, "Always differs");
            LogServiceId(_scoped, scope, "Each scope differs");
            LogServiceId(_sing, scope, "Always same");
        }

        private static void LogServiceId<T>(T service, string scope, string message) where T : IOperation
        {
            Console.WriteLine($"{scope}: {typeof(T).Name,-19} [ {service.ServiceId}...{message,-23} ]");
        }
    }
}
