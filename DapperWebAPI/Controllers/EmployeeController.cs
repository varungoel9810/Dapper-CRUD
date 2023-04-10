using DapperWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeRepository employeeRepository;
        public EmployeeController()
        {
            employeeRepository = new EmployeeRepository();
        }

        //Get All
        [HttpGet]
        [Route("Get")]
        public IEnumerable<Employee> GetAll()
        {
            return employeeRepository.GetAll();
        }

        //GetById
        [HttpGet]
        [Route("Get/{id}")]
        public Employee GetById(int id)
        {
            return employeeRepository.GetById(id);
        }

        // INSERT
        [HttpPost]
        public void Post([FromBody]Employee employee)
        {
            if(ModelState.IsValid)
                employeeRepository.Add(employee);
        }

        // UPDATE
        [HttpPut("{id}")]
        public void Put(int id , [FromBody] Employee employee)
        {
            employee.EmpId = id;
            if (ModelState.IsValid)
                employeeRepository.Update(employee);
        }

        //DELETE
        [HttpDelete]
        public void Delete(int id)
        {
            employeeRepository.Delete(id);
        }

    }
}
