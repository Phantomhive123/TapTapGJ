using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneSelecter : MonoBehaviour
{
    public RectTransform LeftPos;
    public RectTransform RightPos;
    public float speed = 0;
    public GameObject cover;

    private new RectTransform transform;
    

    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if(Input.anyKeyDown)
        {
            if (cover.activeSelf)
                cover.SetActive(false);
        }
    }

    public void LeftButton()
    {
        StopAllCoroutines();
        //Debug.Log(transform.localPosition);
        //Debug.Log(LeftPos.localPosition);
        StartCoroutine(MoveToLeft());
    }

    public void RightButton()
    {
        StopAllCoroutines();
        //Debug.Log(transform.localPosition);
        //Debug.Log(RightPos.localPosition);
        StartCoroutine(MoveToRight());
    }

    IEnumerator MoveToLeft()
    {
        while (transform.localPosition.x <= LeftPos.localPosition.x) 
        {
            Vector3 newPos = Vector3.MoveTowards(transform.localPosition, LeftPos.localPosition, speed);
            transform.localPosition = newPos;
            yield return new WaitForFixedUpdate();
        }       
    }

    IEnumerator MoveToRight()
    {
        while (transform.localPosition.x >= RightPos.localPosition.x)
        {
            Vector3 newPos = Vector3.MoveTowards(transform.localPosition, RightPos.localPosition, speed);
            transform.localPosition = newPos;
            yield return new WaitForFixedUpdate();
        }
    }
}
