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
            try
            {
                string CategoryUrl = baseUrl + "/list.php?c=list";
                HttpClient client = new HttpClient();
                Stream stream = await client.GetStreamAsync(CategoryUrl);
                Drinksdomain Categorylist = await JsonSerializer.DeserializeAsync<Drinksdomain>(stream);
                return Categorylist;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        public async Task<CategoryDrinks> GetDrinksByCategoryAsync(string categoryName)
        {
            try
            {
                string CategoryUrl = baseUrl + $"/filter.php?c={categoryName}";
                HttpClient client = new HttpClient();
                Stream stream = await client.GetStreamAsync(CategoryUrl);
                CategoryDrinks drinksList = await JsonSerializer.DeserializeAsync<CategoryDrinks>(stream);
                return drinksList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        public async Task<InformationDrinks> GetDrinkInformationByIdAsync(string Id)
        {
            try
            {
                HttpClient client = new HttpClient();
                string infoUrl = baseUrl + $"/lookup.php?i={Id}";
                Stream stream = await client.GetStreamAsync(infoUrl);
                InformationDrinks drinksinfo = await JsonSerializer.DeserializeAsync<InformationDrinks>(stream);
                return drinksinfo;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}
