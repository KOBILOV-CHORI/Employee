using Domain.Dtos.EmployeeAddress;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Services;

public class EmployeeAddressService
{
    private readonly DataContext _context;

    public EmployeeAddressService(DataContext context)
    {
        _context = context;
    }

    public EmployeeAddressBase AddEmployeeAddress(EmployeeAddressBase employeeAddress)
    {
        _context.EmployeeAddresses.Add(new EmployeeAddress()
        {
            EmployeeId = employeeAddress.EmployeeId,
            Address = employeeAddress.Address
        });
        _context.SaveChanges();
        return employeeAddress;
    }

    public EmployeeAddressBase UpdateEmployeeAddress(EmployeeAddressBase employeeAddress)
    {
        var find = _context.EmployeeAddresses.Find(employeeAddress.EmployeeId);
        if (find != null)
        {
            find.EmployeeId = employeeAddress.EmployeeId;
            find.Address = employeeAddress.Address;
            _context.SaveChanges();
        }
        return employeeAddress;
    }

    public bool DeleteEmployeeAddress(int id)
    {
        var find = _context.EmployeeAddresses.Find(id);
        if (find != null)
        {
            _context.EmployeeAddresses.Remove(find);
            _context.SaveChanges();
            return true;
        }
        return false;
    }

    public EmployeeAddressBase GetEmployeeAddressById(int id)
    {
        var find = _context.EmployeeAddresses.Find(id);
        if (find == null) return new EmployeeAddressBase();
        return new EmployeeAddressBase()
        {
            Address = find.Address,
            EmployeeId = find.EmployeeId
        };
    }

    public List<EmployeeAddressBase> GetEmployeeAddresses()
    {
        return _context.EmployeeAddresses.Select(c => new EmployeeAddressBase()
        {
            EmployeeId = c.EmployeeId,
            Address = c.Address
        }).ToList();
    }
}