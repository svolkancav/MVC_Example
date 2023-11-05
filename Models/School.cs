using System.ComponentModel.DataAnnotations;

namespace _18_MVC_Example.Models
{
    public class School
    {
        [Key]
        public int SchooldId { get; set; }
        public string SchoolName { get; set; }
        public string SchoolAddress { get; set; }
        public string SchoolPhone { get; set; }
        public string SchoolEmail { get; set; }
        public DateTime SchoolFoundingDate { get; set; }
        public List<Student> Students { get; set; }
    }
}
