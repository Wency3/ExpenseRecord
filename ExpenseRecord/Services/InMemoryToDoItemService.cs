﻿/*using ExpenseRecordDTO.Models;

namespace ExpenseRecordDTO.Services
{
    public class InMemoryToDoItemService : IToDoItemService
    {
        private static readonly List<ExpenseRecordDTO> _toDoItems = new();
        public Task CreateAsync(ToDoItemDto newToDoItem)
        {
            _toDoItems.Add(newToDoItem);
            return Task.CompletedTask;
        }
        public Task<List<ToDoItemDto>> GetAsync()
        {
            return Task.FromResult(_toDoItems);
        }

        public Task<ToDoItemDto?> GetAsync(string id)
        {
            return Task.FromResult(_toDoItems.Find(x => x.Id == id));
        }
        public Task<bool> RemoveAsync(string id)
        {
            var itemToBeRemoved = _toDoItems.Find(x => x.Id == id);
            if (itemToBeRemoved is null)
            {
                return Task.FromResult(false);
            }
            _toDoItems.Remove(itemToBeRemoved);
            return Task.FromResult(true);
        }
        public Task ReplaceAsync(string id, ToDoItemDto updatedToDoItem)
        {
            var index = _toDoItems.FindIndex(x => x.Id == id);
            if (index >= 0)
            {
                updatedToDoItem.CreatedTime = _toDoItems[index].CreatedTime;
                _toDoItems[index] = updatedToDoItem;
            }
            return Task.CompletedTask;
        }
    }
}
*/