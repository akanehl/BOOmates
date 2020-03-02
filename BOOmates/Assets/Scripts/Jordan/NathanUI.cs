using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NathanUI : MonoBehaviour
{
    [SerializeField] private Image emoteBubble;
    [SerializeField] private Image hintIcon;
    [SerializeField] private Slider cleaningTimeGauge;

    private Camera mainCam;

    public Image EmoteBubble { get => emoteBubble; private set => emoteBubble = value; }
    public Image HintIcon { get => hintIcon; private set => hintIcon = value; }
    public Slider CleaningTimeGauge { get => cleaningTimeGauge; private set => cleaningTimeGauge = value; }

    // On start up finds camera and then turns off image. Passes ref to UIManager
    void Start()
    {
        mainCam = FindObjectOfType<Camera>();
        UIManager.instance.SetNathanUI(this);
        emoteBubble.gameObject.SetActive(false);
        hintIcon.gameObject.SetActive(false);
        cleaningTimeGauge.gameObject.SetActive(false);
        cleaningTimeGauge.value = 0;
    }

    

    // Update makes sure that when this is active the icon will always be visiable to the camera if it moves.
    void Update()
    {
        transform.LookAt(mainCam.transform);
    }
}
