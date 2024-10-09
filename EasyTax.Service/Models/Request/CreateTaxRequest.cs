namespace EasyTax.Service.Models.Request
{
    public class CreateTaxRequest
    {
        public required string Email { get; set; }
        public required decimal HouseHoldIncome { get; set; }
        public required string CountryCode { get; set; }
        public required decimal Tax { get; set; }
        public required string FillingStatus { get; set; }
    }
}
