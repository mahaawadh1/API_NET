using Microsoft.AspNetCore.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase

    {
        private readonly BankContext _bankContext;
        // NEW code _bankContext is the injection :we place it all in >
        public EmployeeController(BankContext Context)
        {
            _bankContext = Context;
        }

        [HttpGet]
        public List<BankBranch> GetAll()
        {
            return _bankContext.BankBranches.Select(b => new BankBranch
            {
                location = b.location,
                locationURL = b.locationURL,
            }).ToList();
        }


        [ProducesResponseType(typeof(Employee), 200)]
        [ProducesResponseType(404)]
        [HttpGet("{id}")]
        public ActionResult<EmployeeResponse> Details(int id)
        {
            var employee = _bankContext.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            return new EmployeeResponse
            {
                Name = employee.Name,
                civilId = employee.civilId,
                Position = employee.Position,
            };
        }

        [HttpPost("{id}")]
        public IActionResult Add(int id, AddEmployeeRequest req)
        {
            var bank = _bankContext.BankBranches.Find(id);
            var newEmployee = new Employee()
            {
                Name = req.Name,
                Position = req.position,
                civilId = req.civilId,
                BankBranch = bank,
            };
            _bankContext.Employees.Add(newEmployee);
            _bankContext.SaveChanges();

            return Created(nameof(Details), new { Id = newEmployee.Id });
        }

        [HttpPatch("{id}")]
        public IActionResult Edit(int id, AddEmployeeRequest req)
        {
            var employee = _bankContext.Employees.Find(id);
            employee.Name = req.Name;
            employee.Position = req.position;
            employee.civilId = req.civilId;

            _bankContext.SaveChanges();

            return Created(nameof(Details), new { Id = employee.Id });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var bank = _bankContext.BankBranches.Find(id);
            if (bank == null)
            {
                return BadRequest();
            }
            _bankContext.BankBranches.Remove(bank);
            _bankContext.SaveChanges();

            return Ok();
        }
    }
}