using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Databaser.Models
{
    internal class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(20)]

        public string SocialSecurityNumber { get; set; }
        [MaxLength(20)]
        public string Gender { get; set; }

        public int RoleId {  get; set; }

        public int DepartmentId { get; set; }
        public Decimal Salary { get; set; }

        public DateOnly DateOfEmploy { get; set; }

        public Role Role { get; set; }

        public Department Department { get; set; }

        public ICollection<Mark> Marks { get; set; }

    }
}
