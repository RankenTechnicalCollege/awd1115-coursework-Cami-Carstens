

Dictionary<string, string> users = new Dictionary<string, string>()
{
    {"Cynthia", "314-236-5589"},
    {"John", "636-669-9874"},
    {"Jane", "618-407-5110"},
    {"Abib", "618-530-7899"},
    {"Kali", "314-555-1234" },
    {"Jamal", "217-555-5678"},
    {"Michael", "312-555-8765"},
    {"Sarah", "773-555-4321"},
    {"DeAndre", "847-555-6789"},
    {"Laura", "314-555-3456"}
};

while (true)
{
    Console.WriteLine("\nUser Directory Menu:");
    Console.WriteLine("1. Add Contact");
    Console.WriteLine("2. View Contact");
    Console.WriteLine("3. Update Contact");
    Console.WriteLine("4. Delete Contact");
    Console.WriteLine("5. List All Contacts");
    Console.WriteLine("6. Exit");
    Console.Write("Enter your choice: ");
    string numChoice = Console.ReadLine();


    switch (numChoice)
    {

     //add contact
        case "1":
            Console.WriteLine("Enter Name");
            string addNewName = Console.ReadLine();

            if (users.ContainsKey(addNewName))
            {
                Console.WriteLine("Name already exist in Dictionary Menu");

            }
            else
            {
                Console.WriteLine("Please enter a phone number:");
                string inputPhone = Console.ReadLine();
                users.Add(addNewName, inputPhone);
                Console.WriteLine($"{addNewName} was added successfully.");
            }
            break;


     //View contact
        case "2":
            Console.WriteLine("Enter the users name you would like to view.");
            string name = Console.ReadLine();

            if (users.TryGetValue(name, out string phone))
            {
                Console.WriteLine($"The phone number for {name} is {phone}");
            }
            else
            {
                Console.WriteLine($"Sorry, {name} is not in the directory.");
            }
            break;


      //Update contact
        case "3":
            Console.WriteLine("Enter the users name you would like to update");
            string updateName = Console.ReadLine();
            if (users.ContainsKey(updateName))
            {
                Console.WriteLine("Enter new phone number to update");
                string phoneUpdate = Console.ReadLine();
                users[updateName] = phoneUpdate;
                Console.WriteLine($"{updateName}'s phone number was updated successfully.");
            }
            else
            {
                Console.WriteLine($"Sorry {updateName} is not in the directory.");
            }
            break;


        //Delete contact
        case "4":
            Console.WriteLine("Enter the users name you would like to delete");
            string deleteName = Console.ReadLine();
            if (users.ContainsKey(deleteName))
            {
                users.Remove(deleteName);
                Console.WriteLine($"{deleteName} was deleted successfully.");
            }
            else
            {
                Console.WriteLine($"Sorry {deleteName} is not in the directory.");
            }
            break;


        //List all contacts
        case "5":
            Console.WriteLine("User Directory:");
            foreach (var user in users)
            {
                Console.WriteLine($"Name: {user.Key}, Phone Number: {user.Value}");
            }
            break;

        //Exit
        case "6":
            Console.WriteLine("Exiting the program. Goodbye!");
            return;

        default:
            Console.WriteLine("Invalid entry. Please try again.");
            break;

    }
}












