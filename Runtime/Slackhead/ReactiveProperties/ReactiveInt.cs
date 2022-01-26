using System;

namespace Slackhead.ReactiveProperties
{
  [Serializable]
  public class ReactiveInt : ReactiveProperty<int>
  {
    public static ReactiveInt operator +(ReactiveInt left, ReactiveInt right)
    {
      left.Value += right.Value;
      return left;
    }

    public static ReactiveInt operator +(ReactiveInt left, int right)
    {
      left.Value += right;
      return left;
    }

    public static ReactiveInt operator -(ReactiveInt left, ReactiveInt right)
    {
      left.Value -= right.Value;
      return left;
    }

    public static ReactiveInt operator -(ReactiveInt left, int right)
    {
      left.Value -= right;
      return left;
    }

    public static ReactiveInt operator *(ReactiveInt left, ReactiveInt right)
    {
      left.Value *= right.Value;
      return left;
    }

    public static ReactiveInt operator *(ReactiveInt left, int right)
    {
      left.Value *= right;
      return left;
    }
  }
}