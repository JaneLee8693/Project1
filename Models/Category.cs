using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

//Create a new model for the category for the data normalization. CategoryId is the primary key.

namespace Project1.Models
{
    public class Category
    {   [Key]
        [Required]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
