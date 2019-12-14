using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float SpeedScale = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if (collision.gameObject.CompareTag("Player"))
        {
            ScopeTrigger player = collision.GetComponentInParent<ScopeTrigger>();
            player.Shrink();
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Sprite"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Light"))
        {
            ScopeTrigger player = other.GetComponentInParent<ScopeTrigger>();
            if (player) 
            {
                Vector3 direction = (transform.position - player.transform.position).normalized;
                transform.Translate(direction * Time.deltaTime * SpeedScale);
            }          
        }
    }
}
