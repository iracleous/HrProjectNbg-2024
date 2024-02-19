namespace HrProjectNbg_2024.Models;

public class Department
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public virtual List<Employee> Employees { get; set; } = [];
}
