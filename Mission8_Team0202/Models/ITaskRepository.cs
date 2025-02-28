namespace Mission8_Team0202.Models
{
    public interface ITaskRepository
    {
        List<Task> TasksTodo { get; }
        // Method signatures
        void AddTask(Task task);
        void UpdateTask(Task task);
        void DeleteTask(Task task); // Corrected method name to Pascal casing
    }
}