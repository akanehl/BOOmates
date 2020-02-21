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

    [SerializeField] private Sprite[] playerEmotes;

    //Assigned when player loads in.
    private Image playerEmoteBubble;


    //Flags
    private bool isChoreChanging = false;
    private bool isImageFading = false;
    private int emoteIndex = -1;

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
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
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
        if (scareValue > 50 && scareValue <= 75 && emoteIndex != 0)
        {
            emoteIndex = 0;
            UpdateNathanEmoteSprite(0);
        }
        else if (scareValue > 75 && scareValue <= 96 && emoteIndex != 1)
        {
            emoteIndex = 1;
            UpdateNathanEmoteSprite(1);
        }
        else if (scareValue > 97 && emoteIndex != 2)
        {
            emoteIndex = 2;
            UpdateNathanEmoteSprite(2);
        }
        else if(scareValue < 50)
        {
            emoteIndex = -1;
        }

        scarePoints.text = "Scare Points: " + scareValue.ToString();
    }

    //Performs Chore swap upon call
    public void UpdateChore(Chores currentChore)
    {
        if (isChoreChanging == false) //Prevents button mashing breaking the transition
        {
            isChoreChanging = true;
            StartCoroutine(FadeCrystalBallIcon(currentChore.getChoreIcon()));
        }
    }

    public void SetEmoteBubble(GameObject bubble)
    {
        playerEmoteBubble = bubble.GetComponent<Image>();
    }

    public void UpdateNathanEmoteSprite(int scareLevel)
    {
       
        if (isImageFading == false)
        {
            playerEmoteBubble.sprite = playerEmotes[scareLevel];
            playerEmoteBubble.gameObject.SetActive(true);
            isImageFading = true;
            StartCoroutine(FadeImage(playerEmoteBubble));
        }

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

    //Fades out previous chore and swaps the chore, fades back in with the new chore.
    private IEnumerator FadeCrystalBallIcon(Sprite icon)
    {
        crystalBallIcon.CrossFadeAlpha(0, 1f, false);
        yield return new WaitForSeconds(1f);

        crystalBallIcon.sprite = icon;

        crystalBallIcon.CrossFadeAlpha(1, 1f, false);
        yield return new WaitForSeconds(1f);
        isChoreChanging = false;
    }

    private IEnumerator FadeImage(Image target)
    {
        yield return new WaitForSeconds(1f);
        target.CrossFadeAlpha(0, 0.5f, false);
        yield return new WaitForSeconds(2f);
        isImageFading = false;
        playerEmoteBubble.gameObject.SetActive(false);
    }

}
