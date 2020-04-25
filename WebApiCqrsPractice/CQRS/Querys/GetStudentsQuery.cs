using MediatR;
using System.Collections.Generic;
using WebApiCqrsPractice.Models;

namespace WebApiCqrsPractice.CQRS.Querys
{
    public class GetStudentsQuery : IRequest<IEnumerable<Student>>
    {

    }
}
