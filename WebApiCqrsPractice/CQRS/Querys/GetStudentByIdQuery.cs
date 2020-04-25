using MediatR;
using WebApiCqrsPractice.Models;

namespace WebApiCqrsPractice.CQRS.Querys
{
    public class GetStudentByIdQuery : IRequest<Student>
    {
        public int Id { get; set; }
        public GetStudentByIdQuery(int id)
        {
            Id = id;
        }
    }
}
