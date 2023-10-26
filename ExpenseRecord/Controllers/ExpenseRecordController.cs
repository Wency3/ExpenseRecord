using Microsoft.AspNetCore.Mvc;
using ExpenseRecord.Models;
using ExpenseRecord.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExpenseRecord.Controllers
{
    [Route("api/Record")]
    [ApiController]
    public class ExpenseRecordController : ControllerBase
    {
        private readonly IExpenseRecordService _expenseRecordService;
        public ExpenseRecordController(IExpenseRecordService expenseRecordService)
        {
            _expenseRecordService = expenseRecordService;
        }

        // GET: api/<ToDoItemsController>
        [HttpGet]
        [ProducesResponseType(typeof(ExpenseRecordDTO), 200)]
        [ProducesResponseType( 400)]

        public async Task<ActionResult<List<ExpenseRecordDTO>>> GetAll()
        {

             var result = await _expenseRecordService.GetAsync();
            return Ok(result);
        }

        // GET api/<ToDoItemsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExpenseRecordDTO>> GetAsync(string id)
        {
            var result = await _expenseRecordService.GetAsync(id);
            if (result == null)
            {
                return NotFound($"The item with id {id} does not exist.");
            }
            return Ok(result);
        }

        // POST api/<ToDoItemsController>
        [HttpPost]
        public async Task<ActionResult<ExpenseRecordDTO>> PostAsync([FromBody] ExpenseRecordCreateRequest expenseRecordCreateRequest)
        {
            var toDoItemDto = new ExpenseRecordDTO()
            {
                Description = expenseRecordCreateRequest.Description,
                Type = expenseRecordCreateRequest.Type,
                Amount = expenseRecordCreateRequest.Amount,
            };
            await _expenseRecordService.CreateAsync(toDoItemDto);
            return Created("", toDoItemDto);
        }

        // PUT api/<ToDoItemsController>/5
        /*[HttpPut("{id}")]
        public async Task<ActionResult<ExpenseRecordDTO>> PutAsync(string id, [FromBody] ToDoItemDto toDoItemDto)
        {
            bool isCreate = false;
            var exitingItem = await _expenseRecordService.GetAsync(id);
            if(exitingItem is null) 
            {
                isCreate = true;
                await _expenseRecordService.CreateAsync(toDoItemDto);

            }
            else
            {
                await _expenseRecordService.ReplaceAsync(id, toDoItemDto);
            }
            return isCreate ? Created("",toDoItemDto) : Ok(toDoItemDto);
        }*/

        // DELETE api/<ToDoItemsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(string id)
        {
            var isSuccessful = await _expenseRecordService.RemoveAsync(id);
            if(!isSuccessful)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
