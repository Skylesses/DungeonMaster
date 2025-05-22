using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using SFB;

public class GetTilemapSprite2 : MonoBehaviour
{
    public Image map2;
    public GameObject saveButton;

    private void Start()
    {
        //get sprite from tilemap in Map Scene
        if(MapSprite2.GlobalSpriteStorage2.savedSprite2 != null)
        {
            map2.sprite = MapSprite2.GlobalSpriteStorage2.savedSprite2;
        }
    }

    public void SaveSpriteToDisk()
    {
        if (MapSprite2.GlobalSpriteStorage2.savedSprite2 == null)
        {
            Debug.LogWarning("No sprite to save!");
            return;
        }

        //get texture from sprite
        Sprite sprite = MapSprite2.GlobalSpriteStorage2.savedSprite2;
        Texture2D texture = sprite.texture;

        // Optional: Crop to the sprite's rect
        Rect rect = sprite.rect;
        Texture2D croppedTexture = new Texture2D((int)rect.width, (int)rect.height, TextureFormat.RGBA32, false);
        Color[] pixels = texture.GetPixels((int)rect.x, (int)rect.y, (int)rect.width, (int)rect.height);
        croppedTexture.SetPixels(pixels);
        croppedTexture.Apply();

        //open file dialog to choose path
        var path = StandaloneFileBrowser.SaveFilePanel("Save Sprite", "", "MapImage", "png");

        if (!string.IsNullOrEmpty(path))
        {
            byte[] bytes = croppedTexture.EncodeToPNG();
            File.WriteAllBytes(path, bytes);
            Debug.Log("Saved image to: " + path);
        }
        else
        {
            Debug.Log("Save cancelled.");
        }
    }
}
