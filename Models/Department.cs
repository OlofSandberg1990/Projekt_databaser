using System.ComponentModel.DataAnnotations;

namespace Projekt_Databaser.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string DepartmentName { get; set; }
    }
}