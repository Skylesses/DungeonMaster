using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class CanvasToImage : MonoBehaviour
{
    public Camera cam;
    public RenderTexture renderTexture;

    void Start()
    {
        CaptureCanvas();
    }

    public void CaptureCanvas()
    {
        //create texture from canvas
        RenderTexture.active = renderTexture;
        Texture2D tex = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGB24, false);
        tex.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        tex.Apply();

        //texture to image
        byte[] bytes = tex.EncodeToPNG();
        File.WriteAllBytes(Application.persistentDataPath + "/CanvasImage.png", bytes);

        RenderTexture.active = null;
        Destroy(tex);
    }
}
