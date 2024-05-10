using UnityEngine;
using UnityEngine.SceneManagement;

public class SceanTran2 : MonoBehaviour
{

    // 다음으로 이동할 씬의 이름을 지정합니다.
    public string nextSceneName;

    public void SwitchScene()
    {
        // 다음 씬으로 전환합니다.
        SceneManager.LoadScene(nextSceneName);
    }
}
