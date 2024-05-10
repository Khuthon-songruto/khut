using UnityEngine;
using UnityEngine.SceneManagement; // Scene Management를 사용하기 위해 필요

public class ChangeScene : MonoBehaviour
{
    // 이 함수는 버튼 클릭에 의해 호출됩니다.
    public void LoadNextScene()
    {
        // 현재 활성화된 씬의 인덱스를 가져옵니다.
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        // 다음 씬을 로드합니다.
        SceneManager.LoadScene(1);
    }
}