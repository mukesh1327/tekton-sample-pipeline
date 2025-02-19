
namespace dotnet_todo.Service;

using dotnet_todo.Models.Dto;

public interface ITasksService
{
    Task<TaskResponseDTO> CreateTaskAsync(TaskCreateRequestDTO request);
    Task<TaskResponseDTO> GetTaskByIdAsync(int id);
    Task<TaskResponseDTO> UpdateTaskAsync(int id, TaskUpdateRequestDTO request);
    Task<IEnumerable<TaskResponseDTO>> GetAllTasksAsync();
    Task<bool> DeleteTaskAsync(int id);
}