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

    private int lightChore = 0;

    private float lightTime = 1.5f;

    void Start()
    {
        player1Score = 0;

        player2Score = 0;

        lightChore = 0;
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
            if(currentPlayer.GetComponent<GhostController>().getcurrentChore() != null)
            {
                currentPlayerChore = currentPlayer.GetComponent<GhostController>().getcurrentChore();
            }

            if(currentPlayerChore != null)
            {
                if(currentPlayerChore.complete())
                {
                    if(currentPlayer.GetComponent<GhostController>().playernum == 0){
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
        if(chores.Count > 0 && currentPlayer != null)
        {
            if(lightTime > 0)
            {
                lightTime -= Time.deltaTime;
            }
            else
            {
                choreRotate(currentPlayer.GetComponent<GhostController>().playernum);
                lightTime = 1.5f;
            }
        }
    }

    public void setPlayer(GameObject player)
    {
        currentPlayer = player;
    }

    private void choreRotate(int player)
    {
        chores[lightChore].GetComponent<Chores>().deactiveChore();
        lightChore++;
        if(lightChore >= chores.Count){
            lightChore = 0;
        }
        chores[lightChore].GetComponent<Chores>().activeChore(player);
    }
}
