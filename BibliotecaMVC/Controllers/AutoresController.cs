using Microsoft.AspNetCore.Mvc;

namespace BibliotecaMVC.Controllers;

public class AutoresController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}