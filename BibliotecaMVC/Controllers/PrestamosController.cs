using Microsoft.AspNetCore.Mvc;

namespace BibliotecaMVC.Controllers;

public class PrestamosController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}
