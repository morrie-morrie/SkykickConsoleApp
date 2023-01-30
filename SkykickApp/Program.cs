using SkykickClassLibrary.Helpers;

namespace SkykickApp;

public class Program
{
	static void Main(string[] args)
	{
		var content = SKAuth.GetCustomers();
		Console.WriteLine(content);
		
	}
}