using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class HumanBehavior : MonoBehaviour
{
    public enum HumanState {NORMAL, CONTROL, SCARE}

    private HumanState currentState;

    [SerializeField]
    private float speed;
    
    public Transform[] moveSpots; 
    private int randomSpot;

    private float waitTime;

    [SerializeField]
    private float startWaitTime;

    public UnityEngine.AI.NavMeshAgent agent;

    public float ScarePoint = 0.0f;

    [SerializeField]
    private float freezeTime = 3.0f;

    public GameObject targetPosition;

    //Add by Guanchen Liu
    //This condition will show the script is activated or not
    // Start is called before the first frame update
    void Start()
    {
        randomSpot = Random.Range(0, moveSpots.Length);
        currentState = HumanState.NORMAL;
        waitTime = startWaitTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ScareMagement();
        transform.GetChild(0).rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        if(currentState == HumanState.NORMAL)
        {
            agent.isStopped = false;
            normalBehavior();
        }

    }

    //Human AI, move around when human isn't control by ghost(player)
    void normalBehavior()
    {
        // transform.position = Vector3.MoveTowards(transform.position, moveSpots[randomSpot].position, 
        //                                             speed * Time.deltaTime);

        //Sound: walking sound
        agent.SetDestination(moveSpots[randomSpot].position);
        transform.rotation = Quaternion.LookRotation(transform.forward);
        if(Vector3.Distance(transform.position, moveSpots[randomSpot].position) < 0.5f)
        {
            if(waitTime <= 0) 
            {
                int prevRandomSpot = randomSpot;
                while (prevRandomSpot == randomSpot)
                {
                    randomSpot = Random.Range(0, moveSpots.Length);
                    Debug.Log("change random spot to" + randomSpot);
                }
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    void ScareMagement()
    {
        if(ScarePoint >= 100.0f)
        {
            currentState = HumanState.SCARE;
            ScarePoint = 0.0f;
        }
        else if(ScarePoint > 0.0f)
        {
            ScarePoint -= Time.deltaTime * 5.0f;
        }
        else
        {
            ScarePoint = 0.0f;
        }
    }
}
