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
            foreach(var category in categories.drinkCategories)
            {
                Categorymenu.AddRow($"[yellow]{category.CategoryName}[/]");
            }
            Categorymenu.Border = TableBorder.Double;
            AnsiConsole.Write(Categorymenu );
        }
        public static void drinksListMenu(CategoryDrinks drinksListByCategory)
        {
            Table drinkslist = new Table();
            drinkslist.Title = new TableTitle("Driinks for the chosen category");
            var props = typeof(DrinkInformation).GetProperties();
            foreach (var prop in props)
            {
                drinkslist.AddColumn(prop.Name);
            }
            foreach (var category in drinksListByCategory.DrinksByCategory)
            {
                drinkslist.AddRow(Markup.Escape(category.DrinkName), Markup.Escape(category.DrinkImageUrl), Markup.Escape(category.DrinkId));
            }
            drinkslist.Border = TableBorder.Double;
            AnsiConsole.Write(drinkslist);
        }
    }
}
