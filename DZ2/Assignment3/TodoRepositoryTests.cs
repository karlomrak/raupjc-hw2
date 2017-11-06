using System;
using System.Linq;
using Assignment2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment3
{
    [TestClass]
    public class TodoRepositoryTests
    {
        [TestMethod]
        public void TestAddGetRemove()
        {
            IGenericList<TodoItem> dataBase = new GenericList<TodoItem>();
            TodoItem task1 = new TodoItem("Do something!");
            TodoItem task2 = new TodoItem("Do something else!");
            dataBase.Add(task1);
            dataBase.Add(task2);
            TodoRepository rep = new TodoRepository(dataBase);
            Guid Id1 = task1.Id;
            
            Assert.AreEqual(task1, rep.Get(Id1));
            
            TodoItem task3 = new TodoItem("Do it!");
            Assert.AreEqual(task3, rep.Add(task3));
            
            Assert.IsTrue(rep.Remove(Id1));
            
         
        }
        
        [TestMethod]
        public void TestUpdate()
        {
            IGenericList<TodoItem> dataBase = new GenericList<TodoItem>();
            TodoItem task1 = new TodoItem("Do something!");
            TodoItem task2 = new TodoItem("Do something else!");
            dataBase.Add(task1);
            task2.Id = task1.Id;
            TodoRepository rep = new TodoRepository(dataBase);
            
            
            Assert.AreEqual(rep.Update(task2), task2);
            
            

        }
        
        [TestMethod]
        public void TestMarkAsCompleted()
        {
            IGenericList<TodoItem> dataBase = new GenericList<TodoItem>();
            TodoItem task1 = new TodoItem("Do something!");
            dataBase.Add(task1);
            TodoRepository rep = new TodoRepository(dataBase);

            Guid Id = task1.Id;
            
            Assert.IsTrue(rep.MarkAsCompleted(Id));
            

        }
        
        [TestMethod]
        public void TestGetAll()
        {
            IGenericList<TodoItem> dataBase = new GenericList<TodoItem>();
            TodoItem task1 = new TodoItem("Do something!");
            TodoItem task2 = new TodoItem("Do something else!");
            TodoItem task3 = new TodoItem("Do it!");
            dataBase.Add(task1);
            dataBase.Add(task2);
            dataBase.Add(task3);
            TodoRepository rep = new TodoRepository(dataBase);
            
            Assert.AreEqual(3, rep.GetAll().Count);
            

        }
        
        [TestMethod]
        public void TestGetActiveCompleted()
        {
            IGenericList<TodoItem> dataBase = new GenericList<TodoItem>();
            TodoItem task1 = new TodoItem("Do something!");
            TodoItem task2 = new TodoItem("Do something else!");
            TodoItem task3 = new TodoItem("Do it!");
            task1.MarkAsCompleted();
            task2.MarkAsCompleted();
            dataBase.Add(task1);
            dataBase.Add(task2);
            dataBase.Add(task3);
            TodoRepository rep = new TodoRepository(dataBase);
            
            Assert.AreEqual(1, rep.GetActive().Count);
            Assert.AreEqual(2, rep.GetCompleted().Count);
            

        }
        
        [TestMethod]
        public void TestFilter()
        {
            IGenericList<TodoItem> dataBase = new GenericList<TodoItem>();
            TodoItem task1 = new TodoItem("A");
            TodoItem task2 = new TodoItem("B");
            TodoItem task3 = new TodoItem("A");
            task1.MarkAsCompleted();
            task2.MarkAsCompleted();
            dataBase.Add(task1);
            dataBase.Add(task2);
            dataBase.Add(task3);
            TodoRepository rep = new TodoRepository(dataBase);
            
            Assert.AreEqual(0, rep.GetFiltered(s=>s.Text.Equals("D")).Count);
            

        }
        
    }
}