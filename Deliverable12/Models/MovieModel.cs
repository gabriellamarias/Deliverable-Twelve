using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Deliverable12.Models
{
    public class Movie
    {
        [Required]
        public int ID { get; set; }
        [StringLength(50)]
        public string Title { get; set; }
        [Required]
        public string Genre { get; set; }
        [Range(1880, 2021)]
        public int Year { get; set; }
        [Required]
        public string Actor { get; set; }
        [Required]
        public string Director { get; set; }
        
    }
}
