using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string nextScene;

    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}
