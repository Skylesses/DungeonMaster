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
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedTile = 0;
            RenderUITiles();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedTile = 1;
            RenderUITiles();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectedTile = 2;
            RenderUITiles();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            selectedTile = 3;
            RenderUITiles();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            selectedTile = 4;
            RenderUITiles();
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            selectedTile = 5;
            RenderUITiles();
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            selectedTile = 6;
            RenderUITiles();
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            selectedTile = 7;
            RenderUITiles();
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            selectedTile = 8;
            RenderUITiles();
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            selectedTile = 9;
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
    }
    void PlaceTile()
    {
        Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int cellPos = tilemap.WorldToCell(position);
        tilemap.SetTile(cellPos, tiles[selectedTile]);

        CheckIfFull();
    }

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
        if (CountTiles() >= 180)
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

        Vector3Int minBounds = tilemap.cellBounds.min;
        Vector3Int maxBounds = tilemap.cellBounds.max;

        // Loop through grid cells
        for (int x = minBounds.x; x < maxBounds.x; x++)
        {
            for (int y = minBounds.y; y < maxBounds.y; y++)
            {
                Vector3Int cellPos = new Vector3Int(x, y, 0);

                //cell position not null?
                if (tilemap.GetTile(cellPos) != null)
                {
                    count++;
                }
            }
        }
        return count;        
    }

    //load next scene
    public void LoadNextScene()
    {
        SceneManager.LoadScene("Ending");
    }
}

