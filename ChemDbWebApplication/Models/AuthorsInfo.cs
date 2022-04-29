using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models;

public class AuthorsInfo
{
    [Key] public int AuthorID { get; set; }
    public string AuthorName { get; set; }
}