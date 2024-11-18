class Program
{
  static void Main()
  {
    Phonebook phonebook = new Phonebook();

    phonebook.AddContact("Alice", "555-1234");
    phonebook.AddContact("Bob", "555-5678");

    phonebook.DisplayAllContacts();

    Console.WriteLine(phonebook.GetPhoneNumber("Alice"));

    phonebook.UpdateContact("Bob", "555-8765");

    phonebook.RemoveContact("Alice");

    phonebook.DisplayAllContacts();
  }
}
