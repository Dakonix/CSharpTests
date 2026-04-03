using AutoFixture;
using ClassList.Models;
using System.Xml.XPath;

namespace TestProject1
{
    public class Tests
    {
        Fixture fixture;

        [SetUp]
        public void Setup()
        {
            fixture = new Fixture();
        }

        [Test]
        public void AddNewGroup_ShouldReturnTrue()
        {
            ClassList.ClassManager classManager = new ClassList.ClassManager();
            Group g = fixture.Create<Group>();
            bool result = classManager.AddNewGroup(g);
            Assert.IsTrue(result);
        }
        [Test]
        public void AddNewGroup_ShouldReturnFalse()
        {
            ClassList.ClassManager classManager = new ClassList.ClassManager();
            Group g = fixture.Create<Group>();
            classManager.AddNewGroup(g);
            Group g2 = g;
            bool result = classManager.AddNewGroup(g2);
            Assert.IsFalse(result);
        }
        [Test]
        public void AddNewUserToClass_ShouldReturnTrue()
        {
            ClassList.ClassManager classManager = new ClassList.ClassManager();
            Group g = fixture.Create<Group>();
            classManager.AddNewGroup(g);
            User u = fixture.Create<User>();
            bool result = classManager.AddNewUserToClass(u, g.Id);
            Assert.IsTrue(result);
        }
        [Test]
        public void AddNewUserToClass_ShouldReturnNullRefEx()
        {
            ClassList.ClassManager classManager = new ClassList.ClassManager();
            Group g = fixture.Create<Group>();
            classManager.AddNewGroup(g);
            User u = fixture.Create<User>();
            Assert.Throws<NullReferenceException>(() => classManager.AddNewUserToClass(u, g.Id + 1));
        }
        [Test]
        public void GetUserById_ShouldReturnUser()
        {
            ClassList.ClassManager classManager = new ClassList.ClassManager();
            Group g = fixture.Create<Group>();
            classManager.AddNewGroup(g);
            User u = fixture.Create<User>();
            classManager.AddNewUserToClass(u, g.Id);
            User result = classManager.GetUserById(u.Id);
            Assert.AreSame(u, result);
        }
        [Test]
        public void GetUserById_ShouldReturnNull()
        {
            ClassList.ClassManager classManager = new ClassList.ClassManager();
            Group g = fixture.Create<Group>();
            classManager.AddNewGroup(g);
            User u = fixture.Create<User>();
            classManager.AddNewUserToClass(u, g.Id);
            User result = classManager.GetUserById(u.Id + 1);
            Assert.IsNull(result);
        }
        [Test]
        public void CreateUser_ShouldReturnUser()
        {
            ClassList.ClassManager classManager = new ClassList.ClassManager();
            Group g = fixture.Create<Group>();
            classManager.AddNewGroup(g);
            User u = fixture.Create<User>();
            User result = classManager.CreateUser(u.Id, u.FirstName, u.LastName);
            Assert.AreEqual(u.Id, result.Id);
            Assert.AreEqual(u.FirstName, result.FirstName);
            Assert.AreEqual(u.LastName, result.LastName);
        }
        [Test]
        public void CreateUser_ShouldReturnArgNullEx()
        {
            ClassList.ClassManager classManager = new ClassList.ClassManager();
            Group g = fixture.Create<Group>();
            classManager.AddNewGroup(g);
            User u = fixture.Create<User>();
            u.FirstName = null;
            Assert.Throws<ArgumentNullException> (() => classManager.CreateUser(u.Id, u.FirstName, u.LastName));
        }
        [Test]
        public void CreateUser_ShouldReturnEx()
        {
            ClassList.ClassManager classManager = new ClassList.ClassManager();
            Group g = fixture.Create<Group>();
            classManager.AddNewGroup(g);
            User u = fixture.Create<User>();
            classManager.AddNewUserToClass(u, g.Id);
            Assert.Throws<Exception>(() => classManager.CreateUser(u.Id, u.FirstName, u.LastName));
        }
        [Test]
        public void RemoveUserById_UserShouldBeRemoved()
        {
            ClassList.ClassManager classManager = new ClassList.ClassManager();
            Group g = fixture.Create<Group>();
            classManager.AddNewGroup(g);
            User u = fixture.Create<User>();
            classManager.AddNewUserToClass(u, g.Id);
            classManager.RemoveUserById(u.Id);
            User result = classManager.GetUserById(u.Id);
            Assert.IsNull(result);
        }
        [Test]
        public void EditUserById_ShouldReturnUser()
        {
            ClassList.ClassManager classManager = new ClassList.ClassManager();
            Group g = fixture.Create<Group>();
            classManager.AddNewGroup(g);
            User u = fixture.Create<User>();
            classManager.AddNewUserToClass(u, g.Id);
            string firstName = fixture.Create<string>();
            string lastName = fixture.Create<string>();
            User result = classManager.EditUserById(u.Id, firstName, lastName);
            Assert.AreEqual(u.Id, result.Id);
            Assert.AreEqual(firstName, result.FirstName);
            Assert.AreEqual(lastName, result.LastName);
        }
        [Test]
        public void EditUserById_ShouldReturnNullRefEx()
        {
            ClassList.ClassManager classManager = new ClassList.ClassManager();
            Group g = fixture.Create<Group>();
            classManager.AddNewGroup(g);
            User u = fixture.Create<User>();
            classManager.AddNewUserToClass(u, g.Id);
            string firstName = fixture.Create<string>();
            string lastName = fixture.Create<string>();
            Assert.Throws<NullReferenceException>(() => classManager.EditUserById(u.Id + 1, firstName, lastName));
        }
    }
}