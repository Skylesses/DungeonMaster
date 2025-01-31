using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class MapBuildManager : MonoBehaviour
{
    //set tiles and tilemap
    public Tilemap tilemap;
    public Tile[] tiles;
    public List<GameObject> UITiles;

    //current tiles selected
    public int selectedTile = 0;

    public Transform tileGridUI;

    private void Start()
    {
        int i = 0;
        foreach(Tile tile in tiles)
        {
            GameObject UITile = new GameObject("UI Tile");
            UITile.transform.parent = tileGridUI;
            UITile.transform.localScale = new Vector3(1f, 1f, 1f);

            Image UIImage = UITile.AddComponent<Image>();
            UIImage.sprite = tile.sprite;

            Color tileColor = UIImage.color;
            tileColor.a = 0.5f;

            if(i == selectedTile)
            {
                tileColor.a = 1f;
            }
            UIImage.color = tileColor;
            UITiles.Add(UITile);

            i++;
        }
    }
}
