using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Data;
using StudentManagement.Models;

namespace StudentManagement.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;
        public StudentController(ApplicationDbContext context)
        {
            _context= context;
        }

  
        public IActionResult Index(string searchString, int page = 1)
        {
            int pageSize = 5;

            var query = _context.Students.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                query = query.Where(s =>
                    s.Name.Contains(searchString) ||
                    s.Email.Contains(searchString));
            }

            int totalStudents = query.Count();

            var students = query
          .Include(s => s.Department)
          .OrderBy(s => s.Id)
          .Skip((page - 1) * pageSize)
          .Take(pageSize)
          .ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling(
                totalStudents / (double)pageSize);
            ViewBag.SearchString = searchString;

            return View(students);
        }
        private void LoadDepartments()
        {
            ViewBag.Departments = new SelectList(
                _context.Departments.ToList(),
                "Id",
                "Name"
            );
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            LoadDepartments();
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if (!student.DepartmentId.HasValue)
            {
                ModelState.AddModelError(
                    nameof(student.DepartmentId),
                    "Please select a department");
            }
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            LoadDepartments();
            return View(student);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var student = _context.Students.Find(id);

            if (student == null)
            {
                return NotFound();
            }

            LoadDepartments();

            return View(student);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            if (!student.DepartmentId.HasValue)
            {
                ModelState.AddModelError(
                    nameof(student.DepartmentId),
                    "Please select a department");
            }

            if (ModelState.IsValid)
            {
                _context.Students.Update(student);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            LoadDepartments();

            return View(student);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var student = _context.Students.Find(id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = _context.Students.Find(id);

            if (student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

    }
}
