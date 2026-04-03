// See https://aka.ms/new-console-template for more information
using ClassList;
using ClassList.Models;

Console.WriteLine("Hello, World!");

var classManager = new ClassManager();
string idString = string.Empty;
string name = string.Empty;
string firstName = string.Empty;
string lastName = string.Empty;
bool idParsed;
int groupId = default;
int userId = default;

while (true)
{
    Console.WriteLine("Wybierz operacje");
    Console.WriteLine("1: Dodaj klase");
    Console.WriteLine("2: Dodaj ucznia do klasy");
    Console.WriteLine("3: Wyszukaj ucznia po id");
    Console.WriteLine("4: Usun ucznia");
    Console.WriteLine("5: Stwórz ucznia");
    var readNumber = Console.ReadLine();
    var numberParsed = int.TryParse(readNumber, out var number);
    if(numberParsed)
    switch(number)
    {
        case 1:
                Console.WriteLine("Podaj id klasy (int)");
                idString = Console.ReadLine();
                idParsed = int.TryParse(idString, out groupId);
                if(!idParsed)
                {
                    Console.WriteLine("Id musi byc typu int!!!");
                    break;
                }
                Console.WriteLine("Podaj nazwe klasy");
                name = Console.ReadLine();
                var group = new Group()
                {
                    Id = groupId,
                    Name = name,
                    Users = new List<User>()
                };
                var result = classManager.AddNewGroup(group);
                if (result)
                {
                    Console.WriteLine("Dodano");
                }
                else
                {
                    Console.WriteLine("Nie dodano");
                }
                break;
        case 2: 
                Console.WriteLine("Podaj id ucznia (int)");
                idString = Console.ReadLine();
                idParsed = int.TryParse(idString, out userId);
                if(!idParsed)
                {
                    Console.WriteLine("Id musi byc typu int!!!");
                    break;
                }
                Console.WriteLine("Podaj imie ucznia");
                firstName = Console.ReadLine();
                Console.WriteLine("Podaj nazwisko ucznia");
                lastName = Console.ReadLine();
                
                Console.WriteLine("Podaj id klasy (int)");
                idString = Console.ReadLine();
                idParsed = int.TryParse(idString, out groupId);
                if (!idParsed)
                {
                    Console.WriteLine("Id musi byc typu int!!!");
                    break;
                }
                
                var user = classManager.CreateUser(userId, firstName, lastName);
                try
                {
                    classManager.AddNewUserToClass(user, groupId);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                break;

        case 3:
                Console.WriteLine("Podaj id usera do wyszukania (int)");
                idString = Console.ReadLine();
                idParsed = int.TryParse(idString, out userId);
                if (!idParsed)
                {
                    Console.WriteLine("Id musi byc typu int!!!");
                    break;
                }
                var userResult = classManager.GetUserById(userId);
                Console.WriteLine($"User id: {userResult.Id} User name: {userResult.FirstName} {userResult.LastName}");
                break;

        case 4:
                Console.WriteLine("Podaj id usera do wyszukania (int)");
                idString = Console.ReadLine();
                idParsed = int.TryParse(idString, out userId);
                if (!idParsed)
                {
                    Console.WriteLine("Id musi byc typu int!!!");
                    break;
                }
                classManager.RemoveUserById(userId);
                Console.WriteLine($"Usunieto!");
                break; 
            
        default:
                break;
    }
}