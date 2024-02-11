using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery
{
    class BaseDelivery
    {
        public BaseDelivery(ITransport transport, IChooseOrdersStrategy chooseOrderStategy, decimal baseCostPerHour) 
        {
            BaseCostPerHour = baseCostPerHour;
            Transport = transport;
            ChooseOrdresStrategy = chooseOrderStategy;
        }

        public void StartForWork(DateTime start)
        {
            StartWorkDateTime = start;
        }

        /**
         * Свойства предельных и текущих веса, габарита, скорости делегированы 
         * используемому курьером транспортному средству.
         */


        /// <summary>
        /// Параметр отвечает за максимальную грузоподъёмность курьера.
        /// </summary>
        public double GetWeightLimit()
        {
            return Transport.GetLimitWeight();
        }


        /// <summary>
        /// Параметр отвечает за максимальные габариты доставляемого груза.
        /// </summary>
        public double GetDimensionsLimit()
        { 
            return Transport.GetLimitDimensions();
        }

        /// <summary>
        /// Параметр отвечает за максимальную скорость передвижения курьера.
        /// Достигается при отсутствии переносимого груза.
        /// </summary>
        public double GetSpeedLimit()
        { 
            return Transport.GetLimitSpeed();
        }

        /// <summary>
        /// Параметр отвечает за текущую нагруженность курьера.
        /// </summary>
        public double GetCurrentWeight()
        {
            return Transport.GetCurrentWeight();
        }

        /// <summary>
        /// Параметр отвечает за текущую скорость передвижения курьера.
        /// </summary>
        public double GetCurrentSpeed()
        { 
            return Transport.GetCurrentSpeed();
        }

        /// <summary>
        /// Свойство определяет базовую стоимость обслуживания курьера.
        /// </summary>
        public decimal BaseCostPerHour { get; }

        /// <summary>
        /// Метод производит выборку подходящих данному курьеру заказов, которые он впоследствии 
        /// бронирует и исполняет.
        /// </summary>
        /// <param name="orders">Список доступных заказов на доставку</param>
        /// <returns> Список выбранных курьером заказов</returns>
        public IList<IDeliveryOrder> ChooseOrders(IList<IDeliveryOrder> orders)
        { 
            // Делегируем выбор заказов на исполнение соответствующей стратегии.
            return ChooseOrdresStrategy.ChooseOrders(orders, this);
        }

        /// <summary>
        /// Метод отправляет доставщика из текущего местоположения на станцию распределения посылок.
        /// </summary>
        public void GoToDeliveryStation()
        {
            GoTo(centerPosition);
        }

        /// <summary>
        /// Метод призывает курьера исполнить текущий заказ.
        /// </summary>
        /// <returns>Возвращает true, если удалось выполнить заказ. Иначе - false.</returns>
        public bool ExecuteOrder(IDeliveryOrder order)
        {
            // Если курьер не смог в выданный период времени добраться до места назначения,
            // то прерываем исполнение заказов - ресурс времени израсходован, в этот подход
            // курьер не сможет сделать ничего полезного.
            if (!GoTo(order.GetPosition()))
            {
                return false;
            }

            // Помечаем заказ исполненным.
            MarkFinished(order);
            return true;
        }

        private void CleanupTakenOrders()
        {
            // Удаляем все завершенные заказы.
            TakenOrders.RemoveAll(order => order.IsFinished());
        }

        private void MarkFinished(IDeliveryOrder order)
        {
            // Записываем за курьером выполненный заказ для статистики.
            FinishedOrders.Add(order);

            // Облегчаем ношу доставщика.
            Transport.AddWeight(-order.GetWeight());

            // Помечаем заказ выполненным.
            order.MarkFinished(CurrentDateTime);
        }

        public bool GoTo(PointF targetPosition)
        {
            Console.WriteLine(Transport.GetPosition().X + " " + Transport.GetPosition().Y);
            // Пытаемтся сместить транспорт в точку назначения.
            // Важно, что длина пути может быть больше линейного расстояния между точками
            // (если водитель плутал или объезжал пробку, например).
 
            // Метод вернет отсавшееся
            // количество временного ресурса.
            var updatedDelta = Transport.GoTo(targetPosition, CurrentDelta);
            CurrentDateTime += CurrentDelta - updatedDelta;
            CurrentDelta = updatedDelta;
            var newPosition = Transport.GetPosition();

            return CalcDistance(newPosition, targetPosition) < epsilon;
        }

        // Данный параметр сообщает в пределах какого радиуса присутствие курьера 
        // от места назначения будет считаться прибытием в точку.
        // Введено в силу неточности машинных вещественных чисел. 
        protected static double epsilon = 0.1;


        private double CalcDistance(PointF position, PointF newPosition)
        {
            // Вычисляем евклидово расстояние, допустимо использовать другие метрики.
            double x = position.X - newPosition.X;
            double y = position.Y - newPosition.Y;
            return Math.Sqrt(x * x + y * y);
        }

        /// <summary>
        /// Посредством метода происходит оповещение курьеров о изменении времени симуляции.
        /// </summary>
        /// <param name="delta">Прошедший период времени в симуляции</param>
        public void UpdateDeltaTime(TimeSpan delta)
         {
            CurrentDelta = delta;

            // По очереди начинаем исполнять взятые в распределительном центре заказы.
            for (int i = 0; i < TakenOrders.Count; i++)
            {
                ExecuteOrder(TakenOrders[i]);
            }

            // Удаляем завершенные заказы.
            CleanupTakenOrders();
            // Если забронированных заказов не осталось - возвращаем курьера в распределительный центр.
            if (TakenOrders.Count == 0)
            {
                GoToDeliveryStation();
                if (CalcDistance(Transport.GetPosition(), centerPosition) < epsilon)
                {
                    SetOrdersAnnounce(ref OrdersDataBase);
                    if (TakenOrders.Count == 0)
                    {
                        // Сбрасываем ресурс времени.
                        CurrentDelta = TimeSpan.Zero;
                        return;
                    }
                }

                if (CurrentDelta != TimeSpan.Zero)
                {
                    UpdateDeltaTime(CurrentDelta);
                }
            }

            // Сбрасываем ресурс времени.
            CurrentDelta = TimeSpan.Zero;
        }





        /*
         * Нижеследующий участок кода определяет специфику данной симуляционной модели.
         * В зависимости от установленных инструментов передвижения и принятия решения
         * кокретный тип курьера будет отстаивать своё право называться наиболее эффективным
         * исполнителем.

         * Возможно как изменение и расширение инструментов (через реализацию соответствующих элементов),
         * так и изменение входных параметров симуляции, что может влиять на целесообразность использования 
         * определенных типов курьеров.
         */

        /// <summary>
        /// Свойство содержит экземпляр класса, реализующего интерфейс транспортного средства.
        /// </summary>
        public ITransport Transport { get; set; }

        /// <summary>
        /// Свойство содержит экземпляр класса, реализующего интерфейс стратегии принятия решения
        /// в отношении доступных заказов.
        /// </summary>
        public IChooseOrdersStrategy ChooseOrdresStrategy { get; set; }


        /// <summary>
        /// Метод предоставляет информацию об общей стоимости обслуживания курьера
        /// на текущий момент с учётом выполненных заказов, преодоленных расстояний,
        /// потраченных ресурсов и т.д.
        /// </summary>
        /// <returns>Стоимость обслуживания курьера в условных единицах ценности.</returns>
        public decimal GetTotalCost()
        {
            double spentTime = CalcTotalWorkHours();
            // TODO: check it!
            return BaseCostPerHour * (decimal)spentTime + Transport.CalcTotalCost(CurrentDateTime.Subtract(StartWorkDateTime));
        }

        private double CalcTotalWorkHours()
        {
            // Возвращаем количество часов, прошедших между началом работы курьера и текущим временем.
            return CurrentDateTime.Subtract(StartWorkDateTime).TotalHours;
        }

        private IList<IDeliveryOrder> OrdersDataBase;
        internal void SetOrdersAnnounce(ref IList<IDeliveryOrder> orders)
        {
            Console.WriteLine("Add orders. Count:" + orders.Count.ToString());
            OrdersDataBase = orders;
            var ordersToTake = ChooseOrders(orders);
            foreach (var order in ordersToTake)
            {
                if (CanTakeOrder(order))
                {
                    Transport.AddWeight(order.GetWeight());
                    TakenOrders.Add(order);
                    OrdersDataBase.Remove(order);
                }
            }

            foreach (var o in TakenOrders)
            {
                Console.WriteLine("Taken " + o.ToString() + o.GetPosition().X + " " + o.GetPosition().Y);
            }
        }

        internal bool CanTakeOrder(IDeliveryOrder order)
        {
            return order.GetWeight() <= GetWeightLimit() - GetCurrentWeight() &&
                   order.GetMaxDimension() <= GetDimensionsLimit();
        }

        internal IList<IDeliveryOrder> GetFinishedOrders()
        {
            return FinishedOrders;
        }

        internal double GetTotalWorkHours()
        {
            return CalcTotalWorkHours();
        }

        internal double GetTotalMileageKms()
        {
            return Transport.GetTotalMileAgeKms();
        }

        protected DateTime StartWorkDateTime;
        protected DateTime CurrentDateTime;
        protected TimeSpan CurrentDelta;

        protected List<IDeliveryOrder> TakenOrders = new List<IDeliveryOrder>();
        protected List<IDeliveryOrder> FinishedOrders = new List<IDeliveryOrder>();

        // protected Point deliveryPosition = centerPosition;

        // Положение распределительного центра определим как точку (0, 0)
        protected static readonly PointF centerPosition = new Point(0, 0);
    }
}
