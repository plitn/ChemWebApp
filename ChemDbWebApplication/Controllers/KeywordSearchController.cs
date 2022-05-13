using Microsoft.AspNetCore.Mvc;
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

    [HttpGet]
    public IActionResult KeywordSearch([FromQuery]int pgn = 1)
    {
        ViewData["pageNumber"] = pgn;
        ViewData["keywords"] = _context.KeywordsInfo;
        return View("KeywordSearch", _context.Databases);
    }

    [HttpPost]
    public IActionResult SubmitKeywords(string[] keywordsNames)
    {
        if (keywordsNames.Length == 0)
        {
            return View("KeywordSearch");
        }
        ViewData["keywords"] = _context.KeywordsInfo;
        ViewData["pageNumber"] = 1;
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