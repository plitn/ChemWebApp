using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models;

public class OrganisationsInfo_Databases
{
    public int DatabaseID { get; set; }
    public int OrganisationID { get; set; }
    public string Address_rus { get; set; }
    public string Address_eng { get; set; }
}