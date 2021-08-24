using Hub.Service.Infrastructure.MongoDb;
using Hub.Service.Middleware;
using Hub.Service.Models;
using Hub.Service.Repositories;
using Hub.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Hub.Service
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
			services.Configure<MongoDBConfig>(o => Configuration.GetSection("MongoDBConfig").Bind(o));					

			services.AddControllers();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo 
				{ 
					Title = "Hub.Service",
					Description = "Demo Api with Mongo Db adn docker",
					Version = "v1"
				});
			});

			services.AddScoped<IProductService, ProductService>();
			services.AddScoped<IProductRepository, ProductRepository>();			
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hub.Service v1"));
			}

			app.UseMiddleware<ErrorMiddleware>();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
