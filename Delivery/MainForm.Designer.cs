namespace Delivery
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.MainTimer = new System.Windows.Forms.Timer(this.components);
            this.StartStopButton = new System.Windows.Forms.Button();
            this.CurrentDateTimeLabelHeader = new System.Windows.Forms.Label();
            this.CurrentDateTimeLabel = new System.Windows.Forms.Label();
            this.TotalCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.avgRouteLengthKmsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalWorkHoursDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.finishedOrdersCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delayedOrdersCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deliveryStatisticsBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.deliveryStatisticsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.deliveryStatisticsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deliveryStatisticsBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deliveryStatisticsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deliveryStatisticsBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoGenerateColumns = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.avgRouteLengthKmsDataGridViewTextBoxColumn,
            this.totalWorkHoursDataGridViewTextBoxColumn,
            this.finishedOrdersCountDataGridViewTextBoxColumn,
            this.delayedOrdersCountDataGridViewTextBoxColumn,
            this.TotalCost});
            this.dataGridView.DataSource = this.deliveryStatisticsBindingSource;
            this.dataGridView.Location = new System.Drawing.Point(12, 120);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 62;
            this.dataGridView.RowTemplate.Height = 28;
            this.dataGridView.Size = new System.Drawing.Size(828, 297);
            this.dataGridView.TabIndex = 0;
            // 
            // StartStopButton
            // 
            this.StartStopButton.Location = new System.Drawing.Point(646, 32);
            this.StartStopButton.Name = "StartStopButton";
            this.StartStopButton.Size = new System.Drawing.Size(142, 70);
            this.StartStopButton.TabIndex = 1;
            this.StartStopButton.Text = "|| |>";
            this.StartStopButton.UseVisualStyleBackColor = true;
            this.StartStopButton.Click += new System.EventHandler(this.StartStopButton_Click);
            // 
            // CurrentDateTimeLabelHeader
            // 
            this.CurrentDateTimeLabelHeader.AutoSize = true;
            this.CurrentDateTimeLabelHeader.Location = new System.Drawing.Point(28, 57);
            this.CurrentDateTimeLabelHeader.Name = "CurrentDateTimeLabelHeader";
            this.CurrentDateTimeLabelHeader.Size = new System.Drawing.Size(201, 20);
            this.CurrentDateTimeLabelHeader.TabIndex = 2;
            this.CurrentDateTimeLabelHeader.Text = "Дата и время симуляции:";
            this.CurrentDateTimeLabelHeader.Click += new System.EventHandler(this.label1_Click);
            // 
            // CurrentDateTimeLabel
            // 
            this.CurrentDateTimeLabel.AutoSize = true;
            this.CurrentDateTimeLabel.Location = new System.Drawing.Point(231, 57);
            this.CurrentDateTimeLabel.Name = "CurrentDateTimeLabel";
            this.CurrentDateTimeLabel.Size = new System.Drawing.Size(0, 20);
            this.CurrentDateTimeLabel.TabIndex = 3;
            // 
            // TotalCost
            // 
            this.TotalCost.DataPropertyName = "TotalCost";
            this.TotalCost.HeaderText = "Общая сумма расходов";
            this.TotalCost.MinimumWidth = 8;
            this.TotalCost.Name = "TotalCost";
            this.TotalCost.Width = 203;
            // 
            // avgRouteLengthKmsDataGridViewTextBoxColumn
            // 
            this.avgRouteLengthKmsDataGridViewTextBoxColumn.DataPropertyName = "AvgRouteLengthKms";
            this.avgRouteLengthKmsDataGridViewTextBoxColumn.HeaderText = "Средняя длина маршрута";
            this.avgRouteLengthKmsDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.avgRouteLengthKmsDataGridViewTextBoxColumn.Name = "avgRouteLengthKmsDataGridViewTextBoxColumn";
            this.avgRouteLengthKmsDataGridViewTextBoxColumn.Width = 223;
            // 
            // totalWorkHoursDataGridViewTextBoxColumn
            // 
            this.totalWorkHoursDataGridViewTextBoxColumn.DataPropertyName = "TotalWorkHours";
            this.totalWorkHoursDataGridViewTextBoxColumn.HeaderText = "Общее время работы";
            this.totalWorkHoursDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.totalWorkHoursDataGridViewTextBoxColumn.Name = "totalWorkHoursDataGridViewTextBoxColumn";
            this.totalWorkHoursDataGridViewTextBoxColumn.Width = 190;
            // 
            // finishedOrdersCountDataGridViewTextBoxColumn
            // 
            this.finishedOrdersCountDataGridViewTextBoxColumn.DataPropertyName = "FinishedOrdersCount";
            this.finishedOrdersCountDataGridViewTextBoxColumn.HeaderText = "Количество завершенных заказов";
            this.finishedOrdersCountDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.finishedOrdersCountDataGridViewTextBoxColumn.Name = "finishedOrdersCountDataGridViewTextBoxColumn";
            this.finishedOrdersCountDataGridViewTextBoxColumn.Width = 225;
            // 
            // delayedOrdersCountDataGridViewTextBoxColumn
            // 
            this.delayedOrdersCountDataGridViewTextBoxColumn.DataPropertyName = "DelayedOrdersCount";
            this.delayedOrdersCountDataGridViewTextBoxColumn.HeaderText = "Заказов просрочено";
            this.delayedOrdersCountDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.delayedOrdersCountDataGridViewTextBoxColumn.Name = "delayedOrdersCountDataGridViewTextBoxColumn";
            this.delayedOrdersCountDataGridViewTextBoxColumn.Width = 184;
            // 
            // deliveryStatisticsBindingSource2
            // 
            this.deliveryStatisticsBindingSource2.DataSource = typeof(Delivery.DeliveryStatistics);
            // 
            // deliveryStatisticsBindingSource
            // 
            this.deliveryStatisticsBindingSource.DataSource = typeof(Delivery.DeliveryStatistics);
            // 
            // deliveryStatisticsBindingSource1
            // 
            this.deliveryStatisticsBindingSource1.DataSource = typeof(Delivery.DeliveryStatistics);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 450);
            this.Controls.Add(this.CurrentDateTimeLabel);
            this.Controls.Add(this.CurrentDateTimeLabelHeader);
            this.Controls.Add(this.StartStopButton);
            this.Controls.Add(this.dataGridView);
            this.Name = "MainForm";
            this.Text = "Система доставки";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deliveryStatisticsBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deliveryStatisticsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deliveryStatisticsBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Timer MainTimer;
        private System.Windows.Forms.Button StartStopButton;
        private System.Windows.Forms.Label CurrentDateTimeLabelHeader;
        private System.Windows.Forms.Label CurrentDateTimeLabel;
        private System.Windows.Forms.BindingSource deliveryStatisticsBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn avgRouteLengthKmsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalWorkHoursDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn finishedOrdersCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn delayedOrdersCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalCost;
        private System.Windows.Forms.BindingSource deliveryStatisticsBindingSource2;
        private System.Windows.Forms.BindingSource deliveryStatisticsBindingSource1;
    }
}