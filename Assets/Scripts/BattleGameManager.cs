using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleGameManager : MonoBehaviour
{
    private static BattleGameManager instance;
    public static BattleGameManager Instance
    {
        get { return instance; }
    }

    //public Text player1Score;
    //public Text player2Score;
    public Image sprite1Group;
    public Image sprite2Group;

    private int SpriteMaxNum = 0;

    [SerializeField]
    private Transform group1 = null;
    [SerializeField]
    private Transform group2 = null;
    //[SerializeField]
    //private Text resultText = null;
    [SerializeField]
    private GameObject mask = null;

    [SerializeField]
    private Sprite[] sprites = null;

    [SerializeField]
    private Image player1Result;
    [SerializeField]
    private Image player2Result;

    private int numOfPlayer1 = 1;
    public int NumOfPlayer1
    {
        get { return numOfPlayer1; }
        set
        {
            numOfPlayer1 = value;
            if (numOfPlayer1 == 0)
            {
                if (mask.activeSelf) return;
                mask.SetActive(true);
                SetResult(-1);
            }
        }
    }
    private int numOfPlayer2 = 1;
    public int NumOfPlayer2
    {
        get { return numOfPlayer2; }
        set
        {
            numOfPlayer2 = value;
            if (numOfPlayer2 == 0)
            {
                if (mask.activeSelf) return;
                mask.SetActive(true);
                SetResult(1);
                //resultText.text = "玩家1获胜！";
            }
            //player2Score.text = "Score:" + numOfPlayer2.ToString();
        }
    }

    private int numOfGroup1 = 20;
    public int NumOfGroup1
    {
        get { return numOfGroup1; }
        set
        {
            numOfGroup1 = value;
            //sprite1Group.text = numOfGroup1.ToString();
            sprite1Group.fillAmount = (float)numOfGroup1 / SpriteMaxNum;
            if (numOfGroup1 == 0 && numOfGroup2 == 0)
                CheckWinner();
        }
    }
    private int numOfGroup2 = 20;
    public int NumOfGroup2
    {
        get { return numOfGroup2; }
        set
        {
            numOfGroup2 = value;
            //sprite2Group.text = numOfGroup2.ToString();
            sprite2Group.fillAmount = (float)numOfGroup2 / SpriteMaxNum;
            if (numOfGroup1 == 0 && numOfGroup2 == 0)
                CheckWinner();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;
        else
            DestroyImmediate(gameObject);

        SpriteMaxNum = group1.childCount;
        NumOfGroup1 = group1.childCount;
        NumOfGroup2 = group2.childCount;
    }

    private void CheckWinner()
    {
        if (numOfPlayer1 > numOfPlayer2)
            SetResult(1);
        else if (numOfPlayer1 < numOfPlayer2)
            SetResult(2);
        else
            SetResult(0);
    }

    /// <summary>
    /// i=0平局，+1玩家一获胜，-1玩家二获胜
    /// </summary>
    /// <param name="i"></param>
    private void SetResult(int i)
    {
        //if (mask.activeSelf) return;
        mask.SetActive(true);
        player1Result.gameObject.SetActive(true);
        player2Result.gameObject.SetActive(true);
        switch (i)
        {
            case 0:
                player1Result.overrideSprite = sprites[0];
                player2Result.overrideSprite = sprites[0];
                return;
            case 1:
                player1Result.overrideSprite = sprites[2];
                player2Result.overrideSprite = sprites[1];
                return;
            case -1:
                player1Result.overrideSprite = sprites[1];
                player2Result.overrideSprite = sprites[2];
                return;
        }
    }
}
