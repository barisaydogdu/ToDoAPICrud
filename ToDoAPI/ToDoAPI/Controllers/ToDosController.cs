using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoAPI.Data;
using ToDoAPI.Models;

namespace ToDoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ToDosController : Controller
    {
        //DbContext sınıfını bu sınıfta kullanıyoruz
        private readonly ToDoAPIDbContext dbContext;

        public ToDosController(ToDoAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetTodos()
        {
            return Ok(await dbContext.ToDos.ToListAsync());
        }

        [HttpPost]
        public async Task <IActionResult> AddToDo(AddToDoRequest addToDoRequest)
        {
            var todo = new ToDo()
            {
                Id = new Guid(),
                Task=addToDoRequest.Task,
                Priority = addToDoRequest.Priority, 
                Member = addToDoRequest.Member,
                isDone = addToDoRequest.isDone,
                UserImagePath = addToDoRequest.UserImagePath,
                CreatedDateTime = addToDoRequest.CreatedDateTime
            };
            //Oluşuturulan nesneyi todo sınıfına ekliyoruz
            await dbContext.ToDos.AddAsync(todo);
            await dbContext.SaveChangesAsync();
            return Ok(todo);
         }


        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateTodo([FromRoute] Guid id,UpdateToDoRequest updateToDoRequest)
        {
            //Önce Idyi buluyoruz
            var todo = await dbContext.ToDos.FindAsync(id);
            if (todo!=null)
            {
                todo.Priority = updateToDoRequest.Priority;
                todo.Member = updateToDoRequest.Member;
                todo.isDone = updateToDoRequest.isDone;
                todo.UserImagePath = updateToDoRequest.UserImagePath;
                todo.CreatedDateTime = updateToDoRequest.CreatedDateTime;
                await dbContext.SaveChangesAsync();
                return Ok();

            }
            return NotFound();
        }
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetToDo([FromRoute] Guid id)
        {
            var todo = await dbContext.ToDos.FindAsync(id);
            if (todo==null)
            {
                return NotFound();
            }
            return Ok(todo);
        }


        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteToDo([FromRoute] Guid id)
        {
            var todo = await dbContext.ToDos.FindAsync(id);
            if (todo != null)
            {
                dbContext.Remove(todo);
                await dbContext.SaveChangesAsync();
                return Ok(todo);

            }
            return NotFound();
        }

    }
}
