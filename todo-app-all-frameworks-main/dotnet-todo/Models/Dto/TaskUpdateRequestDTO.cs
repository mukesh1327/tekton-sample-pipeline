using dotnet_todo.Models.Entities;
using System.ComponentModel.DataAnnotations;
public class TaskUpdateRequestDTO
{

    [Required(ErrorMessage = "Name is required.")]
    [MaxLength(255, ErrorMessage = "Name cannot exceed 20 characters.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Description is required.")]
    [MaxLength(1000, ErrorMessage = "Description cannot exceed 300 characters.")]
    public string? Description { get; set; }
    public DateTime DueDate { get; set; }
    public TasksStatusEnum Status { get; set; }
}