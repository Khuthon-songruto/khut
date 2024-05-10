using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class employeeEnter : MonoBehaviour
{
    //게임매니저에서 bool 따로 코드 만들고, colly -> 겜메 -> 
    Vector2 destination1 = new Vector2(-3, 0);
    Vector2 destination2 = new Vector2(0, -8);
    Vector2 firstVec = new Vector2(-7, 0);
    public GameObject doc;
    public GameObject animals;
    public GameObject makeDoc;
    public int speed;
    public bool isStamped = false;
    public bool isRunning = true;

    [SerializeField]
    public TextMeshPro[] text;
    public TextMeshPro[] gauge;
    //public AudioSource animalAppear;
    //public AudioSource docAppear;

    private void Start()
    {

        StartCoroutine(aniDocApp());
    }
    private void Update()
    {
        if (!isRunning) // isRunning이 false면 아래의 코드는 실행되지 않음
        {
            doc.SetActive(false);
            animals.SetActive(false);
            makeDoc.SetActive(false);
            return;
        }

        if (Input.GetMouseButtonDown(0)) // 왼쪽 마우스 버튼 클릭 여부 확인
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == doc) // Doc 오브젝트를 클릭했는지 확인
            {
                // makeDoc 오브젝트를 생성
                makeDoc.SetActive(true);
                doc.SetActive(false);

            }
        }

        if (GameManager.Instance.yesStamp == true || GameManager.Instance.noStamp == true)
        {
            StopCoroutine(aniDocApp());
            if (!isStamped)
            {
                Debug.Log("bb");
                StartCoroutine(aniDocDisapp());
                isStamped = true;
            }
            if (GameManager.Instance.yesStamp == true)
            {
                gaugemake();
                GameManager.Instance.yesStamp = false;
            }
            if (GameManager.Instance.yesStamp == false)
            {
                gaugemake2();
                GameManager.Instance.noStamp = false;
            }


        }
    }
    public void StopAction()
    {
        isRunning = false;
    }

    IEnumerator aniDocApp()
    {
        animals.transform.position = Vector3.MoveTowards(animals.transform.position, destination1, speed * Time.deltaTime);
        yield return new WaitForSeconds(0.5f);
        doc.transform.position = Vector3.MoveTowards(doc.transform.position, destination2, speed * Time.deltaTime);

    }

    IEnumerator aniDocDisapp()
    {

        yield return new WaitForSeconds(1f);
        animals.SetActive(false);
        //ield return new WaitForSeconds(0.5f);
        makeDoc.SetActive(false);

        // 여기서 몇 초 기다린 후 초기화 및 aniDocApp() 다시 시작
        animals.transform.position = firstVec;
        yield return new WaitForSeconds(1.0f); // 예를 들어 3초 후에 초기화 및 재시작한다고 가정
        ResetVariables(); // 모든 변수를 초기화하는 메소드 호출

    }

    void ResetVariables()
    {
        // 변수 초기화 예시입니다. 실제 게임의 로직에 맞게 조정해야 합니다.
        isStamped = false;
        animals.SetActive(true);
        doc.SetActive(true);
        makeDoc.SetActive(false);
        GameManager.Instance.yesStamp = false;
        GameManager.Instance.noStamp = false;
        UpdateTextIndex();
    }
    void gaugemake()
    {
        if (GameManager.Instance.currentTextIndex == 0)
        {
            Debug.Log("2");
            GameManager.Instance.set_all(-13, 20, -20, -20);
        }
        if (GameManager.Instance.currentTextIndex == 1)
        {
            Debug.Log("3");
            GameManager.Instance.set_all(20, -25, 20, 15);
        }
        if (GameManager.Instance.currentTextIndex == 2)
        {
            GameManager.Instance.set_all(-20, 25, -20, -10);
        }
        if (GameManager.Instance.currentTextIndex == 3)
        {
            GameManager.Instance.set_all(20, -20, 20, 20);
        }
        if (GameManager.Instance.currentTextIndex == 4)
        {
            GameManager.Instance.set_all(-15, 20, -10, -5);
        }
        if (GameManager.Instance.currentTextIndex == 5)
        {
            GameManager.Instance.set_all(-15, 10, -10, -10);
        }
    }

    void gaugemake2()
    {
        if (GameManager.Instance.currentTextIndex == 0)
        {
            GameManager.Instance.set_all(0, 40, 0, 0);
        }
        if (GameManager.Instance.currentTextIndex == 1)
        {
            GameManager.Instance.set_all(-20, 0, -15, 0);
        }
        if (GameManager.Instance.currentTextIndex == 2)
        {
            GameManager.Instance.set_all(15, 0, 0, 0);
        }
        if (GameManager.Instance.currentTextIndex == 3)
        {
            GameManager.Instance.set_all(-20, 0, 0, 0);
        }
        if (GameManager.Instance.currentTextIndex == 4)
        {
            GameManager.Instance.set_all(0, 15, 15, 10);
        }
        if (GameManager.Instance.currentTextIndex == 5)
        {
            GameManager.Instance.set_all(15, 0, 10, 10);
        }
    }
    void UpdateTextIndex()
    {
        
    
        
        GameManager.Instance.currentTextIndex++; // 다음 텍스트 요소로 인덱스 업데이트
        if (GameManager.Instance.currentTextIndex >= text.Length) // 배열의 끝에 도달했으면 처음부터 다시 시작
        {
            GameManager.Instance.currentTextIndex = 0;
        }

        // 모든 텍스트 요소를 비활성화
        foreach (var t in text)
        {
            t.gameObject.SetActive(false);
        }

        // 현재 인덱스의 텍스트 요소만 활성화
        text[GameManager.Instance.currentTextIndex].gameObject.SetActive(true);
    }
}
