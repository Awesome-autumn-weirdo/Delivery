using System;
using System.Drawing;

namespace Delivery
{
    public interface IDeliveryOrder
    {
        /// <summary>
        /// Возвращает положение местоназначения для данного заказа.
        /// </summary>
        /// <returns></returns>
        PointF GetPosition();
        /// <summary>
        /// Возвращает true, если заказ был завершен. Иначе - false.
        /// </summary>
        /// <returns></returns>
        bool IsFinished();
        /// <summary>
        /// Помечает заказ завершенным.
        /// </summary>
        void MarkFinished(DateTime deliveryDateTime);

        /// <summary>
        /// Возвращает вес посылки.
        /// </summary>
        /// <returns></returns>
        double GetWeight();
        /// <summary>
        /// Возвращает максимальный габарит посылки.
        /// </summary>
        /// <returns></returns>
        double GetMaxDimension();

        /// <summary>
        /// Возвращает дату и время подачи заявки на доставку.
        /// </summary>
        /// <returns></returns>
        DateTime GetSubmissionDateTime();

        /// <summary>
        /// Возвращает дату и время последнего срока доставки.
        /// 
        /// </summary>
        /// <returns></returns>
        DateTime GetDelayDateTime();

        /// <summary>
        /// Возвращает дату и время совершения доставки.
        /// </summary>
        /// <returns></returns>
        DateTime GetDeliveryDateTime();
    }
}
