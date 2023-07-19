namespace Domain
{
    public class OrderProcessor
    {
        public void Processor(Order? order)
        {
            if(order != null)
            {
                if(order.IsVerified)
                {
                    if(order.Items.Count > 0)
                    {
                        if(order.Items.Count > 15)
                        {
                            throw new OrderHasTooManyLineItemsException(order.Id);
                        }

                        if (order.OrderStatus != "ReadyToProcess")
                        {
                            throw new OrderNotReadyForProcessingException(order.Id);
                        }

                        order.IsProcessed = true;
                    }
                }
            }
        }
    }
}
