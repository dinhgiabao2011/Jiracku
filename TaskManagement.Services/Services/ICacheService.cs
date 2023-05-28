using KPTMockProject.Common.Filter;
using TaskManagement.Services.DTOs;

namespace TaskManagement.Services.Services
{
    public interface ICacheService
    {
        T GetData<T>(string key);
        bool SetData<T>(string key, T data, DateTimeOffset expirationTime);
        object RemoveData<T>(string key);
        (T, PaginationFilter, int) GetDataPagination<T>(string key);
    }
}
