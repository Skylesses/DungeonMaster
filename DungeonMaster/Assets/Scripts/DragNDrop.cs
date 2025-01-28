using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragNDrop : MonoBehaviour,  IPointerClickHandler
{   
    public GameObject dropPos;
    private GameObject dragObj;

    public float dropDistance;

    private bool isLocked;

    Vector3 objStartPos;

    private void Start()
    {
        dragObj = this.gameObject;
        objStartPos = dragObj.transform.position;
        isLocked = false;
    }

    public void DragObj()
    {
        if(!isLocked)
        {
            dragObj.transform.position = Input.mousePosition;
        }
       
    }

    public void DropObj()
    {
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
        if(eventData.button == PointerEventData.InputButton.Right)
        {
            dragObj.transform.position = objStartPos;
            isLocked = false;
        }
    }
}
