﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NotesApp.Skeleton.Repository;

namespace NotesApp.Skeleton
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
            services.AddTransient<INoteRepository, NoteRepository>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use((ctx, next) =>
            {
                KeyValuePair<string, string> serverName = Configuration.AsEnumerable().FirstOrDefault(c => c.Key == "serverName");
                if (serverName.Key != null)
                {
                    ctx.Response.Headers.Add("server-name", serverName.Value);
                }
                return next.Invoke();
            });


            app.UseMvc();
        }
    }
}
