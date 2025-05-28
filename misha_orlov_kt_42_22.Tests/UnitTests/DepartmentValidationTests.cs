using misha_orlov_kt_42_22.Models;
using Xunit;

public class DepartmentTests
{
    [Fact]
    public void IsValidDepartmentName_ValidName_True()
    {
        var department = new Department
        {
            Name = "Кафедра информатики"
        };
        var result = department.IsValidDepartmentName();
        Assert.True(result);
    }

    [Fact]
    public void IsValidDepartmentName_InvalidName_False()
    {
        var department = new Department
        {
            Name = "Кафедра ббб"
        };
        var result = department.IsValidDepartmentName();
        Assert.True(result);
    }
}
