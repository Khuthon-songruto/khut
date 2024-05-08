using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clickB : MonoBehaviour
{
    public Button viewbutton;
    public AudioSource docSound;
    public GameObject doc;
    public bool docMag = false;

    // Update is called once per frame
    void Start()
    {
        gameObject.GetComponent<GameObject>();
    }

    private void Update()
    {
        
    }

    public void docView()
    {
        docSound.Play();


    }

    public void Yes()
    {
        doc.SetActive(false);

    }
}
