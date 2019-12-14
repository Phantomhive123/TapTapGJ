using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteTrigger : MonoBehaviour
{
    [SerializeField]
    private bool mainPlayer = true;
    private CircleCollider2D collider = null;

    private void Start()
    {
        collider = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if (collision.transform.parent.CompareTag("Player1") && mainPlayer) 
            {
                collision.GetComponent<ScopeTrigger>().Expand(transform.localScale * collider.radius);
                Destroy(gameObject);
            }
            else if(collision.transform.parent.CompareTag("Player2") && !mainPlayer)
            {
                collision.GetComponent<ScopeTrigger>().Expand(transform.localScale * collider.radius);
                Destroy(gameObject);
            }
        }
    }
}
