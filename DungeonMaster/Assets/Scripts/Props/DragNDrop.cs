using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragNDrop : MonoBehaviour, IPointerClickHandler
{
    //dragobj and drop position
    public GameObject[] dropPosArray;
    
    private GameObject nearestDropPos;
    private GameObject dragObj;

    private static Dictionary<GameObject, GameObject> occupiedDropSpots = new Dictionary<GameObject, GameObject>();

    public float dropDistance;
    public bool isLocked;
    
    //public GameObject otherObj;
    //private DragNDrop otherObjscript;

    Vector3 objStartPos;

    private void Start()
    {
        //set dragobj and starting position
        dragObj = this.gameObject;
        objStartPos = dragObj.transform.position;
        isLocked = false;

        //otherObjscript = otherObj.GetComponent<DragNDrop>();
    }

    private void Update()
    {
        //lock obj's to dropspot for weapons on props
        if(isLocked == true)
        {
            dragObj.transform.position = nearestDropPos.transform.position;
        }      
    }

    public void DragObj()
    {
        //drag the obj with the mouse
        if (!isLocked)
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
            //check distance between dragged obj and drop spots
            float Distance = Vector3.Distance(dragObj.transform.position, dropPos.transform.position);
            if (Distance < minDistance)
            {
                minDistance = Distance;
                nearestDropPos = dropPos;
            }
        }
        
        if (nearestDropPos != null)
        {
            //drop spot taken? --> reset obj
            if (occupiedDropSpots.ContainsKey(nearestDropPos))
            {
                Debug.Log("can't drop here");
                dragObj.transform.position = objStartPos;
                return;
            }
            //drop
            isLocked = true;
            dragObj.transform.position = nearestDropPos.transform.position;
            occupiedDropSpots[nearestDropPos] = dragObj;
        }
        //reset obj
        else
        {
            dragObj.transform.position = objStartPos;
        }

        //other Obj in drop spot? --> Obj can't be dropped
        /*if (otherObjscript != null && otherObjscript.isLocked == true)
        {
            Debug.Log("can't drop here");
            isLocked = false;
            dragObj.transform.position = objStartPos;
            return;
        }*/
    }

    public void OnPointerClick(PointerEventData eventData)
    {  
        //reset after drop if needed
        if(eventData.button == PointerEventData.InputButton.Right)
        {
            if (isLocked && occupiedDropSpots.ContainsKey(nearestDropPos))
            {
                occupiedDropSpots.Remove(nearestDropPos);
            }
            dragObj.transform.position = objStartPos;
            isLocked = false;
        }
    }
}
