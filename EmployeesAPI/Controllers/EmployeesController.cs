using EmployeesAPI.Services;
using EmployeesAPI.Services.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmployeesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private EmployeesService _employeesService;
        public EmployeesController(EmployeesService employeesService)
        {
            _employeesService = employeesService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllEmployees()
        {
             EmployeeDTO employees = await _employeesService.GetAllEmployees();
             return Ok(employees);
        }

        [HttpGet("GetOldestEmployee")]
        public async Task<ActionResult> GetOldestEmployee()
        {
            EmployeeDataDTO oldetsEmployee = await _employeesService.GetOldestEmployee();
            return Ok(oldetsEmployee);
        }
    }
}
