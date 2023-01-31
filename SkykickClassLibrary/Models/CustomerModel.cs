using Newtonsoft.Json;
using System.Text.Json.Serialization;

public class Customer
{
	[JsonProperty("id")]
	[JsonPropertyName("id")]
	public string Id { get; set; }

	[JsonProperty("companyName")]
	[JsonPropertyName("companyName")]
	public string CompanyName { get; set; }

	[JsonProperty("orderPlacedDate")]
	[JsonPropertyName("orderPlacedDate")]
	public DateTime OrderPlacedDate { get; set; }

	[JsonProperty("onMicrosoftDomain")]
	[JsonPropertyName("onMicrosoftDomain")]
	public string OnMicrosoftDomain { get; set; }

	[JsonProperty("tenantId")]
	[JsonPropertyName("tenantId")]
	public string TenantId { get; set; }

	[JsonProperty("orderState")]
	[JsonPropertyName("orderState")]
	public string OrderState { get; set; }
}

