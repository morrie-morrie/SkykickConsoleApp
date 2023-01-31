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
	
	public static string GetCustomers()
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

		foreach (var customer in customers)
		{
			Console.WriteLine(customer.CompanyName);
		}

		return content;
	}
}
