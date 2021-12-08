using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using ConsoleApp.Services;
using ConsoleApp.Interfaces;

namespace ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create a host to run and manage the services
            var host = Host.CreateDefaultBuilder(args).ConfigureServices(services =>
            {
                services.AddSingleton<ISingleton, MyService>();
                services.AddScoped<IScoped, MyService>();
                services.AddTransient<ITransient, MyService>();
                services.AddTransient<MyLogger>();
            }).Build();

            // Run service in different scopes
            using var serviceScope1 = host.Services.CreateScope();
            {
                IServiceProvider provider = serviceScope1.ServiceProvider;

                provider.GetRequiredService<MyLogger>().CheckServicesId("Scope 1-Call 1");

                Console.WriteLine("...");

                provider.GetRequiredService<MyLogger>().CheckServicesId("Scope 1-Call 1");
            }

            Console.WriteLine();
            
            using var serviceScope2 = host.Services.CreateScope();
            {
                IServiceProvider provider = serviceScope2.ServiceProvider;

                provider.GetRequiredService<MyLogger>().CheckServicesId("Scope 2-Call 1");

                Console.WriteLine("...");

                provider.GetRequiredService<MyLogger>().CheckServicesId("Scope 2-Call 1");
            }

        }
    }
}