using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void LoadLevel(string lvl)
    {
        SceneManager.LoadScene(lvl);
    }
    public void LoadLevel(int lvl)
    {
        SceneManager.LoadScene(lvl);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
