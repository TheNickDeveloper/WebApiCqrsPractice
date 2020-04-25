using MediatR;
using WebApiCqrsPractice.Models;

namespace WebApiCqrsPractice.CQRS.Commands
{
    public class UpdateStudentCommand :IRequest<string>
    {
        public int UpdteId { get; set; }
        public Student UpdateStudent { get; set; }

        public UpdateStudentCommand(int updateId, Student student)
        {
            UpdteId = updateId;
            UpdateStudent = student;
        }
    }
}
