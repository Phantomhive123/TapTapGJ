using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScopeTrigger : MonoBehaviour
{
    [NonSerialized]
    public Vector3 ScaleOfScope = Vector3.zero;
    [SerializeField]
    private Transform Children = null;
    [SerializeField]
    private GameObject childPref = null;
    [SerializeField]
    private float increment = 2f;
    private CircleCollider2D collider = null;

    // Start is called before the first frame update
    void Start()
    {
        ScaleOfScope = transform.localScale;
        collider = GetComponent<CircleCollider2D>();
    }

    private void UpdateScope()
    {
        transform.localScale = ScaleOfScope;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CircleCollider2D other = collision.gameObject.GetComponent<CircleCollider2D>();
        //判断是黑球还是白球
        GameObject obj = Instantiate(childPref, Children);
        Vector2 v = UnityEngine.Random.insideUnitCircle * (transform.localScale * collider.radius - other.radius * other.transform.localScale);
        obj.transform.localPosition = v;
        Destroy(other.gameObject);
        //扩展
        Expand();
    }

    private void Expand()
    {
        Vector3 newScale = new Vector3(transform.localScale.x + increment, transform.localScale.y + increment, transform.localScale.z);
        transform.localScale = newScale;
    }
}
