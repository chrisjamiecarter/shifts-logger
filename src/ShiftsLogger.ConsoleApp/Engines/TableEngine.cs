using ShiftsLogger.ConsoleApp.Models;
using Spectre.Console;

namespace ShiftsLogger.ConsoleApp.Engines;

/// <summary>
/// Engine for Spectre.Table generation.
/// </summary>
internal class TableEngine
{
    #region Methods

    internal static Table GetContactTable()// TODO: Shift shift)
    {
        var table = new Table
        {
            Expand = true,
        };

        // TODO: 
        //table.AddColumn("ColumnName");

        //table.AddRow(TODO);

        return table;
    }

    internal static Table GetShiftsTable(IReadOnlyList<ShiftDto> shifts)
    {
        var table = new Table
        {
            Caption = new TableTitle($"{shifts.Count} shifts found."),
            Expand = true,
        };

        table.AddColumn("ID");
        table.AddColumn("Start Time");
        table.AddColumn("End Time");
        table.AddColumn("Duration (Hours)");

        foreach (var x in shifts)
        {
            table.AddRow(x.ToTableRow());
        }

        return table;
    }

    #endregion
}
