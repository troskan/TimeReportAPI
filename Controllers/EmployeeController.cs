﻿using Microsoft.AspNetCore.Mvc;
using TimeReportAPI.Repositories.Interfaces;
using TimeReportClassLibrary.Models;

namespace TimeReportAPI.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IRepository<Employee> _db;
        public EmployeeController(IRepository )
        {
            
        }
    }
}
