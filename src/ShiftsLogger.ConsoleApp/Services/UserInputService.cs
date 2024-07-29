using System.Globalization;
using ShiftsLogger.ConsoleApp.Enums;
using ShiftsLogger.ConsoleApp.Models;
using Spectre.Console;
using ShiftsLogger.Extensions;

namespace ShiftsLogger.ConsoleApp.Services;

/// <summary>
/// Helper service for getting valid user inputs of different types.
/// </summary>
internal static partial class UserInputService
{
    #region Constants

    // TODO: Validation Messages.

    #endregion
    #region Methods - Internal

    internal static string GetString(string prompt)
    {
        return AnsiConsole.Prompt(
            new TextPrompt<string>(prompt)
            .PromptStyle("blue")
            );
    }

    internal static string GetString(string prompt, string defaultValue)
    {
        return AnsiConsole.Prompt(
            new TextPrompt<string>(prompt)
            .PromptStyle("blue")
            .DefaultValue(defaultValue)
            );
    }

    //internal static Category GetCategory(string prompt, IReadOnlyList<Category> categories)
    //{
    //    return AnsiConsole.Prompt(
    //            new SelectionPrompt<Category>()
    //            .Title(prompt)
    //            .AddChoices(categories)
    //            .UseConverter(c => c.Name)
    //            );
    //}

    internal static SelectionChoice GetPageChoice(string prompt, IEnumerable<SelectionChoice> choices)
    {
        return AnsiConsole.Prompt(
                new SelectionPrompt<SelectionChoice>()
                .Title(prompt)
                .AddChoices(choices)
                .UseConverter(c => c.Name)
                );
    }

    internal static MenuChoice GetMenuChoice(string prompt, IEnumerable<MenuChoice> choices)
    {
        return AnsiConsole.Prompt(
                new SelectionPrompt<MenuChoice>()
                .Title(prompt)
                .AddChoices(choices)
                .UseConverter(c => c.GetDescription())
                );
    }

    #endregion
}

