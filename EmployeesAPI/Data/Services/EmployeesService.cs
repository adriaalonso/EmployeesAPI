using EmployeesAPI.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace EmployeesAPI.Services
{
    public class EmployeesService
    {
        private static HttpClient client;
        static EmployeesService()
        {
            client = new HttpClient()
            {
                BaseAddress = new Uri("http://dummy.restapiexample.com")
            };
        }

        public async Task<EmployeeDTO> GetAllEmployees()
        {
            string url = "/api/v1/employees";
            var response = await client.GetAsync(url);

            var result = new EmployeeDTO();

            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();
                result = JsonSerializer.Deserialize<EmployeeDTO>(stringResponse);
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return result;
        }

        public async Task<EmployeeDataDTO> GetOldestEmployee()
        {
            string url = "/api/v1/employees";
            var response = await client.GetAsync(url);

            var result = new EmployeeDTO();

            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();
                result = JsonSerializer.Deserialize<EmployeeDTO>(stringResponse);
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            var resultSorted = result.data.ToList().OrderByDescending(d => d.employee_age);
            return resultSorted.First();
        }

    }
}
