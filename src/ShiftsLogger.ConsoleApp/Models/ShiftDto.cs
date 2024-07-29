namespace ShiftsLogger.ConsoleApp.Models;

internal class ShiftDto
{
    #region Constructors

    public ShiftDto(Guid id, DateTime startTime, DateTime endTime)
    {
        Id = id;
        StartTime = startTime;
        EndTime = endTime;
    }

    #endregion
    #region Properties

    internal Guid Id { get; set; }

    internal DateTime StartTime { get; set; }

    internal DateTime EndTime { get; set; }

    internal double DurationInHours => (EndTime - StartTime).TotalHours;

    #endregion
    #region Methods

    internal string[] ToTableRow()
    {
        return 
        [
            Id.ToString(),
            StartTime.ToString(),
            EndTime.ToString(),
            DurationInHours.ToString("F2")
        ];
    }

    #endregion
}
