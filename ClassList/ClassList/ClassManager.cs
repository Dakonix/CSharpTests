using ClassList.Models;

namespace ClassList
{
    public class ClassManager
    {
        public IList<Group> classes;
        public ClassManager() 
        {
            classes = new List<Group>();
        }

        public bool AddNewGroup(Group group)
        {
            var groupExist = classes.FirstOrDefault(x => x.Id == group.Id 
                || x.Name == group.Name);
            if (groupExist == null)
            {
                classes.Add(group);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddNewUserToClass(User user, int classId)
        {
            var group = classes.FirstOrDefault(x => x.Id == classId);

            if(group is null)
            {
                throw new NullReferenceException();
            }

            group.Users.Add(user);
            return true;
        }

        public User GetUserById (int id)
        {
            User result = null;
            foreach(var group in classes)
            {
                result = group.Users.FirstOrDefault(x => x.Id == id);
                if (result != null)
                    break;
            }
            return result;         
        }

        public void RemoveUserById (int id)
        {
            foreach (var group in classes)
            {
                var user = group.Users.FirstOrDefault(x => x.Id == id);
                if (user != null)
                {
                    group.Users.Remove(user);
                    break;
                }
            }
        }

        public User CreateUser (int id, string firstName, string lastName) 
        {
            if(string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            {
                throw new ArgumentNullException();
            }

            User findUser = default;
            foreach (var group in classes)
            {
                findUser = group.Users.FirstOrDefault(x => x.Id == id);
                if (findUser != null)
                    break;
            }
            if(findUser != null)
            {
                throw new Exception();
            }

            var user = new User()
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
            };

            return user;
        }
        public User EditUserById(int id, string firstName, string lastName)
        {
            User user = GetUserById(id);
            if (user == null)
                throw new NullReferenceException();
            
            user.FirstName = firstName;
            user.LastName = lastName;

            return user;
        }

    }
}
