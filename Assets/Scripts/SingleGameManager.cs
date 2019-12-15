using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SingleGameManager : MonoBehaviour
{
    private static SingleGameManager instance;
    public static SingleGameManager Instance
    {
        get { return instance; }
    }
    [SerializeField]
    private float totalTime = 30f;
    [NonSerialized]
    public float time = 0;
    [SerializeField]
    private float timeIncrement = 3;

    //[SerializeField]
    //private Text resultText = null;
    [SerializeField]
    private GameObject resultPanel = null;
    [SerializeField]
    private Slider timeSlider = null;

    [SerializeField]
    private Image result = null;
    [SerializeField]
    private Animator mask = null;
    [SerializeField]
    private GameObject note = null;

    public Sprite win;
    public Sprite lose;

    private int numOfPlayer1 = 1;
    public int NumOfPlayer1
    {
        get { return numOfPlayer1; }
        set
        {
            numOfPlayer1 = value;
            if (numOfPlayer1 == 0)
            {
                if (result.gameObject.activeSelf) return;
                mask.Play(Animator.StringToHash("FadeOut"));
                result.gameObject.SetActive(true);
                result.overrideSprite = lose;
                note.SetActive(true);
                //resultText.text = "游戏失败！";
                StopAllCoroutines();
            }
            //player1Score.text = "Score:" + numOfPlayer1.ToString();
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;
        else
            DestroyImmediate(gameObject);

        time = totalTime;
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        while (time >= 0) 
        {
            yield return new WaitForFixedUpdate();
            timeSlider.value = time / totalTime;
            time -= Time.fixedDeltaTime;
        }
        mask.Play(Animator.StringToHash("FadeOut"));
        result.gameObject.SetActive(true);
        result.overrideSprite = win;
        note.SetActive(true);
    }

    public void TimeIncrease()
    {
        time += timeIncrement;
    }
}
