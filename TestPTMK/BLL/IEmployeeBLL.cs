using System.Runtime.InteropServices.JavaScript;
using TestPTMK.DAL.Model;

namespace TestPTMK.BLL;

public interface IEmployeeBLL
{
    Task AddEmployeeAsync(string fullName, DateTime birthDate, string gender);
    Task ListAllEmployeesAsync();
    Task ListFilteredEmployeesAsync();
    Task AddManyEmployeesAsync(IEnumerable<EmployeeModel> employees);
    Task OptimizeDatabaseAsync();
    int CalculateAge(DateTime birthDate);
}