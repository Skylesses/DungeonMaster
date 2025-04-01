using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.IO;

public class MapSprite : MonoBehaviour
{
    public Tilemap tilemap;
    public Camera renderCamera;

    public static class GlobalSpriteStorage
    {
        public static Sprite savedSprite;
    }

    public void SaveTilemapAsSprite()
    {
        //set up the RenderTexture
        int width = Screen.width;
        int height = Screen.height;
        RenderTexture rt = new RenderTexture(width, height, 24);
        renderCamera.targetTexture = rt;
        renderCamera.Render();

        //convert RenderTexture to Texture2D
        Texture2D texture = new Texture2D(width, height, TextureFormat.RGBA32, false);
        RenderTexture.active = rt;
        texture.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        texture.Apply();
        RenderTexture.active = null;

        //convert Texture2D to Sprite
        Sprite newSprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));

        //store sprite for later
        GlobalSpriteStorage.savedSprite = newSprite;
    }
}
