using Baydoun_TaskManagerAPIproj.Module;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

   namespace Baydoun_TaskManagerAPIproj.Controllers
   {

    [ApiController]
    [Route("api/tasks")]
   
        public class TaskController : ControllerBase
        {
            private static List<Module.Task> tasks = new List<Module.Task>();

            [HttpGet]
            public IActionResult GetTasks()
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
            public IActionResult CreateTask(Module.Task task)
            {
                task.Id = tasks.Count + 1;
                tasks.Add(task);

                return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
            }

            [HttpPut("{id}")]
            public IActionResult UpdateTask(int id, Module.Task updateTask)
            {
                var task = tasks.FirstOrDefault(task => task.Id == id);
                if (task == null)
                    return NotFound();

                task.Title = updateTask.Title;
                task.Description = updateTask.Description;
                task.DueDate = updateTask.DueDate;
                task.IsCompleted = updateTask.IsCompleted;

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

    
