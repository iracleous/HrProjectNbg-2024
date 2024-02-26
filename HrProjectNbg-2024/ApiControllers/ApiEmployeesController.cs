using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HrProjectNbg_2024.Data;
using HrProjectNbg_2024.Models;

namespace HrProjectNbg_2024.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiEmployeesController : ControllerBase
    {
        private readonly HrDbContext _context;
        private readonly ILogger<ApiEmployeesController> _logger;
        private readonly IConfiguration _configuration;

        public ApiEmployeesController(HrDbContext context, ILogger<ApiEmployeesController> logger,
            IConfiguration configuration)
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;
        }

        // GET: api/ApiEmployees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            _logger.LogInformation("The API has been  called");
            foreach ( var conf in _configuration.AsEnumerable() )
            {
                _logger.LogInformation($"{conf.Key}= {conf.Value}");
            }
            return await _context.Employees.ToListAsync();
        }

        // GET: api/ApiEmployees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // PUT: api/ApiEmployees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ApiEmployees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
        }

        // DELETE: api/ApiEmployees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        // POST: api/ApiEmployees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("{employeeId}/manager/{managerId}")]
        public async Task<ActionResult<Employee>> PostManagerToEmployee(int employeeId, int managerId)
        {
            var employee = _context.Employees.Find(employeeId);
            var manager = _context.Employees.Find(managerId);
            if (manager == null|| employee == null) { return  NotFound(); }
            employee.Manager = manager;
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
         }

        // POST: api/ApiEmployees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("{employeeId}/department/{departmentId}")]
        public async Task<ActionResult<Employee>> PostDepartmentToEmployee(int employeeId, int departmentId)
        {
            var employee = _context.Employees.Find(employeeId);
            var department = _context.Departments.Find(departmentId);
            if (employee == null || department == null) 
                return NotFound();
            employee.Department = department;
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
        }

            private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
