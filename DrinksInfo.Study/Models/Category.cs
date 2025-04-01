using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DrinksInfo.Study.Models
{
    
    public class Category
    {
        [propery: JsonPropertyName("strCategory")]
        public string CategoryName { get; set; }
    }
}
