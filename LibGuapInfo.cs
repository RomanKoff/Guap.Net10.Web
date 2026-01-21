using Ans.Net10.Common;

namespace Guap.Net10.Web
{

	public static class LibGuapInfo
	{
		public static string GetName() => SuppApp.GetName();
		public static string GetVersion() => SuppApp.GetVersion();
		public static string GetDescription() => SuppApp.GetDescription();
	}

}
