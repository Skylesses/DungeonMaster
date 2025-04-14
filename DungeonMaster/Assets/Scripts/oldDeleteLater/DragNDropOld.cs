using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNDropOld : MonoBehaviour
{
    //obj's for dragging and dropping
    public GameObject dragObj;
    public float dropDistance;

    public bool mouseDown;

    private Vector3 mousePos;

    public GameObject[] dice;
    public float spawnInterval = 2;

    private Coroutine spawnCoroutine;
    private bool isSpawning = false;

    Vector3 objStartPos;

    private void Start()
    {
        objStartPos = dragObj.transform.position;
    }

    private Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        mousePos = Input.mousePosition - GetMousePos();
        mouseDown = true;
    }
    //move with mouse drag
    private void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePos);
        if(!isSpawning)
        {
            spawnCoroutine = StartCoroutine(SpawnDice());
            isSpawning = true;
        }    
    }

    private void OnMouseUp()
    {
        mouseDown = false;

        if(spawnCoroutine != null)
        {
            StopCoroutine(SpawnDice());
            spawnCoroutine = null;
        }

        isSpawning = false;
        dragObj.transform.position = objStartPos;
    }

    public IEnumerator SpawnDice()
    {
        yield return new WaitForSeconds(spawnInterval);
        while(mouseDown)
        {
            int randomIndex = Random.Range(0, dice.Length);
            Instantiate(dice[randomIndex], new Vector3(dragObj.transform.position.x, dragObj.transform.position.y), dice[randomIndex].transform.rotation);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
