namespace ShiftsLogger.Api.Contracts.V1.Requests;

public class ShiftRequest
{
    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }
}
