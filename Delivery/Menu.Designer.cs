namespace Delivery
{
    partial class Menu
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.runSimulationButton = new System.Windows.Forms.Button();
            this.startDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.simulationSpeedMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // runSimulationButton
            // 
            this.runSimulationButton.Location = new System.Drawing.Point(12, 255);
            this.runSimulationButton.Name = "runSimulationButton";
            this.runSimulationButton.Size = new System.Drawing.Size(385, 84);
            this.runSimulationButton.TabIndex = 2;
            this.runSimulationButton.Text = "Запуск моделирования";
            this.runSimulationButton.UseVisualStyleBackColor = true;
            this.runSimulationButton.Click += new System.EventHandler(this.runSimulationButton_Click);
            // 
            // startDateTimePicker
            // 
            this.startDateTimePicker.CustomFormat = "dd-MM-yyyy:HH-mm";
            this.startDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startDateTimePicker.Location = new System.Drawing.Point(12, 56);
            this.startDateTimePicker.Name = "startDateTimePicker";
            this.startDateTimePicker.Size = new System.Drawing.Size(385, 26);
            this.startDateTimePicker.TabIndex = 3;
            this.startDateTimePicker.Value = new System.DateTime(2024, 1, 18, 7, 54, 42, 0);
            // 
            // endDateTimePicker
            // 
            this.endDateTimePicker.CustomFormat = "dd-MM-yyyy:HH-mm";
            this.endDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.endDateTimePicker.Location = new System.Drawing.Point(12, 133);
            this.endDateTimePicker.Name = "endDateTimePicker";
            this.endDateTimePicker.Size = new System.Drawing.Size(385, 26);
            this.endDateTimePicker.TabIndex = 4;
            this.endDateTimePicker.Value = new System.DateTime(2024, 1, 19, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(367, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Дата и время начала работы службы доставки";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(392, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Дата и время окончания работы службы доставки";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Скорость симуляции";
            // 
            // simulationSpeedMaskedTextBox
            // 
            this.simulationSpeedMaskedTextBox.Location = new System.Drawing.Point(12, 212);
            this.simulationSpeedMaskedTextBox.Mask = "00000";
            this.simulationSpeedMaskedTextBox.Name = "simulationSpeedMaskedTextBox";
            this.simulationSpeedMaskedTextBox.Size = new System.Drawing.Size(385, 26);
            this.simulationSpeedMaskedTextBox.TabIndex = 8;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 349);
            this.Controls.Add(this.simulationSpeedMaskedTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.endDateTimePicker);
            this.Controls.Add(this.startDateTimePicker);
            this.Controls.Add(this.runSimulationButton);
            this.Name = "Menu";
            this.Text = "Меню";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button runSimulationButton;
        private System.Windows.Forms.DateTimePicker startDateTimePicker;
        private System.Windows.Forms.DateTimePicker endDateTimePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox simulationSpeedMaskedTextBox;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}

