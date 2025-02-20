using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropsManager : MonoBehaviour
{
    public GameObject tavernProps;
    public GameObject shipProps;
    public GameObject jailProps;
    public GameObject woodsProps;

    // Start is called before the first frame update
    void Start()
    {
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
}
