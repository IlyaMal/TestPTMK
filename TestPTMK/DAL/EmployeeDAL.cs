using Microsoft.EntityFrameworkCore;

namespace TestPTMK.DAL.Model;

public class EmployeeDAL: IEmployeeDAL
{
    public async Task AddEmployeeAsync(EmployeeModel employee)
    {
        using (var connection = new DBHelper())
        {
            await connection.Employees.AddAsync(employee);
            await connection.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<EmployeeModel>> GetAllEmployeesAsync()
    {
        using (var connection = new DBHelper())
        {
            var employees = await connection.Employees
                .GroupBy(e => new { e.FullName, e.BirthDate })
                .Select(g => new EmployeeModel()
                {
                    FullName = g.Key.FullName,
                    BirthDate = g.Key.BirthDate,
                    Gender = g.First().Gender,

                })
                .OrderBy(e => e.FullName)
                .ToListAsync();
            return employees;
        }
    }

    public async Task<IEnumerable<EmployeeModel>> GetFilteredEmployeesAsync()
    {
        using (var connection = new DBHelper())
        {
            return await connection.Employees
                .Where(e => e.Gender == "Male" && e.FullName.StartsWith("F"))
                .ToListAsync();
        }
    }

    public async Task AddManyEmployeesAsync(IEnumerable<EmployeeModel> employees)
    {
        using (var connection = new DBHelper())
        {
            await connection.Employees.AddRangeAsync(employees);
            await connection.SaveChangesAsync();
        }
    }

    public async Task OptimizeDatabaseAsync()
    {
        using (var connection = new DBHelper())
        {
            await connection.Database.ExecuteSqlRawAsync("CREATE INDEX IF NOT EXISTS \"IDX_FullName\" ON public.\"Employees\" (\"FullName\")");
        }
        
    }
}