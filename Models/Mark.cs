using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Databaser.Models
{
    internal class Mark
    {
        [Key]
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public int EmployeeId {  get; set; }
        public int MarkMeaningId {  get; set; }

        public DateOnly DateOfMark { get; set; }

        public Student Student { get; set; }        
        public Employee Employee { get; set; }
        public MarkMeaning MarkMeaning { get; set; }

        public Course Course { get; set; }


    }
}
