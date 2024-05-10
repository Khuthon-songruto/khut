using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTran : MonoBehaviour
{
    // 다음으로 이동할 씬의 이름을 지정합니다.
    public string nextSceneName;

    // 자동으로 씬을 전환할 시간 간격을 지정합니다.
    public float delay = 2f;

    void Start()
    {

        // delay 초 후에 자동으로 씬을 전환하는 함수를 호출합니다.
        Invoke("SwitchScene", delay);
    }

    public void SwitchScene()
    {
        // 다음 씬으로 전환합니다.
        SceneManager.LoadScene(1);
    }
}