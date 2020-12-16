using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fabric : MonoBehaviour
{
    public SkinsController SkinsControllerPrefab;

    private static Fabric _instance;
    public static Fabric Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Fabric>();
                DontDestroyOnLoad(_instance);
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(_instance);
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }

    public static T CreateObjectInstance<T>(T prefab) where T : Component
    {
        GameObject go = Instantiate(prefab.gameObject);
        DontDestroyOnLoad(go);
        return go.GetComponent<T>();
    }
}
