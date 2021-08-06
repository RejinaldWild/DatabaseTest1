using System;
using System.Collections.Generic;
using TestExc_with_ASPNet_Core_and_SQLite.Models;
using TestExc_with_ASPNet_Core_and_SQLite.Services;
using Microsoft.AspNetCore.Mvc;
using TestExc_with_ASPNet_Core_and_SQLite.ViewModels;

namespace TestExc_with_ASPNet_Core_and_SQLite.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HRController:ControllerBase
    {
        private readonly HRService Service;
        public HRController(HRService service)
        {
            Service = service;
        }

        [HttpGet]
        public ActionResult<EmployeeViewModel> GetAll() => Ok(Service.GetAll());

        [HttpGet("{id}")]
        public ActionResult<EmployeeViewModel> Get(int id)
        {
            EmployeeViewModel employee = Service.Get(id);
            if (employee == null) return BadRequest();
            return employee;
        }

        [HttpGet("position/{position}")]
        public ActionResult<ICollection<EmployeeViewModel>> Get(Position position)
        {
            try
            {
                ICollection<EmployeeViewModel> employee = Service.Get(position);
                if (employee == null) return BadRequest();
                return Ok(employee);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Create(EmployeeViewModel employee)
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
        public IActionResult Update(int id, EmployeeViewModel employee)
        {               
            try
            {
                EmployeeViewModel existEmployee = Service.Get(id);
                Service.Update(id, employee, existEmployee);
                return Ok();
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
            catch(NullReferenceException exnull)
            {
                Console.WriteLine("Null Exception");
                Console.WriteLine(exnull.Message);
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            EmployeeViewModel employee = Service.Get(id);
            if (employee == null) return BadRequest();
            try
            {
                Service.Delete(id);
                return Ok();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("The id is not valid");
                return BadRequest();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest();
            }
        }
    }
}
