using Guap.Net10.Web.Models;

namespace Guap.Net10.Web.Services
{

	public interface IGuapUsersProvider
	{
		GuapUserModel[] GetUsers();

		GuapUserProfileModel GetUserProfile(
			string application,
			string nameIdentifier);

		void UpdateUser(
			string nameIdentifier, string idUsername,
			string name, string surname, string givenName,
			string email, string displayedName);
	}

}
