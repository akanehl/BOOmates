using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public int startingTime;
    public int currentTime;

    [SerializeField] private GameObject pauseMenu;

    [SerializeField] private EventSystem eventSys;


    [SerializeField] private TextMeshProUGUI timer;

    //Temporary untill we get bubbles
    [SerializeField] private TextMeshProUGUI scarePoints;

    [SerializeField] private Image crystalBallIcon;
    [SerializeField] private float iconFadeSpeed = 1.5f;

    [SerializeField] private Sprite[] playerEmotes;
    [SerializeField] private Image staticEmoteBubble;
    [SerializeField] private Animator staticEmoteAnimator;

    [SerializeField] private Sprite[] hintIcons;

    //Assigned when Nathan loads in.
    private NathanUI nathanUI;

    


    //Flags
    private bool isChoreChanging = false;
    private bool isImageFading = false;
    private bool isPaused = false;

    private int emoteIndex = -1;

    //Create a singleton pattern for the UI Manager
    private void Awake()
    {
        Time.timeScale = 0;
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
        if(eventSys == null)
        {
           eventSys = FindObjectOfType<EventSystem>();
        }
        pauseMenu.SetActive(false);
        staticEmoteBubble.gameObject.SetActive(false);
        StartCoroutine(StartTimer());
    }

    private void Update()
    {
     
        //var gamepad = Gamepad.current;
        //if (gamepad == null)
        //    return; // No gamepad connected.

        //if (gamepad.startButton.wasPressedThisFrame)
        //{
        //    TogglePause();
        //}


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
            staticEmoteBubble.gameObject.SetActive(true);

            emoteIndex = 0;
            UpdateNathanEmoteSprite(0);
        }
        else if (scareValue > 75 && scareValue <= 96 && emoteIndex != 1)
        {
            staticEmoteBubble.gameObject.SetActive(true);

            emoteIndex = 1;
            UpdateNathanEmoteSprite(1);
        }
        else if (scareValue > 97 && emoteIndex != 2)
        {
            staticEmoteAnimator.SetTrigger("Pop");
            staticEmoteBubble.gameObject.SetActive(true);
            emoteIndex = 2;
            UpdateNathanEmoteSprite(2);
        }
        else if(scareValue < 50)
        {
            emoteIndex = -1;
            staticEmoteBubble.gameObject.SetActive(false);
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

    public void SetNathanUI(NathanUI nathan)
    {
        nathanUI = nathan;
    }

    public void UpdateNathanEmoteSprite(int scareLevel)
    {
        if (isImageFading == false)
        {
            staticEmoteBubble.sprite = playerEmotes[scareLevel];
            nathanUI.EmoteBubble.sprite = playerEmotes[scareLevel];
            nathanUI.EmoteBubble.gameObject.SetActive(true);
            isImageFading = true;
            StartCoroutine(FadeImage(nathanUI.EmoteBubble));
        }

    }

    public void TriggerHint(int iconIndex)
    {
        if (isImageFading == false)
        {
            nathanUI.HintIcon.sprite = hintIcons[iconIndex];
            nathanUI.HintIcon.gameObject.SetActive(true);
        }
        else
        {
            nathanUI.HintIcon.gameObject.SetActive(false);
        }

    }
    public void TriggerHintDeactivate()
    {
        nathanUI.HintIcon.gameObject.SetActive(false);
    }

    public void CleanTimerToggle(bool flag)
    {
        if (isImageFading == false && flag)
        {
            nathanUI.CleaningTimeGauge.gameObject.SetActive(true);
        }
        else
        {
            nathanUI.CleaningTimeGauge.gameObject.SetActive(false);
        }
    }
    public void UpdateCleanTimer(float time)
    {
        nathanUI.CleaningTimeGauge.fillAmount = time;
    }


    //Pause Menu Functions

    public void TogglePause()
    {
        Debug.Log("Pause Called");
        if(isPaused)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
            isPaused = false;
            eventSys.SetSelectedGameObject(null);
        }
        else
        {
            pauseMenu.SetActive(true);

            //Set controller selection to the first button in pause menu.
            GameObject button = pauseMenu.GetComponentInChildren<Button>().gameObject;
            eventSys.SetSelectedGameObject(button);
            Time.timeScale = 0;
            isPaused = true;
        }
    }

    public void ReturnToMenu(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    //Enumerators 
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
        float spd = iconFadeSpeed / 2;
        crystalBallIcon.CrossFadeAlpha(0, spd, false);
        yield return new WaitForSeconds(spd);

        crystalBallIcon.sprite = icon;

        crystalBallIcon.CrossFadeAlpha(1, spd, false);
        yield return new WaitForSeconds(spd);
        isChoreChanging = false;
    }

    private IEnumerator FadeImage(Image target)
    {
        yield return new WaitForSeconds(3f);
        target.CrossFadeAlpha(0, 1f, false);
        yield return new WaitForSeconds(1f);
        isImageFading = false;
        nathanUI.EmoteBubble.gameObject.SetActive(false);
    }

    //Add by Guanchen Liu
    //Related to: GhostController.cs, line 168
    //When the second player has join the game
    //The animation will play

    public void playStartImage(){
        var startAnime = transform.Find("GameStart").gameObject;
        var _pressX = startAnime.transform.Find("pressX").gameObject;
        _pressX.SetActive(false);
        if(startAnime == null){
            Time.timeScale = 1.0f;
            return;
        }
        StartCoroutine(StartAnimation());
    }
    private IEnumerator StartAnimation()
    {
        var startAnime = transform.Find("GameStart").gameObject;
        var _take = startAnime.transform.Find("take").gameObject;
        var _over = startAnime.transform.Find("over").gameObject;
        var _body = startAnime.transform.Find("body").gameObject;
        _take.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        _take.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        _over.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        _over.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        _body.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        _body.SetActive(false);
        Time.timeScale = 1.0f;
        
    }


}
