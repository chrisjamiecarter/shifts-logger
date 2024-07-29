using Microsoft.EntityFrameworkCore;
using ShiftsLogger.Data.Contexts;
using ShiftsLogger.Data.Entities;

namespace ShiftsLogger.Api.Services;

public class ShiftService : IShiftService
{
    #region Fields

    private readonly DatabaseContext _databaseContext;

    #endregion
    #region Constructors

    public ShiftService(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    #endregion
    #region Methods

    public async Task<bool> CreateAsync(Shift shift)
    {
        await _databaseContext.Shift.AddAsync(shift);
        var created = await _databaseContext.SaveChangesAsync();
        return created > 0;
    }

    public async Task<List<Shift>> ReturnAsync()
    {
        return await _databaseContext.Shift.ToListAsync();
    }

    public async Task<Shift?> ReturnByIdAsync(Guid shiftId)
    {
        return await _databaseContext.Shift.SingleOrDefaultAsync(x => x.Id == shiftId);
    }

    public async Task<bool> UpdateAsync(Shift shift)
    {
        _databaseContext.Entry(shift).State = EntityState.Modified;

        try
        {
            var updated = await _databaseContext.SaveChangesAsync();
            return updated > 0;
        }
        catch (DbUpdateConcurrencyException)
        {
            throw;
        }
    }

    public async Task<bool> DeleteAsync(Guid shiftId)
    {
        var post = await ReturnByIdAsync(shiftId);
        if (post != null)
        {
            _databaseContext.Shift.Remove(post);
        }

        var deleted = await _databaseContext.SaveChangesAsync();
        return deleted > 0;
    }

    public bool DoesShiftExist(Guid shiftId)
    {
        return _databaseContext.Shift.Any(e => e.Id == shiftId);
    }

    #endregion
}
