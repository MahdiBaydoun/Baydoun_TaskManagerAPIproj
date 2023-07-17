    namespace Baydoun_TaskManagerAPIproj.Models
{

    public class TaskRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
    }
    
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }

        public Task(int id, string title, string description, DateTime dueDate, bool isCompleted)
        {
            Id = id;
            Title = title;
            Description = description;
            DueDate = dueDate;
            IsCompleted = isCompleted;
        }
        public void Update(string title, string description, DateTime dueDate, bool isCompleted)
        {
            Title = title;
            Description = description;
            DueDate = dueDate;
            IsCompleted = isCompleted;
        }
    }
}
