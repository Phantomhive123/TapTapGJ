using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float PushScale = 1;
    [SerializeField]
    private float MoveScale = 1;
    private bool MovingToward = false;
    private bool InLight = false;
    private Transform LightOrigin = null;
    private Transform MovingTarget = null;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (InLight)
        {
            Vector3 direction = (transform.position - LightOrigin.position).normalized;
            transform.Translate(direction * Time.deltaTime * PushScale);
        }
        else if(MovingToward)
        {
            Vector3 direction = (MovingTarget.position - transform.position).normalized;
            transform.Translate(direction * Time.deltaTime * MoveScale);
        }

        if (!InLight && !MovingToward)
        {
            if (!CurrentAnimTheSame("Idle"))
                anim.Play(Animator.StringToHash("Idle"));
        }
        else if (InLight) 
        {
            if (!CurrentAnimTheSame("Push"))
                anim.Play(Animator.StringToHash("Push"));
        }
        else if(MovingToward)
        {
            if (!CurrentAnimTheSame("MoveToward"))
                anim.Play(Animator.StringToHash("MoveToward"));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Light"))
        {
            InLight = true;
            LightOrigin = collision.transform.parent.transform;
            return;
        }
        if(collision.gameObject.CompareTag("PlayerView"))
        {
            MovingToward = true;
            MovingTarget = collision.transform;
            return;
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            ScopeTrigger player = collision.GetComponentInParent<ScopeTrigger>();
            player.Shrink();
            anim.Play(Animator.StringToHash("Break"));
            enabled = false;//播放破碎动画
            return;
        }
        if (collision.gameObject.CompareTag("Sprite"))
        {
            Destroy(collision.gameObject);
            anim.Play(Animator.StringToHash("Break"));
            enabled = false;
            return;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Light")) 
        {
            LightOrigin = null;
            InLight = false;
        }
        else if(collision.gameObject.CompareTag("PlayerView"))
        {
            if (collision.gameObject != MovingTarget.gameObject) return;
            MovingTarget = null;
            MovingToward = false;
        }
    }

    private bool CurrentAnimTheSame(string name)
    {
        return anim.GetCurrentAnimatorClipInfo(0)[0].clip.name == name;
    }

    private void AnimDestroy()
    {
        Destroy(gameObject);
    }
}
