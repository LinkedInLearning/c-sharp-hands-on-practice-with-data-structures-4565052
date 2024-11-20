public class ApiRateLimiter
{
  private readonly int _requestLimit;
  private readonly TimeSpan _timeWindow;

  public ApiRateLimiter(int requestLimit, TimeSpan timeWindow)
  {
    _requestLimit = requestLimit;
    _timeWindow = timeWindow;
  }

  public bool IsRequestAllowed(string userId)
  {
    return true;
  }
}