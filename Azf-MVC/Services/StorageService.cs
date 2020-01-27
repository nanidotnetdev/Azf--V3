using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Queue;
using Microsoft.Extensions.Configuration;

namespace Azf_MVC
{
    public class StorageService: IStorageService
    {
        private readonly IConfiguration _config;

        public StorageService(IConfiguration config)
        {
            _config = config;
        }

        public CloudQueue GetQueueRef(string queueName)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(_config.GetValue<string>("StorageConnection"));

            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();

            CloudQueue queue = queueClient.GetQueueReference(queueName);

            queue.CreateIfNotExists();

            return queue;
        }
    }
}
