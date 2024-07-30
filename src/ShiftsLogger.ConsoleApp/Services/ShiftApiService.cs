using System.Net;
using System.Web;
using Newtonsoft.Json;
using RestSharp;
using ShiftsLogger.ConsoleApp.Models;
using Spectre.Console;

namespace ShiftsLogger.ConsoleApp.Services;
internal class ShiftApiService
{
    #region Constants

    private readonly static string Base = "http://localhost:5000/api/v1";
    private readonly static string CreateApiRoute = @$"{Base}/shifts";
    private readonly static string GetApiRoute = @$"{Base}/shifts";
    private readonly static string GetByIdApiRoute = @$"{Base}/shifts/{{shiftId}}";
    private readonly static string UpdateApiRoute = @$"{Base}/shifts/{{shiftId}}";
    private readonly static string DeleteApiRoute = @$"{Base}/shifts/{{shiftId}}";

    #endregion
    #region Methods

    internal static ApiResult CreateShift(CreateShiftRequest shift)
    {
        using var client = new RestClient();

        var request = new RestRequest(CreateApiRoute);
        request.AddBody(new
        {
            shift.StartTime,
            shift.EndTime,
        });

        try
        {
            var reponse = client.Execute(request, Method.Post);
            if (reponse.StatusCode is HttpStatusCode.Created)
            {
                return new ApiResult { Success = true };
            }
            else
            {
                throw new InvalidOperationException($"Invalid HTTP Status Code. Expected: {HttpStatusCode.Created}. Actual: {reponse.StatusCode}.");
            }
        }
        catch (Exception exception)
        {
            return new ApiResult { Success = false, Exception = exception };
        }
    }

    internal static ApiResult DeleteShift(Guid shiftId)
    {
        using var client = new RestClient();

        var request = new RestRequest(DeleteApiRoute.Replace("{shiftId}", HttpUtility.UrlEncode(shiftId.ToString())));
        
        try
        {
            var reponse = client.Execute(request, Method.Delete);
            if (reponse.StatusCode is HttpStatusCode.NoContent)
            {
                return new ApiResult { Success = true };
            }
            else
            {
                throw new InvalidOperationException($"Invalid HTTP Status Code. Expected: {HttpStatusCode.NoContent}. Actual: {reponse.StatusCode}.");
            }
        }
        catch (Exception exception)
        {
            return new ApiResult { Success = false, Exception = exception };
        }
    }

    internal static IReadOnlyList<ShiftDto> GetShifts()
    {
        IReadOnlyList<ShiftDto> output = [];

        using var client = new RestClient(GetApiRoute);

        var request = new RestRequest();
        var reponse = client.ExecuteAsync(request, Method.Get);

        if (reponse.Result.StatusCode is System.Net.HttpStatusCode.OK)
        {
            output = JsonConvert.DeserializeObject<IReadOnlyList<ShiftDto>>(reponse.Result.Content!)!;
        }

        return output;
    }

    internal static ApiResult UpdateShift(UpdateShiftRequest shift)
    {
        using var client = new RestClient();

        var request = new RestRequest(UpdateApiRoute.Replace("{shiftId}", HttpUtility.UrlEncode(shift.Id.ToString())));
        request.AddBody(new
        {
            shift.StartTime,
            shift.EndTime,
        });

        try
        {
            var reponse = client.Execute(request, Method.Put);
            if (reponse.StatusCode is HttpStatusCode.OK)
            {
                return new ApiResult { Success = true };
            }
            else
            {
                throw new InvalidOperationException($"Invalid HTTP Status Code. Expected: {HttpStatusCode.OK}. Actual: {reponse.StatusCode}.");
            }
        }
        catch (Exception exception)
        {
            return new ApiResult { Success = false, Exception = exception };
        }
    }

    #endregion
}
