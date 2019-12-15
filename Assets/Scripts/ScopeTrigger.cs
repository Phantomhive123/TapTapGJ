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
    private new CircleCollider2D collider = null;
    [SerializeField]
    private Transform LightTrans = null;
    [SerializeField]
    private int MaxRadius = 16;

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
        if (transform.localScale.x >= MaxRadius) return;
        Vector3 newScale = new Vector3(transform.localScale.x + increment, transform.localScale.y + increment, transform.localScale.z);      
        transform.localScale = newScale;
        newScale = new Vector3(LightTrans.localScale.x, LightTrans.localScale.y + 0.1f * increment, LightTrans.localScale.z);
        LightTrans.localScale = newScale;
    }

    public void Shrink()
    {
        if (children.childCount == 1) return;//死亡
        Destroy(children.GetChild(UnityEngine.Random.Range(1, children.childCount)).gameObject);
        Vector3 newScale = new Vector3(transform.localScale.x - increment, transform.localScale.y - increment, transform.localScale.z);
        transform.localScale = newScale;
        newScale = new Vector3(LightTrans.localScale.x, LightTrans.localScale.y - 0.1f * increment, LightTrans.localScale.z);
        LightTrans.localScale = newScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Sprite"))
        {
            if (collision.gameObject.layer == gameObject.layer)
            {
                Expand(collision.transform.localScale * collision.GetComponent<CircleCollider2D>().radius);
                Destroy(collision.gameObject);//吸收
                //向GM发送数据
                AddScore();
            }
        }
    }

    private void AddScore()
    {
        if(GameMode.Insatance.isBattle)
        {           
            if(gameObject.layer.Equals(LayerMask.NameToLayer("Group1")))
            {
                BattleGameManager.Instance.NumOfPlayer1++;
                BattleGameManager.Instance.NumOfGroup1--;
            }
            else
            {
                BattleGameManager.Instance.NumOfPlayer2++;
                BattleGameManager.Instance.NumOfGroup2--;
            }
        }
        else
        {
            SingleGameManager.Instance.NumOfPlayer1++;
            SingleGameManager.Instance.TimeIncrease();
        }
    }
}
