using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Delivery
{
    internal class DeliveryManLoader
    {
        private static readonly string jsonPath = "deliverymans.json";
        internal List<BaseDelivery> Load()
        {
            try
            {
                string jsonData = File.ReadAllText(jsonPath);
                return JsonConvert.DeserializeObject<List<BaseDelivery>>(jsonData, new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto});
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
