using UnityEngine;

namespace Slackhead.Utils
{
  public class SlackConsole
  {
    public static void Log(object obj, Color color)
    {
      string hexColor = ColorUtility.ToHtmlStringRGB(color);
      Debug.LogFormat("<color=#{1}>{0}</color>", obj, hexColor);
    }

    public static void Log(object obj)
    {
      string hexColor = ColorUtility.ToHtmlStringRGB(Color.white);
      Debug.LogFormat("<color=#{1}>{0}</color>", obj, hexColor);
    }
  }
}