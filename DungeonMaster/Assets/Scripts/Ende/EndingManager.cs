using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingManager : MonoBehaviour
{
    public GameObject tavern;
    public GameObject ship;
    public GameObject jail;
    public GameObject wood;

    // Start is called before the first frame update
    void Start()
    {
        tavern.SetActive(false);
        ship.SetActive(false);
        jail.SetActive(false);
        wood.SetActive(false);

        if (StorySelection.tavern == true)
        {
            tavern.SetActive(true);
        }
        if (StorySelection.ship == true)
        {
            ship.SetActive(true);
        }
        if (StorySelection.jail == true)
        {
            jail.SetActive(true);
        }
        if (StorySelection.woods == true)
        {
            wood.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
