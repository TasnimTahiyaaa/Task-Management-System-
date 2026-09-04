using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagementSystem.Models
{
    [Table("UserInfo")]
    public class UserInfo
    {
        [Key]
        public int UserID { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; }

        public string PasswordHash { get; set; } = string.Empty;

        public string PasswordSalt { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }
        public ICollection<Project> Projects { get; set; }
             = new List<Project>();
    }
}