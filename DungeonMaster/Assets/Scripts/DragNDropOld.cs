using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNDropOld : MonoBehaviour
{
    //obj's for dragging and dropping
    public GameObject dragObj;
    public GameObject dragPos;
    public float dropDistance;

    public bool mouseDown;

    private Vector3 mousePos;

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
    }

    private void OnMouseUp()
    {
        mouseDown = false;
    }

    public void DropObject()
    {
        float Distance = Vector3.Distance(dragObj.transform.position, dragPos.transform.position);
        if(Distance < dropDistance && mouseDown == false)
        {
            dragObj.transform.position = dragPos.transform.position;
            dragObj.transform.rotation = dragPos.transform.rotation;
            Debug.Log("drop");
        }
    }

    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(dragObj.tag) && mouseDown == false)
        {
            dragObj.transform.position = other.transform.position;
            Debug.Log(other.name);
        }
    }*/
}
