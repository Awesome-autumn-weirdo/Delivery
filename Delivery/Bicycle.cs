using System;
using System.Drawing;

namespace Delivery
{
    internal class Bicycle : TransportImpl
    {
        public Bicycle(double baseSpeed, double baseWeightLimit, double baseDimensionsLimit, decimal baseCostPerHour, PointF position) : base(baseSpeed, baseWeightLimit, baseDimensionsLimit, baseCostPerHour, position)
        {
        }

        public override decimal CalcTotalCost(TimeSpan spentTime)
        {
            // Использование велосипеда предполагает траты на почасовую аренду.
            return (decimal)spentTime.TotalHours * CostPerHour;
        }
    }
}
