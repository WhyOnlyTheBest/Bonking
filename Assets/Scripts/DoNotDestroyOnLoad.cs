using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class DoNotDestroyOnLoad : MonoBehaviour
{
    //Static Class for save the current player data;
    //Singleton pattern
    public static DoNotDestroyOnLoad Instance;

    public string PlayerName;

    public int Score;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

}
