using Newtonsoft.Json;
using System;
using System.Drawing;

namespace Delivery
{
    internal class BaseOrder : IDeliveryOrder
    {
        [JsonProperty]
        protected DateTime SubmissionDateTime;
        [JsonProperty]
        protected DateTime DelayDateTime;
        [JsonProperty]
        protected DateTime DeliveryDateTime;

        [JsonProperty]
        protected bool IsOrderFinished;
        [JsonProperty]
        protected double MaxDimension;
        [JsonProperty]
        protected double Weight;

        [JsonProperty]
        PointF TargetPosition;

        public BaseOrder(PointF targetPosition, double weight, double maxDimension, DateTime submission, DateTime delay)
        { 
            TargetPosition = targetPosition;
            Weight = weight;
            MaxDimension = maxDimension;
            DelayDateTime = delay;
            SubmissionDateTime = submission;
        }

        public DateTime GetDelayDateTime()
        {
            return DelayDateTime;
        }

        public DateTime GetDeliveryDateTime()
        {
            return DeliveryDateTime;
        }

        public double GetMaxDimension()
        {
            return MaxDimension;
        }

        public PointF GetPosition()
        {
            return TargetPosition;
        }

        public DateTime GetSubmissionDateTime()
        {
            return SubmissionDateTime;
        }

        public double GetWeight()
        {
            return Weight;
        }

        public bool IsFinished()
        {
            return IsOrderFinished;
        }

        public void MarkFinished(DateTime delivery)
        {
            DeliveryDateTime = delivery;
            IsOrderFinished = true;
        }
    }
}
