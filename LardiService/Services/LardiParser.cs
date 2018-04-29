using HtmlAgilityPack;
using LardiService.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LardiService.Services
{
    public class LardiParser
    {
        /// <summary>
        /// Returns list of OrderInfo objects filtered by array of order id. If there are no orders, empty list is returned.
        /// </summary>
        /// <param name="rawHtmlString">Html string to parse.</param>
        /// <param name="orderIdListToFilterBy">
        ///     List or order id to skip.If order with such id founded, than this order is skiped,
        ///     if not founded, than added to array of new orders, that will be returned.
        /// </param>
        /// <returns></returns>
        public async Task<List<OrderInfo>> GetOrdersAsync(string rawHtmlString, int ordersAmount)
        {
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(rawHtmlString);

            var orderTableXpath = "//tr[@class=\"predlInfoRow\"]";
            var orderNodes = htmlDocument.DocumentNode.SelectNodes(orderTableXpath).ToList();

            if (ordersAmount < 0 || ordersAmount > orderNodes.Count)
            {
                orderNodes = orderNodes.GetRange(0, orderNodes.Count);
            }
            else
            {
                orderNodes = orderNodes.GetRange(0, ordersAmount);
            }

            List<OrderInfo> orderList = new List<OrderInfo>();

            foreach (var item in orderNodes)
            {
                string cityFrom = item.ChildNodes[5].InnerText;
                string cityTo = item.ChildNodes[6].InnerText;       
                string distance =
                    ParseDistance(item.ChildNodes[2].InnerHtml)
                    ??
                    await GetGoogleMapProvidedDestanation(cityFrom, cityTo);

                orderList.Add(new OrderInfo(
                       orderIdFromSite: item.Id,
                       distance: distance,
                       shippingDate: item.ChildNodes[3].InnerText,
                       carBodyType: item.ChildNodes[4].InnerText,
                       cityFrom: cityFrom,
                       cityTo: cityTo,
                       cargoInfo: item.ChildNodes[7].InnerText,
                       paymentInfo: item.ChildNodes[8].InnerText,
                       contactInfoLink: "Link to lardi web site contact page"
                    ));
            }

            return orderList;
        }

        private async Task<string> GetGoogleMapProvidedDestanation(string cityFrom, string cityTo)
        {

            HttpClient httpClient = new HttpClient();
            string response = await httpClient.GetStringAsync($"https://maps.googleapis.com/maps/api/distancematrix/json?" +
                $"origins={cityFrom}" +
                $"&" +
                $"destinations={cityTo}" +
                $"& mode=driving&language=en-EN&sensor=false&key=AIzaSyDnaqSIx40TrBWKT1l9YG2tg5E4ipyev54");


            JObject jObject = JObject.Parse(response);
            string distance = "";

            try
            {
                distance = (string)jObject["rows"][0]["elements"][0]["distance"]["text"];
            }
            catch
            {
                distance = "Not found";
            }

            return distance;
        }

        private string ParseDistance(string rawHtml)
        {
            string kilometers = rawHtml;
            int titleIndex = kilometers.IndexOf("title");
            if (titleIndex > 0)
            {
                kilometers = kilometers.Substring(titleIndex + 7, 6);
            }
            else
            {
                kilometers = null;
            }

            return kilometers;
        }
    }
}
