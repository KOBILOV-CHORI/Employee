using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Company
{
    [Key] public int Id { get; set; }
    public string Name { get; set; }
    public List<Employee> Employees { get; set; }
}