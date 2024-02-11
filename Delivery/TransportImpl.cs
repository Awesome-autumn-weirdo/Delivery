using System;
using System.Drawing;

namespace Delivery
{ 
    /// <summary>
    /// Класс реализует интерфейс транспортного средства 
    /// за исключением метода определения стоимости 
    /// использования транспортного средства.
    /// Реализация этого метода ожидается в наследниках абстрактного класса.
    /// </summary>
    internal abstract class TransportImpl : ITransport
    {
        public TransportImpl()
        { 
        }
        public TransportImpl(double baseSpeed, double baseWeightLimit, double baseDimensionsLimit, decimal baseCostPerHour, PointF startPosition) 
        {
            SpeedLimit = baseSpeed;
            WeightLimit = baseWeightLimit;
            DimensionsLimit = baseDimensionsLimit;
            CostPerHour = baseCostPerHour;
            Position = startPosition;
        }

        public abstract decimal CalcTotalCost(TimeSpan spentTime);

        public double GetCurrentSpeed()
        {
            /*       График зависимости скорости от нагруженности 
             *       Задаётся квадратичным уравнением параболы с ветвями вниз, смещенной на
             *       SpeedLimit вверх.
             *       
             *       S(W) = -alpha * W^2 + SpeedLimit
             *       alpha - неизвестный коэффициент, найдём его из условия S(WeightLimit) = 1 (Если загрузить курьера на максимум, то он будет ооооочень медленно идти)
             *       alpha = (SpeedLimit - 1) / (WeightLinit^2)
             *       
             *       Конечное уравнение скорости в зависимости от нагрузки:
             *       S(W) = SpeedLimit -  alpha * W^2 
             * 
             *                                 speed
             *                               ^
             *                               |   
             *                               |   
             *                               |
             *                    speedLimit + * * * ** 
             *                               |          **
             *                               |             **
             *                               |              **
             *                               |               **
             *                               |               **      
             *      -----------------------------------------+-------------> weight
             *                                           weighLimit
             * 
             * 
             * 
             * */

            double alpha = (SpeedLimit - 1) / (WeightLimit * WeightLimit);
            CurrentSpeed = SpeedLimit  -  alpha * (CurrentWeight * CurrentWeight);

            return CurrentSpeed;
        }

        public double GetCurrentWeight()
        {
            return CurrentWeight;
        }

        public double GetLimitDimensions()
        {
            return DimensionsLimit;
        }

        public double GetLimitSpeed()
        {
            return SpeedLimit;
        }

        public double GetLimitWeight()
        {
            return WeightLimit;
        }

        public TimeSpan GoTo(PointF position, TimeSpan timeResource)
        {
            // Вычисляем вектор между текущим положением транспорта и точкой назначения
            float x = position.X - Position.X;
            float y = position.Y - Position.Y;
            var targetDistance = Math.Sqrt(x * x + y * y);

            // Вычисляем время, необходимое на преодоление расстояния на этом транспортном средстве.
            var time = targetDistance / GetCurrentSpeed();
            // Если предоставленного ресурса времени недостаточно
            if (TimeSpan.FromHours(time) > timeResource)
            {
                // Преодолеем максимально возможное расстояние
                var availableDistance = timeResource.TotalHours * GetCurrentSpeed();


                // Обновляем положение транспортного средства и значение пробега
                float lambda = (float)availableDistance / (float)targetDistance;
                float newX = Position.X + x * lambda;
                float newY = Position.Y + y * lambda;
                Position = new PointF(newX, newY);
                MileageKms += availableDistance;
                
                // Весь ресурс времени был расходован
                return TimeSpan.Zero;
            }
            
            // Расходуем только необходимый ресурс времени
            timeResource -= TimeSpan.FromHours(time);
            // Обновляем положение транспортного средства и значение пробега
            MileageKms += targetDistance;
            Position = position;

            return timeResource;
        }

        public PointF GetPosition()
        {
            return Position;
        }

        public double GetTotalMileAgeKms()
        {
            return MileageKms;
        }

        public void AddWeight(double additionalWeight)
        {
            CurrentWeight += additionalWeight;
        }

        public double SpeedLimit { get; set; }
        public double WeightLimit { get; set; }
        public double DimensionsLimit { get; set; }
        public decimal CostPerHour { get; set; }
        public PointF Position { get; set; }
        public double CurrentSpeed { get; set; }
        public double CurrentWeight { get; set; }

        public double MileageKms { get; set; }
    }
}
