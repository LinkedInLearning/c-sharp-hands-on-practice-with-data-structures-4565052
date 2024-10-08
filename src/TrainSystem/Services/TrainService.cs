using System.Collections.Generic;
using System.Linq;
using TrainSystem.Models;

namespace TrainSystem.Services
{
  public class TrainService
  {
    private Queue<Train> _trainQueue = new Queue<Train>();
    private List<Track> _tracks = new List<Track>() { new Track(1), new Track(2), new Track(3) };

    public IEnumerable<Track> GetAllTracks()
    {
      return _tracks;
    }

    public IEnumerable<Train> GetAllTrains()
    {
      return _trainQueue;
    }

    public Train GetNextTrain()
    {
      if (_trainQueue.Count > 0)
      {
        return _trainQueue.Peek();
      }
      return null;
    }

    public void ArriveTrain(Train train)
    {
      _trainQueue.Enqueue(train);
    }

    public void AssignNextTrainToTrack()
    {
      var nextTrain = GetNextTrain();
      if (nextTrain != null)
      {
        foreach (var track in _tracks)
        {
          if (track.currentTrain == null)
          {
            track.currentTrain = nextTrain;
            _trainQueue.Dequeue();
            return;
          }
        }
      }
    }

    public void DepartTrain(Track track)
    {
      track.currentTrain = null;
    }
  }
}