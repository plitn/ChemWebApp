using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models;

public class Databases_Keywords
{
    public int DatabaseID { get; set; }
    public int KeywordID { get; set; }
}