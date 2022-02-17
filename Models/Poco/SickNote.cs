using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using CodeSec.common;

namespace CodeSec.Models
{
    public class SickNote
    {
        public int SickNoteID { get; set; }

        [Display(Name = "Har du intyg från läkare? Kryssa då i denna ruta.")]
        public bool Certificate { get; set; }

        [Display(Name = "Vilken typ av sjukdom?")]
        [Required(ErrorMessage = "Du måste ange typ av sjukdom")]
        public string TypeOfSickness { get; set; }
      
        [Display(Name = "Vilken dag blev du sjuk?")]
        [DataType(DataType.Date)]
        public DateTime DateOfSickness { get; set; }

    [Display(Name = "Ange datum för läkarintyg här. Om du anmäler vård av barn kan du ange barnets personnummer här.")]
    public string Other { get; set; }

        public string RegularEmployeeInfo { get; set; }

        public string RegularEmployeeAction { get; set; }

        [Display(Name = "Ditt namn (för- och efternamn):")]
        [Required(ErrorMessage = "Du måste ange ett namn")]
        public string EmployeeName { get; set; }

        [Display(Name = "Din telefon:")]
        [Required(ErrorMessage = "Du måste ange ett telefonnummer")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Felaktigt format. Var god ange 10 siffror")] //telefonnumret måste vara 10 siffror
        public string EmployeePhone { get; set; }

        public string StatusId { get; set; }

        public string DepartmentId { get; set; }

        public string EmployeeId { get; set; }
        public string RefNumber { get; set; }

        public ICollection<Sample> Samples { get; set; }
        public ICollection<Picture> Pictures { get; set; }

    
  }
}
