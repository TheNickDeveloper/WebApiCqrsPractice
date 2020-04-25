# Command Query Responsibility Segregation Practice
 Command Query Responsibility Segregation concept practice by using Web API service as example.
 
## Concept

"It states that every method should either be a command that performs an action, or a query that returns data to the caller, but not both. In other words, Asking a question should not change the answer. More formally, methods should return a value only if they are referentially transparent and hence possess no side effects." - [Wiki](https://en.wikipedia.org/wiki/Command%E2%80%93query_separation)

## Technology

* [MediatR](https://github.com/jbogard/MediatR)- .net CQRS package.
* EntityFramewokCore - .net ORM package.

## CQRS Note

* Procsee step be like:

![image](https://github.com/TheNickDeveloper/WebApiCqrsPractice/Images/cqrsPattern.png)

* Use Web API as example, for any action will affact data source should belong to "Command"; For those action which will not affact result belong "Query".
* For each action, they will have their own handler. Handler contain the business.
* Folder structure could look like:

```
Commands folder
    - AddCommand
    - DeleteCommand
    - UpdateCommand

Query folder
    - GetQuery
    - GetQueryById

Handler folder
    - AddHandler
    - DeleteHandler
    - UpdateHandler
    - GetHandler
    - GetByIdHandler
```

* Take Get by ID action as example:

```csharp
[HttpGet]
public async Task<ActionResult<Student>> GetStudent(int id)
{
    var query = new GetStudentByIdQuery(id);
    var result = await _mediator.Send(query);
    return result != null ? (ActionResult)Ok(result) : NotFound();
}

// implement IRequest interface, with return type Student
public class GetStudentByIdQuery : IRequest<Student>
{
    // property that will pass in the handler
    public int Id { get; set; }
    public GetStudentByIdQuery(int id)
    {
        Id = id;
    }
}

// implement IRequestHandler interface, with pass in query/command tyep(GetStudentByIdQuery), and return type(Student)
public class GetStudentByIdHandler : IRequestHandler<GetStudentByIdQuery, Student>
{
    private readonly StudentContext _context;
    
    // initial dbcontext for db connection
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

```




