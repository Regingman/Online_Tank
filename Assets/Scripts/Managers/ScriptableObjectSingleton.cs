using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ScriptableObjectSingleton<T> : ScriptableObject where T : ScriptableObject
{
    private static T _instance = null;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                T[] results = Resources.FindObjectsOfTypeAll<T>();
                string error = typeof(T).ToString();
                if (results.Length == 0)
                {

                    Debug.LogError("SingletonScriptebleObject -> Instance -> results length is 0 for type " + error + ".");
                    return null;
                }
                if (results.Length > 1)
                {
                    Debug.LogError("SingletonScriptebleObject -> Instance -> results length is 1 for type " + error + ".");
                }
                _instance = results[0];
            }
            return _instance;
        }
    }
}
