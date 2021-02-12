using NUnit.Framework;
using ToDoS.ViewModels;

namespace ToDoS.Test
{
    public class ViewModelTest
    {
        TodoListViewModel todolistViewModel;
        [SetUp]
        public void Setup()
        {
            todolistViewModel = new TodoListViewModel();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}