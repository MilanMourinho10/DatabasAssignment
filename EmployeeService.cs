using DB_Assignment.Entitites;
using DB_Assignment.Models;
using DB_Assignment.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Assignment.Services
{
    internal class EmployeeService
    {
        private readonly AddressRepository _addressRepository;
        private readonly EmployeeRepository _employeeRepository;

        public EmployeeService(AddressRepository addressRepository, EmployeeRepository employeeRepository)
        {
            _addressRepository = addressRepository;
            _employeeRepository = employeeRepository;
        }

        public async Task<bool> CreateEmployeeAsync(EmployeeRegistrationForm form)
        {
            //check employee om den inte finns vill vi dubbelkolla adress och användare
            if (!await _employeeRepository.ExistsAsync(x => x.Email == form.Email))
            {
                //checka address
                AddressEntity addressEntity = await _addressRepository.GetAsync(x => x.StreetName == form.SreetName && x.PostalCode == form.PostalCode);
                addressEntity ??= await _addressRepository.CreateAsync(new AddressEntity { StreetName = form.SreetName, PostalCode = form.PostalCode, City = form.City });

                //skapa Employee
                EmployeeEntity employeeEntity = await _employeeRepository.CreateAsync(new EmployeeEntity { FirstName = form.FirstName, LastName = form.LastName, Email = form.Email, AddressId = addressEntity.Id });
                if (employeeEntity != null)
                    return true;



            }

            return false;
        }

        public async Task<IEnumerable<EmployeeEntity>> GetAllAsync()
        {
            var employee = await _employeeRepository.GetAllAsync();
            return employee;

        }
    }
}
