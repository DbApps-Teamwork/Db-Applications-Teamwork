namespace GenerateJsonReports
{
    using Newtonsoft.Json;


    //Created class to store information in required input
    //JsonProperty will save the value under provided key name
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
