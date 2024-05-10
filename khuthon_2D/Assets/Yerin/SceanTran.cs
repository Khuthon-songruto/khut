using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTran : MonoBehaviour
{
    // �������� �̵��� ���� �̸��� �����մϴ�.
    public string nextSceneName;

    // �ڵ����� ���� ��ȯ�� �ð� ������ �����մϴ�.
    public float delay = 2f;

    void Start()
    {

        // delay �� �Ŀ� �ڵ����� ���� ��ȯ�ϴ� �Լ��� ȣ���մϴ�.
        Invoke("SwitchScene", delay);
    }

    public void SwitchScene()
    {
        // ���� ������ ��ȯ�մϴ�.
        SceneManager.LoadScene(1);
    }
}