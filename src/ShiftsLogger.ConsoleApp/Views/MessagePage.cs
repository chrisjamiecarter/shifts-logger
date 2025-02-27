﻿using Spectre.Console;

namespace ShiftsLogger.ConsoleApp.Views;

/// <summary>
/// A page which displays a parameterised message and title.
/// </summary>
internal class MessagePage : BasePage
{
    #region Methods

    internal static void Show(string title, string message)
    {
        WriteHeader(title);

        AnsiConsole.WriteLine(message);

        WriteFooter();
    }

    internal static void Show(Exception exception)
    {
        WriteHeader("Error");

        AnsiConsole.WriteException(exception, ExceptionFormats.NoStackTrace);

        WriteFooter();
    }

    internal static void Show(string title, Table table)
    {
        WriteHeader(title);

        AnsiConsole.Write(table);

        WriteFooter();
    }

    #endregion
}
