using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eisk.Domains.Employee
{
    public class EmployeeTimeSheet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime TimeSheetDate { get; set; }
        public float LoggedHours { get; set; }
        public string ProjectCode { get; set; }

    }
}