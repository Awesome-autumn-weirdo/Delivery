using System;
using System.Drawing;

namespace Delivery
{
    /// <summary>
    /// Интерфейс позволяет доставщику делегировать ограничения на 
    /// вес, габариты, скорость передвижения на своё транспортное средство.
    /// </summary>
    internal interface ITransport
    {
        /// <summary>
        /// Метод определяет максимальную грузоподъёмность транспортного средства.
        /// </summary>
        /// <returns>Максимальный вес груза в килограммах.</returns>
        double GetLimitWeight();
        /// <summary>
        /// Метод определяет максимальную габаритную вместительность транспортного средства.
        /// </summary>
        /// <returns>Максимальный габарит груза в метрах.</returns>
        double GetLimitDimensions();
        /// <summary>
        /// Метод определяет максимальную достигаемую скорость транспортного средства.
        /// </summary>
        /// <returns>Максимальная скорость в км/ч.</returns>
        double GetLimitSpeed();

        /// <summary>
        /// Метод возвращает текущую скорость транспортного средства.
        /// </summary>
        /// <returns>Текущая скорость в км/ч.</returns>
        double GetCurrentSpeed();

        /// <summary>
        /// Метод возвращает текущую нагрузку на транспортное средство.
        /// </summary>
        /// <returns>Текущий вес груза в килограммах.</returns>
        double GetCurrentWeight();
        
        /// <summary>
        /// Метод возвращает общую сумму условных единиц ценности, расходованных за период пользования.
        /// </summary>
        /// <param name="spentTime">Период использования транспортного средства</param>
        /// <returns></returns>
        decimal CalcTotalCost(TimeSpan spentTime);
        
        
        
        TimeSpan GoTo(PointF positioт, TimeSpan timeResource);
        PointF GetPosition();
        double GetTotalMileAgeKms();
        void AddWeight(double v);
    }
}
