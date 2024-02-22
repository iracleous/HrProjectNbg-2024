using HrProjectNbg_2024.Models;

namespace HrProjectNbg_2024.Services;

public interface IApiService
{
    IEnumerable<Employee>? GetEmployees(string url);
}
