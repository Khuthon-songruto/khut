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
            YButton.gameObject.SetActive(true); // GameObject�� Ȱ��ȭ�Ǿ� ������ ��ư�� Ȱ��ȭ
            NButton.gameObject.SetActive(true);
        }
        else
        {
            YButton.gameObject.SetActive(false); // GameObject�� ��Ȱ��ȭ�Ǿ� ������ ��ư�� ��Ȱ��ȭ
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
