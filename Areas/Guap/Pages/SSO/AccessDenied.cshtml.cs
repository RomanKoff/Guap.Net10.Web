using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Guap.Net10.Web.Areas.Guap.Pages.SSO
{

	public class AccessDeniedModel
		: PageModel
	{

		public void OnGet()
		{
			HttpContext.Response.StatusCode = StatusCodes.Status403Forbidden;
		}

	}

}
