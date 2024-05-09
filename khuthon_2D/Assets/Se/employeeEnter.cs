using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class employeeEnter : MonoBehaviour
{
    Vector2 destination1 = new Vector2(-3, 0);
    Vector2 destination2 = new Vector2(0, -8);
    Vector3 spawnPosition = new Vector3(0f, 0f, 0f);

    public GameObject doc;
    public GameObject animals;
    public GameObject makeDoc;
    public int speed;

    [SerializeField]
    private TextMeshPro[] text;
    //public AudioSource animalAppear;
    //public AudioSource docAppear;


    private void OnEnable()
    {
        StartCoroutine(aniDocApp());
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 왼쪽 마우스 버튼 클릭 여부 확인
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == doc) // Doc 오브젝트를 클릭했는지 확인
            {
                // 클릭한 위치에 makeDoc 오브젝트를 생성합니다.
                Instantiate(makeDoc, spawnPosition, Quaternion.identity);

                doc.SetActive(false);
            }
        }
    }

    IEnumerator aniDocApp()
    {
        animals.transform.position = Vector3.MoveTowards(animals.transform.position, destination1, speed * Time.deltaTime);
        yield return new WaitForSeconds(0.5f);
        doc.transform.position = Vector3.MoveTowards(doc.transform.position, destination2, speed * Time.deltaTime);

        
    }
}
