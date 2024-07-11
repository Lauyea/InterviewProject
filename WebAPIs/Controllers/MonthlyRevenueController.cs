using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Net;
using WebAPIs.ActionFilters;
using WebAPIs.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIs.Controllers
{
    [LogActionFilter]
    [Route("api/[controller]")]
    [ApiController]
    public class MonthlyRevenueController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public MonthlyRevenueController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/<MonthlyRevenueController>
        [HttpGet]
        public async Task<IEnumerable<MonthlyRevenue?>> Get()
        {
            List<MonthlyRevenue> monthlyRevenues = await _context.MonthlyRevenues.ToListAsync();

            return monthlyRevenues;
        }

        // GET api/<MonthlyRevenueController>/5
        [HttpGet("{id}")]
        public IEnumerable<MonthlyRevenue> Get(string companyCode)
        {
            string sql = @"SelectMonthlyRevenue @CompanyCode";

            var parameters = new List<object>();

            parameters.Add(new SqlParameter("CompanyCode", companyCode));

            IEnumerable<MonthlyRevenue> monthlyRevenue = _context.MonthlyRevenues.FromSqlRaw(sql, parameters.ToArray()).AsEnumerable();

            return monthlyRevenue;
        }

        // POST api/<MonthlyRevenueController>
        [HttpPost]
        public Task Post([FromBody] MonthlyRevenue? monthlyRevenue)
        {
            if (monthlyRevenue == null) { throw new Exception(); }

            _context.MonthlyRevenues.Add(monthlyRevenue);

            return Task.CompletedTask;
        }
    }
}
