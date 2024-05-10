using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    public GameObject makeDoc;
    public Button YButton;
    public Button NButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (makeDoc.activeSelf)
        {
            YButton.gameObject.SetActive(true); // GameObject가 활성화되어 있으면 버튼도 활성화
            NButton.gameObject.SetActive(true);
        }
        else
        {
            YButton.gameObject.SetActive(false); // GameObject가 비활성화되어 있으면 버튼도 비활성화
            NButton.gameObject.SetActive(false);
        }
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
