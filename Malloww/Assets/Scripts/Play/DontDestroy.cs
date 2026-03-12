using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    static DontDestroy instance;

    void Awake()
    {
        Debug.Log("DontDestroy Awake");
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}