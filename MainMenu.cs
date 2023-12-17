using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Assignment.Menus;

internal class MainMenu
{
    private readonly EmployeeMenu _employeeMenu;
    private readonly PhoneMenu _phoneMenu;

    public MainMenu(EmployeeMenu employeeMenu, PhoneMenu phoneMenu)
    {
        _employeeMenu = employeeMenu;
        _phoneMenu = phoneMenu;
    }

    public async Task StartAsync()
    {
        do
        {
            Console.Clear();
            Console.WriteLine("Main Menu: ");
            Console.WriteLine("1: Manage Employee");
            Console.WriteLine("2. Manage Phone");
            Console.Write("Choose one of the options ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    await _employeeMenu.ManageEmployee();
                    break;
                case "2":
                    await _phoneMenu.ManagePhone();
                    break;


            }

        } while (true);

    }
}
