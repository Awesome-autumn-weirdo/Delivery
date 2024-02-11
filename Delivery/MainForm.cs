using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Delivery
{
    public partial class MainForm : Form
    {
        private SortingCenter sortingCenter;
        private int simulationSpeed;
        private static int timerIntervalInSeconds = 1;
        public MainForm(DateTime start, DateTime finish, int simSpeed)
        {
            simulationSpeed = simSpeed;
            InitializeComponent();
            CurrentDateTime = start;
            CurrentDateTimeLabel.Text = start.ToString();

            MainTimer.Interval = timerIntervalInSeconds * 1000;
            MainTimer.Tick += MainTimer_Tick;

            sortingCenter = new SortingCenter(start, finish);
            sortingCenter.simulationFinished += SortingCenter_simulationFinished;
        }

        private void SortingCenter_simulationFinished()
        {
            MainTimer.Stop();
        }

        private DateTime CurrentDateTime;
        private void MainTimer_Tick(object sender, EventArgs e)
        {
            sortingCenter.Update(timerIntervalInSeconds * simulationSpeed);
            if (MainTimer.Enabled)
            {
                CurrentDateTime = CurrentDateTime.Add(TimeSpan.FromSeconds(timerIntervalInSeconds * simulationSpeed));
                CurrentDateTimeLabel.Text = CurrentDateTime.ToString();
                deliveryStatisticsBindingSource.DataSource = sortingCenter.GetDeliveryStatistics();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Метод при нажатии соответствующей кнопки переключает главный таймер симуляции.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartStopButton_Click(object sender, EventArgs e)
        {
            ToggleTimer();
        }

        private void ToggleTimer()
        {
            if (MainTimer.Enabled)
            {
                MainTimer.Stop();
            }
            else
            {
                MainTimer.Start();
            }
        }
    }
}
