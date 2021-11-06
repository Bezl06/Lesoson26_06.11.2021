using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Lesson2.Models;
using Microsoft.EntityFrameworkCore;

namespace Lesson2.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ProductAppContext _context;

    public HomeController(ILogger<HomeController> logger, ProductAppContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Products.ToList());
    }

    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
        var product = _context.Products.Find(id);
        return View(product);
    }
    [HttpPost]
    public IActionResult Edit(Product product)
    {
        _context.Products.Update(product);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
    public IActionResult Details(int id)
    {
        var product = _context.Products.Find(id);
        return View(product);
    }
    [ActionName("Delete")]
    public IActionResult ConfirmDelete(int id)
    {
        var product = _context.Products.Find(id);
        return View(product);
    }
    [HttpPost]
    public IActionResult Delete(int id)
    {
        var product = _context.Products.Find(id);
        _context.Products.Remove(product);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
