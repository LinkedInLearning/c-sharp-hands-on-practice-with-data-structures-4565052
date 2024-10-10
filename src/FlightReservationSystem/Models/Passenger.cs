namespace FlightReservationSystem.Models
{
  public class Passenger
  {
    public string Name { get; }
    public string Email { get; }

    public Passenger(string name, string email)
    {
      Name = name;
      Email = email;
    }
  }
}