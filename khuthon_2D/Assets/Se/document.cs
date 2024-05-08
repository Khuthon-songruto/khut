using System.Collections;
using UnityEngine;

public class document : MonoBehaviour
{
    Vector2 destination = new Vector2(0, -8);
    public GameObject doc;
    public int speed;

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(docApp());
    }

    IEnumerator docApp()
    {
        yield return new WaitForSeconds(0.5f);
        doc.transform.position = Vector3.MoveTowards(doc.transform.position, destination, speed * Time.deltaTime);
        
    }
}
