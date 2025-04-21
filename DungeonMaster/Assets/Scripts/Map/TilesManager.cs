using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TilesManager : MonoBehaviour
{
    public GameObject tavernTiles;
    public GameObject shipTiles;
    public GameObject jailTiles;
    public GameObject woodsTiles;

    public string nextLevel;

    // Start is called before the first frame update
    void Start()
    {
        /*tavernTiles.SetActive(false);
        shipTiles.SetActive(false);
        jailTiles.SetActive(false);
        woodsTiles.SetActive(false);*/

        if (StorySelection.tavern == true)
        {
            tavernTiles.SetActive(true);
        }
        if (StorySelection.ship == true)
        {
            shipTiles.SetActive(true);
        }
        if (StorySelection.jail == true)
        {
            jailTiles.SetActive(true);
        }
        if (StorySelection.woods == true)
        {
            woodsTiles.SetActive(true);
        }
    }

    //load next scene
    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextLevel);
    }
}
