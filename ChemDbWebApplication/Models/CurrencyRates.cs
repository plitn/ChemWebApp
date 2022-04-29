using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models;

public class CurrencyRates
{
    [Key] 
    public string Currency { get; set; }
    public decimal RateValueCash { get; set; }
    public decimal RateValueWCash { get; set; }
    public string CurrencyName_rus { get; set; }
    public string CurrencyName_eng { get; set; }
}