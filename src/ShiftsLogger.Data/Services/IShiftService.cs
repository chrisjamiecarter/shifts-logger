using ShiftsLogger.Data.Entities;

namespace ShiftsLogger.Data.Services;
public interface IShiftService
{
    Task<bool> CreateAsync(Shift shift);
    Task<bool> DeleteAsync(Guid shiftId);
    Task<List<Shift>> ReturnAsync();
    Task<Shift?> ReturnByIdAsync(Guid shiftId);
    Task<bool> UpdateAsync(Shift shift);
}