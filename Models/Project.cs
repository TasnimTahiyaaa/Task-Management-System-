using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagementSystem.Models
{
    [Table("Projects")]
    public class Project
    {
        [Key]
        public int ProjectID { get; set; }

        public int UserID { get; set; }

        public string ProjectName { get; set; } = string.Empty;

        public string? Description { get; set; }

        public DateTime Deadline { get; set; }

        public string Priority { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }

        [ForeignKey("UserID")]
        public UserInfo? User { get; set; }
        public ICollection<TaskItem> Tasks { get; set; }
          = new List<TaskItem>();
    }
}