using ShiftsLogger.ConsoleApp.Models;
using ShiftsLogger.ConsoleApp.Services;

namespace ShiftsLogger.ConsoleApp.Views;

/// <summary>
/// Page which allows users to create a shift entry.
/// </summary>
internal class CreateShiftPage : BasePage
{
    #region Constants

    private const string PageTitle = "Create Shift";

    #endregion
    #region Methods

    internal static ShiftRequest? Show()
    {
        WriteHeader(PageTitle);

        string dateTimeFormat = "yyyy-MM-dd HH:mm:ss";

        var startTime = UserInputService.GetShiftStartDateTime(
            $"Enter the start date and time, format [blue]{dateTimeFormat}[/], or [blue]0[/] to return to main menu: ",
            dateTimeFormat);
            if (startTime is null)
            {
                return null;
            }

        var endTime = UserInputService.GetShiftEndDateTime(
            $"Enter the end date and time, format [blue]{dateTimeFormat}[/], or [blue]0[/] to return to main menu: ",
            dateTimeFormat,
            startTime.Value);
        if (endTime  is null)
        {
            return null;
        }

        return new ShiftRequest
        {
            StartTime = startTime.Value,
            EndTime = endTime.Value,
        };
    }

    #endregion
}

