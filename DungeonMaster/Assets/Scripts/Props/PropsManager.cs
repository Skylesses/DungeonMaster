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
        DragNDropWeapons[] allInstancesWeapons = FindObjectsOfType<DragNDropWeapons>();

        //check if isLocked from DragNDrop and DragNDropWeapons is true in all instances
        bool allPropsLocked = true;
        bool allWeaponsLocked = true;
        foreach (var instance in allInstances)
        {
            if (!instance.isLocked)
            {
                allPropsLocked = false;
            }
        }
        foreach (var instance in allInstancesWeapons)
        {
            if (!instance.isLocked)
            {
                allWeaponsLocked = false;
            }
        }
        //set nextLevel active
        nextLevel.SetActive(allPropsLocked && allWeaponsLocked);
    }

    //load next scene
    public void LoadNextScene()
    {
        //MUSS NOCH ZURÜCK ZU LEVEL 3 (LEVEL 4 NUR FÜRS TESTEN)!!!!!
        //SceneManager.LoadScene("Level_3_DMScreen");
        SceneManager.LoadScene("Level_4.1_Map");
    }
}
