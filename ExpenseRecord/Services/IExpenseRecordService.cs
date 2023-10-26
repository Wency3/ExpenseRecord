using ExpenseRecord.Models;

namespace ExpenseRecord.Services
{
    public interface IExpenseRecordService
    {
        Task CreateAsync(ExpenseRecordDTO newExpenseRecord);
        Task<List<ExpenseRecordDTO>> GetAsync();
        Task<ExpenseRecordDTO?> GetAsync(string id);
        Task<bool> RemoveAsync(string id);
/*        Task ReplaceAsync(string id, ExpenseRecordDTO updatedToDoItem);*/
    }
}