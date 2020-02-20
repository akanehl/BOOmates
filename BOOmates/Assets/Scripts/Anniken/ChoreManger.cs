using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        rand = Random.Range(0, chores.Count);
        player1Chore = chores[rand].GetComponent<Chores>();
        player1Chore.activeChore();

    }

    void FixedUpdate()
    {
        if(player1Score >= 5)
        {
            //player 1 wins
        }

        if(player2Score >= 5)
        {
            //player 2 wins
        }
        if(chores.Count > 0){
            if(player1Chore != null){
                if(player1Chore.complete() && player1Chore.isActive() )
                {
                    player1Score++;
                    Debug.Log("the chore1 is complete");
                    player1Chore.deactiveChore();
                    chores.Remove(player1Chore.gameObject);
                    if(chores.Count > 0){
                        player1ChoreNum = Random.Range(0, chores.Count);
                        player1Chore = chores[player1ChoreNum].GetComponent<Chores>();
                        player1Chore.activeChore();
                    }
                }
            } 

            if(player2Chore != null){
                if(player2Chore.complete())
                {
                    player2Score++;
                    Debug.Log("the chore2 is complete");
                    player2Chore.deactiveChore();
                    chores.Remove(player2Chore.gameObject);
                    if(chores.Count > 0){
                        player2ChoreNum = Random.Range(0, chores.Count);
                        player2Chore = chores[player2ChoreNum].GetComponent<Chores>();
                        player2Chore.activeChore();
                    }
                }
            }
        }
    }

    public Chores nextChore(int player)
    {
        if (player == 0)
        {
            player1Chore.deactiveChore();
            if(chores.Count > 0){
                player1ChoreNum++;
                if(player1ChoreNum >= chores.Count)
                {
                    player1ChoreNum = 0;
                }
                player1Chore = chores[player1ChoreNum].GetComponent<Chores>();
                player1Chore.activeChore();
                return player1Chore;
            }
        }
        else
        {
            player2Chore.deactiveChore();
            if(chores.Count > 0){
                player2ChoreNum++;
                if(player2ChoreNum >= chores.Count)
                {
                    player2ChoreNum = 0;
                }
                player2Chore = chores[player2ChoreNum].GetComponent<Chores>();
                player2Chore.activeChore();
            }
            return player2Chore;
        }
        return null;
    }

    public Chores prevChore(int player)
    {
        if (player == 0)
        {
            player1Chore.deactiveChore();
            if(chores.Count > 0){
                player1ChoreNum--;
                if(player1ChoreNum <= -1)
                {
                    player1ChoreNum = chores.Count - 1;
                }
                player1Chore = chores[player1ChoreNum].GetComponent<Chores>();
                player1Chore.activeChore();
                return player1Chore;
            }
        }
        else
        {
            player2Chore.deactiveChore();
            if(chores.Count > 0){
                player2ChoreNum--;
                if(player2ChoreNum <= -1)
                {
                    player2ChoreNum = chores.Count -1;
                }
                player2Chore = chores[player2ChoreNum].GetComponent<Chores>();
                player2Chore.activeChore();
            }
            return player2Chore;
        }
        return null;
    }
}
