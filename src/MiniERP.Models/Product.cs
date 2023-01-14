namespace MiniERP.Models
{
    public sealed class Product : BaseIdentifier
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Quantity { get; set; }
        public Unit Unit { get; set; }
        public decimal Price { get; set; }
    }
}