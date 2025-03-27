using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.IO;

public class MapScreenshot : MonoBehaviour
{
    public Camera tilemapCamera;
    public Tilemap tilemap;
    public int imageWidth;
    public int imageHeight;
    public SpriteRenderer spriteRenderer;

    private void Start()
    {
        imageWidth = Screen.width;
        imageHeight = Screen.height;
    }

    public void SaveNow()
    {
        string fileName = "TilemapScreenshot.png";
        Texture2D texture = CaptureTilemapAsTexture();
        SaveTextureAsPNG(texture, fileName);

        // Convert to Sprite and Apply to SpriteRenderer
        if (spriteRenderer != null)
        {
            Sprite sprite = TextureToSprite(texture);
            spriteRenderer.sprite = sprite;
        }
    }

    private Texture2D CaptureTilemapAsTexture()
    {
        //create a RenderTexture
        RenderTexture renderTexture = new RenderTexture(imageWidth, imageHeight, 24);
        tilemapCamera.targetTexture = renderTexture;

        //render the Tilemap
        tilemapCamera.Render();

        //convert to Texture2D
        Texture2D texture = new Texture2D(imageWidth, imageHeight, TextureFormat.RGBA32, false);
        RenderTexture.active = renderTexture;
        texture.ReadPixels(new Rect(0, 0, imageWidth, imageHeight), 0, 0);
        texture.Apply();

        //cleanup
        RenderTexture.active = null;
        tilemapCamera.targetTexture = null;
        Destroy(renderTexture);

        return texture;
    }

    private void SaveTextureAsPNG(Texture2D texture, string fileName)
    {
        byte[] bytes = texture.EncodeToPNG();
        string path = Path.Combine(Application.persistentDataPath, fileName);
        File.WriteAllBytes(path, bytes);
        Debug.Log("Tilemap saved to: " + path);
    }

    private Sprite TextureToSprite(Texture2D texture)
    {
        return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
    }
}
