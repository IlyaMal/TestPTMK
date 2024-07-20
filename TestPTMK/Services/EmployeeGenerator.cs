using TestPTMK.DAL.Model;

namespace TestPTMK.Services;

public static class EmployeeGenerator
{
    private static Random random = new Random();

    public static List<EmployeeModel> GenerateEmployees(int count)
    {
        var employees = new List<EmployeeModel>();
        for (int i = 0; i < count-100; i++)
        {
            string fullName = GenerateRandomName();
            DateTime birthDate = GenerateRandomBirthDate();
            string gender = i % 2 == 0 ? "Male" : "Female";
            employees.Add(new EmployeeModel { FullName = fullName, BirthDate = birthDate, Gender = gender });
        }
        for (int i = 0; i < 100; i++)
        {
            string fullName = GenerateRandomFName();
            DateTime birthDate = GenerateRandomBirthDate();
            employees.Add(new EmployeeModel { FullName = fullName, BirthDate = birthDate, Gender = "Male" });

        }
        return employees;
    }

    private static string GenerateRandomName()
    {
        string[] firstNames = { "John", "Jane", "Michael", "Sarah", "David", "Laura" };
        string[] lastNames = { "Smith", "Johnson", "Williams", "Brown", "Jones", "Garcia" };
        return $"{lastNames[random.Next(lastNames.Length)]} {firstNames[random.Next(firstNames.Length)]}";
    }
    private static string GenerateRandomFName()
    {
        string[] firstNames = { "John", "Alfred", "Michael", "Carl", "David", "Christian" };
        string[] lastNames = { "Flatcher", "Fleming", "Ford", "Forman", "Faber", "Finch" };
        return $"{lastNames[random.Next(lastNames.Length)]} {firstNames[random.Next(firstNames.Length)]}";
    }

    private static DateTime GenerateRandomBirthDate()
    {
        int year = random.Next(1950, 2006);
        int month = random.Next(1, 13);
        int day = random.Next(1, 28);
        return new DateTime(year, month, day);
    }
}
