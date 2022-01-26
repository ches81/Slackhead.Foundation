using System;
using UnityEngine;

namespace Slackhead.ReactiveProperties
{
  [Serializable]
  public class ReactiveProperty<T>
  {
    [SerializeField] private T value;

    public event Action<T> OnValueChanged;

    public T Value
    {
      get => value;
      set
      {
        this.value = value;
        OnValueChanged?.Invoke(this.value);
      }
    }

    public void Set(T @value)
    {
      Value = @value;
    }

    public override string ToString()
    {
      return value.ToString();
    }
  }
}