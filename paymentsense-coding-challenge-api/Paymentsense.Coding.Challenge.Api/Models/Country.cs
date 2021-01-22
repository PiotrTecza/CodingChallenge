namespace Paymentsense.Coding.Challenge.Api.Models
{
    public class Country
    {
        public string Name { get; set; }
        public string Flag { get; set; }
        public long Population { get; set; }
        public string Capital { get; set; }
        public string[] Timezones { get; set; }
        public Currency[] Currencies { get; set; }
        public Language[] Languages { get; set; }
        public string[] Borders { get; set; }
    }
}
