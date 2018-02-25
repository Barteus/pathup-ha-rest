using System.Collections.Generic;
using System.Linq;
using Amazon;
using Amazon.DynamoDBv2;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NotesApp.Complete.Repository;

namespace NotesApp.Complete
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
            services.AddTransient<IAmazonDynamoDB, AmazonDynamoDBClient>(sp =>
                {
                    AmazonDynamoDBConfig clientConfig = new AmazonDynamoDBConfig();                    
                    clientConfig.RegionEndpoint = RegionEndpoint.USEast1;
                    return new AmazonDynamoDBClient(clientConfig);
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
