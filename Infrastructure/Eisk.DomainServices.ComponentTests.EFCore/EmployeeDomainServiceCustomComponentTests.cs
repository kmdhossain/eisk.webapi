using System.IO;
using System.Threading.Tasks;
using Eisk.DataServices.EFCore;
using Eisk.Domains.Entities;
using Eisk.EFCore.Setup;
using Eisk.Test.Core.TestBases;
using Xunit;

namespace Eisk.DomainServices.ComponentTests.EFCore
{
    public class EmployeeDomainServiceCustomComponentTests:TestBase
    {
        static EmployeeDataService Factory_DataService()
        {
            EmployeeDataService employeeDataService = new EmployeeDataService(TestDbContextFactory.CreateDbContext());

            return employeeDataService;
        }

        [Fact]
        public virtual async Task Add_ValidEmployeePassed_ShouldReturnEmployeeAfterCreation()
        {
            //Arrange
            var inputEmployee = Factory_Entity <Employee>();
            var employeeDomainService = new EmployeeDomainService(Factory_DataService());

            //Act
            var returnedEmployee = await employeeDomainService.Add(inputEmployee);

            //Assert
            Assert.NotNull(returnedEmployee);
            Assert.NotEqual(default(int), returnedEmployee.Id);
        }


       
    }
}
