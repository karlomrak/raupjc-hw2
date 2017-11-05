using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment2
{
    public class TodoRepository:ITodoRepository

    {
        /// <summary >
        /// Repository does not fetch todoItems from the actual database ,
        /// it uses in memory storage for this excersise .
        /// </ summary >
        private readonly IGenericList<TodoItem> _inMemoryTodoDatabase;
        public TodoRepository(IGenericList<TodoItem> initialDbState = null)
        {
            _inMemoryTodoDatabase = initialDbState ?? new GenericList<TodoItem>();
        }

        public TodoItem Get(Guid todoId)
        {
            return _inMemoryTodoDatabase.Where(s => s.Id == todoId).FirstOrDefault();
        }

        public TodoItem Add(TodoItem todoItem)
        {
            if (_inMemoryTodoDatabase.Where(s => s.Equals(todoItem)).FirstOrDefault() == null)
            {
                _inMemoryTodoDatabase.Add(todoItem);
                return todoItem;
            }
            else throw new DuplicateTodoItemException("Duplicate ID:" + todoItem.Id);
        }

        public bool Remove(Guid todoId)
        {
            TodoItem remove = Get(todoId);
            if (remove != null)
            {
                return _inMemoryTodoDatabase.Remove(remove);
            }
            else return false;

        }

        public TodoItem Update(TodoItem todoItem)
        {
            if (_inMemoryTodoDatabase.FirstOrDefault(s => s.Equals(todoItem)) != null)
            {
                Remove(todoItem.Id);
                return Add(todoItem);
            }
            else
            {
                return Add(todoItem);
            }
        }

        public bool MarkAsCompleted(Guid todoId)
        {
            TodoItem item = Get(todoId);
            if (item != null)
            {
                bool ret = item.MarkAsCompleted();
                Update(item);
                return ret;

            }
            else
            {
                return false;
            }
        }

        public List<TodoItem> GetAll()
        {
            return _inMemoryTodoDatabase.OrderByDescending(s => s.DateCreated).ToList();
            
        }

        public List<TodoItem> GetActive()
        {
            return _inMemoryTodoDatabase.Where(s=>!s.IsCompleted).ToList();
           
        }

        public List<TodoItem> GetCompleted()
        {
            var comp = _inMemoryTodoDatabase.Where(s => s.IsCompleted);
            return comp as List<TodoItem>;
        }

        public List<TodoItem> GetFiltered(Func<TodoItem, bool> filterFunction)
        {
            return _inMemoryTodoDatabase.Where(filterFunction).ToList();
        }
    }

    public class DuplicateTodoItemException : Exception
    {
        public DuplicateTodoItemException(string s) : base(s)
        
        {
        }
    }
}