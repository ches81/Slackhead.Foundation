using System;
using System.Collections.Generic;

namespace Slackhead.Pooling
{
  public class Pool<T> : IDisposable, IPool<T> where T : IPoolable, IDisposable, new()
  {
    protected readonly List<T> AllocatedItems = new List<T>();
    protected readonly Stack<T> AvailableItems = new Stack<T>();

    protected int poolIncrementSize = 1;

    public int AllAllocatedItems => AllocatedItems.Count;
    public int AllAvailableItems => AvailableItems.Count;
    public int PoolSize => AllocatedItems.Count + AvailableItems.Count;

    public Pool()
    {
    }

    public Pool(int poolIncrementSize)
    {
      this.poolIncrementSize = poolIncrementSize;
    }

    public T Allocate()
    {
      if (AvailableItems.Count <= 0)
      {
        Expand(poolIncrementSize);
      }

      var item = AvailableItems.Pop();
      AllocatedItems.Add(item);
      item.Allocate();
      ItemAllocated(item);
      return item;
    }

    public virtual void Expand(int poolIncrementSize)
    {
      for (int i = 0; i < poolIncrementSize; i++)
      {
        var element = new T();
        AvailableItems.Push(element);
        element.Created();
      }
    }

    public void Release(T item)
    {
      if (AllocatedItems.Contains(item))
      {
        item.Release();
        AllocatedItems.Remove(item);
        AvailableItems.Push(item);
        ItemReleased(item);
      }
    }

    public void Shrink()
    {
      while (AvailableItems.Count > 0)
      {
        AvailableItems.Pop().Dispose();
      }
    }

    public void Dispose()
    {
      while (AllocatedItems.Count > 0)
      {
        Release(AllocatedItems[0]);
      }

      while (AvailableItems.Count > 0)
      {
        AvailableItems.Pop().Dispose();
      }
    }

    protected virtual void ItemAllocated(T item)
    {
      // Override to treat item after its been allocated in subclass.
    }

    protected virtual void ItemReleased(T item)
    {
      // Override to treat item after its been released in subclass.
    }
  }
}