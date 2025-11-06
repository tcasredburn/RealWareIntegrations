namespace RealWare.ExternalServices.Models
{
    public class RealWareApiSettings
    {
        public string BaseUrl { get; set; }
        public string ApiKey { get; set; }
        public bool UseRealWareApiInCostCalculation { get; set; }
        public bool UseRealWareApiInIncomeCalculation { get; set; }
        public bool UseRealWareApiInMarketCalculation { get; set; }
    }
}
