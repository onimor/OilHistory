namespace OilHistory.Web.Business.Services.Oil;

public interface IOilService
{
    Task GetData();
    Task<string[]> GetOilHistory();
}
