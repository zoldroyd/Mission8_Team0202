using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission8_Team0202.Models;

namespace Mission8_Team0202.Controllers;

public class HomeController : Controller
{
    
    private ITaskRepository _repo;

    public HomeController(ITaskRepository temp)
    {
        _repo = temp;
    }
    
    public IActionResult Index()
    {
        var taskToDo = _repo.Tasks
            .Include(x => x.Category) // join the category names
            .Where(x => x.Completed == false)
            .ToList();
        
        return View(taskToDo);
    }
    
    [HttpGet]
    public IActionResult CreateTask()
    {
        ViewBag.Categories = _repo.Categories
            .OrderBy(c => c.CategoryName)
            .ToList();
        
        return View("CreateTask", new TaskToDo());
    }
    
    [HttpPost]
    public IActionResult CreateTask(TaskToDo response)
    {
        if (ModelState.IsValid)
        {
            _repo.Tasks.Add(response); // add response to database
            _repo.SaveChanges(); // save the changes

            return RedirectToAction("Index"); // reload page so form is empty
        }
        else
        {
            // add view bag so its loads the data
            ViewBag.Categories = _repo.Categories
                .OrderBy(c => c.CategoryName)
                .ToList();
            
            return View(response);
        }
    }
    
    [HttpGet]
    public IActionResult Edit(int id)
    {
        // get specific record by id
        var recordToEdit = _repo.Tasks
            .Single(x => x.TaskId == id);
        
        // viewbag to load data
        ViewBag.Categories = _repo.Categories
            .OrderBy(c => c.CategoryName)
            .ToList();
        
        return View("CreateTask", recordToEdit);
    }

    [HttpPost]
    public IActionResult Edit(TaskToDo updatedInfo)
    {
        if (ModelState.IsValid)
        {
            _repo.Update(updatedInfo);  // Update the movie record
            _repo.SaveChanges();  // Save changes to the database
        
            return RedirectToAction("Index");  // Redirect to movie list page
        }

        // If model state is invalid, reload the categories and return the form
        ViewBag.Categories = _repo.Categories
            .OrderBy(c => c.CategoryName)
            .ToList();
    
        return View("CreateTask", updatedInfo);
    }

    [HttpPost] 
    public IActionResult Delete(int id) 
    { 
        var recordToDelete = _repo.Tasks
            .SingleOrDefault(x => x.TaskId == id);
        
        if (recordToDelete != null) 
        { 
            _repo.Tasks.Remove(recordToDelete);
            _repo.SaveChanges();
        } 
        
        return RedirectToAction("Index"); // Redirects to the main list view
    }
}