using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimController : MonoBehaviour
{
    private Animator anim;
    private Animator childAnim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        childAnim = GetComponentInChildren<Animator>();
    }

    public void PlayDestroyAnim()
    {
        anim.Play(Animator.StringToHash("Break"));
        childAnim.Play(Animator.StringToHash("Break"));
    }

    private void AnimDestroy()
    {
        Destroy(gameObject);
    }
}
