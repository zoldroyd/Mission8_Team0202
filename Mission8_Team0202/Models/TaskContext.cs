using Microsoft.EntityFrameworkCore;

namespace Mission8_Team0202.Models;

public class TaskContext :DbContext
{
    public TaskContext()
    {
    }

    public TaskContext(DbContextOptions<TaskContext> options) : base(options)
    { }
 
    public DbSet<Category> Categories { get; set; }
    public DbSet<TaskToDo> Tasks { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder) // seed data
    {
        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, CategoryName = "Home" },
            new Category { CategoryId = 2, CategoryName = "School" },
            new Category { CategoryId = 3, CategoryName = "Work" },
            new Category { CategoryId = 4, CategoryName = "Church" }
        );
        
        modelBuilder.Entity<TaskToDo>().HasData(
            new TaskToDo { TaskId = 1, TaskName = "Clean my room", DueDate = new DateTime(2025,5,10),  CategoryId = 1, Quadrant = 4, Completed = false },
            new TaskToDo { TaskId = 2, TaskName = "Take 414 midterm", DueDate = new DateTime(2025,3,10),  CategoryId = 2, Quadrant = 1, Completed = false },
            new TaskToDo { TaskId = 3, TaskName = "Go for a run", DueDate = new DateTime(2025,4,10),  CategoryId = 1, Quadrant = 2, Completed = false },
            new TaskToDo { TaskId = 4, TaskName = "Go to the grocery story", DueDate = new DateTime(2025,2,10),  CategoryId = 2, Quadrant = 1, Completed = false },
            new TaskToDo { TaskId = 5, TaskName = "Fill up water", DueDate = new DateTime(2025,2,10),  CategoryId = 1, Quadrant = 1, Completed = true},
            new TaskToDo { TaskId = 6, TaskName = "Read a book", DueDate = new DateTime(2025,2,10),  CategoryId = 1, Quadrant = 3, Completed = false },
            new TaskToDo { TaskId = 7, TaskName = "Get a haircut", DueDate = new DateTime(2025,2,10),  CategoryId = 1, Quadrant = 3, Completed = false },
            new TaskToDo { TaskId = 8, TaskName = "Do homework", DueDate = new DateTime(2025,2,10),  CategoryId = 3, Quadrant = 2, Completed = false }

        );
    }
    
}