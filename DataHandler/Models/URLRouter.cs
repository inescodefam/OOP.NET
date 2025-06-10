using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataHandler.Models
{
    public class URLRouter
    {
        public static string BASE_URL_F = "https://worldcup-vua.nullbit.hr/women";
        public static string BASE_URL_M = "https://worldcup-vua.nullbit.hr/men";

        public static string Matches(string baseURL)
            => baseURL + Match.ENDPOINT;

        public static string MatchesFiltered(string baseURL, string fifa_code)
            => Matches(baseURL) + Match.COUNTRY_CODE + fifa_code;

        public static string Teams(string baseURL)
            => baseURL + TeamsResults.ENDPOINT;
    }
}
