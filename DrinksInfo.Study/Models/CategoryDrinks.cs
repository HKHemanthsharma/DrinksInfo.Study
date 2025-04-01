using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DrinksInfo.Study.Models
{
    public class CategoryDrinks
    {
        [property:JsonPropertyName("drinks")]
        public List<DrinkInformation> DrinksByCategory { get; set; }

    }
}
