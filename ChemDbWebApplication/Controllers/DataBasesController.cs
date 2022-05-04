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
    public IActionResult DataBases([FromQuery]string filter="По названию",[FromQuery]int pgn=1)
    {
        ViewData["Filter"] = filter;
        ViewData["pageNumber"] = pgn;
        return filter switch
        {
            "По названию" => View(_context.Databases),
            "Организация разработчик" => View(_context.OrganisationsInfo),
            "Ключевые слова" => View(_context.KeywordsInfo),
            _ => View(_context.Databases)
        };
    }
    
    [HttpGet]
    public IActionResult DataBasesDefaultPaging([FromQuery]int pgn=1)
    {
        ViewData["Filter"] = "По названию";
        ViewData["pageNumber"] = pgn;
        return View("DataBases",_context.Databases);
    }
    
    public IActionResult DataBasesDefault()
    {
        ViewData["Filter"] = "По названию";
        ViewData["pageNumber"] = 1;
        return View("DataBases",_context.Databases);
    }
    
}