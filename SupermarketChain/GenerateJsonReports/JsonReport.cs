namespace GenerateJsonReports
{
    using Newtonsoft.Json;

    public class JsonReport
    {

        [JsonProperty("product-id")]
        public int Id { get; set; }

        [JsonProperty("product-name")]
        public string ProductName { get; set; }

        [JsonProperty("vendor-name")]
        public string VendorName { get; set; }

        [JsonProperty("total-quantity-sold")]
        public decimal QtySold { get; set; }

        [JsonProperty("total-incomes")]
        public decimal TotalIncome { get; set; }

    }
}
