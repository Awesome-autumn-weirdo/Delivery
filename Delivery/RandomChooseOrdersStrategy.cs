using System;
using System.Collections.Generic;
using System.Linq;
namespace Delivery
{

    internal class RandomChooseOrdersStrategy : IChooseOrdersStrategy
    {
        private static IList<T> Shuffle<T>(IList<T> list)
        {
            Random r = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = r.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }

            return list;
        }

        public IList<IDeliveryOrder> ChooseOrders(IList<IDeliveryOrder> orders, BaseDelivery deliveryman)
        {
            orders = Shuffle(orders);
            var ordersToTake = new List<IDeliveryOrder>();

            foreach (var order in orders)
            {
                if (deliveryman.CanTakeOrder(order))
                {
                    ordersToTake.Add(order);
                }
            }

            return ordersToTake;
        }
    }
}
