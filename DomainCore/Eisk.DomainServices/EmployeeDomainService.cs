using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
namespace Eisk.DomainServices
{
    using Core.DomainService;
    using DataServices.Interfaces;
    using Domains.Entities;

    public class EmployeeDomainService : DomainService<Employee, int>
    {
        private readonly IEmployeeDataService _employeeDataService;

        public EmployeeDomainService(IEmployeeDataService employeeDataService) : base(employeeDataService)
        {
            _employeeDataService = employeeDataService;
        }

        public virtual async Task<IList<Employee>> GetByFirstName(string firstName)
        {
            return await _employeeDataService.GetByFirstName(firstName);
        }
        public override Task<Employee> Add(Employee entity)
        {
            return base.Add(entity, CheckBirthdate);
        }

        private void CheckBirthdate(Employee e){
          
            // throw exception
            //throw new InvalidOperationException("Test");
            //throw  new InvalidDataException()
        }
    }
}