using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagementSystem.Models
{
    [Table("Tasks")]
    public class TaskItem
    {
        [Key]
        public int TaskID { get; set; }

        public int ProjectID { get; set; }

        public string TaskTitle { get; set; } = string.Empty;

        public string? Description { get; set; }

        public DateTime DueDate { get; set; }

        public string Priority { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }

        [ForeignKey("ProjectID")]
        public Project? Project { get; set; }
    }
}