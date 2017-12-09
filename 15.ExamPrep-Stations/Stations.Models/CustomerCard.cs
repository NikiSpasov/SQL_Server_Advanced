﻿namespace Stations.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Drawing;
    using Stations.Models.Enums;

    public class CustomerCard
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        [Required]
        [Range(0, 120)]
        public int Age { get; set; }

        public CardType Type { get; set; }

        public ICollection<Ticket> BoughtTickets { get; set; }


    }
}
