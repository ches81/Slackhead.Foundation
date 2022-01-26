using System;
using JetBrains.Annotations;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using Object = UnityEngine.Object;

namespace Slackhead.Utils
{
    public class ApplicationLifecycle
    {
        [PublicAPI] public event Action<bool> OnApplicationPauseEvent;
        [PublicAPI] public event Action OnApplicationQuitEvent;
        [PublicAPI] public event Action<float> OnUpdate;
        [PublicAPI] public event Action<float> OnLateUpdate;


        public ApplicationLifecycle()
        {
            var gameObject = new GameObject("ApplicationLifecycle");
            gameObject.AddComponent<ApplicationLifecycleBehaviour>().SetApplicationLifeCycle(this);

            Object.DontDestroyOnLoad(gameObject);
        }


        private class ApplicationLifecycleBehaviour : MonoBehaviour
        {
            private ApplicationLifecycle applicationLifecycle;


            public void OnApplicationPause(bool pauseStatus)
            {
                applicationLifecycle.OnApplicationPauseEvent.Invoke(pauseStatus);
            }


            public void OnApplicationQuit()
            {
                applicationLifecycle.OnApplicationQuitEvent?.Invoke();
            }


            public void SetApplicationLifeCycle(ApplicationLifecycle applicationLifecycle)
            {
                this.applicationLifecycle = applicationLifecycle;
            }


            public void Update()
            {
                applicationLifecycle.OnUpdate?.Invoke(Time.deltaTime);
            }
            
            public void LateUpdate()
            {
                applicationLifecycle.OnLateUpdate?.Invoke(Time.deltaTime);
            }
        }

        public static void QuitApplication()
        {
            //If we are running in a standalone build of the game
#if UNITY_STANDALONE
            //Quit the application
            Application.Quit();
#endif

            //If we are running in the editor
#if UNITY_EDITOR
            //Stop playing the scene
            EditorApplication.isPlaying = false;
#endif
        }
    }
}