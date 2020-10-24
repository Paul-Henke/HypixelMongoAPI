using Hypixel.BusinessLogic;
using Hypixel.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Hypixel.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessionController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<BAZAAR_CHILD>> GetInformations()
        {
            FormatData dataFormater = new FormatData();
            HashSet<BAZAAR> allLists = new HashSet<BAZAAR>();
            GetHTTPResponse logic = new GetHTTPResponse();

            BazaarItems items = new BazaarItems();
            using (var reader = new StreamReader(logic.getResponse("https://api.hypixel.net/skyblock/bazaar/products?key=b6c4154f-df9c-4a06-81ed-31088596b5d9")))
            {
                string json = reader.ReadToEnd();
                items = JsonConvert.DeserializeObject<BazaarItems>(json);
            }

            List<HashSet<BAZAAR>> myList = new List<HashSet<BAZAAR>>();

            List<Task> tasks = new List<Task>();
            foreach (string item in items.productIds)
            {
                tasks.Add(new Task(() =>
                {
                    using (var reader = new StreamReader(logic.getResponse($"https://api.hypixel.net/skyblock/bazaar/product?key=b6c4154f-df9c-4a06-81ed-31088596b5d9&productId={item}")))
                    {
                        string json = reader.ReadToEnd();
                        allLists.Add(JsonConvert.DeserializeObject<BAZAAR>(json));
                    }
                }));
            }
            int i = 0;
            foreach (Task item in tasks)
            {
                if (i <= 10)
                {
                    Thread.Sleep(1000);
                    item.Start();
                    i++;
                }
            }
            allLists = dataFormater.FormatBazaarItems(allLists);
            List<BAZAAR_CHILD> newVal = dataFormater.FormatDatas(allLists);
            return newVal;
        }
    }

}
