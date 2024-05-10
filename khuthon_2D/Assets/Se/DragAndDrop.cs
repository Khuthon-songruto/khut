using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private Vector2 firstTouch;
    GameObject stamp;
    GameObject square;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firstTouch = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Ray2D ray2D = new Ray2D(firstTouch, Vector2.zero);
            RaycastHit2D hit = Physics2D.Raycast(ray2D.origin, ray2D.direction);

            if (hit.collider != null && hit.collider.gameObject != stamp )
            {
                stamp = hit.collider.gameObject;
                //stamp.isMove = true;
            }
        }
    }
}
