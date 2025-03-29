namespace ADONET.DTO
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int StockQuantity { get; set; }
        public string WarrantyPeriod { get; set; }
        public string Color { get; set; }
        public string? ScreenSize { get; set; }
        public string? Storage { get; set; }
        public string? Processor { get; set; }
        public string? BatteryCapacity { get; set; }
    }
}
