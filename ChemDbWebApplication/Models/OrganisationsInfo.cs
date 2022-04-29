using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models;

public class OrganisationsInfo : ITabled
{
    [Key] 
    public int OrganisationID { get; set; }
    public int? CountryID { get; set; }
    public string? Name_rus { get; set; }
    public string? Name_eng { get; set; }
    public string? Abbreviation_rus { get; set; }
    public string? Abbreviation_eng { get; set; }
}