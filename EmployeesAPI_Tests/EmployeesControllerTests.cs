using EmployeesAPI.Controllers;
using EmployeesAPI.Services;
using EmployeesAPI.Services.DTOs;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesAPI_Tests
{
    public class EmployeesControllerTests
    {
        EmployeesService employeesService;
        EmployeesController employeesController;

        [SetUp]
        public void Setup()
        {
            employeesService = new EmployeesService();
            employeesController = new EmployeesController(employeesService);
        }

        [Test]
        public void HTTPGET_GetAllEmployees_IsOk()
        {
            var result = employeesController.GetAllEmployees().Result;
            Assert.That(result, Is.TypeOf<OkObjectResult>());

            var data = ((result as OkObjectResult).Value as EmployeeDTO).data;
            Assert.That(data.First().employee_name, Is.EqualTo("Tiger Nixon"));
        }

        [Test]
        public void HTTPGET_GetOldestEmployee_IsOk()
        {
            var result = employeesController.GetOldestEmployee().Result;
            Assert.That(result, Is.TypeOf<OkObjectResult>());

            var oldestEmployeeeName = ((result as OkObjectResult).Value as EmployeeDataDTO).employee_name;
            Assert.That(oldestEmployeeeName, Is.EqualTo("Ashton Cox"));
        }
    }
}
