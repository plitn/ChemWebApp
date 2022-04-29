using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Data;


public class IricContext : DbContext
{
    public IricContext(DbContextOptions<IricContext> options) : base(options)
    {
        
    } 
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DatabasePrices>()
            .HasKey(o => new {o.DatabaseID, o.LicenseTypeID});
        modelBuilder.Entity<Databases_Keywords>()
            .HasKey(o => new {o.DatabaseID, o.KeywordID});
        modelBuilder.Entity<DB_LitReferences>()
            .HasKey(o => new {o.DatabaseID, o.ReferenceID});
        modelBuilder.Entity<LitReferences_AuthorsInfo>()
            .HasKey(o => new {o.AuthorID, o.ReferenceID});
        modelBuilder.Entity<OrganisationsInfo_Databases>()
            .HasKey(o => new {o.DatabaseID, o.OrganisationID});
    }
    

    public DbSet<Databases> Databases { get; set; }
    public DbSet<AuthorsInfo> AuthorsInfo { get; set; }
    public DbSet<CountriesInfo> CountriesInfo { get; set; }
    public DbSet<CurrencyRates> CurrencyRates { get; set; }
    public DbSet<DatabasePrices> DatabasePrices { get; set; }
    public DbSet<Databases_Keywords> Databases_Keywords { get; set; }
    public DbSet<DB_LitReferences> DB_LitReferences { get; set; }
    public DbSet<KeywordsInfo> KeywordsInfo { get; set; }
    public DbSet<LicenseTypes> LicenseTypes { get; set; }
    public DbSet<LitReferences> LitReferences { get; set; }
    public DbSet<LitReferences_AuthorsInfo> LitReferences_AuthorsInfo { get; set; }
    public DbSet<OrganisationsInfo> OrganisationsInfo { get; set; }
    public DbSet<OrganisationsInfo_Databases> OrganisationsInfo_Databases { get; set; }
}   