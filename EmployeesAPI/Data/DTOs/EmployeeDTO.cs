using System.Collections.Generic;

namespace EmployeesAPI.Services.DTOs
{
    public class EmployeeDTO
    {
        public string status { get; set; }
        public string message { get; set; }
        public List<EmployeeDataDTO> data { get; set; }
    }
}
