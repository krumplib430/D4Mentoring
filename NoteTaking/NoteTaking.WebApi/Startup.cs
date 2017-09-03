using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using NoteTaking.Common.Mapping;
using NoteTaking.Common.Wrappers;
using NoteTaking.DataAccess.Contracts;
using NoteTaking.DataAccess.EfCore.Bootstrap;
using NoteTaking.DataAccess.EfCore.Services;
using NoteTaking.Service;
using NoteTaking.Service.Contracts;
using NoteTaking.WebApi.Bootstrap;
using NoteTaking.WebApi.Repositories;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace NoteTaking.WebApi
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
			services.AddMvc();

			// TODO: move this to autofac modules to appropriate projects
			services.AddTransient<IUserRepository, UserRepository>();
			services.AddTransient<IMappingService, MappingService>();
			services.AddTransient<IUserService, UserService>();
			services.AddTransient<IGuidWrapper, GuidWrapper>();
			services.AddTransient<IDateTimeWrapper, DateTimeWrapper>();
			services.AddTransient<IUserStore, UserStore>();
			services.AddTransient<IUserQuery, UserQuery>();

			// TODO: make this nicer, refactor to extension method etc.
			var mapperConfig = new MapperConfigurationExpression();

			new WebApiMappingConfiguration().Configure(mapperConfig);
			new EfCoreMappingConfiguration().Configure(mapperConfig);

			Mapper.Initialize(mapperConfig);
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseMvc();
		}
	}
}