using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WebApiCqrsPractice.CQRS.Commands;
using WebApiCqrsPractice.Data;
using WebApiCqrsPractice.Models;

namespace WebApiCqrsPractice.CQRS.Handlers.CommandsHandlers
{
    public class AddStudentHandler : IRequestHandler<AddStudentCommand, Student>
    {
        private readonly StudentContext _context;

        public AddStudentHandler(StudentContext context)
        {
            _context = context;
        }

        public async Task<Student> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            _context.Student.Add(request.NewStudent);
            await _context.SaveChangesAsync();

            return request.NewStudent;
        }
    }
}
