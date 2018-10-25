using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Persistence;
using Service;
using Service.IService;

namespace Api_Crud
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
            services.AddDbContext<PersistenceDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("SqlServer")));

            services.AddTransient<IStudentService, StudentService>();

            //seteamos la dependencia
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin", builder =>
                 builder.AllowAnyHeader()
                         .AllowAnyMethod()
                         .AllowAnyOrigin()
                 );
            });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //implementamos el cors
            app.UseCors("AllowSpecificOrigin");

            app.UseMvc();
        }
    }
}
