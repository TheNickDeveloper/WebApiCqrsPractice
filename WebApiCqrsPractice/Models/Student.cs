using System.Collections.Generic;

namespace WebApiCqrsPractice.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public List<Subject> Subjects { get; set; }
    }
}
