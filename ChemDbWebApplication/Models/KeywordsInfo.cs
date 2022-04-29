using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models;

public class KeywordsInfo : ITabled
{
    [Key]
    public int KeywordID { get; set; }
    public string? Keyword_rus { get; set; }
    public string? Keyword_eng { get; set; }
}