using UnityEngine;
using UnityEngine.SceneManagement;

public class SceanTran2 : MonoBehaviour
{

    // �������� �̵��� ���� �̸��� �����մϴ�.
    public string nextSceneName;

    public void SwitchScene()
    {
        // ���� ������ ��ȯ�մϴ�.
        SceneManager.LoadScene(nextSceneName);
    }
}
