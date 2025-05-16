using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSavedProps : MonoBehaviour
{
    public Vector2 skeletOne;
    public Vector2 skeletTwo;
    public Vector2 zombie;
    public Vector2 sailorOne;
    public Vector2 sailorTwo;
    public Vector2 drake;
    public Vector2 banditOne;
    public Vector2 banditTwo;
    public Vector2 guard;
    public Vector2 spider;
    public Vector2 goblinOne;
    public Vector2 golbinTwo;
    public Vector2 ogre;

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoad;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoad;
    }

    void OnSceneLoad(Scene Ending, LoadSceneMode single)
    {
        SaveProps.skeletOne.transform.position = skeletOne;
        SaveProps.skeletTwo.transform.position = skeletTwo;
        SaveProps.zombie.transform.position = zombie;
        SaveProps.sailorOne.transform.position = sailorOne;
        SaveProps.sailorTwo.transform.position = sailorTwo;
        SaveProps.drake.transform.position = drake;
        SaveProps.banditOne.transform.position = banditOne;
        SaveProps.banditTwo.transform.position = banditTwo;
        SaveProps.guard.transform.position = guard;
        SaveProps.spider.transform.position = spider;
        SaveProps.goblinOne.transform.position = goblinOne;
        SaveProps.goblinTwo.transform.position = golbinTwo;
        SaveProps.ogre.transform.position = ogre;
    }

}
