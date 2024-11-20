using System.Collections.Generic;
public class ApiRateLimiter
{
  private readonly int _requestLimit;
  private readonly TimeSpan _timeWindow;
  private readonly Dictionary<string, Queue<DateTime>> _userRequests = new();

  public ApiRateLimiter(int requestLimit, TimeSpan timeWindow)
  {
    _requestLimit = requestLimit;
    _timeWindow = timeWindow;
  }

  public bool IsRequestAllowed(string userId)
  {
    if (!_userRequests.ContainsKey(userId)) {
      _userRequests[userId] = new Queue<DateTime>();
    }
    var now = DateTime.UtcNow;
    var requestTimestamps = _userRequests[userId];
    while (requestTimestamps.Count > 0 && 
      now - requestTimestamps.Peek() > _timeWindow) {
        requestTimestamps.Dequeue();
    }
    if (requestTimestamps.Count >= _requestLimit) {
      return false;
    }
    requestTimestamps.Enqueue(now);
    return true;
  }
}