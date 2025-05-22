using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using SFB;

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
        saveOneShot.SetActive(false);

        StartCoroutine(CaptureAndSaveFullScreen(() =>
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
            savePropsOne.SetActive(true);
        }));
    }

    public void changeToPropsTwo()
    {   
        savePropsOne.SetActive(false);

        StartCoroutine(CaptureAndSaveFullScreen(() =>
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
            savePropsTwo.SetActive(true);
        }));
    }

    public void changeToMapOne()
    {
        savePropsTwo.SetActive(false);

        StartCoroutine(CaptureAndSaveFullScreen(() =>
        {
            tavernTwo.SetActive(false);
            shipTwo.SetActive(false);
            jailTwo.SetActive(false);
            woodsTwo.SetActive(false);

            mapOne.SetActive(true);

            saveMapOne.SetActive(true);
        }));
    }

    public void changeToMapTwo()
    {
        saveMapOne.SetActive(false);

        StartCoroutine(CaptureAndSaveFullScreen(() =>
        {
            mapOne.SetActive(false);
            mapTwo.SetActive(true);

        }));
    }

    private IEnumerator CaptureAndSaveFullScreen(Action onComplete)
    {
        //ensure image is fully rendered
        yield return new WaitForEndOfFrame();

        //capture screen as Texture2D
        Texture2D screenTexture = ScreenCapture.CaptureScreenshotAsTexture();

        //open file save dialog
        string path = StandaloneFileBrowser.SaveFilePanel("Save Screenshot", "", "FullScreenImage", "png");

        if (!string.IsNullOrEmpty(path))
        {
            byte[] pngData = screenTexture.EncodeToPNG();
            File.WriteAllBytes(path, pngData);
            Debug.Log("Saved full screen image to: " + path);
        }
        else
        {
            Debug.Log("Save cancelled.");
        }

        //clean up
        //Object.Destroy(screenTexture);

        onComplete?.Invoke();
    }
}
