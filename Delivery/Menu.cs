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
    public partial class Menu : Form
    { 
        public Menu()
        {
            InitializeComponent();
            InitializeDateTimeValidation();
            SetDefaultValues();
        }

        private void InitializeDateTimeValidation()
        {
            this.startDateTimePicker.Validating += DateTimePicker_Validating;
            this.endDateTimePicker.Validating += DateTimePicker_Validating;
        }
        private void DateTimePicker_Validating(object sender, CancelEventArgs e)
        {

            if (this.startDateTimePicker.Value >= this.endDateTimePicker.Value)
            {
                e.Cancel = true;
                this.errorProvider.SetError((DateTimePicker)sender, "Дата (время) начала симуляции должна быть меньше даты (времени) окончания симуляции");
                return;
            }

            this.errorProvider.Clear();
        }
        private void SetDefaultValues()
        {
            // Устанавливаем по умолчанию в параметрах начала и окончания симуляции текущую и завтрашнюю даты соответственно.
            this.startDateTimePicker.Value = DateTime.Now;
            this.endDateTimePicker.Value = DateTime.Now.AddDays(1);
            // Устанавливаем по умолчанию скорость симуляции == 500.
            // Одна минута реального времени == 500 минут в симуляции.
            this.simulationSpeedMaskedTextBox.Text = "500";
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void runSimulationButton_Click(object sender, EventArgs e)
        {
            // build Configs from this form data.
            // ....

            DateTime startDateTime = startDateTimePicker.Value;
            DateTime endDateTime = endDateTimePicker.Value;
            int simulationSpeed = int.Parse(simulationSpeedMaskedTextBox.Text); 

            // var deliveryStationForm = new DeliveryStationForm(configs);
            // deliveryStationForm.ShowDialog();
            var mainForm = new MainForm(startDateTime, endDateTime, simulationSpeed); 
            mainForm.ShowDialog();
        }
    }
}
