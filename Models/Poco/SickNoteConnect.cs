using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSec.Models
{
    public class SickNoteConnect //class for connecting SickNote table with other tables
    {
        public DateTime DateOfSickness { get; set; }
        public int SickNoteId { get; set; }
        public string RefNumber { get; set; }
        public string TypeOfSickness { get; set; }
        public string StatusName { get; set; }
        public string DepartmentName { get; set; }
        public string EmployeeName { get; set; }
    }
}
