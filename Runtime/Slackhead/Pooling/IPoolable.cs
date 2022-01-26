namespace Slackhead.Pooling
{
  public interface IPoolable
  {
    void Created();
    void Allocate();
    void Release();
  }
}