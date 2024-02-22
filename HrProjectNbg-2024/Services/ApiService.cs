using HrProjectNbg_2024.Models;
using Newtonsoft.Json;

namespace HrProjectNbg_2024.Services;

public class ApiService : IApiService
{
    public   IEnumerable<Employee>? GetEmployees(string url)
    {
        using HttpClient client = new();
        client.BaseAddress = new Uri(url);
        var response = client.GetAsync("");
        response.Wait();
        var result = response.Result;

        IEnumerable<Employee>? employees =null ;
        if (result.IsSuccessStatusCode)
        {
            //Storing the response details recieved from web api
            var EmpResponse = result.Content.ReadAsStringAsync().Result;
            //Deserializing the response recieved from web api and storing into the Employee list
            var data = JsonConvert.DeserializeObject<IEnumerable<Employee>>(EmpResponse);
            employees = data;
        }
        return employees;
    }
}
