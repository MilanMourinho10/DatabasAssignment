using DB_Assignment.Entitites;
using DB_Assignment.Models;
using DB_Assignment.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Assignment.Services;

internal class PhoneService
{
    private readonly PhoneEntity _phone;
    private readonly PhoneRepository _phoneRepository;
    private readonly PricingUnitRepository _pricingUnitRepository;
    private readonly PhoneCategoryRepository _phoneCategoryRepository;

    public PhoneService(PhoneRepository phoneRepository, PricingUnitRepository currencyUnitRepository, PhoneCategoryRepository phoneCategoryRepository)
    {
        _phoneRepository = phoneRepository;
        _pricingUnitRepository = currencyUnitRepository;
        _phoneCategoryRepository = phoneCategoryRepository;
    }



    public async Task<bool> CreatePhoneAsync(PhoneRegistrationForm form)
    {
        if (!await _phoneRepository.ExistsAsync(x => x.PhoneName == form.PhoneName))
        {
            // check if pricing unit exists else create
            var pricingUnitEntity = await _pricingUnitRepository.GetAsync(x => x.Unit == form.Unit);
            pricingUnitEntity ??= await _pricingUnitRepository.CreateAsync(new PricingUnitEntity { Unit = form.Unit });

            //check if category exists else create 
            var phoneCategoryEntity = await _phoneCategoryRepository.GetAsync(x => x.CategoryName == form.PhoneCategory);
            phoneCategoryEntity ??= await _phoneCategoryRepository.CreateAsync(new PhoneCategoryEntity { CategoryName = form.PhoneCategory });


            //create product
            var phoneEntity = new PhoneEntity
            {
                PhoneName = form.PhoneName,
                PhoneDescription = form.PhoneDescription,
                PhonePrice = form.PhonePrice,
                PricingUnitId = pricingUnitEntity.Id,
                PhoneCategoryId = phoneCategoryEntity.Id,
            };


            if (phoneEntity != null)
                return true;

        }

        return false;
    }

    public async Task<IEnumerable<PhoneEntity>> GetAllAsync()
    {
        var phones = await _phoneRepository.GetAllAsync();
        return phones;
    }

    public async Task<IEnumerable<PricingUnitEntity>> GetAllPricingUnitsAsync()
    {
        var units = await _pricingUnitRepository.GetAllAsync();
        return units;
    }

    public async Task<bool> DeletePhoneAsync(int id)
    {
        var result = await _phoneRepository.DeleteAsync(x => x.Id == id);
        return result;
    }

    public async Task UpdateAsync(int id)
    {
        try
        {
            var phones = await _phoneRepository.GetAsync(x => x.Id == id);
            if (phones == null)
            {
                Console.Clear();
                Console.WriteLine("Update was done correctly");
                Console.ReadKey();
                await _phoneRepository.UpdateAsync(phones);
            }

            else
            {
                Console.Clear();
                Console.WriteLine("Update was not done correctly");
                Console.ReadKey();
            }

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }
}
