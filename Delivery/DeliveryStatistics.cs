namespace Delivery
{
    internal class DeliveryStatistics
    {
        public double AvgRouteLengthKms { get; set; }
        public double TotalWorkHours { get; set; }
        public double FinishedOrdersCount { get; set; }
        public double DelayedOrdersCount { get; set; }

        public decimal TotalCost { get; set; }
        public DeliveryStatistics(BaseDelivery deliveryMan) 
        {
            FinishedOrdersCount = deliveryMan.GetFinishedOrders().Count;
            foreach (var order in deliveryMan.GetFinishedOrders())
            {
                if (order.GetDeliveryDateTime() > order.GetDelayDateTime())
                {
                    DelayedOrdersCount++;
                }
            }

            TotalWorkHours = deliveryMan.GetTotalWorkHours();
            AvgRouteLengthKms = (FinishedOrdersCount == 0) ? 0 : deliveryMan.GetTotalMileageKms() / FinishedOrdersCount;
            TotalCost = deliveryMan.GetTotalCost();
        }
    }
}
