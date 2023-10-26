using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ExpenseRecord.Models;
using ExpenseRecord.Services;
namespace ExpenseRecord.Services
{
    public class ExpenseRecordService : IExpenseRecordService
    {
        private readonly IMongoCollection<Models.ExpenseRecords> _ExpenseRecordsCollection;

        public ExpenseRecordService(
            IOptions<ExpenseRecordDatabaseSettings> ExpenseRecordDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                ExpenseRecordDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                ExpenseRecordDatabaseSettings.Value.DatabaseName);

            _ExpenseRecordsCollection = mongoDatabase.GetCollection<Models.ExpenseRecords>(
                ExpenseRecordDatabaseSettings.Value.CollectionName);
        }
        public async Task CreateAsync(ExpenseRecordDTO newExpenseRecord)
        {
            var item = new ExpenseRecords
            {
                Description = newExpenseRecord.Description,
                Type = newExpenseRecord.Type,
                Amount = newExpenseRecord.Amount,
            };
            await _ExpenseRecordsCollection.InsertOneAsync(item);
        }

        public async Task<List<ExpenseRecordDTO>> GetAsync()
        {
            var toDoItemDtos = new List<ExpenseRecordDTO>();

            var toDoItems = await _ExpenseRecordsCollection.Find(_ => true).ToListAsync();
            if (toDoItems is null)
            {
                return toDoItemDtos;
            }
            for (var i = 0; i < toDoItems.Count; i++)
            {
                toDoItemDtos.Add(new ExpenseRecordDTO
                {
                    Id = toDoItems[i].Id,
                    Description = toDoItems[i].Description,
                    Type = toDoItems[i].Type,
                    Date = toDoItems[i].Date,
                    Amount = toDoItems[i].Amount,
                });
            }
            return toDoItemDtos;
        }

        public async Task<ExpenseRecordDTO?> GetAsync(string id)
        {
            var expenseRecord = await _ExpenseRecordsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            if (expenseRecord is null)
            {
                return null;
            }
            var toDoItemDtos = new ExpenseRecordDTO
            {
                Id = expenseRecord.Id,
                Description = expenseRecord.Description,
                Type = expenseRecord.Type,
                Amount = expenseRecord.Amount,
                Date = expenseRecord.Date,
            };
            return toDoItemDtos;

        }

        public async Task<bool> RemoveAsync(string id)
        {
            var result = await _ExpenseRecordsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            if (result is null)
            {
                return false;
            }
            await _ExpenseRecordsCollection.DeleteOneAsync(x => x.Id == id);
            return true;
        }

/*        public async Task ReplaceAsync(string id, ToDoItemDto updatedToDoItem)
        {
            var itemToBeUpdated = await _ToDoItemsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

            var toDoItem = new Models.ExpenseRecord
            {
                Id = id,
                Description = updatedToDoItem.Description,
                Done = updatedToDoItem.Done,
                Favorite = updatedToDoItem.Favorite,
                Date = itemToBeUpdated.CreatedTime,
            };
            var result = await _ToDoItemsCollection.ReplaceOneAsync(x => x.Id == id, toDoItem);


        }*/
    }
}
