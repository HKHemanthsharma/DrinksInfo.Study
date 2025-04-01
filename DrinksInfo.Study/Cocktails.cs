using DrinksInfo.Study.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DrinksInfo.Study
{
    public class Cocktails
    {
        private readonly string baseUrl;
        public  Cocktails(string baseUrl)
        {
            this.baseUrl = baseUrl;
        }
        public async Task<Drinksdomain> GetCategoryAsync()
        {
            string CategoryUrl = baseUrl + "/list.php?c=list";
            HttpClient client = new HttpClient();
            Stream stream = await client.GetStreamAsync(CategoryUrl);
            Drinksdomain Categorylist = await JsonSerializer.DeserializeAsync<Drinksdomain>(stream);
            return Categorylist;
        }
    }
}
