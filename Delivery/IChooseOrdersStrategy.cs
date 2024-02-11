using System.Collections.Generic;

namespace Delivery
{
    internal interface IChooseOrdersStrategy
    {
        IList<IDeliveryOrder> ChooseOrders(IList<IDeliveryOrder> orders, BaseDelivery deliveryman);
    }
}