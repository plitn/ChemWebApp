using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models;

public class LitReferences_AuthorsInfo
{
    public int ReferenceID { get; set; }
    public int AuthorID { get; set; }
}