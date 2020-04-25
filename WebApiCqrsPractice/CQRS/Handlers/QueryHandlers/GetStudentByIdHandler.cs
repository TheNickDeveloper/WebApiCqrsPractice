using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApiCqrsPractice.CQRS.Querys;
using WebApiCqrsPractice.Data;
using WebApiCqrsPractice.Models;
using Microsoft.EntityFrameworkCore;


namespace WebApiCqrsPractice.CQRS.Handlers.QueryHandlers
{
    public class GetStudentByIdHandler : IRequestHandler<GetStudentByIdQuery, Student>
    {
        private readonly StudentContext _context;

        public GetStudentByIdHandler(StudentContext context)
        {
            _context = context;
        }

        public async Task<Student> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            if (_context.Student.Any(s => s.Id == request.Id))
            {
                return await _context.Student
                    .Include(s => s.Subjects)
                    .Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            }
            return null;
        }
    }
}
