using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace NoteTaking.WebApi
{
	public class Program
	{
		public static void Main(string[] args)
		{
			BuildWebHost(args).Run();
		}

		public static IWebHost BuildWebHost(string[] args)
		{
			var host = WebHost.CreateDefaultBuilder(args)
				.ConfigureServices(s => s.AddAutofac())
				.UseStartup<Startup>()
				.Build();

			return host;
		}
	}
}