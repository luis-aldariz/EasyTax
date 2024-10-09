using EasyTax.Service.Data;
using EasyTax.Service.Models;
using EasyTax.Service.Models.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyTax.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxController : ControllerBase
    {
        private readonly ILogger<TaxController> _logger;
        private readonly TaxContext _context;

        public TaxController(ILogger<TaxController> logger, TaxContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "GetTaxHistory")]
        public async Task<IEnumerable<TaxHistory>> GetTaxHistory()
        {
            IEnumerable<TaxHistory> taxHistory = await _context.TaxHistory.ToListAsync();
            return taxHistory;
        }

        [HttpPost(Name = "CreateTax")]
        public async Task CreateTax([FromBody] CreateTaxRequest request)
        {
            await _context.TaxHistory.AddAsync(new TaxHistory 
            { 
                Email = request.Email, 
                CountryCode = request.CountryCode, 
                FillingStatus = request.FillingStatus, 
                HouseHoldIncome = request.HouseHoldIncome, 
                Tax = request.Tax,
                CreatedOn = DateTime.Now
            });
            await _context.SaveChangesAsync();
        }
    }
}
