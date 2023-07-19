namespace Domain
{
    public class Order
    {
        public long Id { get; set; }
        public bool IsVerified { get; set; }
        public bool IsProcessed { get; set; }
        public string OrderStatus { get; set; } = string.Empty;
        public List<LineItem> Items { get; set; } = new();
    }
}