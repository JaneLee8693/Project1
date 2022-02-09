using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Project1.Models
{
    public class ApplicationResponse
    {
        [Key]
        [Required]
        public int TaskId { get; set; }
        public string Task { get; set; }
        public string DueDate { get; set; }
        public byte Quadrant { get; set; }
        public string Category { get; set; }
        public bool Completed { get; set; }

    }
}
