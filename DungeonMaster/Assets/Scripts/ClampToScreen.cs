using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampToScreen : MonoBehaviour
{
    public Camera cam;
    private Vector3 screenBounds;

    private float objWidth;
    private float objHeight;

    private void Start()
    {
        cam = Camera.main;
        screenBounds = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, cam.transform.position.z));
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        objWidth = sr.bounds.extents.x;
        objHeight = sr.bounds.extents.y;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -screenBounds.x + objWidth, screenBounds.x - objWidth),
            Mathf.Clamp(transform.position.y, -screenBounds.y + objHeight, screenBounds.y - objHeight), transform.position.z);
    }
}
