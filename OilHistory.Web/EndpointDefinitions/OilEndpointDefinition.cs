using OilHistory.Client.Responses;
using OilHistory.Web.Business.Services.Oil;
using OilHistory.Web.Extensions.EndpointExtensions;

namespace OilHistory.Web.EndpointDefinitions;

public class OilEndpointDefinition : IEndpointDefinition
{
    public void DefineEndpoints(WebApplication app)
    {
        app.MapGet("/api/v1/Oils", GetAll);
        app.MapGet("/api/v1/Oils/History", GetHistory); 
    }

    /// <summary>Получить все Цены</summary> 
    /// <response code="200">Успех</response>
    internal async Task<IResult> GetAll(IOilService service)
    {
        try
        {
            await service.GetData();
            return Results.Ok();
        }
        catch (HttpRequestException ex)
        {
            return Results.BadRequest(new ErrorResponse { Message = ex.Message });
        }
        catch (NullReferenceException ex)
        {
            return Results.BadRequest(new ErrorResponse { Message = ex.Message });
        }
        catch
        {
            return Results.BadRequest(new ErrorResponse { Message = "Неизвестная ошибка на сервере" });
        }
    }

    /// <summary>Получить историю Цены</summary> 
    /// <response code="200">Вся история Цены</response>
    internal async Task<IResult> GetHistory(IOilService service)
    {
        try
        {
            return Results.Ok(await service.GetOilHistory());
        }
        catch (HttpRequestException ex)
        {
            return Results.BadRequest(new ErrorResponse { Message = ex.Message });
        }
        catch (NullReferenceException ex)
        {
            return Results.BadRequest(new ErrorResponse { Message = ex.Message });
        }
        catch
        {
            return Results.BadRequest(new ErrorResponse { Message = "Неизвестная ошибка на сервере" });
        }
    } 

    public void DefineServices(IServiceCollection services)
    {
        services.AddSingleton<IOilService, OilService>();
    }
}

