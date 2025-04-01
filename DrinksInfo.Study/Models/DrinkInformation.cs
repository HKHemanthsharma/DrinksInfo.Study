using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DrinksInfo.Study.Models
{
    public class DrinkInformation
    {
        [property:JsonPropertyName("strDrink")]        
        public string DrinkName { get; set; }
        [property: JsonPropertyName("strDrinkThumb")]
        public string DrinkImageUrl { get; set; }
        [property: JsonPropertyName("idDrink")]
        public string DrinkId { get; set; }
    }
}
