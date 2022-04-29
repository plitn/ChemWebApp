using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models;

public class LicenseTypes
{
    [Key]
    public int LicenseTypeID { get; set; }
    public string LicName { get; set; }
    public decimal PeriodInMonths { get; set; }
    public string Restrictions { get; set; }
    public string Description { get; set; }
}