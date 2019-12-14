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

    public Text player1Score;
    public Text player2Score;
    public Text sprite1Group;
    public Text sprite2Group;

    [SerializeField]
    private PlayerController player1;
    [SerializeField]
    private PlayerController player2;
    [SerializeField]
    private Transform group1;
    [SerializeField]
    private Transform group2;

    private int numOfPlayer1 = 1;
    public int NumOfPlayer1
    {
        get { return numOfPlayer1; }
        set
        {
            numOfPlayer1 = value;
            player1Score.text = "Score:" + numOfPlayer1.ToString();
        }
    }
    private int numOfPlayer2 = 1;
    public int NumOfPlayer2
    {
        get { return numOfPlayer2; }
        set
        {
            numOfPlayer2 = value;
            player2Score.text = "Score:" + numOfPlayer2.ToString();
        }
    }

    private int numOfGroup1 = 20;
    public int NumOfGroup1
    {
        get { return NumOfGroup1; }
        set
        {
            numOfGroup1 = value;
            sprite1Group.text = numOfGroup1.ToString();
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
            sprite2Group.text = numOfGroup2.ToString();
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

        NumOfGroup1 = group1.childCount;
        NumOfGroup2 = group2.childCount;
    }

    private void CheckWinner()
    {
        if (numOfPlayer1 > numOfPlayer2)
            Debug.Log("player1 wins！");
        else if (numOfPlayer1 < numOfPlayer2)
            Debug.Log("player2 wins！");
        else
            Debug.Log("both win!");
    }
}
