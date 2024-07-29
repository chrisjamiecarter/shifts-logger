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

    private readonly MenuChoice[] _pageChoices =
    [
        MenuChoice.CloseApplication
    ];

    #endregion
    #region Constructors

    public MainMenuPage()// TODO: ShiftController shiftController)
    {
        // TODO: _shiftController = shiftController;
    }

    #endregion
    #region Methods - Internal

    internal void Show()
    {
        var choice = MenuChoice.Default;

        while (choice != MenuChoice.CloseApplication)
        {
            WriteHeader(PageTitle);

            choice = UserInputService.GetMenuChoice(PromptTitle, _pageChoices);
            switch (choice)
            {
                default:
                    break;
            }
        }
    }

    #endregion
    #region Methods - Private

    #endregion
}
