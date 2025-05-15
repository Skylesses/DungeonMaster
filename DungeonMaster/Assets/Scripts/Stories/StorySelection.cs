using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StorySelection : MonoBehaviour
{
    public static bool tavern;
    public static bool jail;
    public static bool ship;
    public static bool woods;
    public GameObject nextLevel;
    public string nextScene;

    // Start is called before the first frame update
    void Start()
    {
        tavern = false;
        jail = false;
        ship = false;
        woods = false;
        nextLevel.SetActive(false);
    }
    //story selected for later and next level start
    public void SelectTavern()
    {
        tavern = true;
        nextLevel.SetActive(true);
        jail = false;
        ship = false;
        woods = false;
        Debug.Log("tavern");
    }
    public void SelectJail()
    {
        jail = true;
        nextLevel.SetActive(true);
        tavern = false;
        ship = false;
        woods = false;
        Debug.Log("jail");
    }
    public void SelectShip()
    {
        ship = true;
        nextLevel.SetActive(true);
        tavern = false;
        jail = false;
        woods = false;
        Debug.Log("ship");
    }
    public void SelectWoods()
    {
        woods = true;
        nextLevel.SetActive(true);
        tavern = false;
        jail = false;
        ship = false;
        Debug.Log("woods");
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}
