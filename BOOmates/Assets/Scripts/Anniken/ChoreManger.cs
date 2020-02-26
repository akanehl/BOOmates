using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoreManger : MonoBehaviour
{
    public int player1Score;
    public int player2Score;
    
    [SerializeField]
    private List<GameObject> chores;

    public Chores player1Chore;

    public int player1ChoreNum;

    public Chores player2Chore;

    public int player2ChoreNum;

    private int rand;

    void Start()
    {
        player1Score = 0;
        player2Score = 0;
        player1ChoreNum = Random.Range(0, chores.Count);
        Debug.Log(player1ChoreNum);
        Debug.Log(chores.Count);
        player1Chore = chores[player1ChoreNum].GetComponent<Chores>();
        if(chores.Count > 1){
            player1Chore.activeChore(0);
            player2ChoreNum = Random.Range(0, chores.Count);
            player2Chore = chores[player2ChoreNum].GetComponent<Chores>();
            while (player1Chore.getID() == player2Chore.getID())
            {
                player2ChoreNum = Random.Range(0, chores.Count);
                player2Chore = chores[player2ChoreNum].GetComponent<Chores>();
            }
            player2Chore.activeChore(1);
        }
        player2Chore.activeChore(1);
    }

    void FixedUpdate()
    {
        if(player1Score >= 3)
        {
            var UI = GameObject.Find("UI");
            var image = UI.transform.Find("player1Win").gameObject;
            image.SetActive(true);
            Debug.Log("p1win");
            //player 1 wins
        }

        if(player2Score >= 3)
        {
            //player 2 wins
            var UI = GameObject.Find("UI");
            var image = UI.transform.Find("player2Win").gameObject;
            image.SetActive(true);
            Debug.Log("p2win");
        }

        if(chores.Count > 0){
            if(player1Chore != null){
                if(player1Chore.complete() && player1Chore.isActive() )
                {
                    player1Score++;
                    Debug.Log("the chore1 is complete");
                    player1Chore.deactiveChore(0);
                    if(player2ChoreNum > player1ChoreNum)
                        player2ChoreNum--;
                    chores.Remove(player1Chore.gameObject);
                    if(chores.Count > 1){
                        player1ChoreNum = Random.Range(0, chores.Count);               
                        player1Chore = chores[player1ChoreNum].GetComponent<Chores>();
                        while(player1Chore.getID() == player2Chore.getID())
                        {
                            player1ChoreNum = Random.Range(0, chores.Count);               
                            player1Chore = chores[player1ChoreNum].GetComponent<Chores>();
                        }
                        player1Chore.activeChore(0);
                    }
                }
            } 

            if(player2Chore != null){
                if(player2Chore.complete() && player2Chore.isActive())
                {
                    player2Score++;
                    Debug.Log("the chore2 is complete");
                    player2Chore.deactiveChore(1);
                    if(player1ChoreNum > player2ChoreNum)
                        player1ChoreNum--;
                    chores.Remove(player2Chore.gameObject);
                    if(chores.Count > 1){
                        player2ChoreNum = Random.Range(0, chores.Count);               
                        player2Chore = chores[player2ChoreNum].GetComponent<Chores>();
                        while(player1Chore.getID() == player2Chore.getID())
                        {
                            player2ChoreNum = Random.Range(0, chores.Count);               
                            player2Chore = chores[player2ChoreNum].GetComponent<Chores>();
                        }
                        player2Chore.activeChore(1);
                    }
                }
            }
        }
    }

    public Chores nextChore(int player)
    {
        if (player == 0)
        {
            player1Chore.deactiveChore(0);
            if(chores.Count > 0){
                player1ChoreNum++;
                if(player1ChoreNum == player2ChoreNum)
                {
                    player1ChoreNum++;
                }
                if(player1ChoreNum >= chores.Count)
                {
                    player1ChoreNum = 0;
                    if(player1ChoreNum == player2ChoreNum)
                    {
                        player1ChoreNum++;
                    }
                }
                player1Chore = chores[player1ChoreNum].GetComponent<Chores>();
                player1Chore.activeChore(0);
                return player1Chore;
            }
        }
        else
        {
            player2Chore.deactiveChore(1);
            if(chores.Count > 0){
                player2ChoreNum++;
                if(player2ChoreNum == player1ChoreNum)
                {
                    player2ChoreNum++;
                }
                if(player2ChoreNum >= chores.Count)
                {
                    player2ChoreNum = 0;
                    if(player2ChoreNum == player1ChoreNum)
                    {
                        player2ChoreNum++;
                    }
                }
                player2Chore = chores[player2ChoreNum].GetComponent<Chores>();
                player2Chore.activeChore(1);
            }
            return player2Chore;
        }
        return null;
    }

    public Chores prevChore(int player)
    {
        if (player == 0)
        {
            player1Chore.deactiveChore(0);
            if(chores.Count > 0){
                player1ChoreNum--;
                if(player1ChoreNum == player2ChoreNum)
                {
                    player1ChoreNum--;
                }
                if(player1ChoreNum <= -1)
                {
                    player1ChoreNum = chores.Count - 1;
                    if(player1ChoreNum == player2ChoreNum)
                    {
                        player1ChoreNum--;
                    }
                }
                player1Chore = chores[player1ChoreNum].GetComponent<Chores>();
                player1Chore.activeChore(0);
                return player1Chore;
            }
        }
        else
        {
            player2Chore.deactiveChore(1);
            if(chores.Count > 0){
                player2ChoreNum--;
                if(player2ChoreNum == player1ChoreNum)
                {
                    player2ChoreNum--;
                }
                if(player2ChoreNum <= -1)
                {
                    player2ChoreNum = chores.Count -1;
                    if(player2ChoreNum == player1ChoreNum)
                    {
                        player2ChoreNum--;
                    }
                }
                player2Chore = chores[player2ChoreNum].GetComponent<Chores>();
                player2Chore.activeChore(1);
            }
            return player2Chore;
        }
        return null;
    }

}
