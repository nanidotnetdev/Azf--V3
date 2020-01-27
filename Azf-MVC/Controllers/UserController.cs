using Azf_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Storage.Queue;
using Newtonsoft.Json;
using System;

namespace Azf_MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IStorageService _storageService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="storageService"></param>
        public UserController(IStorageService storageService)
        {
            _storageService = storageService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        public IActionResult CreateUser(User user)
        {
            if (ModelState.IsValid)
            {
                user.UserId = Guid.NewGuid();

                //add message to queue.
                var queue = _storageService.GetQueueRef("userupdatequeue");
                CloudQueueMessage message = new CloudQueueMessage(JsonConvert.SerializeObject(user));
                queue.AddMessage(message);
            }

            return RedirectToAction("Index");
        }
    }
}