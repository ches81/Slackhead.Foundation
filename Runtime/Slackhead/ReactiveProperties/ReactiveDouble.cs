using System;

namespace Slackhead.ReactiveProperties
{
  [Serializable]
  public class ReactiveDouble : ReactiveProperty<double>
  {
    public static ReactiveDouble operator +(ReactiveDouble left, ReactiveDouble right)
    {
      left.Value += right.Value;
      return left;
    }

    public static ReactiveDouble operator +(ReactiveDouble left, double right)
    {
      left.Value += right;
      return left;
    }

    public static ReactiveDouble operator -(ReactiveDouble left, ReactiveDouble right)
    {
      left.Value -= right.Value;
      return left;
    }

    public static ReactiveDouble operator -(ReactiveDouble left, double right)
    {
      left.Value -= right;
      return left;
    }

    public static ReactiveDouble operator *(ReactiveDouble left, ReactiveDouble right)
    {
      left.Value *= right.Value;
      return left;
    }

    public static ReactiveDouble operator *(ReactiveDouble left, double right)
    {
      left.Value *= right;
      return left;
    }
  }
}