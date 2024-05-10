using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public static Vector2 DefaultPos;
    public static bool collN = false;
    public bool okN = false;

    void Update()
    {

    }
    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        DefaultPos = this.transform.position;
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        Vector2 currentPos = eventData.position;
        this.transform.position = currentPos;

        if (currentPos.x >= 1200 && currentPos.x <= 1600 && currentPos.y >= 600 && currentPos.y <= 800)
        {
            if (!okN)
            {
                collN = true;
                okN = true;
            }

        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        StartCoroutine(StayInPlaceForASecond());
    }

    IEnumerator StayInPlaceForASecond()
    {
        yield return new WaitForSeconds(1f);
        transform.position = DefaultPos;
    }
}