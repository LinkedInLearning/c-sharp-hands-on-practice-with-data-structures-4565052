namespace TrainSystem.Models
{
  public class Track
  {
    public int Id { get; set; }
    public Train currentTrain { get; set; }

    public Track(int id)
    {
      Id = id;
    }
  }
}