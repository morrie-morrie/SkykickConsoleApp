using RestSharp;
using System.Text;
using Newtonsoft.Json;
using SkykickClassLibrary.Models;

namespace SkykickClassLibrary.Helpers;

public class SKAuth
{
	public static string CreateBearer()
	{
		var config = SKConfigHelper.ReadAppConfig();
		var token = $"{config.userId}" + ":" + $"{config.subId}";
		var base64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(token));
		var bearer = "Basic " + base64;

		return bearer;
	}

	public static string GetAccessToken()
	{
		var config = SKConfigHelper.ReadAppConfig();
		var bearer = SKAuth.CreateBearer();
		RestClient client = new RestSharp.RestClient("https://apis.skykick.com");
		RestSharp.RestRequest request = new RestSharp.RestRequest("auth/token", RestSharp.Method.Post);
		request.AddHeader("Authorization", bearer);
		request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
		request.AddHeader("Ocp-Apim-Subscription-Key", $"{config.subId}");
		request.AddParameter("grant_type=client_credentials&scope", "Partner");
		RestSharp.RestResponse response = client.Execute(request);
		var content = response.Content;
		var token = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.TokenModel>(content);

		return token.access_token;
	}
	
	public static List<Customer> GetCustomers()
	{
		var config = SKConfigHelper.ReadAppConfig();
		var accessToken = SKAuth.GetAccessToken();
		
		RestClient client = new RestSharp.RestClient("https://apis.skykick.com");
		RestSharp.RestRequest request = new RestSharp.RestRequest("/backup", RestSharp.Method.Get);
		request.AddHeader("Authorization", $"Bearer {accessToken}");
		request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
		request.AddHeader("Ocp-Apim-Subscription-Key", $"{config.subId}");
		request.AddParameter("grant_type=client_credentials&scope", "Partner");
		RestSharp.RestResponse<List<Customer>> response = client.Execute<List<Customer>>(request);
		var content = response.Content;
		var customers = JsonConvert.DeserializeObject<List<Customer>>(content);

		return customers;
	}

	public static List<SubscriptionSettings>? GetSubscriptionSettings()
	{
		var config = SKConfigHelper.ReadAppConfig();
		var accessToken = SKAuth.GetAccessToken();
		List<Customer> customers = SKAuth.GetCustomers();
		if (customers == null || customers.Count == 0)
		{
			return null;
		}

		var subscriptionSettingsList = new List<SubscriptionSettings>();
		foreach (var customer in customers)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine(customer.CompanyName);
			Console.ResetColor();
			var customerId = customers[0].Id;
			var client = new RestSharp.RestClient($"https://apis.skykick.com/Backup/{customer.Id}/subscriptionsettings");
			var request = new RestRequest("", Method.Get);
			request.AddHeader("Authorization", $"Bearer {accessToken}");
			request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
			request.AddHeader("Ocp-Apim-Subscription-Key", $"{config.subId}");
			request.AddParameter("grant_type=client_credentials&scope", "Partner");
			RestSharp.RestResponse<List<SubscriptionSettings>> response = client.Execute<List<SubscriptionSettings>>(request);
			var content = response.Content;
			var subscriptionSettings = JsonConvert.DeserializeObject<SubscriptionSettings>(content);
		subscriptionSettingsList.Add(subscriptionSettings);

			Console.WriteLine($"Exchange Backuped Enabled: {subscriptionSettings.BackupExchangeEnabled}");
			Console.WriteLine($"Sharepoint Backup Enabled: {subscriptionSettings.BackupSharepointEnabled}");
			Console.WriteLine($"Individual Mailboxes Charged: {subscriptionSettings.IndividualMailboxesCharged}");
			Console.WriteLine();
		}
		return subscriptionSettingsList;
	}
}
