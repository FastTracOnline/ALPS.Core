using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ALPS.API.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ALPS.Common;

namespace ALPS.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ALPSContext>(options => options.UseSqlServer(connectionString));

            services.AddMvcCore()
                .AddAuthorization()
                .AddJsonFormatters()
                .AddJsonOptions(options =>
                {
                    // handle loops correctly
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

                    // use standard name conversion of properties
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

                    // include $id property in the output
                    options.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
                });

            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication(options =>
                {
					options.Authority = ALPSConstants.IdSrv;
                    options.RequireHttpsMetadata = false;

                    options.ApiName = "api1";
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
