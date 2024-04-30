using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.Models;
namespace WebApplication5.Controllers
{
    [Route("api/bank")]
    [ApiController]
    [Authorize]
    public class BankController : ControllerBase
    {
        private readonly BankContext _bankContext;
        public BankController(BankContext Context)
        {
            _bankContext = Context;
        }

        [HttpGet]
        public PageListResult<BankBranch> GetAll(int page = 1, string search = "")
        {
            if (search == "")
            {
                return _bankContext.BankBranches
                   
                    .Select(b => new BankBranch
                    {
                        location = b.location,
                        locationURL = b.locationURL,
                    }).ToPageList(page, 1);
            }
            return _bankContext.BankBranches
                    .Where(r => r.location.StartsWith(search))
                     .Select(b => new BankBranch
                     {
                         location = b.location,
                         locationURL = b.locationURL,
                     }).ToPageList(page, 1);
        }
        [HttpGet("{id}")]
        public ActionResult<BankBranch> DetailsBank(int id)
        {
            var bank = _bankContext.BankBranches.Find(id);
            if (bank == null)
            {
                return NotFound();
            }
            return new BankBranch
            {
                location = bank.location,
                locationURL = bank.locationURL,
            };
        }

        [HttpPost]
        public IActionResult Add(AddBankRequest req)
        {
            var newBank = new BankBranch()
            {
                location = req.location,
                locationURL = req.locationURL,
                branchManager = "",
            };
            _bankContext.BankBranches.Add(newBank);
            _bankContext.SaveChanges();

            return Created(nameof(DetailsBank), new { Id = newBank.Id });
        }

        [HttpPatch("{id}")]
        public IActionResult Edit(int id, AddBankRequest req)
        {
            var bank = _bankContext.BankBranches.Find(id);
            bank.location = req.location;
            bank.locationURL = req.locationURL;
            bank.branchManager = req.BranchManager;
            _bankContext.SaveChanges();

            return Created(nameof(DetailsBank), new { Id = bank.Id });
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var bank = _bankContext?.BankBranches.Find(id);
            if (bank == null)
            {
                return BadRequest();
            }
            _bankContext?.BankBranches.Remove(bank);
            _bankContext.SaveChanges();

            return Ok();
        }
    }
}