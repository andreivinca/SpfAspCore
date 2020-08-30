using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace SpfAspCore
{
    public static class SPFASPCOREMiddlewareExtensions
    {
        /// <summary>
        /// Configure the MarkdownPageProcessor in Startup.ConfigureServices.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configAction"></param>
        /// <returns></returns>
        public static IServiceCollection AddSpfAspCore(this IServiceCollection services,
            Action<SpfAspCoreConfiguration> configAction = null)

        {
            var provider = services.BuildServiceProvider();
            var configuration = provider.GetService<IConfiguration>();

            var config = new SpfAspCoreConfiguration();
            configuration.Bind("AddSpfAspCore", config);

            SpfAspCoreConfiguration.Current = config;

            if (config.SpfAspCoreEnabled)
            {
#if NETCORE2
                var env = provider.GetService<IHostingEnvironment>();
#else
                var env = provider.GetService<IWebHostEnvironment>();
#endif

                if (configAction != null)
                    configAction.Invoke(config);

                SpfAspCoreConfiguration.Current = config;
            }

            return services;
        }


        /// <summary>
        /// Hook up the Markdown Page Processing functionality in the Startup.Configure method
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseSpfAspCore(this IApplicationBuilder builder)
        {
            var config = SpfAspCoreConfiguration.Current;

            if (config.SpfAspCoreEnabled)
            {
                builder.UseMiddleware<SpfAspCoreMiddleware>();
            }

            return builder;
        }
    }
}
