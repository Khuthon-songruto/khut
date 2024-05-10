using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class employeeEnter : MonoBehaviour
{
    //���ӸŴ������� bool ���� �ڵ� �����, colly -> �׸� -> 
    Vector2 destination1 = new Vector2(-3, 0);
    Vector2 destination2 = new Vector2(0, -8);
    Vector2 destination3 = new Vector2(15, 0);
    Vector3 spawnPosition = new Vector3(0f, 0f, 0f);
    public GameObject doc;
    public GameObject animals;
    public GameObject makeDoc;
    public int speed;
    public bool isStamped = false;
    private int currentTextIndex = 0;

    [SerializeField]
    public TextMeshPro[] text;
    //public AudioSource animalAppear;
    //public AudioSource docAppear;

    private void Update()
    {
        StartCoroutine(aniDocApp());
        if (Input.GetMouseButtonDown(0)) // ���� ���콺 ��ư Ŭ�� ���� Ȯ��
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
            

            if (hit.collider != null && hit.collider.gameObject == doc) // Doc ������Ʈ�� Ŭ���ߴ��� Ȯ��
            {
                // makeDoc ������Ʈ�� ����
                makeDoc.SetActive(true);

                doc.SetActive(false);
            }
        }

        if (GameManager.Instance.yesStamp == true || GameManager.Instance.noStamp == true)
        {
            if (!isStamped)
            {
                StopCoroutine(aniDocApp());
                Debug.Log("bb");
                StartCoroutine(aniDocDisapp());
                isStamped = true;
            }

        }
    }

    IEnumerator aniDocApp()
    {
        animals.transform.position = Vector3.MoveTowards(animals.transform.position, destination1, speed * Time.deltaTime);
        yield return new WaitForSeconds(0.5f);
        doc.transform.position = Vector3.MoveTowards(doc.transform.position, destination2, speed * Time.deltaTime);

        
    }

    IEnumerator aniDocDisapp()
    {
        yield return new WaitForSeconds(1.5f);
        animals.SetActive(false);
        //ield return new WaitForSeconds(0.5f);
        makeDoc.SetActive(false);

        // ���⼭ �� �� ��ٸ� �� �ʱ�ȭ �� aniDocApp() �ٽ� ����
        yield return new WaitForSeconds(1.0f); // ���� ��� 3�� �Ŀ� �ʱ�ȭ �� ������Ѵٰ� ����
        ResetVariables(); // ��� ������ �ʱ�ȭ�ϴ� �޼ҵ� ȣ��
        StartCoroutine(aniDocApp()); // aniDocApp �ڷ�ƾ �ٽ� ����

    }

    void ResetVariables()
    {
        // ���� �ʱ�ȭ �����Դϴ�. ���� ������ ������ �°� �����ؾ� �մϴ�.
        isStamped = false;
        animals.SetActive(true);
        doc.SetActive(true);
        makeDoc.SetActive(false);
        GameManager.Instance.yesStamp = false;
        GameManager.Instance.noStamp = false;
        UpdateTextIndex();
    }

    void UpdateTextIndex()
    {
        currentTextIndex++; // ���� �ؽ�Ʈ ��ҷ� �ε��� ������Ʈ
        if (currentTextIndex >= text.Length) // �迭�� ���� ���������� ó������ �ٽ� ����
        {
            currentTextIndex = 0;
        }

        // ��� �ؽ�Ʈ ��Ҹ� ��Ȱ��ȭ
        foreach (var t in text)
        {
            t.gameObject.SetActive(false);
        }

        // ���� �ε����� �ؽ�Ʈ ��Ҹ� Ȱ��ȭ
        text[currentTextIndex].gameObject.SetActive(true);
    }
}
