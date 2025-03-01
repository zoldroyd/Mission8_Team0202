using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission8_Team0202.Models;


namespace Mission8_Team0202.Controllers
{
    public class HomeController : Controller
    {
        private ITaskRepository _repo;

        public HomeController(ITaskRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index()
        {
            var taskToDo = _repo.TasksToDo
                .AsQueryable()
                .Include(x => x.Category)
                .Where(x => !x.Completed) // Fix: Use _repo.TasksTodo
                .ToList();  // Use ToList() here to execute the query

            return View(taskToDo);
        }

        [HttpGet]
        public IActionResult CreateTask()
        {
            ViewBag.Categories = _repo.GetCategories(); // Fix: Use repository method

            return View(new TaskToDo());
        }

        [HttpPost]
        public IActionResult CreateTask(TaskToDo response)
        {
            if (ModelState.IsValid)
            {
                _repo.AddTask(response);
                _repo.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Categories = _repo.GetCategories(); // Fix: Use repository method
            return View(response);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _repo.TasksToDo
                .Single(x => x.TaskId == id);

            ViewBag.Categories = _repo.GetCategories(); // Fix: Use repository method

            return View("CreateTask", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(TaskToDo updatedInfo)
        {
            if (ModelState.IsValid)
            {
                _repo.UpdateTask(updatedInfo); // Fix: Use repository method
                _repo.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Categories = _repo.GetCategories();
            return View("CreateTask", updatedInfo);
        }
        
        public IActionResult Delete(int id)
        {
            var recordToDelete = _repo.TasksToDo
                .SingleOrDefault(x => x.TaskId == id);

            if (recordToDelete != null)
            {
                _repo.DeleteTask(recordToDelete); // Fix: Use repository method
                _repo.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
