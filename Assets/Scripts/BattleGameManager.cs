using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleGameManager : MonoBehaviour
{
    private static BattleGameManager instance;
    public static BattleGameManager Instance
    {
        get { return instance; }
    }

    [SerializeField]
    private PlayerController player1;
    [SerializeField]
    private PlayerController player2;

    private int numOfPlayer1 = 1;
    public int NumOfPlayer1
    {
        get { return numOfPlayer1; }
        set
        {
            numOfPlayer1 = value;
        }
    }
    private int numOfPlayer2 = 1;
    public int NumOfPlayer2
    {
        get { return numOfPlayer2; }
        set
        {
            numOfPlayer2 = value;
        }
    }

    private int numOfGroup1 = 20;
    public int NumOfGroup1
    {
        get { return NumOfGroup1; }
        set
        {
            numOfGroup1 = value;
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CheckWinner()
    {

    }
    
}
