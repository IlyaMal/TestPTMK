using System.Diagnostics;
using TestPTMK.DAL;
using TestPTMK.DAL.Model;

namespace TestPTMK.BLL;

public class EmployeeBLL(IEmployeeDAL employeeDal): IEmployeeBLL
{
    public async Task AddEmployeeAsync(string fullName, DateTime birthDate, string gender)
    {
        var employee = new EmployeeModel()
        {
            FullName = fullName,
            BirthDate = birthDate,
            Gender = gender
        };
        await employeeDal.AddEmployeeAsync(employee);
    }

    public async Task ListAllEmployeesAsync()
    {
        
        var employees =  await employeeDal.GetAllEmployeesAsync();
        foreach (var employee in employees)
        {
            Console.WriteLine($"{employee.FullName}, {employee.BirthDate.ToShortDateString()}, {employee.Gender}, {CalculateAge(employee.BirthDate)} years old");
        }
        
    }

    public async Task ListFilteredEmployeesAsync()
    {
        var watch = Stopwatch.StartNew();
        var employees = await employeeDal.GetFilteredEmployeesAsync();
        watch.Stop();

        foreach (var employee in employees)
        {
            Console.WriteLine($"{employee.FullName}, {employee.BirthDate.ToShortDateString()}, {employee.Gender}, {CalculateAge(employee.BirthDate)} years old");
        }

        Console.WriteLine($"Query execution time: {watch.ElapsedMilliseconds} ms");
    }

    public async Task AddManyEmployeesAsync(IEnumerable<EmployeeModel> employees)
    {
        await employeeDal.AddManyEmployeesAsync(employees);
    }

    public async Task OptimizeDatabaseAsync()
    {
        await employeeDal.OptimizeDatabaseAsync();
    }

    public int CalculateAge(DateTime birthDate)
    {
            int age = DateTime.Now.Year - birthDate.Year;
            if (DateTime.Now.DayOfYear < birthDate.DayOfYear)
                age -= 1;
            return age;
    }
}