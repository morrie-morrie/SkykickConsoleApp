using Newtonsoft.Json;
using System.Text.Json.Serialization;

public class CustomerInformation
{
	[JsonProperty("CompanyName")]
	[JsonPropertyName("CompanyName")]
	public string CompanyName { get; set; }

	[JsonProperty("FirstName")]
	[JsonPropertyName("FirstName")]
	public object FirstName { get; set; }

	[JsonProperty("LastName")]
	[JsonPropertyName("LastName")]
	public object LastName { get; set; }

	[JsonProperty("EmailAddress")]
	[JsonPropertyName("EmailAddress")]
	public object EmailAddress { get; set; }

	[JsonProperty("PhoneNumber")]
	[JsonPropertyName("PhoneNumber")]
	public object PhoneNumber { get; set; }
}

public class SubscriptionSettings
{
	[JsonProperty("BackupExchangeEnabled")]
	[JsonPropertyName("BackupExchangeEnabled")]
	public bool BackupExchangeEnabled { get; set; }

	[JsonProperty("TotalExchangeMailboxesEnabled")]
	[JsonPropertyName("TotalExchangeMailboxesEnabled")]
	public int TotalExchangeMailboxesEnabled { get; set; }

	[JsonProperty("BackupSharepointEnabled")]
	[JsonPropertyName("BackupSharepointEnabled")]
	public bool BackupSharepointEnabled { get; set; }

	[JsonProperty("TotalSharepointSitesEnabled")]
	[JsonPropertyName("TotalSharepointSitesEnabled")]
	public int TotalSharepointSitesEnabled { get; set; }

	[JsonProperty("TotalSharepointActiveLicenses")]
	[JsonPropertyName("TotalSharepointActiveLicenses")]
	public int TotalSharepointActiveLicenses { get; set; }

	[JsonProperty("ExchangeSeatLimit")]
	[JsonPropertyName("ExchangeSeatLimit")]
	public int ExchangeSeatLimit { get; set; }

	[JsonProperty("ExchangeDisabledOn")]
	[JsonPropertyName("ExchangeDisabledOn")]
	public object ExchangeDisabledOn { get; set; }

	[JsonProperty("SharepointDisabledOn")]
	[JsonPropertyName("SharepointDisabledOn")]
	public object SharepointDisabledOn { get; set; }

	[JsonProperty("CustomerInformation")]
	[JsonPropertyName("CustomerInformation")]
	public CustomerInformation CustomerInformation { get; set; }

	[JsonProperty("State")]
	[JsonPropertyName("State")]
	public int State { get; set; }

	[JsonProperty("TotalOneDriveSitesEnabled")]
	[JsonPropertyName("TotalOneDriveSitesEnabled")]
	public int TotalOneDriveSitesEnabled { get; set; }

	[JsonProperty("TotalIndividualMailboxesEnabled")]
	[JsonPropertyName("TotalIndividualMailboxesEnabled")]
	public int TotalIndividualMailboxesEnabled { get; set; }

	[JsonProperty("TotalSharedResourcesEnabled")]
	[JsonPropertyName("TotalSharedResourcesEnabled")]
	public int TotalSharedResourcesEnabled { get; set; }

	[JsonProperty("IndividualMailboxesCharged")]
	[JsonPropertyName("IndividualMailboxesCharged")]
	public int IndividualMailboxesCharged { get; set; }

	[JsonProperty("SharedResourcesCharged")]
	[JsonPropertyName("SharedResourcesCharged")]
	public int SharedResourcesCharged { get; set; }

	[JsonProperty("TotalSharepointLicensesCharged")]
	[JsonPropertyName("TotalSharepointLicensesCharged")]
	public int TotalSharepointLicensesCharged { get; set; }

	[JsonProperty("SeatLimit")]
	[JsonPropertyName("SeatLimit")]
	public object SeatLimit { get; set; }

	[JsonProperty("ExchangeLimit")]
	[JsonPropertyName("ExchangeLimit")]
	public object ExchangeLimit { get; set; }

	[JsonProperty("SharepointLimit")]
	[JsonPropertyName("SharepointLimit")]
	public object SharepointLimit { get; set; }

	[JsonProperty("OnMicrosoftDomain")]
	[JsonPropertyName("OnMicrosoftDomain")]
	public string OnMicrosoftDomain { get; set; }
}

