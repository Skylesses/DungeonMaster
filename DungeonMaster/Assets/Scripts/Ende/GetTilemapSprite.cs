using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetTilemapSprite : MonoBehaviour
{
    public Image image;


    private void Start()
    {
        if(MapSprite.GlobalSpriteStorage.savedSprite != null)
        {
            image.sprite = MapSprite.GlobalSpriteStorage.savedSprite;
        }
    }
}
