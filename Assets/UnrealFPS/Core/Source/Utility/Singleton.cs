/* ================================================================
   ---------------------------------------------------
   Project   :    Unreal FPS
   Publisher :    XI
   Author    :    BINBIN
   ---------------------------------------------------
   ================================================================ */
using UnityEngine;

namespace UnrealFPS.Utility
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instace;
        private static object _lock= new object();
        private static bool applicationIsQuitting = false;

        public static T Instance
        {
            get
            {
                if (applicationIsQuitting)
                {
                    Debug.LogError("[Singleton] Instance "+typeof(T)+
                        "already destroyed on application quit. Wonot create again - retutning null.");
                    return null;
                }

                lock (_lock)
                {
                    if (instace == null)
                    {
                        instace = (T)FindObjectOfType(typeof(T));

                        if (FindObjectsOfType(typeof(T)).Length > 1)
                        {
                            Debug.LogError("[Singleton] Someting went really wrong - there should never be more than 1 singleton ! Reopening the scene might fix it .");
                            return instace;
                        }
                        if (instace == null)
                        {
                            GameObject singleton = new GameObject();
                            instace = singleton.AddComponent<T>();
                            singleton.name = "(Singleton)" + typeof(T).ToString();

                            DontDestroyOnLoad(singleton);
                        }
                    }
                    return instace;
                }
            }
        }

        public void OnDestroy()
        {
            applicationIsQuitting = true;
        }
    }
}