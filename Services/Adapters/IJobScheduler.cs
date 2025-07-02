using System.Linq.Expressions;

namespace CapsulaDoTempo.Services.Adapters;

public interface IJobScheduler
{
  void Schedule<T>(Expression<Func<T, Task>> methodCall, DateTime executeAt);
}