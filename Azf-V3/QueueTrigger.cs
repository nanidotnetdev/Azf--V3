using Azf_V3.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Azf_V3
{
    public static class QueueTrigger
    {
        [FunctionName("fnQueueTrigger")]
        public static void Run([QueueTrigger("userupdatequeue", Connection = "")]string myQueueItem, ILogger log)
        {
            //trigger the function on new queue item.
            //process the data.
            var user = JsonConvert.DeserializeObject<User>(myQueueItem);

            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
