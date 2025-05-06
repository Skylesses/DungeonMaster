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
        DragNDropStories[] allDNDInstances = FindObjectsOfType<DragNDropStories>();
        StoryInput[] allSIInstances = FindObjectsOfType<StoryInput>();

        //check if correctPos from DragNDropStories is true in all instances
        bool allCorrect = true;
        foreach(var instance in allDNDInstances)
        {
            if(!instance.correctPos)
            {
                allCorrect = false;
            }
        }
        //check if all input fields have input
        bool allFilled = true;
        foreach(var instance in allSIInstances)
        {
            if(!instance.inputDone)
            {
                allFilled = false;
            }
        }

        if(allCorrect && allFilled)
        {   
            //show story selection
            storySelection.SetActive(true);
            Debug.Log("you're god damn right");
        }
    }
}
