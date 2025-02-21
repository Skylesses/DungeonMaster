using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DicebagController : MonoBehaviour
{
    public GameObject[] dice;
    public float startDelay = 2;
    public float spawnInterval = 2;

    public GameObject canvas;

    private GameObject dragObj;

    Vector3 objStartPos;

    // Start is called before the first frame update
    void Start()
    {
        //set dragobj and starting position
        dragObj = this.gameObject;
        objStartPos = dragObj.transform.position;
    }

    public void DragObj()
    {
        //drag the obj with the mouse
        dragObj.transform.position = Input.mousePosition;
        //InvokeRepeating("SpawnDice", startDelay, spawnInterval);
    }

    public void DropObj()
    {   
        //reset to 
        dragObj.transform.position = objStartPos;
        //CancelInvoke("SpawnDice");
    }

    public void SpawnDice()
    {
        int randomIndex = Random.Range(0, dice.Length);
        GameObject spawnedDice = Instantiate(dice[randomIndex], new Vector3(dragObj.transform.position.x, dragObj.transform.position.y), dice[randomIndex].transform.rotation);
        spawnedDice.transform.SetParent(canvas.transform);
    }
}
