using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
namespace EmployeeCrudOpsController;

using EmployeeCrudOpsApi.Model;
using EmployeeCrudOpsApi.DAL;

[ApiController]
[Route("api/[controller]")]

public class EmployeeCrudOpsController:ControllerBase
{
    private readonly ILogger<EmployeeCrudOpsController> _logger;

    public EmployeeCrudOpsController(ILogger<EmployeeCrudOpsController> logger)
    {
        _logger = logger;
    } 

    [HttpGet]
    [EnableCors]

    public IEnumerable<Employee> GetAllEmployees()
    {
        List<Employee> employee = EmployeeDataAccess.GetAllEmployees();
        return employee;
    }

    [Route("{id}")]
    [HttpGet]
    [EnableCors()]

    public ActionResult<Employee> GetOneEmployee(int id){
        Employee employee  = EmployeeDataAccess.GetEmployeeById(id);
        return employee;
    }

    [HttpPost]
    [EnableCors()]

    public IActionResult InsertNewUser(Employee employee){
        EmployeeDataAccess.SaveNewEmp(employee);
        return Ok(new {message = "Emplooyee data created"});
    }

    [Route("{id}")]
    [HttpDelete]
    [EnableCors()]

    public ActionResult<Employee> DeleteOneEmployee(int id){
        EmployeeDataAccess.DeleteEmpById(id);
        return Ok(new {message = "Emplooyee data deleted"});
    }
    
}    