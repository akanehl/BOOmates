using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoreManger : MonoBehaviour
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

    private UIManager UI;

    void Start()
    {
        player1Score = 0;

        player2Score = 0;

        Worldlight = GameObject.Find("LightsMaster");

        UI = GameObject.Find("UI").GetComponent<UIManager>();
    }

    void FixedUpdate()
    {
        if(chores.Count == 0 || UI.currentTime <= 0){
            if(player1Score > player2Score)
            {
                var UI = GameObject.Find("UI");
                var image = UI.transform.Find("player1Win").gameObject;
                image.SetActive(true);
                Debug.Log("p1win");
                //player 1 wins
            }
            else
            {
                //player 2 wins
                var UI = GameObject.Find("UI");
                var image = UI.transform.Find("player2Win").gameObject;
                image.SetActive(true);
                Debug.Log("p2win");
            }
        }
        //Edit by Enxuan
        if(currentPlayer != null){
            //update currentChore to last Chore player is doing
            if(currentPlayer.GetComponent<GhostController>().getcurrentChore() != null)
            {
                currentPlayerChore = currentPlayer.GetComponent<GhostController>().getcurrentChore();
            }

            if(currentPlayerChore != null)
            {
                if(currentPlayerChore.complete())
                {
                    if(currentPlayer.GetComponent<GhostController>().playernum == 0){
                        if(chores.Count > 2)
                        {
                            player1Score++;
                        }
                        else
                        {
                            player1Score += 2;
                        }
                    }
                    else
                    {
                        if(chores.Count > 2)
                        {
                            player2Score++;
                        }
                        else
                        {
                            player2Score += 2;
                        }
                    }
                    chores.Remove(currentPlayerChore.gameObject);
                    currentPlayerChore.deactiveChore();
                    currentPlayerChore = null;
                }
            }
        }
        if(chores.Count > 0 && currentPlayer != null && Worldlight.activeSelf)
        {
 
            choresActive(currentPlayer.GetComponent<GhostController>().playernum);
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
