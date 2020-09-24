using Inseego.Utils.Shared;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using VehicleMaintenceService;

namespace VehicleMaintenceService
{
    /// <summary>
    /// 
    /// </summary>
    public class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            #if DEBUG
                        ILog.Init(true);
            #else
                        ILog.Init();
            #endif

            CreateWebHostBuilder(args).UseUrls("http://0.0.0.0:8080").Build().Run();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
