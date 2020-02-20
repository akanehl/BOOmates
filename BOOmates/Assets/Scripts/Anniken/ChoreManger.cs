using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoreManger : MonoBehaviour
{
    public int player1Score;
    public int player2Score;
    public GameObject[] chores;

    public Chores player1Chore;

    public Chores player2Chore;

    void Start()
    {
        player1Score = 0;
        player2Score = 0;
        player1Chore = chores[0].GetComponent<Chores>();
    }

    void FixedUpdate()
    {
        if(player1Chore.complete())
        {
            player1Score++;
            Debug.Log("the chore is complete");
            player1Chore = null;
        }
    }
}
