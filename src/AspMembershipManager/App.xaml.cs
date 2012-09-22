﻿using System;
using System.IO;
using System.Windows;

namespace AspMembershipManager
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			ClearConfig();
		}

		private void ClearConfig()
		{
			File.Delete(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
		}
	}
}
