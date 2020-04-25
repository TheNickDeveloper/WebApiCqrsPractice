using MediatR;

namespace WebApiCqrsPractice.CQRS.Commands
{
    public class DeleteStudentCommand : IRequest<bool>
    {
        public int DeleteId { get; set; }

        public DeleteStudentCommand(int deleteId)
        {
            DeleteId = deleteId;
        }
    }
}
