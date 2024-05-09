using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class animal : MonoBehaviour
{
   
    Vector2 destination = new Vector2(-3, 0);

    public int speed;
    public AudioSource animalAppear;
    public GameObject animals;
    


    // Update is called once per frame
    void Update()
    {

        StartCoroutine(animalApp());

    }

    IEnumerator animalApp()
    {
        animalAppear.Play();
        animals.transform.position = Vector3.MoveTowards(animals.transform.position, destination, speed * Time.deltaTime);
        yield return new WaitForSeconds(0.5f);

    }

}
