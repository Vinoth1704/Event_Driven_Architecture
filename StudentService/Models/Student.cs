using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentService.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentID { get; set; }
        public string? StudentName { get; set; }
        public int RollNumber { get; set; }
        public string? Address { get; set; }
        public double MobileNumber { get; set; }
    }
}