using DrinksInfo.Study.Models;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinksInfo.Study
{
    public class UserInputs
    {
        public static string ChooseCategory(Drinksdomain categories)
        {
            var chosenCategory = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[pink3]Please Select a Category of drink you want to Order[/]")
                    .PageSize(10)
                    .MoreChoicesText("[grey](Move up and down to reveal more categories)[/]")
                    .AddChoices(categories.drinkCategories.Select(d => d.CategoryName)));
            return chosenCategory;
        }
        public static string ChooseId(List<string> drinksId)
        {
            AnsiConsole.MarkupLine("Please Enter the [yellow]ID[/] to view the [pink3]Drinks info[/]");
            AnsiConsole.MarkupLine("Press [yellow]'X'[/] to go [red]back to main menu[/]");
            string userChoice = Console.ReadLine();
            if (userChoice.ToLower() != "x")
            {
                while ((!drinksId.Contains(userChoice)))
                {
                    AnsiConsole.MarkupLine("Please enter a [red] valid ID[/] from the table:");
                    userChoice = Console.ReadLine();
                }
                return userChoice;
            }
            return userChoice;
        }
    }
}
