using System;
using System.Collections.Generic;
using System.Text;

namespace FastFood.DataProcessor.Dto.Import
{
    using FastFood.Models;

    public class OrderDto
    {
        public string Customer { get; set; }

        public Employee Employee { get; set; }

        public DateTime DateTime { get; set; }

        public ItemDto[] Items { get; set; }
    }
}
