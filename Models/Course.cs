using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Databaser.Models
{
    internal class Course
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string CourseName { get; set; }

        public bool IsActive { get; set; }

        
        
    }
}
