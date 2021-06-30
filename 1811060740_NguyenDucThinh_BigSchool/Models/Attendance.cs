using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _1811060740_NguyenDucThinh_BigSchool.Models
{
    public class Attendance
    {
        public Course Course { get; set; }
        
        [Key]
        [Column(Order = 1)]
        public int CourseId { get; set; }

        public ApplicationUser Attendee { get; set; }
        
        [Key]
        [Column(Order = 2)]
        public string AttendeeId { get; set; }
    }
}