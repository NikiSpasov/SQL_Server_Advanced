namespace FastFood.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Employee
	{
	    public int Id { get; set; }

        [Required]
        [Range(15, 80)]
	    public int Age { get; set; }

        [MinLength(3), MaxLength(30), Required]
	    public string Name { get; set; }

	    public int PositionId { get; set; }

        [Required]
        public Position Position { get; set; }

	    public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}