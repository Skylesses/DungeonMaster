using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragNDrop : MonoBehaviour,  IPointerClickHandler
{   
    //dragobj and drop position
    public GameObject dropPos;
    private GameObject dragObj;

    public float dropDistance;

    private bool isLocked;

    Vector3 objStartPos;

    private void Start()
    {
        //set dragobj and starting position
        dragObj = this.gameObject;
        objStartPos = dragObj.transform.position;
        isLocked = false;
    }

    private void Update()
    {
        //lock obj's to dropspot for weapons on props
        if(isLocked == true)
        {
            dragObj.transform.position = dropPos.transform.position;
        }
    }

    public void DragObj()
    {
        //drag
        if(!isLocked)
        {
            dragObj.transform.position = Input.mousePosition;
        }
       
    }

    public void DropObj()
    {
        //drop
        float Distance = Vector3.Distance(dragObj.transform.position, dropPos.transform.position);
        if(Distance < dropDistance)
        {
            isLocked = true;
            dragObj.transform.position = dropPos.transform.position;
        }
        else
        {
            dragObj.transform.position = objStartPos;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {  
        //reset after drop if needed
        if(eventData.button == PointerEventData.InputButton.Right)
        {
            dragObj.transform.position = objStartPos;
            isLocked = false;
        }
    }
}
