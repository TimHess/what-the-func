using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Pivotal.Extensions.Configuration.ConfigServer;

namespace Funstore.Web.Admin
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost
                    .CreateDefaultBuilder(args)
                    .UseCloudFoundryHosting()
                    .ConfigureAppConfiguration((builder, config) =>
                    {
                        config.AddConfigServer();
                    })
                    .UseStartup<Startup>();
        }
    }
}
