using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.EndToEndTests
{
    public static class SeleniumExtensions
    {
        private const string _baseUrl = "http://localhost:63671";

        public static void GoToPage(this INavigation navigation, string url)
        {
            var path = Path.Combine(_baseUrl, url);
            navigation.GoToUrl(path);
        }
    }
}
