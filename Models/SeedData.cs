using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace CodeSec.Models
{
    public class SeedData
    {
    //this method ensures that data is added to the database
        public static void EnsurePopulated(IServiceProvider services)
        {
            var context = services.GetRequiredService<ApplicationDbContext>(); //Dependency Injection is used to support checklist: 1 (use existing libraries and frameworks)
            //Check if table SickNote is empty and then fills it with data
            if (!context.Departments.Any())
      {
        context.Departments.AddRange(
          new Department { DepartmentId = "D00", DepartmentName = "CodeSec" },
          new Department { DepartmentId = "D01", DepartmentName = "Avdelning 1" },
          new Department { DepartmentId = "D02", DepartmentName = "Avdelning 2" },
          new Department { DepartmentId = "D03", DepartmentName = "Avdelning 3" }
        );
        context.SaveChanges(); //spara tabellen
      }

      if (!context.SickNoteStatuses.Any())
      {
        context.SickNoteStatuses.AddRange(
          new SickNoteStatus { StatusId = "S_A", StatusName = "Inrapporterad" },
          new SickNoteStatus { StatusId = "S_B", StatusName = "Ej godkänd anmälan" },
          new SickNoteStatus { StatusId = "S_C", StatusName = "Sjukanmäld" },
          new SickNoteStatus { StatusId = "S_D", StatusName = "Vård av barn" }
        );
        context.SaveChanges();
      }

      if (!context.Sequences.Any())
      {
        context.Sequences.Add(
          new Sequence { CurrentValue = 200 }
          );
        context.SaveChanges();
      }

      if (!context.Employees.Any())
      {
        context.Employees.AddRange(
          new Employee { EmployeeId = "E001", EmployeeName = "Jarl Hövding", RoleTitle = "Admin", DepartmentId = "D00" },
          new Employee { EmployeeId = "E101", EmployeeName = "Anna Åkerman", RoleTitle = "ExecutiveEmployee", DepartmentId = "D01" },
          new Employee { EmployeeId = "E201", EmployeeName = "Fredrik Roos", RoleTitle = "ExecutiveEmployee", DepartmentId = "D02" },
          new Employee { EmployeeId = "E301", EmployeeName = "Gösta Qvist", RoleTitle = "ExecutiveEmployee", DepartmentId = "D03" },
          new Employee { EmployeeId = "E102", EmployeeName = "Rolf Gunnarsson", RoleTitle = "RegularEmployee", DepartmentId = "D01" },
          new Employee { EmployeeId = "E202", EmployeeName = "Susanne Fred", RoleTitle = "RegularEmployee", DepartmentId = "D02" },
          new Employee { EmployeeId = "E302", EmployeeName = "Ulla Davidsson", RoleTitle = "RegularEmployee", DepartmentId = "D03" }
        );
        context.SaveChanges();
      }

      if (!context.SickNotes.Any())
      {
        context.SickNotes.AddRange(
          new SickNote { RefNumber = "2018-45-195", Certificate = false, TypeOfSickness = "Vård av barn", DateOfSickness = new DateTime(2018, 04, 24), Other = "20170706-1234", RegularEmployeeInfo = "Anmälan är korrekt", RegularEmployeeAction = "Anmälan godkänd", EmployeeName = "Fredrik Roos", EmployeePhone = "0432-5545522", StatusId = "S_D", DepartmentId = "D02", EmployeeId = "E201" },

          new SickNote { RefNumber = "2018-45-196", Certificate = false, TypeOfSickness = "Förkylning", DateOfSickness = new DateTime(2018, 04, 29), Other = "", RegularEmployeeInfo = "Undersökning har gjorts på plats, ingen fläck har hittas", RegularEmployeeAction = "", EmployeeName = "Rolf Gunnarsson", EmployeePhone = "0432-5152255", StatusId = "S_C", DepartmentId = "D01", EmployeeId = "E102" },

          new SickNote { RefNumber = "2018-45-197", Certificate = false, TypeOfSickness = "Halsont med feber", DateOfSickness = new DateTime(2018, 05, 28), Other = "", RegularEmployeeInfo = "Anmälan är korrekt", RegularEmployeeAction = "Anmälan godkänd", EmployeeName = "Rolf Gunnarsson", EmployeePhone = "0432-5152255", StatusId = "S_C", DepartmentId = "D01", EmployeeId = "E102" },

          new SickNote { RefNumber = "2018-45-198", Certificate = false, TypeOfSickness = "Förkyld med feber", DateOfSickness = new DateTime(2018, 06, 04), Other = "", RegularEmployeeInfo = "Anmälan stämmer", RegularEmployeeAction = "Anmälan godkänd", EmployeeName = "Susanne Fred", EmployeePhone = "0432-5322255", StatusId = "S_C", DepartmentId = "D02", EmployeeId = "E202" },

          new SickNote { RefNumber = "2018-45-199", Certificate = false, TypeOfSickness = "Vård av barn", DateOfSickness = new DateTime(2018, 07, 10), Other = "20180504-4321", RegularEmployeeInfo = "Anmälan stämmer", RegularEmployeeAction = "Anmälan godkänd", EmployeeName = "Ulla Davidsson", EmployeePhone = "0432-5322555", StatusId = "S_D", DepartmentId = "D03", EmployeeId = "E302" }
        );
        context.SaveChanges();
      }
    }
  }
}
