using Microsoft.EntityFrameworkCore;

namespace Mission8_Team0202.Models;

public class TaskContext :DbContext
{
    public TaskContext(DbContextOptions<TaskContext> options) : base(options)
    { }
 
    public DbSet<Category> Categories { get; set; }
    public DbSet<Task> Tasks { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder) // seed data
    {
        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, CategoryName = "Home" },
            new Category { CategoryId = 2, CategoryName = "School" },
            new Category { CategoryId = 3, CategoryName = "Work" },
            new Category { CategoryId = 4, CategoryName = "Church" }
        );
        
        modelBuilder.Entity<Task>().HasData(
            new Task { TaskId = 1, TaskName = "Clean my room", DueDate = "May 1, 2021",  CategoryId = 1, Quadrant = 4, Completed = "false" },
            new Task { TaskId = 2, TaskName = "Take 414 midterm", DueDate = "April 1, 2021",  CategoryId = 2, Quadrant = 1, Completed = "false" },
            new Task { TaskId = 3, TaskName = "Go for a run", DueDate = "March 1, 2021",  CategoryId = 1, Quadrant = 2, Completed = "false" },
            new Task { TaskId = 4, TaskName = "Go to the grocery story", DueDate = "Feb 1, 2021",  CategoryId = 2, Quadrant = 1, Completed = "false" }

        );
    }
    
}