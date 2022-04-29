using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers;

public class DbPageController : Controller
{

    private readonly IricContext _context;
    
    public DbPageController(IricContext db)
    {
        _context = db;
    }
    
    // GET
    public IActionResult DbPage()
    {
        return View();
    }

    [HttpGet]
    public IActionResult DbPage(int id)
    {
        // вся инфа о конкретной бд
        ViewData["dbData"] = _context.Databases.First(x => x.DatabaseID == id);
        
        // id организаций разработчиков
        var orgIds = (_context.OrganisationsInfo_Databases
                .Select(x => x)
                .Where(x => x.DatabaseID == id))
            .Select(x => x.OrganisationID);
        // вся инфа о огранизациях-разработчиках
        var organisations = _context.OrganisationsInfo
            .Select(x => x)
            .Where(x => orgIds.Contains(x.OrganisationID));
        var countriesId = organisations.Select(x => x.CountryID).Distinct();
        var countries = _context.CountriesInfo.Where(x => countriesId.Contains(x.CountryID));

        // id ключевых слов
        var keywordId = _context.Databases_Keywords.Select(x => x)
            .Where(x => x.DatabaseID == id)
            .Select(x => x.KeywordID);
        // все ключевые слова от таблицы
        var keywords = _context.KeywordsInfo.Select(x => x)
            .Where(x => keywordId.Contains(x.KeywordID));

        var refrencesId = _context.DB_LitReferences
            .Where(x => x.DatabaseID == id)
            .Select(x => x.ReferenceID);
        var references = _context.LitReferences.Select(x => x)
            .Where(x => refrencesId.Contains(x.ReferenceID));
        List<LitRefModel> referenceList =
            new List<LitRefModel>();
        foreach (var reference in references)
        {
            var auId = _context.LitReferences_AuthorsInfo
                .Where(x => x.ReferenceID == reference.ReferenceID)
                .Select(x => x.AuthorID);
            var authorsList = _context.AuthorsInfo.Where(x => auId.Contains(x.AuthorID)).ToList();
            
            referenceList.Add(new LitRefModel(reference, authorsList));
            
        }
        var authorsId = _context.LitReferences_AuthorsInfo
            .Where(x => refrencesId.Contains(x.ReferenceID))
            .Select(x => x.AuthorID);
        var authors = _context.AuthorsInfo.Where(x => authorsId.Contains(x.AuthorID));
        
        

        string keywordsString = "";
        keywordsString = string.Join(", ",  keywords.Select(x => x.Keyword_rus));

        string countriesString = "";
        countriesString = string.Join(", ", countries.Select(x => x.CountryName_rus));

        ViewData["referenceList"] = referenceList;
        ViewData["countries"] = countriesString;
        ViewData["authors"] = authors;
        ViewData["litReferences"] = references;
        ViewData["keywords"] = keywordsString;
        ViewData["organisations"] = organisations;
        ViewData["id"] = id;
        
        return View(referenceList);
    }
}