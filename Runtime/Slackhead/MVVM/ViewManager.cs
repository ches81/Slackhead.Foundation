using System.Collections.Generic;
using UnityEngine;

namespace Slackhead.MVVM
{
    public class ViewManager
    {
        private readonly Dictionary<string, GameObject> cachedViews = new Dictionary<string, GameObject>();


        public T Load<T>(string path) where T : MonoBehaviour
        {
            if (!cachedViews.TryGetValue(path, out var viewPrefab))
            {
                viewPrefab = Resources.Load<GameObject>(path);
            }

            return Object.Instantiate(viewPrefab).GetComponent<T>();
        }


        public void Dismiss(UIView view)
        {
            view.OnDispose();
            Object.Destroy(view.gameObject);
        }
    }
}