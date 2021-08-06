using System.Collections.Generic;
using System;
using TestExc_with_ASPNet_Core_and_SQLite.Models;
using TestExc_with_ASPNet_Core_and_SQLite.Services;
using Microsoft.AspNetCore.Mvc;
using TestExc_with_ASPNet_Core_and_SQLite.ViewModels;

namespace TestExc_with_ASPNet_Core_and_SQLite.Controllers
{
    // КПП контроллер

    [ApiController]
    [Route("[controller]")]
    public class CheckpointController : ControllerBase
    {
        private readonly CheckpointService Service;
        public CheckpointController(CheckpointService service)
        {
            Service = service;
        }

        [HttpGet]
        public ActionResult<TimeShiftViewModel> GetAll() => Ok(Service.GetAll()); 

        [HttpPost("{shift}")]
        public IActionResult Create(TimeShift employeeShift , Employee employee)//must be 1 parameter - не понимаю, как тогда связывать Id работника с его списком смен, как не в сервисе
        {
            try
            {
                if (employeeShift.EndShift == null || employeeShift.EndShift.Date != DateTime.Now)
                {
                    Service.AddStartShift(employeeShift.StartShift, employee.Id);
                    return CreatedAtAction(nameof(Create), employeeShift);
                }
                else
                {
                    Service.AddEndShift(employeeShift.EndShift, employee.Id);
                    return CreatedAtAction(nameof(Create), employeeShift);
                }                
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest();
            }
        }

        //[HttpPost("{shift}/{id}")]
        //public IActionResult Create(TimeShift employeeShift, Employee employee)//must be 1 parameter - не понимаю, как тогда связывать Id работника с его списком смен, как не в сервисе
        //{
        //    Service.AddEndShift(employeeShift.EndShift, employee.Id);
        //    return CreatedAtAction(nameof(Create), employeeShift);
        //}
    }
}
