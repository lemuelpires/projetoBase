using HelperStockBeta.Infra.IoC;
using Microsoft.Extensions.Configuration;
namespace HelperStockBeta.WebUI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInfraStructure(Configuration);
            services.AddControllersWithViews();
        }


    }
}
