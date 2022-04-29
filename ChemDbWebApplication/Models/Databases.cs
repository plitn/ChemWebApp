using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models;

public class Databases : ITabled
{
    [Key]
    public int DatabaseID { get; set; }
    public string Name_rus { get; set; }
    public string Name_eng { get; set; }
    public string Abbreviation_rus { get; set; }
    public string Abbreviation_eng { get; set; }
    public string Phone { get; set; }
    public string Fax { get; set; }
    public string Email { get; set; }
    public string URL { get; set; }
    public string Comments_rus { get; set; }
    public string Comments_eng { get; set; }
}