using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApiCqrsPractice.CQRS.Commands;
using Microsoft.EntityFrameworkCore;
using WebApiCqrsPractice.Data;

namespace WebApiCqrsPractice.CQRS.Handlers.CommandsHandlers
{
    public class DeleteStudentHandler : IRequestHandler<DeleteStudentCommand, bool>
    {
        private readonly StudentContext _context;

        public DeleteStudentHandler(StudentContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            if (_context.Student.Any(s => s.Id == request.DeleteId))
            {
                var deleteStudent = await _context.Student
                .Include(s => s.Subjects)
                .Where(x => x.Id == request.DeleteId).FirstOrDefaultAsync();

                _context.Student.Remove(deleteStudent);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
