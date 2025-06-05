using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TilesManager : MonoBehaviour
{
    [Header("Tiles")]
    public GameObject tavernTiles;
    public GameObject shipTiles;
    public GameObject jailTiles;
    public GameObject woodsTiles;

    [Header("UI")]
    public GameObject tavernText;
    public GameObject shipText;
    public GameObject jailText;
    public GameObject woodsText;

    [Header("Next Level")]
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
            tavernText.SetActive(true);
        }
        if (StorySelection.ship == true)
        {
            shipTiles.SetActive(true);
            shipText.SetActive(true);
        }
        if (StorySelection.jail == true)
        {
            jailTiles.SetActive(true);
            jailText.SetActive(true);
        }
        if (StorySelection.woods == true)
        {
            woodsTiles.SetActive(true);
            woodsText.SetActive(true);
        }
    }

    //load next scene
    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextLevel);
    }
}
