using ShiftsLogger.ConsoleApp.Engines;
using ShiftsLogger.ConsoleApp.Enums;
using ShiftsLogger.ConsoleApp.Models;
using ShiftsLogger.ConsoleApp.Services;
using Spectre.Console;

namespace ShiftsLogger.ConsoleApp.Views;

/// <summary>
/// The main menu page of the application.
/// </summary>
internal class MainMenuPage : BasePage
{
    #region Constants

    private const string PageTitle = "Main Menu";

    #endregion
    #region Fields

    private static readonly MenuChoice[] _pageChoices =
    [
        MenuChoice.ViewShifts,
        MenuChoice.CreateShift,
        MenuChoice.CloseApplication,
    ];

    #endregion
    #region Methods - Internal

    internal static void Show()
    {
        var choice = MenuChoice.Default;

        while (choice != MenuChoice.CloseApplication)
        {
            WriteHeader(PageTitle);

            choice = UserInputService.GetMenuChoice(PromptTitle, _pageChoices);
            switch (choice)
            {
                case MenuChoice.CreateShift:
                    CreateShift();
                    break;
                case MenuChoice.ViewShifts:
                    ViewShifts();
                    break;
                default:
                    break;
            }
        }
    }

    #endregion
    #region Methods - Private

    private static void CreateShift()
    {
        var request = CreateShiftPage.Show();
        //{
        //    StartTime = DateTime.Now.AddHours(-8),
        //    EndTime = DateTime.Now,
        //};
        if (request is null)
        {
            return;
        }

        var result = ShiftApiService.CreateShift(request);

        if (result.Success)
        {
            MessagePage.Show("Create Shift", "Shift created successfully");            
        }
        else
        {
            MessagePage.Show(result.Exception!);
        }
    }

    private static void ViewShifts()
    {
        var shifts = ShiftApiService.GetShifts();

        var table = TableEngine.GetShiftsTable(shifts);

        MessagePage.Show("View Shifts", table);

    }

    #endregion
}
