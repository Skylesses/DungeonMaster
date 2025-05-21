using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using SFB;

public class SaveToDisk : MonoBehaviour
{
    public void SaveSpriteToDisk()
    {
        if (MapSprite.GlobalSpriteStorage.savedSprite == null)
        {
            Debug.LogWarning("No sprite to save!");
            return;
        }

        //get texture from sprite
        Sprite sprite = MapSprite.GlobalSpriteStorage.savedSprite;
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
