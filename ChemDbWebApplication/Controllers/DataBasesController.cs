using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;

namespace WebApplication2.Controllers;

public class DataBasesController : Controller
{   
    private readonly IricContext _context;

    public DataBasesController(IricContext iric)
    {
        _context = iric;
    }   
    
    [HttpGet]
    public IActionResult DataBases(string filter="По названию")
    {
        ViewData["Filter"] = filter;
        return filter switch
        {
            "По названию" => View(_context.Databases),
            "Организация разработчик" => View(_context.OrganisationsInfo),
            "Ключевые слова" => View(_context.KeywordsInfo),
            _ => View()
        };
    }
}