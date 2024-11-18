using System;
using System.Collections.Generic;

public class Phonebook
{
  private Dictionary<string, string> _contacts = new Dictionary<string, string>();

  public void AddContact(string name, string phoneNumber)
  {
    if (!_contacts.ContainsKey(name))
    {
      _contacts.Add(name, phoneNumber);
    }
  }

  public string GetPhoneNumber(string name)
  {
    return _contacts.TryGetValue(name, out string phoneNumber) ? phoneNumber : null;
  }

  public void UpdateContact(string name, string newPhoneNumber)
  {
    if (_contacts.ContainsKey(name))
    {
      _contacts[name] = newPhoneNumber;
    }
  }

  public void RemoveContact(string name)
  {
    _contacts.Remove(name);
  }

  public void DisplayAllContacts()
  {
    foreach (var contact in _contacts)
    {
      Console.WriteLine($"{contact.Key}: {contact.Value}");
    }

    // var allNames = _contact.Keys;
    // var allPhoneNumbers = _contact.Values;
  }
}