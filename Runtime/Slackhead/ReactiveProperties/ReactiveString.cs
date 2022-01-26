using System;

namespace Slackhead.ReactiveProperties
{
  [Serializable]
  public class ReactiveString : ReactiveProperty<string>
  {
    public static ReactiveString operator +(ReactiveString left, ReactiveString right)
    {
      left.Value += right.Value;
      return left;
    }

    public static ReactiveString operator +(ReactiveString left, string right)
    {
      left.Value += right;
      return left;
    }
  }
}