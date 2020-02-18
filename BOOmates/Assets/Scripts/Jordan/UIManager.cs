using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public int startingTime;
    private int currentTime;

    [SerializeField] private TextMeshProUGUI timer;

    //Temporary untill we get bubbles
    [SerializeField] private TextMeshProUGUI scarePoints;

    [SerializeField] private Image crystalBallIcon;
    [SerializeField] private Image completedChores;

    [SerializeField] private Sprite[] playerEmotes;

    //Assigned when player loads in.
    private Image playerEmoteBubble;


    //Create a singleton pattern for the UI Manager
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        StartCoroutine(StartTimer());
    }

    private void Update()
    {
        //Debug Keys
        if(Input.GetKeyDown(KeyCode.P))
        {
            //Activates Bubble
            if(!playerEmoteBubble.gameObject.activeSelf)
            {
                playerEmoteBubble.gameObject.SetActive(true);
            }
            else
            {
                playerEmoteBubble.gameObject.SetActive(false);
            }
        }

        //Changes Bubble color
        if (Input.GetKeyDown(KeyCode.G))
        {
            UpdateNathanEmoteColor(Color.green);
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            UpdateNathanEmoteColor(Color.yellow);
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            UpdateNathanEmoteColor(Color.red);
        }
    }

    //Requires time in int where 1 is 1 sec and 60 is a minute etc.
    public void UpdateTimer(int time)
    {
        int min = time / 60;
        int seconds = time - (60 * min);

        if(seconds < 10)
        {
            timer.text = min.ToString() + ":0" + seconds.ToString();

        }
        else
        {
            timer.text = min.ToString() + ":" + seconds.ToString();
        }

    }

    public void UpdateScarePoints(int scareValue)
    {
        scarePoints.text = "Scarepoints: "+ scareValue.ToString();
    }

    private void SetChores()
    {
         
    }
    public void SetEmoteBubble(GameObject bubble)
    {
        playerEmoteBubble = bubble.GetComponent<Image>();
    }

    public void UpdateNathanEmoteColor(Color c)
    {
        playerEmoteBubble.color = c;
    }
    public void UpdateNathanEmoteSprite(int scareLevel)
    {
        playerEmoteBubble.sprite = playerEmotes[scareLevel];
    }
    private IEnumerator StartTimer()
    {
        currentTime = startingTime;
        UpdateTimer(currentTime);

        while (currentTime > 0)
        {
            yield return new WaitForSeconds(1f);
            currentTime--;
            UpdateTimer(currentTime);
        }
    }
}
