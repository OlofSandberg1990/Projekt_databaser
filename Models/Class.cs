using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Databaser.Models
{
    internal class Class
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string ClassName { get; set; }

        public ICollection<Student> ClassList { get; set;}
    }
}
