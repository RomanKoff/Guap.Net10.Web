using Ans.Net10.Web;
using Microsoft.Extensions.Configuration;

namespace Guap.Net10.Web
{

	public static partial class _e
	{
		private static LibGuapOptions _options;
		public static LibGuapOptions GetLibGuapOptions(
			this IConfiguration configuration)
		{
			return _options ??= configuration.GetOptions<LibGuapOptions>("Guap.Net10.Web");
		}
	}



	public class LibGuapOptions
		: _AppSettingsOptions_Proto
	{
		public override void Test()
		{
			if (AppName == null)
				throw GetExceptionParamRequired(nameof(AppName));
			if (AppTitle == null)
				throw GetExceptionParamRequired(nameof(AppTitle));
		}

		public string AppName { get; set; } // Required!
		public string AppTitle { get; set; } // Required!
	}

}
