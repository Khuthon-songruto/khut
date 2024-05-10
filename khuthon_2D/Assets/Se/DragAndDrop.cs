using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public static Vector2 DefaultPos;
    Vector2 destination3 = new Vector2(15, 0);
    Vector2 destination4 = new Vector2(0, -12);
    public static bool collN = false;
    public bool okN = false;
    public GameManager gameManager;

    public GameObject animals;
    public GameObject doc;
    public int speed = 50;
    void Start()
    {
 
    }

    void Update()
    {
        if (okN)
        {
            StartCoroutine(aniDocDisapp());
        }
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

    IEnumerator aniDocDisapp()
    {
        yield return new WaitForSeconds(1.5f);
        animals.transform.position = Vector3.MoveTowards(animals.transform.position, destination3, speed * Time.deltaTime);
        yield return new WaitForSeconds(0.5f);
        //doc.transform.position = Vector3.MoveTowards(doc.transform.position, destination4, speed * Time.deltaTime);
        Destroy(doc);
    }
}