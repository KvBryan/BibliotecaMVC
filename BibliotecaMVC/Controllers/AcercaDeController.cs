using Microsoft.AspNetCore.Mvc;

namespace BibliotecaMVC.Controllers;

public class AcercaDeController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}
