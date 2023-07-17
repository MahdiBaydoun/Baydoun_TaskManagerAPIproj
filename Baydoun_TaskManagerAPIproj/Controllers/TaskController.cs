using Baydoun_TaskManagerAPIproj.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace Baydoun_TaskManagerAPIproj.Controllers
{

    [ApiController]
    [Route("api/tasks")]

    public class TaskController : ControllerBase
    {
        private static readonly List<Models.Task> tasks = new();

        [HttpGet]
        public  IActionResult GetTasks()
        {
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public IActionResult GetTask(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
                return NotFound();

            return Ok(task);
        }

        [HttpPost]
        public async IActionResult CreateTask(TaskRequest task)
        {
            var newId = tasks.Any() ? tasks.Max(t => t.Id) + 1 : 1;
            var newTask = new Models.Task(newId, task.Title, task.Description, task.DueDate, task.IsCompleted);
            tasks.Add(newTask);

            return  CreatedAtAction(nameof(CreateTask), task, newTask);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, TaskRequest updateTask)
        {
            var task = tasks.FirstOrDefault(task => task.Id == id);
            if (task == null)
                return NotFound();

            task.Update(updateTask.Title, updateTask.Description, updateTask.DueDate, updateTask.IsCompleted);
            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
                return NotFound();

            tasks.Remove(task);

            return NoContent();
        }
    }
}

//public async Task<IActionResult> GetTasks()
//{
//    var tasks = await _context.Tasks.ToListAsync();
//    return Ok(tasks);
//}

//public async Task<IActionResult> GetTask(int id)
//{
//    var task = await _context.Tasks.FindAsync(id);
//    if (task == null)
//    {
//        return NotFound();
//    }

//    return Ok(task);
//}

//public async Task<IActionResult> CreateTask(Task task)
//{
//    await _context.Tasks.AddAsync(task);
//    await _context.SaveChangesAsync();

//    return CreatedAtAction("GetTask", new { id = task.Id });
//}

//public async Task<IActionResult> UpdateTask(int id, Task task)
//{
//    var existingTask = await _context.Tasks.FindAsync(id);
//    if (existingTask == null)
//    {
//        return NotFound();
//    }

//    existingTask.Title = task.Title;
//    existingTask.Description = task.Description;
//    existingTask.DueDate = task.DueDate;

//    await _context.SaveChangesAsync();

//    return Ok(existingTask);
//}

//public async Task<IActionResult> DeleteTask(int id)
//{
//    var task = await _context.Tasks.FindAsync(id);
//    if (task == null)
//    {
//        return NotFound();
//    }

//    _context.Tasks.Remove(task);
//    await _context.SaveChangesAsync();

//    return Ok();
//}
