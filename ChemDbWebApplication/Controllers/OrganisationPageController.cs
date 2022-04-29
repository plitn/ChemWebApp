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
        ViewBag["organisation"] = organisation;
        List<Databases> databasesList = new List<Databases>();
        
        return View();
    }
}