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

    private void Update()
    {
        if (InLight)
        {
            Vector3 direction = (transform.position - LightOrigin.position).normalized;
            transform.Translate(direction * Time.deltaTime * PushScale);
            return;
        }

        if(MovingToward)
        {
            Vector3 direction = (MovingTarget.position - transform.position).normalized;
            transform.Translate(direction * Time.deltaTime * MoveScale);
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
            Destroy(gameObject);
            return;
        }
        if (collision.gameObject.CompareTag("Sprite"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            return;
        }
    }

    /*
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Light"))
        {
            Transform otherTrans = other.transform.parent.transform;
            Vector3 direction = (transform.position - otherTrans.position).normalized;
            //Vector3 direction = (otherTrans.localPosition - transform.localPosition).normalized;
            transform.Translate(direction * Time.deltaTime * SpeedScale);     
        }
    }*/
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Light")) 
        {
            LightOrigin = null;
            InLight = false;
            return;
        }
        if(collision.gameObject.CompareTag("PlayerView"))
        {
            if (collision.gameObject != MovingTarget.gameObject) return;
            MovingTarget = null;
            MovingToward = false;
            return;
        }
    }
}
