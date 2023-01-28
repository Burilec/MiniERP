namespace MiniERP.Models
{
    public sealed class Product : BaseIdentifier
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Unit Unit { get; set; }
    }
}