using Baydoun_TaskManagerAPIproj;
using Microsoft.AspNetCore.Mvc;

namespace TaskManager.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TaskController : ControllerBase
    {
        private readonly TaskDbContext _context;

        public TaskController(TaskDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Task>> GetAllTasks()
        {
            var tasks = _context.Task.ToList();
            return tasks;
        }

        [HttpGet("{id}")]
        public ActionResult<Task> GetTaskById(int id)
        {
            var task = _context.Task.Find(id);
            if (task == null)
            {
                return NotFound();
            }

            return task;
        }

        [HttpPost]
        public ActionResult<Task> CreateTask(Task task)
        {
            _context.Task.Add(task);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetTaskById), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Task Update)
        {
            var task = _context.Task.Find(id);
            if (task == null)
            {
                return NotFound();
            }

            task.title = Update.title;
            task.description = Update.description;
            task.IsCompleted = Update.IsCompleted;

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            var task = _context.Task.Find(id);
            if (task == null)
            {
                return NotFound();
            }

            _context.Task.Remove(task);
            _context.SaveChanges();

            return NoContent();
        }
    }
}


