using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Uniview.Server
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/{plugin}/{**path}", async context =>
                {
										var plug = (string)context.Request.RouteValues["plugin"];
										var path = (string)context.Request.RouteValues["path"];
										var pathParts = path?.Split("/", options: StringSplitOptions.RemoveEmptyEntries);
                    await context.Response.WriteAsync($"{plug} - {string.Join(" - ", pathParts)}");
                });
            });
        }
    }
}
