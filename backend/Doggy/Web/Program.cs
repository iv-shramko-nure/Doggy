using Autofac;
using Autofac.Extensions.DependencyInjection;
using Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                //.ConfigureAppConfiguration((hostingContext, config) =>
                //{
                //    config.AddJsonFile(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).ToString(), "config.json"), optional: false, reloadOnChange: false);
                //})
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureContainer<ContainerBuilder>(containerBuilder =>
                {
                    containerBuilder.RegisterBuildCallback(ctx => IoC.Container = ctx.Resolve<ILifetimeScope>());
                    BLL.Startup.Bootstrapper.Bootstrap(containerBuilder);
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
