namespace ADONET.DTO
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public int StockQuantity { get; set; }
        public string WarrantyPeriod { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public string? ScreenSize { get; set; }
        public string? Storage { get; set; }
        public string? Processor { get; set; }
        public string? BatteryCapacity { get; set; }
        public decimal? DiscountedPrice { get; set; }
    }
}
