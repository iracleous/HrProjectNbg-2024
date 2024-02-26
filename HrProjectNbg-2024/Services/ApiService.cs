using HrProjectNbg_2024.Models;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace HrProjectNbg_2024.Services;

public class ApiService : IApiService
{
    public async Task<IEnumerable<Employee>> GetEmployeesAsync(string url)
    {
        using HttpClient client = new();
        client.BaseAddress = new Uri(url);
        var response = await client.GetAsync("");
        var EmpResponse = await response.Content.ReadAsStringAsync() ;
        if (response.IsSuccessStatusCode && EmpResponse!=null)
        {
            return JsonConvert.DeserializeObject<IEnumerable<Employee>>(EmpResponse)??[];
        }
        return [] ;
    }
}
