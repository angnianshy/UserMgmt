using System.Linq;
using AspNetMembershipManager.Web;

namespace AspNetMembershipManager.User
{
	class ResetPasswordViewModel : SaveViewModelBase
	{
		private readonly IMembershipSettings membershipSettings;

		public ResetPasswordViewModel(IMembershipSettings membershipSettings)
		{
			this.membershipSettings = membershipSettings;
			IsManualPasswordEntry = true;
		}

		public string NewPassword { get; set; }

		public string PasswordConfirmation { get; set; }

		public bool IsPasswordAutoGenerated { get; private set; }

		public bool IsManualPasswordEntry { get; private set; }

		public void SetAutoGenerateneratedPassword(string password)
		{
			NewPassword = password;
			PasswordConfirmation = password;
			IsPasswordAutoGenerated = true;
			IsManualPasswordEntry = false;

			OnPropertyChanged("NewPassword");
			OnPropertyChanged("PasswordConfirmation");
			OnPropertyChanged("IsPasswordAutoGenerated");
			OnPropertyChanged("IsManualPasswordEntry");
		}

		public override string this[string columnName]
		{
			get
			{
				switch (columnName)
    			{
					case "NewPassword":
                        if (! ValidatePassword(NewPassword))
						{
							return "Password does not meet the length or complexity requirements";
						}
						break;

					case "PasswordConfirmation":
                        if (NewPassword != PasswordConfirmation)
						{
							return "Passwords do not match";
						}
						break;
    			}
				return string.Empty;
			}
		}

		private bool ValidatePassword(string password)
		{
            if (string.IsNullOrEmpty(password) || password.Length < membershipSettings.MinRequiredPasswordLength)
			{
				return false;
			}
		    return membershipSettings.MinRequiredNonAlphanumericCharacters <= password.Count(c => ! char.IsLetterOrDigit(c));
		}
	}
}