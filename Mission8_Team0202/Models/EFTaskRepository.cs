

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
