

using UnityEngine;

public class MoveDown : MonoBehaviour
{
    public float speed = 5.0f; // ������Ʈ�� �̵� �ӵ�
    private bool stopMoving = false; // �̵��� ������ �����ϴ� ����

    void Update()
    {
        if (!stopMoving)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);

            // Main Camera�� �������� ������Ʈ�� ȭ��� ��ġ�� ����մϴ�.
            Vector3 screenPosition = Camera.main.WorldToViewportPoint(transform.position);
            // ȭ���� �߾ӿ� �����ߴ��� Ȯ���մϴ�. Y�� ���� 0.5���� �۾����� �߾��� ���� ���Դϴ�.
            if (screenPosition.y >= 0.45f)
            {
                stopMoving = true; // �̵��� ����ϴ�.
            }
        }
    }
}