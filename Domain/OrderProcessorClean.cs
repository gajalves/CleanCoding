namespace Domain
{
    public class OrderProcessorClean
    {
        private const int ProcessableNumberOfLineItems = 15;

        public ProcessOrderResult Process(Order? order)
        {
            if (!IsOrderProcessable(order))            
                return ProcessOrderResult.NotProcessable();
            
            if (order!.Items.Count > ProcessableNumberOfLineItems)
            {                
                return ProcessOrderResult.HasToManyLineItems(order.Id);
            }

            if (order.OrderStatus != OrderStatus.ReadyToProcess)
            {
                return ProcessOrderResult.NotReadyForProcessing(order.Id);
            }

            order.IsProcessed = true;

            return ProcessOrderResult.Successful(order.Id);
        }

        private static bool IsOrderProcessable(Order? order)
        {
            return order is not null &&
                   order.IsVerified &&
                   order.Items.Any();
        }
    }
}
