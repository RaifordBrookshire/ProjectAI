using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace ProjectAI.Api.Controllers;

public class ImageController : Controller
{
    // GET
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet("/image")]
    public IActionResult GetImage()
    {
        var filePath =@"C:\\temp\\api-images\\pic1.jpg";
        var fileBytes = System.IO.File.ReadAllBytes(filePath);
        return File(fileBytes, "image/jpeg");
    }
}