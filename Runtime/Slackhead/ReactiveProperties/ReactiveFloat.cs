using System;

namespace Slackhead.ReactiveProperties
{
  [Serializable]
  public class ReactiveFloat : ReactiveProperty<float>
  {
    public static ReactiveFloat operator +(ReactiveFloat left, ReactiveFloat right)
    {
      left.Value += right.Value;
      return left;
    }

    public static ReactiveFloat operator +(ReactiveFloat left, float right)
    {
      left.Value += right;
      return left;
    }

    public static ReactiveFloat operator -(ReactiveFloat left, ReactiveFloat right)
    {
      left.Value -= right.Value;
      return left;
    }

    public static ReactiveFloat operator -(ReactiveFloat left, float right)
    {
      left.Value -= right;
      return left;
    }

    public static ReactiveFloat operator *(ReactiveFloat left, ReactiveFloat right)
    {
      left.Value *= right.Value;
      return left;
    }

    public static ReactiveFloat operator *(ReactiveFloat left, float right)
    {
      left.Value *= right;
      return left;
    }
  }
}