using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingManager : MonoBehaviour
{
    public GameObject tavernText;
    public GameObject shipText;
    public GameObject jailText;
    public GameObject woodText;

    // Start is called before the first frame update
    void Start()
    {
        tavernText.SetActive(false);
        shipText.SetActive(false);
        jailText.SetActive(false);
        woodText.SetActive(false);

        if (StorySelection.tavern == true)
        {
            tavernText.SetActive(true);
        }
        if (StorySelection.ship == true)
        {
            shipText.SetActive(true);
        }
        if (StorySelection.jail == true)
        {
            jailText.SetActive(true);
        }
        if (StorySelection.woods == true)
        {
            woodText.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
