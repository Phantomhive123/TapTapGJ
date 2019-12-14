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

    public void Expand(Vector3 radius)
    {
        GameObject obj = Instantiate(childPref, Children);
        Vector2 v = UnityEngine.Random.insideUnitCircle * (transform.localScale * collider.radius - radius);
        obj.transform.localPosition = v;
        Vector3 newScale = new Vector3(transform.localScale.x + increment, transform.localScale.y + increment, transform.localScale.z);
        transform.localScale = newScale;
    }

    public void Shrink()
    {
        if (Children.childCount == 1) return;//死亡
        Destroy(Children.GetChild(UnityEngine.Random.Range(0, Children.childCount)).gameObject);
        Vector3 newScale = new Vector3(transform.localScale.x - increment, transform.localScale.y - increment, transform.localScale.z);
        transform.localScale = newScale;
    }
}
