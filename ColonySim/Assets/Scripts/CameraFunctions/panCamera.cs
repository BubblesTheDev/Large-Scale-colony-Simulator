using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panCamera : MonoBehaviour
{
    public float maxX, minX, maxY, minY;

    private Vector3 startPos;
    public Camera cam;

    public void Update()
    {
        moveCam();

    }

    void moveCam()
    {
        if (Input.GetMouseButtonDown(0)) startPos = cam.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButton(0))
        {
            Vector3 difference = startPos - cam.ScreenToWorldPoint(Input.mousePosition);

            cam.transform.position += difference;
        }
    }
}
