namespace ExternalFormatProcessingLab.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    public class Product
    {
        [JsonIgnore]
        public int  Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        
        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }

        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }

        public decimal Price { get; set; }

        public ICollection<ProductsWarehouse> ProductsWarehouses { get; set; } = new List<ProductsWarehouse>();
    }
}
