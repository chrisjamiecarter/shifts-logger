namespace ShiftsLogger.ConsoleApp.Models;

internal class ApiResult
{
    #region Properties

    internal bool Success { get; init; }

    internal Exception? Exception { get; init; }

    #endregion
}
