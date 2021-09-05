using Eisk.Domains.Employee;
using Microsoft.AspNetCore.Mvc;

namespace Eisk.WebApi.Controllers
{
    using Core.DomainService;
    using Domains.Entities;
    using Eisk.Core.WebApi;

    [Route("api/[controller]")]
    public class EmployeeTimeSheetsController
        : WebApiControllerBase<EmployeeTimeSheet, int>
    {
        public EmployeeTimeSheetsController(
            DomainService<EmployeeTimeSheet, int>
                employeeTimeSheetDomainService)
            : base(employeeTimeSheetDomainService)
        {

        }
    }
}