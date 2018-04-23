using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Items")]
    public class ItemsController : Controller
    {
        private const string sessionKey = "items";
        [HttpGet]
        public List<Item> Get()
        {
            string maxWeight = HttpContext.Request.Query["maxWeight"];
            if (string.IsNullOrEmpty(maxWeight)) return getItems();
            float max = float.Parse(HttpContext.Request.Query["maxWeight"]);
            return getItems().Where(item => { return item.Weight < max; }).ToList();
        }

        [HttpGet("{index}", Name = "Get")]
        public Item Get(int index)
        {
            return getItems()[index];
        }

        [HttpPost]
        public void Post([FromBody]Item item)
        {
            var items = getItems();
            items.Add(item);
            HttpContext.Session.SetString(sessionKey, JsonConvert.SerializeObject(items));
        }

        private List<Item> getItems()
        {
            var data = HttpContext.Session.GetString(sessionKey);
            if (data == null) return new List<Item>();
            var items = JsonConvert.DeserializeObject<List<Item>>(data);
            return items;
        }
    }
}