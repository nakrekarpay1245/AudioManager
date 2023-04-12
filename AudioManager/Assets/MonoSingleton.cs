using UnityEngine;

public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
    private static T singleton;

    public static T Singleton
    {
        get
        {
            if (singleton == null)
            {
                singleton = FindObjectOfType<T>();
                if (singleton == null)
                {
                    GameObject singletonObject = new GameObject();
                    singleton = singletonObject.AddComponent<T>();
                    singletonObject.name = typeof(T).ToString() + " (Singleton)";
                    DontDestroyOnLoad(singletonObject);
                }
            }
            return singleton;
        }
    }

    protected virtual void OnEnable()
    {
        //Debug.Log("Base awake");

        if (singleton == null)
        {
            singleton = (T)this;
            DontDestroyOnLoad(gameObject);
        }
        else if (singleton != this)
        {
            Destroy(gameObject);
        }
    }

    protected virtual void OnDestroy()
    {
        if (singleton == this)
        {
            singleton = null;
        }
    }
}
