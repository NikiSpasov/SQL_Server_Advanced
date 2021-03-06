﻿namespace FastFood.DataProcessor.Dto.Import
{
    using System.ComponentModel.DataAnnotations;

    public class EmployeeDto
    {
        [MinLength(3), MaxLength(30), Required]
        public string Name { get; set; }

        [Required]
        [Range(15, 80)]
        public int Age { get; set; }

        [Required]
        [MinLength(3), MaxLength(30)]
        public string Position { get; set; }
    }
}