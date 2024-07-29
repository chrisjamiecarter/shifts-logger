namespace ShiftsLogger.Data.Entities;

public class Shift
{
    #region Properties

    public Guid Id { get; set; }

    public DateTime StartTime { get; set; }
    
    public DateTime EndTime { get; set; }

    #endregion
}
