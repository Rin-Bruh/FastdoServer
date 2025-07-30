using System.Diagnostics;

namespace FastdoServer.Infrastructure.Helpers
{
  public class MongoQueryInterceptor
  {

    public async Task<T> ExecuteWithTiming<T>(Func<Task<T>> query, string queryName)
    {
      var stopwatch = Stopwatch.StartNew();

      try
      {
        var result = await query();
        stopwatch.Stop();
        Console.WriteLine($"[{queryName}] Query time: {stopwatch.ElapsedMilliseconds} ms");
        return result;
      }
      catch (Exception ex)
      {
        stopwatch.Stop();
        Console.WriteLine($"[{queryName}] Query failed after {stopwatch.ElapsedMilliseconds} ms: {ex.Message}");
        throw;
      }
    }

  }
}
