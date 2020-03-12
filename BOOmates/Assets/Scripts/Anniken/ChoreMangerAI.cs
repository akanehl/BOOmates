using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoreMangerAI : MonoBehaviour
{
    [SerializeField]
    private int player1Score;

    [SerializeField]
    private int player2Score;

    [SerializeField]
    private Chores currentPlayerChore;

    [SerializeField]
    private GameObject currentPlayer;

    [SerializeField]
    private List<GameObject> chores;

    private float lightTime = 1.5f;

    private GameObject Worldlight;

    void Start()
    {
        player1Score = 0;

        player2Score = 0;

        Worldlight = GameObject.Find("LightsMaster");
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
        //Edit by Enxuan
        if(currentPlayer != null){
            //update currentChore to last Chore player is doing
            if(currentPlayer.GetComponent<GhostAI>().getcurrentChore() != null)
            {
                currentPlayerChore = currentPlayer.GetComponent<GhostAI>().getcurrentChore();
            }

            if(currentPlayerChore != null)
            {
                if(currentPlayerChore.complete())
                {
                    if(currentPlayer.GetComponent<GhostAI>().playernum == 0){
                        player1Score++;
                    }
                    else
                    {
                        player2Score++;
                    }
                    chores.Remove(currentPlayerChore.gameObject);
                    currentPlayerChore.deactiveChore();
                    currentPlayerChore = null;
                }
            }
        }
        if(chores.Count > 0 && currentPlayer != null && Worldlight.activeSelf)
        {
 
            choresActive(currentPlayer.GetComponent<GhostAI>().playernum);
        }

        if(!Worldlight.activeSelf)
        {
            choresdeactive();
        }
    }

    public void setPlayer(GameObject player)
    {
        currentPlayer = player;
    }

    private void choresActive(int player)
    {
        foreach(GameObject x in chores)
        {
            x.GetComponent<Chores>().activeChore(player);
        }
    }

    private void choresdeactive()
    {
        foreach(GameObject x in chores)
        {
            x.GetComponent<Chores>().deactiveChore();
        }
    }
}
