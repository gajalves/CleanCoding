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
                            throw new Exception("The order " + order.Id + " has too many items.");
                        }

                        if (order.OrderStatus != "ReadyToProcess")
                        {
                            throw new Exception("The order " + order.Id + " isn't ready to process");
                        }

                        order.IsProcessed = true;
                    }
                }
            }
        }
    }
}
