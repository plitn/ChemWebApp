using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models;

public class CountriesInfo
{
    [Key] 
    public int CountryID { get; set; }
    public string CountryName_rus { get; set; }
    public string CountryName_eng { get; set; }
}