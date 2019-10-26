using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace POCAttribute
{
    public class Startup
    {
        IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services
            .AddLogging()
            .AddOptions()
            .AddApplicationInsightsTelemetry();
        }
    }
}