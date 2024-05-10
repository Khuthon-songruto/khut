using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Pop : MonoBehaviour
{
    public GameObject targetObject;
    private static Pop instance;

    void Start()
    {

        gameObject.SetActive(false);

    }

    public void Show()
    {
        gameObject.SetActive(true);
        ChangeColor(targetObject, new Color(0.4f, 0.4f, 0.4f));
    }
    void ChangeColor(GameObject obj, Color color)
    {
        if (obj.GetComponent<Renderer>() != null)
        {
            obj.GetComponent<Renderer>().material.color = color;
        }
    }

    public void Hide()
    {
     
        gameObject.SetActive(false);
       
    }
}