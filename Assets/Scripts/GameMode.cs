using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour
{
    public bool isBattle = true;

    private static GameMode instance;
    public static GameMode Insatance
    {
        get { return instance; }
    }

    private void Start()
    {
        if (instance == null)
            instance = this;
        else
            DestroyImmediate(gameObject);
    }
}
