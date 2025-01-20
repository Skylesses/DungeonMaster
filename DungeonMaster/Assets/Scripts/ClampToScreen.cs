using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampToScreen : MonoBehaviour
{
    public float yPos = 4;
    public float xPos = 8;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -xPos, xPos),
            Mathf.Clamp(transform.position.y, -yPos, yPos), transform.position.z);
    }
}
