using EmployeesAPI.Services;
using NUnit.Framework;

namespace EmployeesAPI_Tests
{
    public class Tests
    {
        EmployeesService employeesService;

        [SetUp]
        public void Setup()
        {
            employeesService = new EmployeesService();
        }

        [Test]
        public void GetAllEmployees_IsSuccess()
        {
            var result = employeesService.GetAllEmployees().Result;
            Assert.That(result.status, Is.EqualTo("success"));
        }

        [Test]
        public void GetAllEmployees_HasCorrectSize()
        {
            var result = employeesService.GetAllEmployees().Result;
            Assert.That(result.data.Count, Is.EqualTo(24));
        }

        [Test]
        public void GetOldestEmployee_HasCorrectAge()
        {
            var result = employeesService.GetOldestEmployee().Result;
            Assert.That(result.employee_age, Is.EqualTo(66));
        }
    }
}