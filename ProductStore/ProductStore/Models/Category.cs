﻿using System.ComponentModel.DataAnnotations;

namespace ProductStore.Models
{
    public class Category
    {
        [Key] 
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }

        public List<Product> Products { get; set; }
    }
}
