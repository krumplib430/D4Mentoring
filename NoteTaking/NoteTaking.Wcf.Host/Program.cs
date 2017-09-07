using System;
using System.ServiceModel;
using Autofac;
using Autofac.Integration.Wcf;
using AutoMapper;
using AutoMapper.Configuration;
using NoteTaking.Common.Mapping;
using NoteTaking.Common.Wrappers;
using NoteTaking.DataAccess.Contracts;
using NoteTaking.DataAccess.EfCore.Bootstrap;
using NoteTaking.DataAccess.EfCore.Services;
using NoteTaking.Models;
using NoteTaking.Wcf.Contracts.Interfaces;
using NoteTaking.Wcf.Implementation;
using NoteTaking.Wcf.Implementation.Bootstrap;

namespace NoteTaking.Wcf.Host
{
	public class Program
	{
		public static void Main(string[] args)
		{
			AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionTrapper;

			var builder = new ContainerBuilder();

			// TODO: separate these to modules
			builder.RegisterType<UserService>().As<IUserService>();
			builder.RegisterType<MappingService>().As<IMappingService>();
			builder.RegisterType<Service.Implementation.UserService>().As<Service.Contracts.IUserService>();
			builder.RegisterType<GuidWrapper>().As<IGuidWrapper>();
			builder.RegisterType<DateTimeWrapper>().As<IDateTimeWrapper>();
			builder.RegisterType<UserStore>().As<IStore<User>>();
			builder.RegisterType<UserQuery>().As<IUserQuery>();

			var mapperConfig = new MapperConfigurationExpression();

			new WcfMappingConfiguration().Configure(mapperConfig);
			new EfCoreMappingConfiguration().Configure(mapperConfig);

			Mapper.Initialize(mapperConfig);

			using (var container = builder.Build())
			{
				using (var serviceHost = new ServiceHost(typeof(UserService)))
				{
					serviceHost.AddDependencyInjectionBehavior<IUserService>(container);
					serviceHost.Open();

					Console.WriteLine("The service is listening...");
					Console.WriteLine("Press <Enter> to stop the service.");
					Console.ReadLine();
				}
			}
		}

		private static void UnhandledExceptionTrapper(object sender, UnhandledExceptionEventArgs e)
		{
			Console.WriteLine(e.ExceptionObject.ToString());
			Console.WriteLine("Press Enter to continue");
			Console.ReadLine();
			Environment.Exit(1);
		}
	}
}