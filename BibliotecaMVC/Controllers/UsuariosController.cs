using Microsoft.AspNetCore.Mvc;

namespace BibliotecaMVC.Controllers;

public class UsuariosController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}
