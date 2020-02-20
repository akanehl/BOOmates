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

    public Chores player2Chore;

    private int rand;

    void Start()
    {
        player1Score = 0;
        player2Score = 0;
        rand = Random.Range(0, chores.Count);
        player1Chore = chores[rand].GetComponent<Chores>();

    }

    void FixedUpdate()
    {
        if(chores.Count > 0){
            if(player1Chore != null){
                if(player1Chore.complete() && player1Chore != null )
                {
                    player1Score++;
                    Debug.Log("the chore1 is complete");
                    chores.Remove(player1Chore.gameObject);
                    rand = Random.Range(0, chores.Count);
                    player1Chore = chores[rand].GetComponent<Chores>();
                }
            } 

            // if(player2Chore != null){
            //     if(player2Chore.complete())
            //     {
            //         player2Score++;
            //         Debug.Log("the chore2 is complete");
            //         rand = Random.Range(0, chores.Length);
            //         player2Chore = chores[rand].GetComponent<Chores>();
            //     }
            // }
        }
    }
}
