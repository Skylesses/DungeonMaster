using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class MapBuildManager : MonoBehaviour
{
    //set tiles and tilemap
    public Tilemap tilemap;
    public Tile[] tiles;
    public List<GameObject> UITiles;

    //current tiles selected
    public int selectedTile = 0;

    public Transform tileGridUI;

    public GameObject nextLevel;

    Vector3 mousePos;

    private void Start()
    {
        //set tile UI
        int i = 0;
        foreach (Tile tile in tiles)
        {
            GameObject UITile = new GameObject("UI Tile");
            UITile.transform.parent = tileGridUI;
            UITile.transform.localScale = new Vector3(1f, 1f, 1f);

            Image UIImage = UITile.AddComponent<Image>();
            UIImage.sprite = tile.sprite;

            Color tileColor = UIImage.color;
            tileColor.a = 0.5f;

            if (i == selectedTile)
            {
                tileColor.a = 1f;
            }
            UIImage.color = tileColor;
            UITiles.Add(UITile);

            i++;
        }

        nextLevel.SetActive(false);

        int tileCount = CountTiles();
        Debug.Log("" + tileCount);
    }

    private void Update()
    {
        //select tile
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll > 0f)
        {
            selectedTile = (selectedTile + 1) % tiles.Length;
            RenderUITiles();
        }
        else if (scroll < 0f)
        {
            selectedTile = (selectedTile - 1 + tiles.Length) % tiles.Length;
            RenderUITiles();
        }

        //place tile
        if (Input.GetMouseButton(0))
        {
            PlaceTile();
        }
        //delete tile
        if (Input.GetMouseButton(1))
        {
            DeleteTile();
        }

        mousePos = Input.mousePosition;

        mousePos.x = Mathf.Clamp(mousePos.x, 0, Screen.width);
        mousePos.y = Mathf.Clamp(mousePos.y, 0, Screen.height);

        Cursor.SetCursor(null, new Vector2(mousePos.x, mousePos.y), CursorMode.Auto);

    }

    //place tile on mouse position
    void PlaceTile()
    {
        Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int cellPos = tilemap.WorldToCell(position);
        tilemap.SetTile(cellPos, tiles[selectedTile]);

        CheckIfFull();
    }

    //delete tile on mouse position
    void DeleteTile()
    {
        Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int cellPos = tilemap.WorldToCell(position);
        tilemap.SetTile(cellPos, null);

        CheckIfFull();
    }

    //select tile out of selection
    void RenderUITiles()
    {
        int i = 0;
        foreach(GameObject tile in UITiles)
        {
            Image UIImage = tile.GetComponent<Image>();
            Color tileColor = UIImage.color;
            tileColor.a = 0.5f;

            if(i == selectedTile)
            {
                tileColor.a = 1;
            }

            UIImage.color = tileColor;

            i++; 
        }
    }

    //tilemap full?
    void CheckIfFull()
    {
        Debug.Log("check");
        if (CountTiles() >= 72)
        {
            Debug.Log("isFull");
            nextLevel.SetActive(true);
        }
        else
        {
            Debug.Log("notFull");
            nextLevel.SetActive(false);
        }
    }

    //check tile count
    int CountTiles()
    {
        int count = 0;

        //min max positions of grid
        Vector3Int minBounds = tilemap.cellBounds.min;
        Vector3Int maxBounds = tilemap.cellBounds.max;

        // Loop through grid cells
        for (int x = minBounds.x; x < maxBounds.x; x++)
        {
            for (int y = minBounds.y; y < maxBounds.y; y++)
            {
                Vector3Int cellPos = new Vector3Int(x, y, 0);

                //tile in cell?
                if (tilemap.GetTile(cellPos) != null)
                {
                    count++;
                }
            }
        }
        Debug.Log("tile count" + count);
        return count;        
    }
}

