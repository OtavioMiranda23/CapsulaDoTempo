using System.Linq.Expressions;
using Hangfire;

namespace CapsulaDoTempo.Services.Adapters;

public class HangfireScheduler : IJobScheduler
{
  public void Schedule<T>(Expression<Func<T, Task>> methodCall, DateTime executeAt)
  {
    BackgroundJob.Schedule<T>(methodCall, new DateTimeOffset(executeAt));
  }
}