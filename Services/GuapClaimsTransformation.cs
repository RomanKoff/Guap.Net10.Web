using Ans.Net10.Common;
using Ans.Net10.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;

namespace Guap.Net10.Web.Services
{

	/*
	 *	LibStartup.Add_GuapNet10Web()
	 *		_addSsoAuthentication()
	 *			builder.Services.AddSingleton
	 *				<IClaimsTransformation, GuapClaimsTransformation>();
	 */



	public class GuapClaimsTransformation(
		IGuapUsersProvider users,
		IConfiguration configuration)
		: IClaimsTransformation
	{

		private readonly IGuapUsersProvider _users = users;
		private readonly LibGuapOptions _options = configuration.GetLibGuapOptions();


		/* functions */


		public Task<ClaimsPrincipal> TransformAsync(
			ClaimsPrincipal principal)
		{
			if (principal.Identity.IsAuthenticated)
			{
				var profile1 = _users.GetUserProfile(
					_options.AppName,
					principal.GetNameIdentifierFromClaim());
				if (profile1 != null)
				{

					// right
					principal.AddClaims(
						Ans.Net10.Web._Consts.CLAIM_AUTH_POLICY_TYPE,
						profile1.Right.ToString());

					// roles
					if (!string.IsNullOrEmpty(profile1.Roles))
						principal.AddRolesClaims(
							profile1.Roles.Split(';'));

					// actions
					if (!string.IsNullOrEmpty(profile1.Actions))
					{
						var helper1 = new MvcAccessHelper(profile1.Actions);
						principal.AddClaims(
							Ans.Net10.Web._Consts.CLAIM_ACTIONS_TYPE,
							helper1.GetResultClaimsValue());
					}

					// resources
					if (!string.IsNullOrEmpty(profile1.Resources))
						principal.AddClaims(
							Ans.Net10.Web._Consts.CLAIM_RESOURCES_TYPE,
							profile1.Resources.Split(';'));

				}
			}
			return Task.FromResult(principal);
		}

	}

}
