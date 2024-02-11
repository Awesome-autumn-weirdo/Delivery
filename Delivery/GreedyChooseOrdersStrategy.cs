using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Delivery
{
    internal class GreedyChooseOrdersStrategy : IChooseOrdersStrategy
    {
        public IList<IDeliveryOrder> ChooseOrders(IList<IDeliveryOrder> orders, BaseDelivery deliveryman)
        {
            var availableOrders = orders.Where(order => deliveryman.CanTakeOrder(order)).ToList();
            if (availableOrders.Count >= 1)
            {
                var target = availableOrders[0];
                return OrderByDistanceToTarget(availableOrders, target);
            }

            return availableOrders;
        }

        private IList<IDeliveryOrder> OrderByDistanceToTarget(List<IDeliveryOrder> availableOrders, IDeliveryOrder target)
        {
            return availableOrders.OrderBy(order => CalcDistance(order.GetPosition(), target.GetPosition())).ToList();
        }

        private double CalcDistance(PointF order, PointF target)
        {
            double x = order.X - target.X;
            double y = order.Y - target.Y;
            return Math.Sqrt(x * x  + y * y);
        }
    }
}
