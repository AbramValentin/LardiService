using LardiService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LardiService.Services
{
    /*
         Todo : 
            1.Make search available for all pages.
            2.Make search available for all car types.
     */


    public class LardiHttpClient
    {
        private string _mainUrlPart;
        private string _carType;
        private string _endOfUrlPart;
        private string _pageNumber;

        private string CountryFrom;
        private string CountryTo;

        private string AreaIdFrom;
        private string AreaIdTo;

        private string CityFrom;

        private string CityTo;

        private string DateFrom;

        private string DateTo;

        private string WeightTonMin;

        private string WeightTonMax;

        private string VolumeMin;

        private string VolumeMax;

        public LardiHttpClient()
        {

        }

        public LardiHttpClient(
            OrderParameters orderParameters
            )
        {
            AreaIdFrom = DefineAreaId(orderParameters.AreaIdFrom);
            AreaIdTo = DefineAreaId(orderParameters.AreaIdTo);

            WeightTonMin = orderParameters.MassTonMin;
            WeightTonMax = orderParameters.MassTonMax;

            VolumeMin = orderParameters.VolumeMin;
            VolumeMax = orderParameters.VolumeMax;

            SetDefaultValues();
        }

        /// <summary>
        /// Returns raw html string for further parsing.
        /// </summary>
        /// <returns></returns>
        public async Task<string> MakeSearchRequestAsync()
        {
            HttpClient httpClient = new HttpClient();

            string response = await httpClient.GetStringAsync(GetSearchUrl());

            return response;
        }

        public async Task<string> MakeSearchRequestAsync(string url)
        {
            HttpClient httpClient = new HttpClient();

            string response = await httpClient.GetStringAsync(url);

            return response;
        }


        private void SetDefaultValues()
        {
            _pageNumber = $"page={1}&fi=413bc406-3224-4cfd-9aab-7eff9961c986";
            _mainUrlPart = "https://lardi-trans.com/gruz/?foi=&filter_marker=new&";
            _carType = "bt_chbs_slc=1%2C1.34%2C1.36%2C1.23%2C1.27%2C1.43%2C1.25%2C1.32%2C1.68&bt_chb_group=1&bt_chb_group=1.34&bt_chb_group=1.36&bt_chb_group=1.23&bt_chb_group=1.27&bt_chb_group=1.43&bt_chb_group=1.25&bt_chb_group=1.32&bt_chb_group=1.68";
            _endOfUrlPart = "gabDl=&gabSh=&gabV=&zagruzFilterId=&adr=-1&showType=all&startSearch=%D0%A1%D0%B4%D0%B5%D0%BB%D0%B0%D1%82%D1%8C+%D0%B2%D1%8B%D0%B1%D0%BE%D1%80%D0%BA%D1%83";
            CountryFrom = "UA";
            CountryTo = "UA";
            CityFrom = "";
            CityTo = "";
            DateFrom = "";
            DateTo = "";
        }

        public string GetSearchUrl()
        {
            string url = $"{_mainUrlPart}" +
                $"countryfrom={CountryFrom}&countryto={CountryTo}" +
                $"&" +
                $"areafrom={AreaIdFrom}&areato={AreaIdTo}" +
                $"&" +
                $"cityFrom={CityFrom}&cityTo={CityTo}" +
                $"&" +
                $"dateFrom={DateFrom}&dateTo={DateTo}" +
                $"&" +
                $"{_carType}" +
                $"&" +
                $"mass={WeightTonMin}&mass2={WeightTonMax}" +
                $"&" +
                $"value={VolumeMin}&value2={VolumeMax}" +
                $"&" +
                $"{_endOfUrlPart}" +
                $"&" +
                $"{_pageNumber}";

            return url;
        }

        /*AREA ID DICTIONARY FOR LARDI TRANS SERVISE
         * 
        "Vinnytska"       : "15",
        "Volynska"        : "16",
        "Dnipropetrovska" : "17",
        "Donetska"        : "18",
        "Zhitomyrska"     : "19",
        "Zakarpatska"     : "20",
        "Zaporozska"      : "21",
        "Ivano-Frankivska": "22",
        "Kievska"         : "23",
        "Kirovogradska"   : "24",
        "Krym"            : "25",
        "Luganska"        : "26",
        "Lvivska"         : "27",
        "Nikolaevska"     : "28",
        "Odeska"          : "29",
        "Poltavska"       : "30",
        "Rovenska"        : "31",
        "Sumska"          : "32",
        "Ternopilska"     : "33",
        "Kharkovska"      : "34",
        "Khersonska"      : "35",
        "Khmelnitska"     : "36",
        "Cherkaska"       : "37",
        "Chernigovska"    : "38",
        "Chernivetska"    : "39"
             */

        private string DefineAreaId(string areaId)
        {
            string result = "";

            switch (areaId)
            {
                case "0": result = ""; break;
                case "1": result = "r2"; break;
                case "2": result = "r4"; break;
                case "3": result = "r6"; break;
                case "4": result = "r8"; break;
                case "5": result = "r10"; break;
                case "6": result = "15"; break;
                case "7": result = "16"; break;
                case "8": result = "17"; break;
                case "9": result = "18"; break;
                case "10": result = "19"; break;
                case "11": result = "20"; break;
                case "12": result = "21"; break;
                case "13": result = "22"; break;
                case "14": result = "23"; break;
                case "15": result = "24"; break;
                case "16": result = "25"; break;
                case "17": result = "26"; break;
                case "18": result = "27"; break;
                case "19": result = "28"; break;
                case "20": result = "29"; break;
                case "21": result = "30"; break;
                case "22": result = "31"; break;
                case "23": result = "32"; break;
                case "24": result = "33"; break;
                case "25": result = "34"; break;
                case "26": result = "35"; break;
                case "27": result = "36"; break;
                case "28": result = "37"; break;
                case "29": result = "38"; break;
                case "30": result = "39"; break;
                case "31": result = "40"; break;
                case "32": result = "41"; break;
                case "33": result = "42"; break;
                case "34": result = "43"; break;
                default: result = ""; break;
            }
            return result;
        }

    }
}
