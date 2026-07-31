using Microsoft.AspNetCore.Mvc;
using BibliotecaMVC.Models;

namespace BibliotecaMVC.Controllers;

public class AutoresController : Controller
{
    private static List<Autor> autores = new List<Autor>
    {
        new Autor
        {
            ID = 1,
            Nombre = "Gabriel",
            Apellido = "García Márquez",
            Nacionalidad = "Colombiana",
            FechaNacimiento = new DateTime(1927, 3, 6),
            Activo = false
        },
        new Autor
        {
            ID = 2,
            Nombre = "Isabel",
            Apellido = "Allende",
            Nacionalidad = "Chilena",
            FechaNacimiento = new DateTime(1942, 8, 2),
            Activo = true
        },
        new Autor
        {
            ID = 3,
            Nombre = "Claudia",
            Apellido = "Lars",
            Nacionalidad = "Salvadoreña",
            FechaNacimiento = new DateTime(1899, 12, 20),
            Activo = false
        },
        new Autor
        {
            ID = 4,
            Nombre = "J.K.",
            Apellido = "Rowling",
            Nacionalidad = "Británica",
            FechaNacimiento = new DateTime(1965, 7, 31),
            Activo = true
        },
        new Autor
        {
            ID = 5,
            Nombre = "Alfredo",
            Apellido = "Espino",
            Nacionalidad = "Salvadoreña",
            FechaNacimiento = new DateTime(1900, 1, 8),
            Activo = false
        }
    };
    
    public IActionResult Index()
    {
        return View(autores);
    }

    public IActionResult Details(int id)
    {
        var autor = autores.FirstOrDefault(x => x.ID == id);
        if (autor == null)
        {
            return NotFound();
        }
        return View(autor);
    }

   
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Autor autor)
    {
        if (!ModelState.IsValid)
        {
            return View(autor);
        }
        if(autores.Any())
        {
            autor.ID = autores.Max(x => x.ID) + 1;
        }
        else
        {
            autor.ID = 1;
        }
        autores.Add(autor);
        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
        var autor = autores.FirstOrDefault(x => x.ID == id);
        if (autor == null)
        {
            return NotFound();
        }
        return View(autor);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Autor autor)
    {
        if (!ModelState.IsValid)
        {
            return View(autor);
        }
        var index = autores.FindIndex(x => x.ID == autor.ID);
        if (index == -1)
        {
            return NotFound();
        }
        autores[index] = autor;
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        var autor = autores.FirstOrDefault(x => x.ID == id);
        if (autor != null)
        {
            autores.Remove(autor);
        }
        return RedirectToAction("Index");
    }
}







