using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Employee
{
    [Key]public int Id { get; set; }
    public string Name { get; set; }
    public int CompanyId { get; set; }
    public Company Company { get; set; }
    public List<EmployeeAddress> EmployeeAddresses { get; set; }
    public List<EmployeeSkill> EmployeeSkills { get; set; }
}