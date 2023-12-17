using DB_Assignment.Models;
using DB_Assignment.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Assignment.Menus;

internal class EmployeeMenu
{
    private readonly EmployeeService _employeeService;
    private IEnumerable<object> employees;

    public EmployeeMenu(EmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    public async Task ManageEmployee()
    {

        Console.WriteLine("1 : View All Employees");
        Console.WriteLine("2 : Add Employee");
        Console.WriteLine("Choose one option");
        var option = Console.ReadLine();

        switch (option)
        {
            case "1":
                await ListAllAsync();
                break;
            case "2":
                await CreateAsync();
                break;


        }
    }

    public async Task CreateAsync()
    {
        var form = new EmployeeRegistrationForm();

        Console.Clear();
        Console.Write("First Name: ");
        form.FirstName = Console.ReadLine()!;

        Console.Clear();
        Console.Write("Last Name: ");
        form.LastName = Console.ReadLine()!;

        Console.Clear();
        Console.Write("Email: ");
        form.Email = Console.ReadLine()!;

        Console.Clear();
        Console.Write("Street Name: ");
        form.SreetName = Console.ReadLine()!;

        Console.Clear();
        Console.Write("Postal Code: ");
        form.PostalCode = Console.ReadLine()!;

        Console.Clear();
        Console.Write("City: ");
        form.City = Console.ReadLine()!;

        var result = await _employeeService.CreateEmployeeAsync(form);

        if (result)
            Console.WriteLine("Employee has been created succesfully");
        else
            Console.WriteLine("Employee can not be created");

    }

    public async Task ListAllAsync()
    {
        var employees = await _employeeService.GetAllAsync();
        foreach (var employee in employees)
        {
            Console.WriteLine($"{employee.FirstName} {employee.LastName}");
            Console.WriteLine($"{employee.Address.StreetName} {employee.Address.PostalCode} {employee.Address.City}");
        }

        Console.ReadKey();
    }
}
