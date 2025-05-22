using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingManager : MonoBehaviour
{   
    [Header("OneShots")]
    public GameObject tavernOS;
    public GameObject shipOS;
    public GameObject jailOS;
    public GameObject woodsOS;

    [Header("Props")]
    public GameObject tavernOne;
    public GameObject shipOne;
    public GameObject jailOne;
    public GameObject woodsOne;
    public GameObject tavernTwo;
    public GameObject shipTwo;
    public GameObject jailTwo;
    public GameObject woodsTwo;

    [Header("Maps")]
    public GameObject mapOne;
    public GameObject mapTwo;

    [Header("Save Buttons")]
    public GameObject saveOneShot;
    public GameObject savePropsOne;
    public GameObject savePropsTwo;
    public GameObject saveMapOne;
    public GameObject saveMapTwo;

    // Start is called before the first frame update
    void Start()
    {
        tavernOS.SetActive(false);
        shipOS.SetActive(false);
        jailOS.SetActive(false);
        woodsOS.SetActive(false);

        tavernOne.SetActive(false);
        shipOne.SetActive(false);
        jailOne.SetActive(false);
        woodsOne.SetActive(false);

        tavernTwo.SetActive(false);
        shipTwo.SetActive(false);
        jailTwo.SetActive(false);
        woodsTwo.SetActive(false);

        saveOneShot.SetActive(true);
        savePropsOne.SetActive(false);
        savePropsTwo.SetActive(false);
        saveMapOne.SetActive(false);
        saveMapTwo.SetActive(false);

        //show One Shot depending on story selection
        if (StorySelection.tavern == true)
        {
            tavernOS.SetActive(true);
        }
        if (StorySelection.ship == true)
        {
            shipOS.SetActive(true);
        }
        if (StorySelection.jail == true)
        {
            jailOS.SetActive(true);
        }
        if (StorySelection.woods == true)
        {
            woodsOS.SetActive(true);
        }
    }

    //get next to Props
    public void changeToPropsOne()
    {
        tavernOS.SetActive(false);
        shipOS.SetActive(false);
        jailOS.SetActive(false);
        woodsOS.SetActive(false);

        if (StorySelection.tavern == true)
        {
            tavernOne.SetActive(true);
        }
        if (StorySelection.ship == true)
        {
            shipOne.SetActive(true);
        }
        if (StorySelection.jail == true)
        {
            jailOne.SetActive(true);
        }
        if (StorySelection.woods == true)
        {
            woodsOne.SetActive(true);
        }
    }

    public void changeToPropsTwo()
    {
        tavernOne.SetActive(false);
        shipOne.SetActive(false);
        jailOne.SetActive(false);
        woodsOne.SetActive(false);

        if (StorySelection.tavern == true)
        {
            tavernTwo.SetActive(true);
        }
        if (StorySelection.ship == true)
        {
            shipTwo.SetActive(true);
        }
        if (StorySelection.jail == true)
        {
            jailTwo.SetActive(true);
        }
        if (StorySelection.woods == true)
        {
            woodsTwo.SetActive(true);
        }
    }

    public void changeToMapOne()
    {
        tavernTwo.SetActive(false);
        shipTwo.SetActive(false);
        jailTwo.SetActive(false);
        woodsTwo.SetActive(false);

        mapOne.SetActive(true);
    }

    public void changeToMapTwo()
    {
        mapOne.SetActive(false);
        mapTwo.SetActive(true);
    }
}
