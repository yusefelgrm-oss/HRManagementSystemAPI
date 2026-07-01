using System.ComponentModel.DataAnnotations.Schema;
namespace HRManagementSystem.API.Model
{
    public class Employee
    {

            public int Id { get; set; }

            public string Name { get; set; } = string.Empty;

            public string Email { get; set; } = string.Empty;

            public decimal Salary { get; set; }
        

    }
}   
