namespace Mission8_Team0202.Models
{
    // Implementing the ITaskRepository interface
    public class EFTaskRepository : ITaskRepository
    {
        private TaskContext _context;

        // Constructor with dependency injection
        public EFTaskRepository(TaskContext temp)
        {
            _context = temp;
        }
        
        public List<Task> TasksTodo => _context.Tasks.ToList();

        // AddTask method to add a new task
        public void AddTask(Task task)
        {
            _context.Add(task);
            _context.SaveChanges();
        }

        // UpdateTask method to update an existing task
        public void UpdateTask(Task task)
        {
            _context.Update(task);
            _context.SaveChanges();
        }

        // DeleteTask method to remove an existing task
        public void DeleteTask(Task task)
        {
            _context.Remove(task);
            _context.SaveChanges();
        }
    }
}