﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestExc_with_ASPNet_Core_and_SQLite.Models;
using TestExc_with_ASPNet_Core_and_SQLite.Services;
using Microsoft.AspNetCore.Mvc;

namespace TestExc_with_ASPNet_Core_and_SQLite.Controllers
{
    // КПП контроллер

    [ApiController]
    [Route("[controller]")]
    // It will be more convenient if this controller is renamed to CheckpointController
    // Read the requirements carefully. This controller should have two methods: 
    // the first adds the beginning of the shift to a specific employee, and the second adds the end of the shift.
    public class EmployeeController : ControllerBase
    {
        EmployeeService Service;
        public EmployeeController(EmployeeService service)
        {
            Service = service;
        }

        [HttpGet]
        public ActionResult<List<Employee>> GetAll() => Service.GetAll();
        
        [HttpGet("{id}")]
        public ActionResult<List<TimeShift>> Get(int id)
        {
            List<TimeShift> employee = Service.Get(id);
            if (employee == null) return BadRequest();
            else return employee;
        }

        [HttpPost]
        public IActionResult Create(TimeShift employeeShift , Employee employee)//must be 1 parameter - не понимаю, как тогда связывать Id работника с его списком смен, как не в сервисе
        {
            Service.Add(employeeShift, employee);
            return CreatedAtAction(nameof(Create), employeeShift);
        }
    }
}
