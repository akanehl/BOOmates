using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{

    GameObject Nathan;

    public float scarePoint = 0f;

    private GameObject worldLighting;

    GameObject humanPlayer;

    GameObject[] ghosts;

    public bool musicPlaying = false;
    
    // Start is called before the first frame update
    void Start()
    {
        Nathan = GameObject.Find("Nathan");
        worldLighting = GameObject.FindGameObjectWithTag("EnvironmentLights");
        ghosts = GameObject.FindGameObjectsWithTag("Ghost");

    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject ghost in ghosts)
        {
            if(ghost.GetComponent<GhostController>().onHuman)
            {
                humanPlayer = ghost;
            }
        }
    }

    void scareManager()
    {
        
        if(scarePoint > 100)
        {
            Nathan.transform.Find("Firefly").gameObject.SetActive(true);
            humanPlayer.GetComponent<GhostController>().currentCond = GhostController.ghostCond.onEjecting;
            //OnLeaving();
            //var otherScript = OtherGhost.GetComponent<GhostController>();
            //otherScript.OnTaking();
        }

        if(scarePoint < 100)
        {
            //Nathan.transform.Find("Firefly").gameObject.SetActive(false);
            humanPlayer.GetComponent<GhostController>().currentCond = GhostController.ghostCond.inHuman;
            if (!worldLighting.activeSelf)
            {
                scarePoint += 0.05f;
            }
            if (musicPlaying)
            {
                scarePoint += 0.05f;
            }
        }

        if(scarePoint >0)
        {
            scarePoint = scarePoint -= 0.01f;
        }

        UIManager.instance.UpdateScarePoints((int)scarePoint);
    }
}
