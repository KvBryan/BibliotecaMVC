using Microsoft.AspNetCore.Mvc;
using BibliotecaMVC.Models;

namespace BibliotecaMVC.Controllers;

public class LibrosController : Controller
{
    private static List<Libro> libros = new List<Libro>
    {
        new Libro
        {
            ID = 1,
            Titulo = "Clean Code",
            Autor = "Robert C. Martin",
            Categoria = "Programación",
            Precio = 35.50m,
            Disponible = true,
            Imagen = "clean_code.png"
        },
        new Libro
        {
            ID = 2,
            Titulo = "Cien años de soledad",
            Autor = "Gabriel García Márquez",
            Categoria = "Literatura",
            Precio = 18.00m,
            Disponible = false,
            Imagen = "cien_anios.png"
        }
    };

    public IActionResult Index()
    {
        return View(libros);
    }

    public IActionResult Details(int id)
    {
        var libro = libros.FirstOrDefault(x => x.ID == id);
        if (libro == null)
        {
            return NotFound();
        }
        return View(libro);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Libro libro)
    {
        if (!ModelState.IsValid)
        {
            return View(libro);
        }
        if (libros.Any())
        {
            libro.ID = libros.Max(x => x.ID) + 1;
        }
        else
        {
            libro.ID = 1;
        }
        libros.Add(libro);
        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
        var libro = libros.FirstOrDefault(x => x.ID == id);
        if (libro == null)
        {
            return NotFound();
        }
        return View(libro);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Libro libro)
    {
        if (!ModelState.IsValid)
        {
            return View(libro);
        }
        var index = libros.FindIndex(x => x.ID == libro.ID);
        if (index == -1)
        {
            return NotFound();
        }
        libros[index] = libro;
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        var libro = libros.FirstOrDefault(x => x.ID == id);
        if (libro != null)
        {
            libros.Remove(libro);
        }
        return RedirectToAction("Index");
    }
}