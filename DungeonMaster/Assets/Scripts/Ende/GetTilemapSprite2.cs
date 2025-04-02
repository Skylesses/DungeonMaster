using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetTilemapSprite2 : MonoBehaviour
{
    public Image map;

    private void Start()
    {
        //get sprite from tilemap in Map Scene
        if(MapSprite2.GlobalSpriteStorage2.savedSprite != null)
        {
            map.sprite = MapSprite.GlobalSpriteStorage.savedSprite;
        }
    }
}
