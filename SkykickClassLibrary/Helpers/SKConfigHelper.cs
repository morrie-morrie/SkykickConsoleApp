using System.Configuration;
using SkykickClassLibrary.Models;

namespace SkykickClassLibrary.Helpers;

    public class SKConfigHelper
{
	private static ConfigModel? config = null;
	
	public static ConfigModel ReadAppConfig()
	{
		if (config == null)
		{
			config = new ConfigModel();

			try
			{
				config.userId = ConfigurationManager.AppSettings["userId"];
				config.subId = ConfigurationManager.AppSettings["SubID"];
			}
			catch (ConfigurationErrorsException)
			{
				Console.WriteLine("Error reading app settings");
				throw;
			}
		}
		return config;
	}
}
