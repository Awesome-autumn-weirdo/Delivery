using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Delivery
{
    internal class DeliveryOrdersLoader
    {
        private static readonly string jsonPath = "deliveryorders.json";
        internal List<IDeliveryOrder> Load()
        {
            try
            {
                string jsonData = File.ReadAllText(jsonPath);
                return JsonConvert.DeserializeObject<List<IDeliveryOrder>>(jsonData, new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
