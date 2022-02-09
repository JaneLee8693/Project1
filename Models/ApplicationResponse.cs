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

        [Required(ErrorMessage = " Please enter the task.")]
        public string Task { get; set; }

        public DateTime DueDate { get; set; }

        [Required(ErrorMessage = " Please enter the quadrant it belongs to.")]
        public byte Quadrant { get; set; }

        public bool Completed { get; set; }

        //Build Foreign Key Relationship
        [Required(ErrorMessage = "Please enter a valid category")]
        public int CategoryId { get; set; }
        public Category CategoryName { get; set; }

    }
}