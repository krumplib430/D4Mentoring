using System;
using System.ServiceModel;
using Autofac;
using Autofac.Integration.Wcf;
using NoteTaking.Wcf.Contracts.Interfaces;
using NoteTaking.Wcf.Implementation;

namespace NoteTaking.Wcf.Host
{
	public class Program
	{
		private const string BASE_URI = "http://localhost:8733/NoteTaking.Wcf.Implementation/UserService/";

		public static void Main(string[] args)
		{
			AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionTrapper;

			var builder = new ContainerBuilder();
			builder.RegisterType<UserService>().As<IUserService>();

			using (var container = builder.Build())
			{
				using (var serviceHost = new ServiceHost(typeof(UserService), new Uri(BASE_URI)))
				{
					serviceHost.AddDependencyInjectionBehavior<IUserService>(container);
					serviceHost.Open();

					Console.WriteLine("The service is ready at {0}", BASE_URI);
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