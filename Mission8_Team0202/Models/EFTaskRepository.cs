// namespace Mission8_Team0202.Models
// {
//     // Implementing the ITaskRepository interface
//     public class EFTaskRepository : ITaskRepository
//     {
//         private TaskContext _context;
//
//         // Constructor with dependency injection
//         public EFTaskRepository(TaskContext temp)
//         {
//             _context = temp;
//         }
//         
//         public List<Task> TasksTodo => _context.Tasks.ToList();
//
//         // AddTask method to add a new task
//         public void AddTask(Task task)
//         {
//             _context.Add(task);
//             _context.SaveChanges();
//         }
//
//         // UpdateTask method to update an existing task
//         public void UpdateTask(Task task)
//         {
//             _context.Update(task);
//             _context.SaveChanges();
//         }
//
//         // DeleteTask method to remove an existing task
//         public void DeleteTask(Task task)
//         {
//             _context.Remove(task);
//             _context.SaveChanges();
//         }
//     }
// }

using Microsoft.EntityFrameworkCore;

namespace Mission8_Team0202.Models
{
    public class EFTaskRepository : ITaskRepository
    {
        private TaskContext _context;

        public EFTaskRepository(TaskContext temp)
        {
            _context = temp;
        }

        public List<TaskToDo> TasksToDo => _context.Tasks.Include(t => t.Category).ToList();

        public void AddTask(TaskToDo task)
        {
            _context.Tasks.Add(task);
        }

        public void UpdateTask(TaskToDo task)
        {
            _context.Tasks.Update(task);
        }

        public void DeleteTask(TaskToDo task)
        {
            _context.Tasks.Remove(task);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public List<Category> GetCategories() // Implement GetCategories method
        {
            return _context.Categories.OrderBy(c => c.CategoryName).ToList();
        }
    }
}
