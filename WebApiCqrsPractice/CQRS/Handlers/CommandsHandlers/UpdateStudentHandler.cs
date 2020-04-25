using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApiCqrsPractice.CQRS.Commands;
using WebApiCqrsPractice.Data;
using Microsoft.EntityFrameworkCore;
using WebApiCqrsPractice.Models;

namespace WebApiCqrsPractice.CQRS.Handlers.CommandsHandlers
{
    public class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand, string>
    {
        private readonly StudentContext _context;

        public UpdateStudentHandler(StudentContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            if (_context.Student.Any(s => s.Id == request.UpdteId))
            {
                var originalStudent = await _context.Student
                .Include(s => s.Subjects)
                .Where(x => x.Id == request.UpdteId).FirstOrDefaultAsync();

                _context.Entry(originalStudent).CurrentValues.SetValues(request.UpdateStudent);
                UpdateSubjects(originalStudent.Subjects, request.UpdateStudent.Subjects);

                _context.SaveChanges();

                return "Ok";
            }

            return "NotFound";
        }

        private void UpdateSubjects(List<Subject> originalSubjects, List<Subject> inputSubjects)
        {
            _context.Subjects.RemoveRange(originalSubjects);

            foreach (var inputSubject in inputSubjects)
            {
                var newAddress = new Subject
                {
                    Grades = inputSubject.Grades,
                    SubjectName = inputSubject.SubjectName
                };

                originalSubjects.Add(newAddress);
            }
        }
    }
}
