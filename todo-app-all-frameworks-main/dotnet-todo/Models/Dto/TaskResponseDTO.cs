namespace dotnet_todo.Models.Dto;

using dotnet_todo.Models.Entities;

public class TaskResponseDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime DueDate { get; set; }
    public TasksStatusEnum Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}