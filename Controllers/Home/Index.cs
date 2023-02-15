using System.Net.Mime;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.Home;

public class HomeController : Controller
{
    // GET
    [HttpGet]
    public ContentResult Index()
    {
        return new ContentResult
        {
            Content = "<h1>Hello World</h1>",
            ContentType = "text/html"
        };
    }
}