public class ApiRateLimiter
{
  private readonly int _requestLimit;
  private readonly TimeSpan _timeWindow;
  private readonly Dictionary<string, Queue<DateTime>> _userRequests;

  public ApiRateLimiter(int requestLimit, TimeSpan timeWindow)
  {
    _requestLimit = requestLimit;
    _timeWindow = timeWindow;
    _userRequests = new Dictionary<string, Queue<DateTime>>();
  }

  public bool IsRequestAllowed(string userId)
  {
    if (!_userRequests.ContainsKey(userId))
    {
      _userRequests[userId] = new Queue<DateTime>();
    }

    var now = DateTime.UtcNow;
    var requestTimestamps = _userRequests[userId];

    // Remove timestamps older than the sliding window (1 minute)
    while (requestTimestamps.Count > 0 && now - requestTimestamps.Peek() > _timeWindow)
    {
      requestTimestamps.Dequeue();
    }

    // Check if the user has exceeded the limit
    if (requestTimestamps.Count >= _requestLimit)
    {
      return false; // Limit exceeded
    }

    // Record the new request
    requestTimestamps.Enqueue(now);
    return true;
  }
}