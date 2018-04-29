using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LardiService.Models
{
    public class OrderInfo
    {
        public string OrderIdFromSite { get; set; }

        public string OrderRegistrationTime { get; set; }

        public string ShippingDate { get; set; }

        public string CarBodyType { get; set; }

        public string CityFrom { get; set; }

        public string CityTo { get; set; }

        public string Distance { get; set; }

        public string CargoInfo { get; set; }

        public string PaymentInfo { get; set; }

        public string ContactInfoLink { get; set; }

        public OrderInfo(
            string orderIdFromSite,
            string shippingDate,
            string carBodyType,
            string cityFrom,
            string cityTo,
            string distance,
            string cargoInfo,
            string paymentInfo,
            string contactInfoLink
            )
        {
            OrderIdFromSite = orderIdFromSite;
            ShippingDate = shippingDate;
            CarBodyType = carBodyType;
            CityFrom = cityFrom;
            CityTo = cityTo;
            Distance = distance;
            CargoInfo = cargoInfo;
            PaymentInfo = paymentInfo;
            ContactInfoLink = contactInfoLink;

            OrderRegistrationTime = DateTime.Now.ToShortTimeString();
        }
    }
}
