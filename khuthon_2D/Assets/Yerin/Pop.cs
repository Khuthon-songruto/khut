using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Pop : MonoBehaviour
{
    private static Pop instance;

    void Start()
    {

        gameObject.SetActive(false);

    }

    public void Show()
    {
        gameObject.SetActive(true);
    }


    public void Hide()
    {
     
        gameObject.SetActive(false);
       
    }
}