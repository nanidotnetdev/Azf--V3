using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Azf_V3
{
    public static class TimerTrigger
    {
        [FunctionName("fnTimerTrigger")]
        public static void Run([TimerTrigger("0 */5 * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        }
    }
}
