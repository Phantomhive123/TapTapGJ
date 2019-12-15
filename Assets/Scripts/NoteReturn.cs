using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteReturn : MonoBehaviour
{
    public SceneLoader sceneLoader;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            sceneLoader.LoadSceneDirectly(0);
        }
    }
}
