using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Databaser.Models
{
    internal class MarkMeaning
    {
        [Key]
        public int Id { get; set; }
        public string MarkName { get; set; }
        
    }
}
