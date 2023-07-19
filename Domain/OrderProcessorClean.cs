namespace Domain
{
    public class OrderProcessorClean
    {
        private const int ProcessableNumberOfLineItems = 15;

        public void Process(Order? order)
        {
            if (!IsOrderProcessable(order))            
                return;
            
            if (order!.Items.Count > ProcessableNumberOfLineItems)
            {
                throw new OrderHasTooManyLineItemsException(order.Id);
            }

            if (order.OrderStatus != OrderStatus.ReadyToProcess)
            {
                throw new OrderNotReadyForProcessingException(order.Id);
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
