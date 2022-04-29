using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;

namespace WebApplication2.Controllers;

public class KeyWordController : Controller
{
    
    private readonly IricContext _context;
    
    public KeyWordController(IricContext db)
    {
        _context = db;
    }
    
    public IActionResult KeyWord()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Keyword(int id)
    {
        ViewData["keyword"] = _context.KeywordsInfo.First(x => x.KeywordID == id);
        var databasesIds = _context.Databases_Keywords.Where(x => x.KeywordID == id).Select(x => x.DatabaseID);
        var databases = _context.Databases.Where(x => databasesIds.Contains(x.DatabaseID));
        return View(databases);
    }
}