namespace ExternalFormatProcessingLab.Data.Models
{
    public class ProductsWarehouse
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }
    }
}
