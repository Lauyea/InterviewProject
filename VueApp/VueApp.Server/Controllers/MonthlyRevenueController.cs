﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using VueApp.Server.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VueApp.Server.Controllers
{
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
        public async Task<IEnumerable<MonthlyRevenue?>> Get(int id)
        {
            List<MonthlyRevenue> monthlyRevenues = await _context.MonthlyRevenues.Where(r => r.CompanyCode == id).ToListAsync();

            return monthlyRevenues;
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
