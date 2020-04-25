using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApiCqrsPractice.CQRS.Commands;
using WebApiCqrsPractice.CQRS.Querys;
using WebApiCqrsPractice.Models;

namespace WebApiCqrsPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudent()
        {
            var query = new GetStudentsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var query = new GetStudentByIdQuery(id);
            var result = await _mediator.Send(query);
            return result != null ? (ActionResult)Ok(result) : NotFound();
        }

        // POST: api/Students
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            var command = new AddStudentCommand(student);
            var result = await _mediator.Send(command);
            return CreatedAtAction("GetStudent", new { id = result.Id }, result);
        }

        // PUT: api/Students/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            var command = new UpdateStudentCommand(id, student);
            var result = await _mediator.Send(command);

            return result switch
            {
                "Ok" => Ok(),
                "NotFound" => NotFound(),
                _ => BadRequest(),
            };
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStudent(int id)
        {
            var command = new DeleteStudentCommand(id);
            var result = await _mediator.Send(command);
            return result ? Ok() : (ActionResult)NotFound();
        }
    }
}
