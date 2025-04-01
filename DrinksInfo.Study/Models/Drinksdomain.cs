using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DrinksInfo.Study.Models
{
    public class Drinksdomain
    {
        [property:JsonPropertyName("drinks")]
        public List<Category> drinks { get; set; }
    }
}
