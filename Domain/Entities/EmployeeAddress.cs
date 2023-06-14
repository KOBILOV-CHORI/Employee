using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class EmployeeAddress
{
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
    public string Address { get; set; }
}