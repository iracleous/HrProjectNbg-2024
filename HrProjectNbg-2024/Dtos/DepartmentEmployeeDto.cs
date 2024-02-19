using HrProjectNbg_2024.Models;

namespace HrProjectNbg_2024.Dtos;

public class DepartmentEmployeeDto
{
    public List<Employee> Employees { get; set; }
    public List<Department> Departments { get; set; }
    public int EmployeeId { get; set; }
    public int DepartmentId { get; set; }

}
