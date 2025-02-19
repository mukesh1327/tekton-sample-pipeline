using dotnet_todo.Service;

using Microsoft.AspNetCore.Mvc;
using dotnet_todo.Models.Dto;
using dotnet_todo.Exceptions;

namespace dotnet_todo.Controller;

[ApiController]
[Route("api/tasks")]
public class TasksController : ControllerBase
{
    private readonly ITasksService _taskService;

    public TasksController(ITasksService taskService)
    {
        _taskService = taskService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateTask([FromBody] TaskCreateRequestDTO request)
    {
        if (request.DueDate == DateTime.MinValue)
        {
        var errorResponse = new TasksErrorResponse
        {
            Message = "DueDate is required."
        };
        return BadRequest(errorResponse);
        }
        
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var taskDto = await _taskService.CreateTaskAsync(request);
            return CreatedAtAction(nameof(GetTask), new { id = taskDto.Id }, taskDto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal Server Error: {ex.Message}");
        }
    }

[HttpGet("read")]
public async Task<IActionResult> GetAllTasks()
{
    var tasks = await _taskService.GetAllTasksAsync();
    return Ok(tasks);
}

[HttpGet("get/{id}")]
public async Task<IActionResult> GetTask(int id)
{
    var taskDto = await _taskService.GetTaskByIdAsync(id);

    if (taskDto == null)
    {
        return NotFound();
    }

    return Ok(taskDto);
}


[HttpPut("update/{id}")]
public async Task<IActionResult> UpdateTask(int id, TaskUpdateRequestDTO request)
{
    var updatedTask = await _taskService.UpdateTaskAsync(id, request);

    if (updatedTask == null)
    {
        return NotFound(); // Task not found
    }

    return Ok(updatedTask);
}

[HttpDelete("delete/{id}")]
public async Task<IActionResult> DeleteTask(int id)
{
    var isDeleted = await _taskService.DeleteTaskAsync(id);

    if (!isDeleted)
    {
        return NotFound();
    }

    var response = new
    {
        message = "Task deleted"
    };

    return Ok(response);
}


}