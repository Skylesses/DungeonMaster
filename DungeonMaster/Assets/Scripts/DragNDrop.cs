using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNDrop : MonoBehaviour
{
    public GameObject dragObj;
    public GameObject dropPos;

    public float dropDistance;

    public void DragObj()
    {
        dragObj.transform.position = Input.mousePosition;
    }

    public void DropObj()
    {
        float Distance = Vector3.Distance(dragObj.transform.position, dropPos.transform.position);
        if(Distance < dropDistance)
        {
            dragObj.transform.position = dropPos.transform.position;
        }
    }
}
