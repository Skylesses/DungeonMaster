using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampToScreen : MonoBehaviour
{
    public RectTransform canvasRect;
    private RectTransform obj;

    void Start()
    {
        obj = GetComponent<RectTransform>();
    }

    void Update()
    {
        ClampToBounds();
    }

    void ClampToBounds()
    {
        if (canvasRect == null || obj == null) return;

        // get position of obj
        Vector3[] canvasCorners = new Vector3[4];
        canvasRect.GetWorldCorners(canvasCorners);

        Vector3[] elementCorners = new Vector3[4];
        obj.GetWorldCorners(elementCorners);

        Vector3 position = obj.position;

        // Clamp position
        position.x = Mathf.Clamp(position.x, canvasCorners[0].x + obj.rect.width / 2, canvasCorners[2].x - obj.rect.width / 2);
        position.y = Mathf.Clamp(position.y, canvasCorners[0].y + obj.rect.height / 2, canvasCorners[2].y - obj.rect.height / 2);
        obj.position = position;
    }
}
