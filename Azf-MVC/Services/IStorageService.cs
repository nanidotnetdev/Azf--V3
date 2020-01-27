using Microsoft.Azure.Storage.Queue;

namespace Azf_MVC
{
    public interface IStorageService
    {
        CloudQueue GetQueueRef(string queueName);
    }
}
