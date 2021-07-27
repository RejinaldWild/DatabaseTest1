using System;
using System.Collections.Generic;
// not used "using" is better to remove
using System.Linq;
using System.Threading.Tasks;
using TestExc_with_ASPNet_Core_and_SQLite.Models;
using TestExc_with_ASPNet_Core_and_SQLite.Services;
using Microsoft.AspNetCore.Mvc;

namespace TestExc_with_ASPNet_Core_and_SQLite.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HRController:ControllerBase
    {
        // forgot about access modifiers? here you can add private and readonly
        HRService Service;
        public HRController(HRService service)
        {
            Service = service;
        }

        [HttpGet]
        // Instead of database entities, it is better to add view models (DTO)
        public ActionResult<List<Employee>> GetAll() => Service.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Employee> Get(int id)
        {
            Employee employee = Service.Get(id);
            if (employee == null) return BadRequest();
            return employee;
        }

        [HttpGet("position/{position}")]
        public ActionResult<List<Employee>> Get(Position position)
        {
            try
            {
                List<Employee> employee = Service.Get(position);
                if (employee == null) return BadRequest();
                return employee;
            }
            catch (Exception e)
            {
                // it is better to use a logger to save such information
                Console.WriteLine(e.Message);
                // it would be nice if response contained information for the user what exactly went wrong
                return BadRequest();
            }
            // execution will not come here
            return Ok();
        }

        [HttpPost]
        // No validation required?
        public IActionResult Create(Employee employee)
        {
            try
            {
                Service.Add(employee);
                return CreatedAtAction(nameof(Create), employee);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Fill the all fields");
            }
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Employee employee)
        {
            if (id != employee.Id) return BadRequest();
            // This check is best done inside the Service.Update method
            Employee existEmployee = Service.Get(id);
            if (existEmployee == null) return BadRequest();
            try
            {
                Service.Update(employee);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("Fill the all fields");
                Console.WriteLine(e.Message);
                Console.WriteLine(e.TargetSite);
                return BadRequest();
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Wrong format in the field");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.TargetSite);
                return BadRequest();
            }            
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Employee employee = Service.Get(id);
            if (employee == null) return BadRequest();
            try
            {
                Service.Delete(id);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("The id is not valid");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return Ok();
        }
    }
}
