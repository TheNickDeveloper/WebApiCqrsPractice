using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebApiCqrsPractice.CQRS.Querys;
using WebApiCqrsPractice.Data;
using WebApiCqrsPractice.Models;

namespace WebApiCqrsPractice.CQRS.Handlers.QueryHandlers
{
    public class GetStudentsHandler : IRequestHandler<GetStudentsQuery, IEnumerable<Student>>
    {
        private readonly StudentContext _context;

        public GetStudentsHandler(StudentContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Student.Include(s=>s.Subjects).ToListAsync();
        }
    }
}
