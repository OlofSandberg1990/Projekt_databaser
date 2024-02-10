using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Databaser.Models
{
    internal class Student
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        [Required] 
        
        public string FirstName { get; set; }
        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }


        public string SocialSecurityNumber { get; set; }

        public string Gender { get; set; }

        public int? ClassId { get; set; }

        public Class Class { get; set; }

        public ICollection<Mark> Marks { get; set; }


    }
}
