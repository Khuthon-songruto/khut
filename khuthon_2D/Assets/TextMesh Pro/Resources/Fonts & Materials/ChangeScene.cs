using UnityEngine;
using UnityEngine.SceneManagement; // Scene Management�� ����ϱ� ���� �ʿ�

public class ChangeScene : MonoBehaviour
{
    // �� �Լ��� ��ư Ŭ���� ���� ȣ��˴ϴ�.
    public void LoadNextScene()
    {
        // ���� Ȱ��ȭ�� ���� �ε����� �����ɴϴ�.
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        // ���� ���� �ε��մϴ�.
        SceneManager.LoadScene(1);
    }
}