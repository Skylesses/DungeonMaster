using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNDrop : MonoBehaviour
{
    //obj's for dragging and dropping
    public GameObject dragObj;
    //public GameObject dragPos;
    //public float dropDistance;

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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(dragObj.tag) /*&& mouseDown == false*/)
        {
            dragObj.transform.position = other.transform.position;
            Debug.Log(other.name);
        }
    }
}
