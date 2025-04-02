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
        public static string drinksListMenu(CategoryDrinks drinksListByCategory)
        {
            List<string> drinksName = new List<string>();
            List<string> drinksId = new List<string>();
            Table drinkslist = new Table();
            drinkslist.Title = new TableTitle("Drinks for the chosen category");
            var props = typeof(DrinkInformation).GetProperties();
            foreach (var prop in props)
            {
                drinkslist.AddColumn(prop.Name);
            }
            foreach (var category in drinksListByCategory.DrinksByCategory)
            {
                drinkslist.AddRow(Markup.Escape(category.DrinkName), Markup.Escape(category.DrinkImageUrl), Markup.Escape(category.DrinkId));
                drinksName.Add(category.DrinkName);
                drinksId.Add(category.DrinkId);
            }
            drinkslist.Border = TableBorder.Double;
            AnsiConsole.Write(drinkslist);
            string userChoice = UserInputs.ChooseId(drinksId);
            return userChoice;
        }
        public static void DisplayDrinkInfo(InformationDrinks drinksInfo)
        {
            if (drinksInfo?.DrinksInformation == null || !drinksInfo.DrinksInformation.Any())
            {
                AnsiConsole.Markup("[red]No drinks information available![/]");
                return;
            }

            
            var table = new Table()
                .Border(TableBorder.Rounded)
                .BorderColor(Color.CornflowerBlue)
                .Title("[underline yellow]Cocktail Menu[/]")
                .Expand()
                .AddColumn(new TableColumn("[u]#[/]").Centered())
                .AddColumn(new TableColumn("[u]Name[/]").Centered())
                .AddColumn(new TableColumn("[u]Category[/]").Centered())
                .AddColumn(new TableColumn("[u]Type[/]").Centered())
                .AddColumn(new TableColumn("[u]Glass[/]").Centered());

            
            var instructionGrid = new Grid()
                .Expand()
                .AddColumn()
                .AddColumn();

            
            for (int i = 0; i < drinksInfo.DrinksInformation.Count; i++)
            {
                var drink = drinksInfo.DrinksInformation[i];

                
                table.AddRow(
                    $"{i + 1}",
                    drink.DrinkName.EscapeMarkup() ?? "Unknown",
                    drink.CategoryName.EscapeMarkup() ?? "N/A",
                    drink.IsAlcoholic.EscapeMarkup() ?? "N/A",
                    drink.Glass.EscapeMarkup() ?? "N/A"
                );

                
                var instructionsPanel = new Panel(drink.Instructions.EscapeMarkup() ?? "No instructions provided")
                {
                    Border = BoxBorder.Rounded,
                    BorderStyle = new Style(Color.LightSkyBlue1),
                    Header = new PanelHeader($"[yellow]{drink.DrinkName}[/] Instructions"),
                    Padding = new Padding(2, 1, 2, 1)
                };

                
                instructionGrid.AddRow(instructionsPanel);
            }

            
            var layout = new Layout("Root")
                .SplitRows(
                    new Layout("Top"),
                    new Layout("Bottom")
                );

           
            AnsiConsole.Clear();
            AnsiConsole.Write(new Rule("[yellow] Cocktail Database [/]").RuleStyle("grey"));
            AnsiConsole.Write(table);
            AnsiConsole.Write(new Rule("[yellow] Preparation Instructions [/]").RuleStyle("grey"));
            AnsiConsole.Write(instructionGrid);
            AnsiConsole.Write(new Rule().RuleStyle("grey"));
            Console.WriteLine("please press any key to continue.....");
            Console.ReadLine();
        }
    }
}
