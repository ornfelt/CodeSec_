using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSec.Models
{
  //repository interface
    public interface ICodeSecRepository //changed to public
    {
        
        IQueryable<Department> Departments { get; }
        IQueryable<Employee> Employees { get; }
        IQueryable<SickNoteStatus> SickNoteStatuses { get; }

        //Create
        string SaveSickNote(SickNote SickNote);

        //Read
        IQueryable<SickNote> SickNotes { get; }
        Task<SickNote> GetSickNoteDetail(int id);
        SickNote GetSickNoteInfo(int id);
        string PicturePath(int id);
        string SamplePath(int id);

        //Delete
        SickNote DeleteSickNote(int id);
        Sample DeleteSample(int id);
        Picture DeletePicture(int id);

        //Update
        void UpdateSequenceValue(Sequence sequence);
        void UpdateSickNoteStatus(int id, string status);
        void UpdateSickNoteDepartment(int id, string department);
        void UpdateRegularEmployee(int id, string RegularEmployee, string reason, bool noAction);
        void UpdateRegularEmployeeAction(int id, string action);
        void UpdateRegularEmployeeInfo(int id, string info);
        void UpdatePicture(int id, string picturePath);
        void UpdateSample(int id, string samplePath);
    }
}
