using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance
    {
        get { return instance; }
    }

    public Transform listener;
    public AudioClip patching;
    public AudioClip attack;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;
        else
            DestroyImmediate(gameObject);
    }

    public void PlayPatchingSound()
    {
        AudioSource.PlayClipAtPoint(patching, listener.transform.position);
    }
    public void PlayAttachSound()
    {
        AudioSource.PlayClipAtPoint(attack, listener.transform.position);
    }
}
