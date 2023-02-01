using SkykickClassLibrary.Helpers;

namespace SkykickApp;

public class Program
{
	static void Main(string[] args)
	{
		var response = SKAuth.GetSubscriptionSettings();
		Console.WriteLine(response);
	}
}