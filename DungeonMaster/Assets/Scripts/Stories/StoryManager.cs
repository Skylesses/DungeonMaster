using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour
{   
    public GameObject storySelection;
    public GameObject nextLevel;

    private void Start()
    {
        storySelection.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {   
        //get all Instances of the script
        DragNDropStories[] allInstances = FindObjectsOfType<DragNDropStories>();

        //check if correctPos from DragNDropStories is true in all instances
        bool allCorrect = true;
        foreach(var instance in allInstances)
        {
            if(!instance.correctPos)
            {
                allCorrect = false;
            }
        }
        if(allCorrect)
        {   
            //show story selection
            storySelection.SetActive(true);
            Debug.Log("you're god damn right");
        }
    }
}
