namespace HrProjectNbg_2024.Models;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateOnly HiringDate { get; set; }
    public virtual Department ?Department { get; set; }
    public virtual Employee ?Manager { get; set; }
}
