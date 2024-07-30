namespace ShiftsLogger.ConsoleApp.Models;

public class UpdateShiftRequest
{
    public Guid Id { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }
}
