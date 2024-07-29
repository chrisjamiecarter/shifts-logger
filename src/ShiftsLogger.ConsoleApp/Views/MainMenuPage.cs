using ShiftsLogger.ConsoleApp.Engines;
using ShiftsLogger.ConsoleApp.Enums;
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
        MenuChoice.CloseApplication,
    ];

    #endregion
    //#region Constructors

    //public MainMenuPage()// TODO: ShiftController shiftController)
    //{
        // TODO: _shiftController = shiftController;
    //}

    //#endregion
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

    private static void ViewShifts()
    {
        var shifts = ShiftApiService.GetShifts();

        var table = TableEngine.GetShiftsTable(shifts);

        MessagePage.Show("View Shifts", table);

    }

    #endregion
}
