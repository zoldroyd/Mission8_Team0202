namespace Mission8_Team0202.Models
{
    public interface ITaskRepository
    {
       List<TaskToDo> TasksToDo{ get; } // Fix: Use TaskToDo instead of Task

        // Method signatures
        void AddTask(TaskToDo task);
        void UpdateTask(TaskToDo task);
        void DeleteTask(TaskToDo task);
        void SaveChanges(); // Ensure SaveChanges exists

        List<Category> GetCategories(); // NEW: Add method to fetch categories
    }
}