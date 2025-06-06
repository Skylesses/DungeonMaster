using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DicebagController : MonoBehaviour
{
    //obj's for dragging and dropping
    public GameObject dragObj;

    public bool mouseDown;

    private Vector3 mousePos;

    //dice for spawning
    public GameObject[] dice;
    public float spawnInterval = 2;

    private Coroutine spawnCoroutine;
    private bool isSpawning = false;

    Vector3 objStartPos;

    public GameObject nextLevel;

    //count of dice spawned
    private int diceCount;

    //text
    public GameObject startText;
    public GameObject nextTextOne;
    public GameObject nextTextTwo;
    public GameObject nextTextThree;

    public string nextScene;

    private void Start()
    {   //starting position
        objStartPos = dragObj.transform.position;

        nextLevel.SetActive(false);
        diceCount = 0;

        startText.SetActive(true);
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
    //move with mouse drag and start SpawnDice
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
        //stop SpawnDice
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
            diceCount++;
            yield return new WaitForSeconds(spawnInterval);
            //dice count 
            if(diceCount >= 20)
            {
                nextLevel.SetActive(true);
                startText.SetActive(false);
                nextTextOne.SetActive(true);
            }
            if(diceCount >= 35)
            {
                nextTextOne.SetActive(false);
                nextTextTwo.SetActive(true);
            }
            if(diceCount >= 50)
            {
                nextTextTwo.SetActive(false);
                nextTextThree.SetActive(true);
            }
        }
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}
