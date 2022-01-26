using System;
using System.Reflection;
using UnityEngine;

namespace Slackhead.Utils
{
    public class Singleton<T> where T : Singleton<T>
    {
        private static T instance;

        public static T Instance
        {
            get
            {
                try
                {
                    if (null == instance)
                    {
                        var constructorInfo = typeof(T).GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[0], null);

                        if (null != constructorInfo)
                        {
                            instance = (T) constructorInfo.Invoke(null);
                        }
                        else
                        {
                            Debug.LogErrorFormat("The singleton class<{0}> has no private or protected constructor. Instantiation failed!", typeof(T).Name);
                        }
                    }

                    return instance;
                }
                catch (Exception e)
                {
                    Debug.LogErrorFormat("游戏内部错误。单例 Singleton<{0}> 创建失败：{1}", typeof(T).Name, e);
                    return null;
                }
            }
        }
    }
}