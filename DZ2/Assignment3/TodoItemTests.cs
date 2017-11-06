using Assignment2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment3
{
    [TestClass]
    public class TodoItemTests
    {
        [TestMethod]
        public void TestingEquals()
        {
            TodoItem task1 = new TodoItem("Do something!");
            TodoItem task2 = new TodoItem("Do something else!");
            Assert.IsFalse(task1.Equals(task2));
        }
        
        [TestMethod]
        public void TestingMarkAsCompleted()
        {
            TodoItem task = new TodoItem("Do something!");
            
            Assert.IsTrue(task.MarkAsCompleted());
            Assert.IsFalse(task.MarkAsCompleted());
        }
        
        [TestMethod]
        public void TestingGetHashCode()
        {
            TodoItem task1 = new TodoItem("Do something!");
            TodoItem task2 = new TodoItem("Do something!");
            task1.Id = task2.Id;
            
            Assert.AreEqual(task1.GetHashCode(), task2.GetHashCode());
        }
        
    }
}