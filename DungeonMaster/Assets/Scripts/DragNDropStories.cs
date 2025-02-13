using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragNDropStories : MonoBehaviour,  IPointerClickHandler
{   
    //dragobj and drop position
    public GameObject[] dropPosArray;    
    public GameObject rightPos;

    private GameObject nearestDropPos;
    private GameObject dragObj;

    public float dropDistance;

    //public GameObject otherObj;

    public bool isLocked;
    public bool correctPos;

    //private DragNDropStories otherObjScript;

    Vector3 objStartPos;

    private void Start()
    {
        //set dragobj and starting position
        dragObj = this.gameObject;
        objStartPos = dragObj.transform.position;
        isLocked = false;
        correctPos = false;

        //otherObjScript = otherObj.GetComponent<DragNDropStories>();
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
        //drop dragged obj
        float minDistance = dropDistance;
        nearestDropPos = null;

        foreach (GameObject dropPos in dropPosArray)
        {
            float Distance = Vector3.Distance(dragObj.transform.position, dropPos.transform.position);
            if(Distance < minDistance)
            {
                minDistance = Distance;
                nearestDropPos = dropPos;
            }
        } 
        //drop
        if (nearestDropPos != null)
        {
            isLocked = true;
            dragObj.transform.position = nearestDropPos.transform.position;
        }
        //reset obj
        else
        {
            dragObj.transform.position = objStartPos;
            correctPos = false;
        }

        //obj in the right drop position?
        if(nearestDropPos == rightPos)
        {
            correctPos = true;
        }

        //other Obj in drop spot? --> Obj can't be dropped
        /*if (otherObjScript != null && otherObjScript.isLocked == true)
        {
            Debug.Log("can't drop here");
            isLocked = false;
            correctPos = false;
            dragObj.transform.position = objStartPos;
            return;
        }*/
    }

    public void OnPointerClick(PointerEventData eventData)
    {  
        //reset after drop if needed
        if(eventData.button == PointerEventData.InputButton.Right)
        {
            dragObj.transform.position = objStartPos;
            isLocked = false;
            correctPos = false;
            nearestDropPos = null;
        }
    }
}
