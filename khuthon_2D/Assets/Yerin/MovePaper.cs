

using UnityEngine;

public class MoveDown : MonoBehaviour
{
    public float speed = 5.0f; // 오브젝트의 이동 속도
    private bool stopMoving = false; // 이동을 멈출지 결정하는 변수

    void Update()
    {
        if (!stopMoving)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);

            // Main Camera를 기준으로 오브젝트의 화면상 위치를 계산합니다.
            Vector3 screenPosition = Camera.main.WorldToViewportPoint(transform.position);
            // 화면의 중앙에 도달했는지 확인합니다. Y축 값이 0.5보다 작아지면 중앙을 지난 것입니다.
            if (screenPosition.y >= 0.45f)
            {
                stopMoving = true; // 이동을 멈춥니다.
            }
        }
    }
}