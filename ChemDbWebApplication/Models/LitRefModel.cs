namespace WebApplication2.Models;

public class LitRefModel
{
    public LitRefModel(LitReferences references, List<AuthorsInfo> authorsInfos)
    {
        this.References = references;
        this.AuthorsInfos = authorsInfos;
    }
    public LitReferences References { get; set; }
    public List<AuthorsInfo> AuthorsInfos { get; set; }
}