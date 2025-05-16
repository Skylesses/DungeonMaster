using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveProps : MonoBehaviour
{
    public static GameObject skeletOne;
    public static GameObject skeletTwo;
    public static GameObject zombie;
    public static GameObject sailorOne;
    public static GameObject sailorTwo;
    public static GameObject drake;
    public static GameObject banditOne;
    public static GameObject banditTwo;
    public static GameObject guard;
    public static GameObject spider;
    public static GameObject goblinOne;
    public static GameObject goblinTwo;
    public static GameObject ogre;

    private void Start()
    {
        DontDestroyOnLoad(skeletOne);
        DontDestroyOnLoad(skeletTwo);
        DontDestroyOnLoad(zombie);
        DontDestroyOnLoad(sailorOne);
        DontDestroyOnLoad(sailorTwo);
        DontDestroyOnLoad(drake);
        DontDestroyOnLoad(banditOne);
        DontDestroyOnLoad(banditTwo);
        DontDestroyOnLoad(guard);
        DontDestroyOnLoad(spider);
        DontDestroyOnLoad(goblinOne);
        DontDestroyOnLoad(goblinTwo);
        DontDestroyOnLoad(ogre);
    }

    //save the prop as prefab for later
    public void SaveObjects()
    {
        skeletOne = GameObject.Find("Skeleton");
        skeletTwo = GameObject.Find("Skeleton (1)");
        zombie = GameObject.Find("Zombie");
        sailorOne = GameObject.Find("Sailor");
        sailorTwo = GameObject.Find("Sailor (1)");
        drake = GameObject.Find("Wyrmling");
        banditOne = GameObject.Find("Bandit");
        banditTwo = GameObject.Find("Bandit (1)");
        guard = GameObject.Find("Guard");
        spider = GameObject.Find("GiantSpider");
        goblinOne = GameObject.Find("Goblin");
        goblinTwo = GameObject.Find("Goblin (1)");
        ogre = GameObject.Find("Ogre");

        skeletOne.transform.SetParent(null);
        skeletTwo.transform.SetParent(null);
        zombie.transform.SetParent(null);
        sailorOne.transform.SetParent(null);
        sailorTwo.transform.SetParent(null);
        drake.transform.SetParent(null);
        banditOne.transform.SetParent(null);
        banditTwo.transform.SetParent(null);
        guard.transform.SetParent(null);
        spider.transform.SetParent(null);
        goblinOne.transform.SetParent(null);
        goblinTwo.transform.SetParent(null);
        ogre.transform.SetParent(null);

    }
}
