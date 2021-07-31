using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TestExc_with_ASPNet_Core_and_SQLite.Models;
using TestExc_with_ASPNet_Core_and_SQLite.Services;
using TestExc_with_ASPNet_Core_and_SQLite.ViewModels;

namespace TestExc_with_ASPNet_Core_and_SQLite.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HRController:ControllerBase
    {
        HRService Service;
        public HRController(HRService service)
        {
            Service = service;
        }

        [HttpGet]
        public ActionResult<ICollection<EmployeeViewModel>> GetAll() => Ok(Service.GetAll());

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
                Console.WriteLine(e.Message);
                return BadRequest();
            }
            return Ok();
        }

        [HttpPost]
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
