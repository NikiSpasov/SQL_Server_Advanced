namespace ExternalFormatProcessingLab.Data.Models
{
    using System.Collections.Generic;

    public class Warehouse
    {
        public int Id { get; set; }

        public string Location { get; set; }

        public ICollection<ProductsWarehouse> ProductsWarehouses { get; set; } = new List<ProductsWarehouse>();
    }
}
