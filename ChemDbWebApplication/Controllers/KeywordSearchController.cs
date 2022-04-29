using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers;

public class KeywordSearchController : Controller
{
    private readonly IricContext _context;
    
    public KeywordSearchController(IricContext db)
    {
        _context = db;
    }
    // GET
    public IActionResult KeywordSearch()
    {
        ViewData["keywords"] = _context.KeywordsInfo;
        return View(_context.Databases);
    }
    
    [HttpPost]
    public IActionResult SubmitKeywords(string[] keywordsNames) 
    {
        ViewData["keywords"] = _context.KeywordsInfo;
        var keywordsSub = _context.KeywordsInfo.Where(x =>
            keywordsNames.Contains(x.Keyword_rus) || keywordsNames.Contains(x.Keyword_eng));
        List<Databases> databasesList = new List<Databases>();
        foreach (var db in _context.Databases)
        {
            var keywordsIds = _context.Databases_Keywords.Where(x => x.DatabaseID == db.DatabaseID)
                .Select(x => x.KeywordID);
            var allKw = _context.KeywordsInfo.Where(x => keywordsIds.Contains(x.KeywordID));
            if (keywordsSub.All(allKw.Contains))
            {
                databasesList.Add(db);
            }
        }
        return View("KeywordSearch", databasesList);
    }
}