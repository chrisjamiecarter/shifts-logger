﻿using ShiftsLogger.Data.Entities;

namespace ShiftsLogger.Api.Services;
public interface IShiftService
{
    Task<bool> CreateAsync(Shift shift);
    Task<bool> DeleteAsync(Guid shiftId);
    bool DoesShiftExist(Guid shiftId);
    Task<List<Shift>> ReturnAsync();
    Task<Shift?> ReturnByIdAsync(Guid shiftId);
    Task<bool> UpdateAsync(Shift shift);
}