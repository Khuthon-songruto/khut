using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BtnType : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
   public BTNType currentType;

    // public Transform buttonScale;
    //Vector3 defaultScale;

    private void Start()
    {
       // defaultScale = buttonScale.localScale;
    }

   public void OnBtnClick()
    {
        switch (currentType)
        {
            case BTNType.LeftClick:
                GameManager.Instance.Popup.gameObject.SetActive(false);
                Debug.Log("�������"); // ��� ���شٿ� �Լ� ����� �θ��� �ɵ�
                SceneManager.LoadScene(2);
                break;

            case BTNType.MiddleClick:
                GameManager.Instance.Popup.gameObject.SetActive(false);
                Debug.Log("���");
                SceneManager.LoadScene(2);
                break;

            case BTNType.RightClick:
                GameManager.Instance.Popup.gameObject.SetActive(false);
                Debug.Log("���ʽ�");
                SceneManager.LoadScene(2);
                break;

            case BTNType.NextDay:
                GameManager.Instance.Popup.gameObject.SetActive(false);
                Debug.Log("������");
                SceneManager.LoadScene(2);
                break;
        }
    } 

    public void OnPointerEnter(PointerEventData eventData)
    {
    //    buttonScale.localScale = defaultScale * 1.2f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
    //    buttonScale.localScale = defaultScale ;
    }

}
