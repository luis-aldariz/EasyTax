namespace EasyTax.Service.Models
{
    public class TaxHistory
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public decimal HouseHoldIncome { get; set; }
        public string CountryCode { get; set; }
        public decimal Tax { get; set; }
        public string FillingStatus { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
