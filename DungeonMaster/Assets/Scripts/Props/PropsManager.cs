using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PropsManager : MonoBehaviour
{
    public GameObject tavernProps;
    public GameObject shipProps;
    public GameObject jailProps;
    public GameObject woodsProps;

    public GameObject nextLevel;

    // Start is called before the first frame update
    void Start()
    {
        nextLevel.SetActive(false);

        tavernProps.SetActive(false);
        shipProps.SetActive(false);
        jailProps.SetActive(false);
        woodsProps.SetActive(false);

        if (StorySelection.tavern == true)
        {
            tavernProps.SetActive(true);
        }
        if (StorySelection.ship == true)
        {
            shipProps.SetActive(true);
        }
        if (StorySelection.jail == true)
        {
            jailProps.SetActive(true);
        }
        if (StorySelection.woods == true)
        {
            woodsProps.SetActive(true);
        }
    }  
    
    void Update()
    {
        //get all Instances of the script
        DragNDrop[] allInstances = FindObjectsOfType<DragNDrop>();

        //check if isLocked from DragNDropStories is true in at least one instance
        bool oneLocked = false;
        foreach (var instance in allInstances)
        {
            if (instance.isLocked)
            {
                oneLocked = true;
                break;
            }
        }
        //set nextLevel active
        nextLevel.SetActive(oneLocked);
    }

    //load next scene
    public void LoadNextScene()
    {
        SceneManager.LoadScene("Level_3_DMScreen");
    }
}
