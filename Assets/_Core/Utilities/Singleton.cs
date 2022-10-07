using UnityEngine;

namespace Core.Utilities
{
    public class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        private static T instance = null;

        public static T Instance
        {
            get
            {
                if (instance != null)
                {
                    return instance;
                }
                else
                {
                    T[] managers = GameObject.FindObjectsOfType<T>();
                    if (managers != null)
                    {
                        if (managers.Length == 1)
                        {
                            instance = managers[0];
                            DontDestroyOnLoad(instance);
                            return instance;
                        }
                        else
                        {
                            if (managers.Length > 1)
                            {
                                for (int i = 0; i < managers.Length; ++i)
                                {
                                    T manager = managers[i];
                                    Destroy(manager.gameObject);
                                }
                            }
                        }
                    }

                    GameObject go = new GameObject(typeof(T).Name, typeof(T));
                    instance = go.GetComponent<T>();
                    DontDestroyOnLoad(instance.gameObject);
                    return instance;
                }
            }

            set
            {
                instance = value as T;
            }
        }

        protected void Awake()
        {
            if (instance == null)
            {
                DontDestroyOnLoad(gameObject);
                instance = this as T;
            }
            else
            {
                DestroyImmediate(this);
            }
        }
    }
}