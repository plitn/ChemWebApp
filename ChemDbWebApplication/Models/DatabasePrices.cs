using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models;

public class DatabasePrices
{
    public int DatabaseID { get; set; }
    public int LicenseTypeID { get; set; }
    public decimal Price { get; set; }
    public string Currency { get; set; }
}