using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery
{
    internal class OnFoot : TransportImpl
    {
        public OnFoot(double baseSpeed, double baseWeightLimit, double baseDimensionsLimit, decimal baseCostPerHour, PointF position) : base(baseSpeed, baseWeightLimit, baseDimensionsLimit, baseCostPerHour, position)
        {
        }

        public override decimal CalcTotalCost(TimeSpan spentTime)
        {
            // Использование своих двоих не требует никаких расходов.
            return 0;
        }
    }
}
