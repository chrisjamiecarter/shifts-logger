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

    internal static Table GetContactsTable()// TODO: IReadOnlyList<Shift> shifts)
    {
        var table = new Table
        {
            // TODO: Caption = new TableTitle($"{shifts.Count} shifts found."),
            Expand = true,
        };

        // TODO:
        //table.AddColumn("ColumnName");
        
        //foreach (var x in shifts)
        //{
        //    table.AddRow(TODO);
        //}

        return table;
    }

    #endregion
}
