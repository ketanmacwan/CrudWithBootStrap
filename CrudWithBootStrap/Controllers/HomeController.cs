using CrudWithBootStrap.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CrudWithBootStrap.Controllers
{
    public class HomeController : Controller
    {
        private List<Student> studentsList = new List<Student>()
        {
            new Student() { StudentId = 1 , Name = "Joy", Branch = "IT", Gender = "Male", Section = "A"},
            new Student() { StudentId = 2 , Name = "Hardik", Branch = "IT", Gender = "Male", Section = "A"}
        };

        public ViewResult Index()
        {
            return View(studentsList);
        }

        public ViewResult Details(int Id)
        {
            var StudentDetails = studentsList.FirstOrDefault(s => s.StudentId == Id);
            return View(StudentDetails);
        }

        public IActionResult Edit(int Id)
        {
            var StudentDetails = studentsList.FirstOrDefault(s => s.StudentId == Id);
            return View(StudentDetails);
        }

        [HttpPost]
        public IActionResult Edit(Student updatedStudent)
        {
            var studentToEdit = studentsList.FirstOrDefault(s => s.StudentId == updatedStudent.StudentId);
            if (studentToEdit != null)
            {
                studentToEdit.Name = updatedStudent.Name;
                studentToEdit.Branch = updatedStudent.Branch;
                studentToEdit.Gender = updatedStudent.Gender;
                studentToEdit.Section = updatedStudent.Section;
            }
            return RedirectToAction("Index");
        }
    }
}
