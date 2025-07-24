using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{

    private bool dragging;

    private Vector2 offset, origin;

    void Awake()
    {
        origin = transform.position;
    }

    void Update()
    {
        if (!dragging)
        {
            return;
        }

        var mousePosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = mousePosition - offset;

    }

    void OnMouseDown()
    {
        dragging = true;

        offset = getMousePos() - (Vector2)transform.position;
    }

    void OnMouseUp()
    {
        transform.position = origin;
        dragging = false;
    }

    Vector2 getMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
