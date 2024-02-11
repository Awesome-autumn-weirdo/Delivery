using Newtonsoft.Json;
using System;
using System.Drawing;

namespace Delivery
{
    internal class Car : TransportImpl
    {
        [JsonProperty]
        private readonly double fuelConsumptionPerKm;
        [JsonProperty]
        private readonly decimal fuelCost;

        public Car(double baseSpeed, double baseWeightLimit, double baseDimensionsLimit, decimal baseCostPerHour, PointF startPosition, double fuelConsumptionPerKm, decimal fuelCost) : base(baseSpeed, baseWeightLimit, baseDimensionsLimit, baseCostPerHour, startPosition)
        {
            this.fuelConsumptionPerKm = fuelConsumptionPerKm;
            this.fuelCost = fuelCost;
        }
        
        public override decimal CalcTotalCost(TimeSpan spentTime)
        {
            return (decimal)spentTime.TotalHours * CostPerHour + (decimal)GetTotalMileAgeKms() * (decimal)fuelConsumptionPerKm * fuelCost;
        }
    }
}
