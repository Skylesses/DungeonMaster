using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetTilemapSprite2 : MonoBehaviour
{
    public Image map2;

    private void Start()
    {
        //get sprite from tilemap in Map Scene
        if(MapSprite2.GlobalSpriteStorage2.savedSprite2 != null)
        {
            map2.sprite = MapSprite2.GlobalSpriteStorage2.savedSprite2;
        }
    }
}
