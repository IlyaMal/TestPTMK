using TestPTMK.DAL.Model;

namespace TestPTMK.DAL;

public interface IEmployeeDAL
{
    Task AddEmployeeAsync(EmployeeModel employee);
    Task<IEnumerable<EmployeeModel>> GetAllEmployeesAsync();
    Task<IEnumerable<EmployeeModel>> GetFilteredEmployeesAsync();
    Task AddManyEmployeesAsync(IEnumerable<EmployeeModel> employees);
    Task OptimizeDatabaseAsync();
}