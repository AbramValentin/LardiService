using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LardiService.Models
{
    public class OrderParameters
    {
        public string AreaIdFrom { get; set; }
        public string AreaIdTo { get; set; }
        public string MassTonMin { get; set; }
        public string MassTonMax { get; set; }
        public string VolumeMin { get; set; }
        public string VolumeMax { get; set; }

        public OrderParameters
            (
                string areaIdFrom,
                string areaIdTo,
                string massTonMin,
                string massTonMax,
                string volumeMin,
                string volumeMax
            )
        {
            AreaIdFrom = areaIdFrom;
            AreaIdTo = areaIdTo;
            MassTonMin = massTonMin;
            MassTonMax = massTonMax;
            VolumeMin = volumeMin;
            VolumeMax = volumeMax;
        }
    }
}
