using HRManagementSystem.API.Data;
using HRManagementSystem.API.DTOs;
using HRManagementSystem.API.Model;
using HRManagementSystem.API.Model;
using Microsoft.AspNetCore.Mvc;

namespace HRManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public EmployeesController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult AddEmployee(EmployeeDto dto)
    {
        var employee = new Employee
        {
            Name = dto.Name,
            Email = dto.Email,
            Salary = dto.Salary
        };

        _context.Employees.Add(employee);
        _context.SaveChanges();

        return Ok(employee);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var employees = _context.Employees.ToList();
        return Ok(employees);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var employee = _context.Employees.FirstOrDefault(e => e.Id == id);

        if (employee == null)
            return NotFound();

        return Ok(employee);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Employee updatedEmployee)
    {
        var employee = _context.Employees.FirstOrDefault(e => e.Id == id);

        if (employee == null)
            return NotFound();

        employee.Name = updatedEmployee.Name;
        employee.Email = updatedEmployee.Email;
        employee.Salary = updatedEmployee.Salary;

        _context.SaveChanges();

        return Ok(employee);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var employee = _context.Employees.FirstOrDefault(e => e.Id == id);

        if (employee == null)
            return NotFound();

        _context.Employees.Remove(employee);
        _context.SaveChanges();

        return Ok("Deleted successfully");
    }
}