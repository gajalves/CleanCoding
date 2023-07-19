namespace Domain
{
    public class OrderProcessorClean
    {
        public void Process(Order? order)
        {
            if (!IsOrderProcessable(order))            
                return;
            
            if (order!.Items.Count > 15)
            {
                throw new Exception("The order " + order.Id + " has too many items.");
            }

            if (order.OrderStatus != "ReadyToProcess")
            {
                throw new Exception("The order " + order.Id + " isn't ready to process");
            }

            order.IsProcessed = true;
        }

        private static bool IsOrderProcessable(Order? order)
        {
            return order is not null &&
                   order.IsVerified &&
                   order.Items.Any();
        }
    }
}
