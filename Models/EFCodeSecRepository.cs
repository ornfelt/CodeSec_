using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CodeSec.Models
{
    public class EFCodeSecRepository : ICodeSecRepository //inherits from ICodeSecRepository
    {
        private ApplicationDbContext context;

        //constructor
        public EFCodeSecRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        //Create SickNote
        public string SaveSickNote(SickNote SickNote)
        {
            if (SickNote.SickNoteID == 0)
            {
                var currentVal = context.Sequences.Where(cv => cv.Id == 1).First(); //get CurrentValue for id = 1
        var empId = context.Employees.Where(em => em.EmployeeName == SickNote.EmployeeName).FirstOrDefault().EmployeeId;
        var depId = context.Employees.Where(em => em.EmployeeName == SickNote.EmployeeName).FirstOrDefault().DepartmentId;
                SickNote.RefNumber = "2019-45-" + currentVal.CurrentValue.ToString();
                SickNote.StatusId = "S_A";
        SickNote.EmployeeId = empId;
        SickNote.DepartmentId = depId;
                context.SickNotes.Add(SickNote);
                context.SaveChanges();
                UpdateSequenceValue(currentVal); //calls the method that adds 1 to currentvalue
            }
            else
            {
                SickNote dbEntry = context.SickNotes.FirstOrDefault(e => e.SickNoteID == SickNote.SickNoteID);
                if (dbEntry != null)
                {
                    dbEntry.Certificate = SickNote.Certificate;
                    dbEntry.Other = SickNote.Other;
                    context.SaveChanges();
                }
            }

            string refNumb = SickNote.RefNumber;
            return refNumb;
        }

        //Read SickNote
        public IQueryable<SickNote> SickNotes => context.SickNotes.Include(e => e.Samples).Include(e => e.Pictures); //gets SickNotes from dbContext with samples and pictures included

        public Task<SickNote> GetSickNoteDetail(int id)
        {
            return Task.Run(() =>
            {
                var SickNoteDetail = context.SickNotes.Where(ed => ed.SickNoteID == id).FirstOrDefault(); //changed to look at context.SickNotes instead of just SickNotes.Where...
                return (SickNoteDetail);
            });
        }

        public SickNote GetSickNoteInfo(int id)
        {
            var SickNoteDetail = context.SickNotes.Where(ed => ed.SickNoteID == id).FirstOrDefault(); //changed to look at context.SickNotes instead of just SickNotes.Where...

            return (SickNoteDetail);
        }

        //Delete SickNote
        public SickNote DeleteSickNote(int id)
        {
            SickNote dbEntry = context.SickNotes.FirstOrDefault(e => e.SickNoteID == id);
            if (dbEntry != null)
            {
                context.SickNotes.Remove(dbEntry);
            }
            context.SaveChanges();
            return dbEntry;
        }

        //Update Sequence
        public void UpdateSequenceValue(Sequence sequence)
        {
            Sequence dbEntry = context.Sequences.FirstOrDefault(s => s.Id == 1);
            if (dbEntry != null)
            {
                dbEntry.CurrentValue = (sequence.CurrentValue + 1);
                context.SaveChanges();
            }
        }

        //Update SickNoteStatus
        public void UpdateSickNoteStatus(int id, string status)
        {

            SickNote dbEntry = context.SickNotes.FirstOrDefault(e => e.SickNoteID == id);
            if (dbEntry != null)
            {
                dbEntry.StatusId = status;
            }
            context.SaveChanges();
        }

        public void UpdateSickNoteDepartment(int id, string department)
        {
            SickNote dbEntry = context.SickNotes.FirstOrDefault(e => e.SickNoteID == id);
            if (dbEntry != null)
            {
                dbEntry.DepartmentId = department;
        //try-catch used - in accordance with checklist: 9
                try
                {
                    var employeeDepartment = context.Employees.Where(em => em.EmployeeId == dbEntry.EmployeeId).FirstOrDefault().DepartmentId; //gets DepartmentId from the SickNotes employee
                    if (employeeDepartment != department)
                    {
                        dbEntry.EmployeeId = null;
                    }
                }
                catch(Exception e)
                {

                }
            }
            context.SaveChanges();
        }

        public void UpdateRegularEmployee(int id, string RegularEmployee, string reason, bool noAction)
        {
            SickNote dbEntry = context.SickNotes.FirstOrDefault(e => e.SickNoteID == id);
      var empsDep = context.Employees.Where(em => em.EmployeeId == RegularEmployee).FirstOrDefault().DepartmentId;

            if (dbEntry != null)
            {
                if (noAction)
                {
                    dbEntry.StatusId = "S_B";
                    dbEntry.EmployeeId = null;
                    if (reason.Equals("Ange motivering"))
                    {
                        reason = "";
                    }
                    dbEntry.RegularEmployeeInfo = reason;
                }
                else
                {
                    dbEntry.EmployeeId = RegularEmployee;
          dbEntry.DepartmentId = context.Departments.Where(de => de.DepartmentId == empsDep).FirstOrDefault().DepartmentId;
                }
            }
            context.SaveChanges();
        }

        public void UpdateRegularEmployeeAction(int id, string action)
        {
            SickNote dbEntry = context.SickNotes.FirstOrDefault(e => e.SickNoteID == id);
            if (dbEntry.RegularEmployeeAction == "") //if info is already empty only info is added, else with space between previous info
            {
                dbEntry.RegularEmployeeAction = action;
            }
            else
            {
                dbEntry.RegularEmployeeAction += (" " + action);
            }
            context.SaveChanges();
        }

        public void UpdateRegularEmployeeInfo(int id, string info)
        {
            SickNote dbEntry = context.SickNotes.FirstOrDefault(e => e.SickNoteID == id);
            if (dbEntry != null)
            {
                if (dbEntry.RegularEmployeeInfo == "") //if info is already empty only info is added, else with space between previous info
                {
                    dbEntry.RegularEmployeeInfo = info;
                }
                else
                {
                    dbEntry.RegularEmployeeInfo += (" " + info);
                }
            }
            context.SaveChanges();
        }

        public void UpdatePicture(int id, string picturePath)
        {
            //update in picture table
            context.Pictures.Add(new Picture { PictureName = picturePath, SickNoteId = id });
            context.SaveChanges();
        }

        public void UpdateSample(int id, string samplePath)
        {
            //update in sample table
            context.Samples.Add(new Sample { SampleName = samplePath, SickNoteId = id });
            context.SaveChanges();
        }

        public string PicturePath(int id)
        {
      //try-catch used - in accordance with checklist: 9
      try
      {
        Picture dbEntry = context.Pictures.FirstOrDefault(p => p.SickNoteId == id); //gets last picture uploaded, can be switched to FirstOrDefault
        if (dbEntry != null)
        {
          return dbEntry.PictureName;
        }
        else
        {
          return "";
        }
      }
      catch(Exception e)
      {
        Console.WriteLine("The process failed: {0}", e.ToString());
        return "";
      }
        }

        public string SamplePath(int id)
        {
            Sample dbEntry = context.Samples.FirstOrDefault(s => s.SickNoteId == id); //gets last sample uploaded, can be switched to FirstOrDefault
            if (dbEntry != null)
            {
                return dbEntry.SampleName;
            }
            else
            {
                return "";
            }
        }

        /*
         * Delete methods for removing tests..
         */
        public Sample DeleteSample(int id)
        {
            Sample dbEntry = context.Samples.FirstOrDefault(s => s.SampleId == id);
            if (dbEntry != null)
            {
                context.Samples.Remove(dbEntry);
            }
            context.SaveChanges();
            return dbEntry;
        }

        public Picture DeletePicture(int id)
        {
            Picture dbEntry = context.Pictures.FirstOrDefault(p => p.PictureId == id);
            if (dbEntry != null)
            {
                context.Pictures.Remove(dbEntry);
            }
            context.SaveChanges();
            return dbEntry;
        }

        public IQueryable<Department> Departments => context.Departments;
        public IQueryable<SickNoteStatus> SickNoteStatuses => context.SickNoteStatuses;
        public IQueryable<Employee> Employees => context.Employees;
    }
}
