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
        public ActionResult<ICollection<TimeShiftViewModel>> GetAll() => Ok(Service.GetAll()); 

        [HttpPost("{id}")] //???
        public IActionResult Create(int id,CheckpointViewModel checkpoint)
        {
            try
            {                
                Service.AddShiftPoint(id,checkpoint);
                return CreatedAtAction(nameof(Create), checkpoint);                                            
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest();
            }
        }        
    }
}
