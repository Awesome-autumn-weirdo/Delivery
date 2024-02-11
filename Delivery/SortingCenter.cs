using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Delivery
{
    internal class SortingCenter
    {
        private DateTime start;
        private DateTime finish;

        private DeliveryOrdersLoader ordersLoader = new DeliveryOrdersLoader();
        private DeliveryManLoader deliverymanLoader = new DeliveryManLoader();

        private IList<BaseDelivery> deliverymans = new List<BaseDelivery>();
        private IList<IDeliveryOrder> orders = new List<IDeliveryOrder>();

        public delegate void SimulationFinishedHandler();
        public event SimulationFinishedHandler simulationFinished;
        public SortingCenter(DateTime start, DateTime finish)
        {
            this.start = start;
            this.finish = finish;

            try 
            {
                deliverymans = deliverymanLoader.Load();
            }
            catch 
            {
                MessageBox.Show("Не удалось загрузить данные о доставщиках распределительного центра. Убедитесь, что соответствующие конфигурационные файлы существуют и корректны.", "Ошибка загрузки данных", MessageBoxButtons.OK);
                Application.Exit();
            }
            try
            {
                orders = ordersLoader.Load();
            }
            catch
            {
                MessageBox.Show("Не удалось загрузить данные о заказах распределительного центра. Убедитесь, что соответствующие конфигурационные файлы существуют и корректны.", "Ошибка загрузки данных", MessageBoxButtons.OK);
                Application.Exit();
            }

            for (int i = 0; i < deliverymans.Count; i++)
            {
                deliverymans[i].SetOrdersAnnounce(ref orders);
            }
        }

        internal IList<DeliveryStatistics> GetDeliveryStatistics()
        {
            var deliveryStatistics = new List<DeliveryStatistics>();
            foreach (var delivery in deliverymans)
            { 
                deliveryStatistics.Add(new DeliveryStatistics(delivery));
            }

            return deliveryStatistics;
        }

        internal void Update(int deltaTimeInseconds)
        {
            var deltaTimeSpan = TimeSpan.FromSeconds(deltaTimeInseconds);
            for (int i = 0; i < deliverymans.Count; i++)
            {
                deliverymans[i].UpdateDeltaTime(deltaTimeSpan);
            }

            start += deltaTimeSpan;
            if (start >= finish)
            {
                simulationFinished?.Invoke();
                MessageBox.Show("Заданный временной период симуляции подошёл к концу.", "Симуляция завершена", MessageBoxButtons.OK);
            }
        }
    }
}
