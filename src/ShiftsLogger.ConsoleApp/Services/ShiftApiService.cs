using Newtonsoft.Json;
using RestSharp;
using ShiftsLogger.ConsoleApp.Models;

namespace ShiftsLogger.ConsoleApp.Services;
internal class ShiftApiService
{
    #region Constants

    private readonly static string Base = "http://localhost:5240/api/v1";
    private readonly static string CreateShift = @$"{Base}/shifts";
    private readonly static string GetShift = @$"{Base}/shifts";
    private readonly static string GetShiftById = @$"{Base}/shifts/{{shiftId}}";
    private readonly static string UpdateShift = @$"{Base}/shifts/{{shiftId}}";
    private readonly static string DeleteShift = @$"{Base}/shifts/{{shiftId}}";
    #endregion
    #region Methods

    internal static IReadOnlyList<ShiftDto> GetShifts()
    {
        IReadOnlyList<ShiftDto> output = [];

        using var client = new RestClient(GetShift);

        var request = new RestRequest();
        var reponse = client.ExecuteAsync(request);

        if (reponse.Result.StatusCode is System.Net.HttpStatusCode.OK)
        {
            output = JsonConvert.DeserializeObject<IReadOnlyList<ShiftDto>>(reponse.Result.Content!)!;
        }

        return output;
    }

    #endregion
}
