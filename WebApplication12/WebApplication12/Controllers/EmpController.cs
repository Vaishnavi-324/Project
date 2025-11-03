using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Eventing.Reader;
using WebApplication12.Models;
using WebApplication12.Controllers;

public class EmpController : Controller
{
     private readonly EmpContext context;
    public EmpController(EmpContext context)
    {
        this.context = context;
        var connectionString = context.Database.GetConnectionString();
        Console.WriteLine(connectionString);
    }
    public IActionResult Create()


    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(EmpModel obj)
    {
        context.Employees.Add(obj);
         context.SaveChanges();
        return View();
    }
    public IActionResult Read()
    {
        var data = context.Employees.ToList();
        return View(data);

    }
    [HttpGet]
    public IActionResult Update(int id)
    {
        var data = context.Employees.Where(x => x.Id == id).FirstOrDefaultAsync();
        return View(data);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(int id, EmpModel obj)
    {
        var data = await context.Employees.FirstOrDefaultAsync(x => x.Id == id);
        if (data! == null)
        {
            data!.Id = obj.Id;
            context.SaveChanges();
        }
        else
        return RedirectToAction("Read");

        return View();
    }
    public async Task<IActionResult> Delete(int id) 
    {
         var data = await context.Employees.FirstOrDefaultAsync(x => x.Id == id);
        if (data != null)
        {
            context.Employees.Remove(data);
            context.SaveChanges();
        }
        else
            return RedirectToAction("Read");
        return View();
           
        }

    }

    
            

