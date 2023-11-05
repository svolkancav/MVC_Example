namespace _18_MVC_Example.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentFirstName { get; set;}
        public string StudentLastName { get; set; }
        public int StudentNo { get; set; }
        public DateTime StudentBirthday { get; set; }
        public string StudentClass { get; set; }
        public string StudentAddress { get; set; }
        public string StudentPhone { get; set; }
        public int SchoolID { get; set; }
        public School School { get; set; }


    }
}
