using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string nextScene;
    public string credits;

    public GameObject controlsMenu;

    private void Start()
    {
        controlsMenu.SetActive(false);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextScene);
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene(credits);
    }

    public void ShowControls()
    {
        controlsMenu.SetActive(true);
    }

    public void CloseControls()
    {
        controlsMenu.SetActive(false);
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
