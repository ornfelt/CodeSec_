﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSec.Models //removed .Poco
{
    public class Employee
    {
        public string EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        public string RoleTitle { get; set; }

        public string DepartmentId { get; set; }
    }
}
