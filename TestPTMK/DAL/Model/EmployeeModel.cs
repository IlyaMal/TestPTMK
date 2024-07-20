namespace TestPTMK.DAL.Model;

public class EmployeeModel
{
    public int Id { get; set; }
    public string FullName { get; set; }
    private DateTime birthDate;
    public DateTime BirthDate {
        get => birthDate;
        set => birthDate = DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }
    public string Gender { get; set; }
}