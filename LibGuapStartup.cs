using Ans.Net10.Web;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Web;

namespace Guap.Net10.Web
{

	public static class LibGuapStartup
	{

		/* methods */


		public static void Init_GuapNet10Web(
			Action<WebApplicationBuilder> builderAction,
			Action<WebApplication> applicationAction)
		{
			var logger1 = LogManager.Setup()
				.LoadConfigurationFromAppSettings()
				.GetCurrentClassLogger();
			logger1.Info("[Guap.Net10.Web] Init");

			try
			{

				/*
				 * Builder
				 */

				var builder1 = WebApplication.CreateBuilder();
				var configuration1 = builder1.Configuration;
				builder1.Logging.ClearProviders();
				builder1.Host.UseNLog();
				builder1.Add_AnsNet10Web(configuration1);
				builder1.Add_GuapNet10Web(configuration1);
				//AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
				//builder1.Services.AddDbContext<AppDbContext>(o =>
				//{
				//	o.ConfigureWarnings(x => x.Ignore(RelationalEventId.BoolWithDefaultWarning));
				//	o.UseNpgsql(builder1.Configuration.GetConnectionString("AppDbConnection"));
				//});
				builderAction?.Invoke(builder1);

				/*
				 * Application
				 */

				var app1 = builder1.Build();
				app1.Use_AnsNet10Web(configuration1);
				app1.Use_GuapNet10Web(configuration1);
				//app1.AppDbContext_Prepare(null);
				applicationAction?.Invoke(app1);

				app1.Run();
			}
			catch (Exception exception)
			{
				logger1.Error(exception, "[Guap.Net10.Web] Stopped program because of exception");
				throw;
			}
			finally
			{
				LogManager.Shutdown();
			}
		}


		public static void Add_GuapNet10Web(
			this WebApplicationBuilder builder,
			IConfiguration configuration)
		{
			var options1 = configuration.GetLibGuapOptions();
		}


		public static void Use_GuapNet10Web(
			this WebApplication app,
			IConfiguration configuration)
		{
			var options1 = configuration.GetLibGuapOptions();
		}

	}

}
