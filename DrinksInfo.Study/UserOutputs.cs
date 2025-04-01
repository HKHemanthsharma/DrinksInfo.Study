using DrinksInfo.Study.Models;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinksInfo.Study
{
    public class UserOutputs
    {
        public static void CategoryMenu(Drinksdomain categories)
        {
            Table Categorymenu = new Table();
            Categorymenu.Title = new TableTitle("Available Categories");
            Categorymenu.AddColumn("CategoryName");
            foreach(var category in categories.drinks)
            {
                Categorymenu.AddRow($"[yellow]{category.CategoryName}[/]");
            }
            Categorymenu.Border = TableBorder.Double;
            AnsiConsole.Write(Categorymenu );
        }
    }
}
