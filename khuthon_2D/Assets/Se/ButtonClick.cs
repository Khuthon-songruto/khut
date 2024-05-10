using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clickYes()
    {
        Debug.Log("Yes");
        GameManager.Instance.yesStamp = true;
        Debug.Log(GameManager.Instance.yesStamp);
    }

    public void clickNo()
    {
        Debug.Log("NO");
        GameManager.Instance.noStamp = true;
    }
}
