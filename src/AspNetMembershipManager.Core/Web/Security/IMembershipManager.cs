using System.Collections.Generic;
using System.Web.Security;

namespace AspNetMembershipManager.Web.Security
{
	public interface IMembershipManager
	{
		bool DeleteUser(string userName);
		IEnumerable<System.Web.Security.MembershipUser> GetAllUsers();
		void UpdateUser(System.Web.Security.MembershipUser user);
		MembershipCreateStatus CreateUser(string userName, string password, string emailAddress, string passwordQuestion, string passwordQuestionAnswer);
		System.Web.Security.MembershipUser GetUser(string userName);
	    IMembershipSettings Settings { get; }
	}
}