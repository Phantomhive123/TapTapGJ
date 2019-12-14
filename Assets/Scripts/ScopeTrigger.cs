using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScopeTrigger : MonoBehaviour
{
    [NonSerialized]
    public Vector3 scaleOfScope = Vector3.zero;
    [SerializeField]
    private Transform children = null;
    [SerializeField]
    private GameObject childPref = null;
    [SerializeField]
    private float increment = 2f;
    private CircleCollider2D collider = null;

    // Start is called before the first frame update
    void Start()
    {
        scaleOfScope = transform.localScale;
        collider = GetComponent<CircleCollider2D>();
    }

    private void UpdateScope()
    {
        transform.localScale = scaleOfScope;
    }

    public void Expand(Vector3 radius)
    {
        GameObject obj = Instantiate(childPref, children);
        Vector2 v = UnityEngine.Random.insideUnitCircle * (transform.localScale * collider.radius - radius);
        obj.transform.localPosition = v;
        Vector3 newScale = new Vector3(transform.localScale.x + increment, transform.localScale.y + increment, transform.localScale.z);
        transform.localScale = newScale;
    }

    public void Shrink()
    {
        if (children.childCount == 1) return;//死亡
        Destroy(children.GetChild(UnityEngine.Random.Range(0, children.childCount)).gameObject);
        Vector3 newScale = new Vector3(transform.localScale.x - increment, transform.localScale.y - increment, transform.localScale.z);
        transform.localScale = newScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Sprite"))
        {
            if (collision.gameObject.layer == gameObject.layer)
            {
                Expand(collision.transform.localScale * collision.GetComponent<CircleCollider2D>().radius);
                Destroy(collision.gameObject);//吸收
            }
        }
    }
}
