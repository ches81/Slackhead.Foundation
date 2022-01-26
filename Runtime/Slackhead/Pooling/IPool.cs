using System;

namespace Slackhead.Pooling
{
  public interface IPool<T> where T : IPoolable, IDisposable
  {
    T Allocate();
    void Release(T item);
    void Expand(int poolIncrementSize);
  }
}