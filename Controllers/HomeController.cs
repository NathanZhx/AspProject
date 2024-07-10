using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AspProject.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _context;

    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, AppDbContext context)
    {
        _context = context;
        _logger = logger;
    }

    // public IActionResult Index()
    // {
    //     return View();
    // }
    public async Task<IActionResult> Index()
    {
        return View(await _context.products.ToListAsync());
    }


    // public IActionResult ShopDetail()
    // {
    //     return View();
    // }

    public async Task<IActionResult> ShopDetail(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var product = await _context.products
            .FirstOrDefaultAsync(m => m.Id == id);
        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }

    public IActionResult Shop()
    {
        return View();
    }

    public IActionResult Cart()
    {
        return View();
    }

    public IActionResult Checkout()
    {
        return View();
    }

    public async Task<IActionResult> Testimonial()
    {
        return View(await _context.comments.ToListAsync());
    }

    public IActionResult Page404()
    {
        return View();
    }

    public IActionResult Contact()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
