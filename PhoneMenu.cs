using DB_Assignment.Entitites;
using DB_Assignment.Models;
using DB_Assignment.Repositories;
using DB_Assignment.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Assignment.Menus;

internal class PhoneMenu
{
    private readonly PhoneEntity _Phone;
    private readonly PhoneRepository _phoneRepository;
    private readonly PhoneService _phoneService;

    public PhoneMenu(PhoneService phoneService)
    {
        _phoneService = phoneService;


    }


    public async Task ManagePhone()
    {

        Console.WriteLine("1 : View All Phones");
        Console.WriteLine("2 : Add New Phone");
        Console.WriteLine("3 : Delete an Phone");
        Console.WriteLine("4 : Update an Phone");

        Console.WriteLine("Choose one of the options");
        var option = Console.ReadLine();

        switch (option)
        {
            case "1":
                await ListAllAsync();
                break;
            case "2":
                await CreateAsync();
                break;
            case "3":
                Console.Clear();
                Console.WriteLine("Write an id for the phone you want to delete");
                var respons = int.Parse(Console.ReadLine()!);
                await DeleteAsync(respons);
                break;

            case "4":
                Console.Clear();
                Console.WriteLine("Write the Id for the phone you wish to update.");
                var respons2 = int.Parse(Console.ReadLine()!);

                await UpdateAsync(respons2);
                break;



        }
    }

    public async Task ListAllAsync()
    {
        var Phones = await _phoneService.GetAllAsync();
        foreach (var phone in Phones)
        {
            Console.WriteLine($"{phone.PhoneName} {phone.PhoneCategory.CategoryName}");
            Console.WriteLine($"{phone.PhonePrice} {phone.PricingUnit.Unit}");
        }

        Console.ReadKey();
    }

    public async Task CreateAsync()
    {
        var form = new PhoneRegistrationForm();

        Console.Clear();
        Console.Write(" Phone Name ");
        form.PhoneName = Console.ReadLine()!;

        Console.Write(" Phone Description ");
        form.PhoneDescription = Console.ReadLine()!;

        Console.WriteLine("Phone Category");
        form.PhoneCategory = Console.ReadLine()!;

        Console.Write(" Pricing (sek) ");
        form.PhonePrice = decimal.Parse(Console.ReadLine()!);

        Console.Write(" Phone Pricing Unit (st,pkt,tim) ");
        form.Unit = Console.ReadLine()!;

        var result = await _phoneService.CreatePhoneAsync(form);

        if (result)
            Console.WriteLine("phone has been added succesfully");
        else
            Console.WriteLine("The phone can not be added");
    }

    public async Task DeleteAsync(int id)
    {
        var result = await _phoneService.DeletePhoneAsync(id);
        if (result)
            Console.WriteLine($"Phone was {id} was deleted successfully.");
        else
            Console.WriteLine($"Could not locate an phone with the current id: {id}.");

    }

    public async Task UpdateAsync(int id)
    {
        var device = await _phoneService.GetAllAsync();

        Console.Clear();
        Console.WriteLine("Choose to update one option");
        Console.WriteLine(" 1 : phone name/ phone description");
        Console.WriteLine(" 2 : phone price etc");
        var option = Console.ReadLine();

        switch (option)
        {
            case "1":

                Console.Clear();

                Console.WriteLine("Phone name");
                _Phone.PhoneName = Console.ReadLine()!;

                Console.WriteLine("Phone Description");
                _Phone.PhoneDescription = Console.ReadLine()!;

                break;

            case "2":
                Console.Clear();
                Console.WriteLine("Phone Price");
                _Phone.PhonePrice = decimal.Parse(Console.ReadLine()!);
                await _phoneService.UpdateAsync(id);

                break;




        }
    }

}
