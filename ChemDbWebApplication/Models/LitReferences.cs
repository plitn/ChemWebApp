using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models;

public class LitReferences
{
    [Key] public int ReferenceID { get; set; }
    public string Article { get; set; }
    public string Source { get; set; }
    public int Year { get; set; }
    public string Volume { get; set; }
    public string Number { get; set; }
    public string Pages { get; set; }
}