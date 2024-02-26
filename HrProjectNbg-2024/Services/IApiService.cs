using HrProjectNbg_2024.Models;

namespace HrProjectNbg_2024.Services;

public interface IApiService
{
    Task<IEnumerable<Employee>> GetEmployeesAsync(string url);
}
