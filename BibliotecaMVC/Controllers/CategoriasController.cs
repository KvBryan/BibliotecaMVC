using Microsoft.AspNetCore.Mvc;

namespace BibliotecaMVC.Controllers;

public class CategoriasController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}
