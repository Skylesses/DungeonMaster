using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using SFB;

public class SaveImages : MonoBehaviour
{
    public void SaveImage()
    {
        StartCoroutine(CaptureAndSaveFullScreen());
    }

    private IEnumerator CaptureAndSaveFullScreen()
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
        Object.Destroy(screenTexture);
    }
}
