using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using TestPTMK.BLL;
using TestPTMK.DAL;
using TestPTMK.DAL.Model;
using TestPTMK.Services;

namespace TestPTMK;

class Program
{
    static async Task Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddSingleton<IEmployeeDAL, EmployeeDAL>()
            .AddScoped<IEmployeeBLL, EmployeeBLL>()
            .BuildServiceProvider();
        
        var employeeService = serviceProvider.GetService<IEmployeeBLL>();

        if (args.Length == 0)
        {
            Console.WriteLine("Please provide a mode of operation.");
            return;
        }

        switch (args[0])
        {
            case "1":
                Console.WriteLine("Table 'Employees' created successfully");
                break;
            case "2":
                if (args.Length < 4)
                {
                    Console.WriteLine("Please provide FullName, BirthDate and Gender.");
                    return;
                }
                await employeeService.AddEmployeeAsync(args[1], DateTime.Parse(args[2]), args[3]);
                break;
            case "3":
                await employeeService.ListAllEmployeesAsync();
                break;
            case "4":
                var employees = EmployeeGenerator.GenerateEmployees(1000100);
                await employeeService.AddManyEmployeesAsync(employees);
                break;
            case "5":
                await employeeService.ListFilteredEmployeesAsync();
                break;
            case "6":
                await employeeService.OptimizeDatabaseAsync();
                await employeeService.ListFilteredEmployeesAsync();
                break;
            default:
                Console.WriteLine("Invalid mode of operation.");
                break;
        }
    }
}