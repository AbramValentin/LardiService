using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using LardiService.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using LardiService.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LardiService
{
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Get(
            string orderParameters,
            string userLogin,
            string userPassword,
            int ordersToReturn
            )
        {
            //TODO : check is request is authorized

            OrderParameters parameters = JsonConvert
                .DeserializeObject<OrderParameters>(orderParameters);

            LardiHttpClient lardiClient = new LardiHttpClient(parameters);

            string htmlString = await lardiClient.MakeSearchRequestAsync();

            LardiParser lardiParser = new LardiParser();

            List<OrderInfo> orders =  await lardiParser.GetOrdersAsync(htmlString, ordersToReturn);

            string searchPageUrl = lardiClient.GetSearchUrl();

            foreach (var item in orders)
            {
                item.ContactInfoLink = searchPageUrl;
            }

            return Ok(orders);
        }
        
    }
}
