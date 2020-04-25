using MediatR;
using WebApiCqrsPractice.Models;

namespace WebApiCqrsPractice.CQRS.Commands
{
    public class AddStudentCommand : IRequest<Student>
    {
        public Student NewStudent { get; set; }

        public AddStudentCommand(Student newStudent)
        {
            NewStudent = newStudent;
        }
    }
}
