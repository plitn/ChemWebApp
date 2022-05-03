using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers;

public class OrganisationPageController : Controller
{
    private readonly IricContext _context;
    
    public OrganisationPageController(IricContext db)
    {
        _context = db;
    }
    
    public IActionResult OrganisationPage()
    {
        return View();
    }

    [HttpGet]
    public IActionResult OrganisationPage(int id)
    {
        var organisation = _context.OrganisationsInfo.First(x => x.OrganisationID == id);
        ViewData["organisation"] = organisation;
        var countryInfo = _context.CountriesInfo.First(x => x.CountryID == organisation.CountryID);
        var countryName = string.IsNullOrEmpty(countryInfo.CountryName_rus) ? countryInfo.CountryName_eng : countryInfo.CountryName_rus;
        ViewData["countryName"] = countryName;
        var dbIds = _context.OrganisationsInfo_Databases
            .Where(x => x.OrganisationID == organisation.OrganisationID)
            .Select(x => x.DatabaseID);
        var dataBases = _context.Databases.Where(x => dbIds.Contains(x.DatabaseID));
        
        return View(dataBases);
    }
}