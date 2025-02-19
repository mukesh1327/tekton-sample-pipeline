using dotnet_todo.Helpers;
using dotnet_todo.Models.Dto;
using dotnet_todo.Models.Entities;
using Microsoft.EntityFrameworkCore;


namespace dotnet_todo.Service;

public class TasksService : ITasksService {
    private readonly AppDbContext _dbContext;
    public TasksService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<TaskResponseDTO> CreateTaskAsync(TaskCreateRequestDTO request)
    {
        var taskEntity = new Tasks
        {
            Name = request.Name,
            Description = request.Description,
            DueDate = request.DueDate.ToUniversalTime(),
            Status = request.Status,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
        };

        _dbContext.Tasks?.Add(taskEntity);
        await _dbContext.SaveChangesAsync();

        return new TaskResponseDTO
        {
            Id = taskEntity.Id,
            Name = taskEntity.Name,
            Description = taskEntity.Description,
            DueDate = taskEntity.DueDate,
            Status = taskEntity.Status,
            CreatedAt = taskEntity.CreatedAt,
            UpdatedAt = taskEntity.UpdatedAt,
        };
    }

    public async Task<IEnumerable<TaskResponseDTO>> GetAllTasksAsync()
    {
        var tasks = await _dbContext.Tasks!.ToListAsync();
        return tasks.Select(taskEntity => new TaskResponseDTO
        {
            Id = taskEntity.Id,
            Name = taskEntity.Name,
            Description = taskEntity.Description,
            DueDate = taskEntity.DueDate,
            Status = taskEntity.Status,
            CreatedAt = taskEntity.CreatedAt,
            UpdatedAt = taskEntity.UpdatedAt,
        });
    }

    public async Task<TaskResponseDTO> GetTaskByIdAsync(int id)
    {
        var taskEntity = await _dbContext.Tasks!.FirstOrDefaultAsync(t => t.Id == id);

        if (taskEntity == null)
        {
            return new TaskResponseDTO();
        }

        var status = Enum.GetName(typeof(TasksStatusEnum), taskEntity.Status);

        var taskDto = new TaskResponseDTO
        {
            Id = taskEntity.Id,
            Name = taskEntity.Name,
            Description = taskEntity.Description,
            DueDate = taskEntity.DueDate,
            Status = taskEntity.Status,
            CreatedAt = taskEntity.CreatedAt,
            UpdatedAt = taskEntity.UpdatedAt,
        };

        return taskDto;
    }

    public async Task<TaskResponseDTO> UpdateTaskAsync(int id, TaskUpdateRequestDTO request)
    {
        var taskEntity = await _dbContext.Tasks!.FirstOrDefaultAsync(t => t.Id == id);

        if (taskEntity == null)
        {
            return new TaskResponseDTO();
        }

        if (!string.IsNullOrEmpty(request.Name))
        {
            taskEntity.Name = request.Name;
        }

        if (!string.IsNullOrEmpty(request.Description))
        {
            taskEntity.Description = request.Description;
        }

        taskEntity.DueDate = request.DueDate.ToUniversalTime();
        taskEntity.Status = request.Status;
        taskEntity.UpdatedAt = DateTime.UtcNow;

        await _dbContext.SaveChangesAsync();

        return new TaskResponseDTO
        {
            Id = taskEntity.Id,
            Name = taskEntity.Name,
            Description = taskEntity.Description,
            DueDate = taskEntity.DueDate,
            Status = taskEntity.Status,
            CreatedAt = taskEntity.CreatedAt,
            UpdatedAt = taskEntity.UpdatedAt,
        };
    }

    public async Task<bool> DeleteTaskAsync(int id)
    {
        var taskEntity = await _dbContext.Tasks!.FirstOrDefaultAsync(t => t.Id == id);

        if (taskEntity == null)
        {
            return false; // Task not found
        }

        _dbContext.Tasks!.Remove(taskEntity);
        await _dbContext.SaveChangesAsync();

        return true; // Task deleted successfully
    }


}
