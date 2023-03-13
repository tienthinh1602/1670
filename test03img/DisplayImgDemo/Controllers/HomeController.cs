using DisplayImgDemo.Data;
using DisplayImgDemo.Models;
using DisplayImgDemo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DisplayImgDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IWebHostEnvironment webHostEnvironment;

        public HomeController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            dbContext = context;
            this.webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var employee = await dbContext.Employees.ToListAsync();
            return View(employee);
        }
        public async Task<IActionResult> Index2()
        {
            var employee = await dbContext.Employees.ToListAsync();
            return View(employee);
        }

        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> New(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniFileName = UploadedFile(model);
                Employee employee = new Employee
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Gender = model.Gender,
                    Age = model.Age,
                    Office = model.Office,
                    Position = model.Position,
                    Salary = model.Salary,
                    ProfilePicture = uniFileName,
                };
                dbContext.Add(employee);
                await dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult New2()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> New2(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniFileName = UploadedFile(model);
                Employee employee = new Employee
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Gender = model.Gender,
                    Age = model.Age,
                    Office = model.Office,
                    Position = model.Position,
                    Salary = model.Salary,
                    ProfilePicture = uniFileName,
                };
                dbContext.Add(employee);
                await dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        private string UploadedFile(EmployeeViewModel model)
        {
            string uniFileName = null;
            if (model.ProfilePicture != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniFileName = Guid.NewGuid().ToString() + "_" + model.ProfilePicture.FileName;  
                string filePath = Path.Combine(uploadsFolder, uniFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ProfilePicture.CopyTo(fileStream);
                }
            }

            return uniFileName;

        }
    }
}