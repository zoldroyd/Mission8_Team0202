using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission8_Team0202.Models;

public class Task
{
    [Key]
    public int TaskId { get; set; }
    [Required]
    public string TaskName { get; set; }
    public string DueDate { get; set; }
    [Required]
    public int Quadrant { get; set; }
    [ForeignKey("CategoryId")]
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public string Completed { get; set; }
}