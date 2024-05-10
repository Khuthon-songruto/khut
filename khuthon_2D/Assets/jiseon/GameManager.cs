using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    #region singletone
    public static GameManager Instance = null;
    public int currentTextIndex = 0;
    public employeeEnter empent;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if(Instance != this)
            {
                Destroy(this.gameObject);
            }
        }
    }
    #endregion

    private static GameManager instance;
    private float environment, capital, reputation, staff;
    float time, realtime;
    int day; // 시간(9~6)과 날짜
    // 시간은 1~10 9to6
    // bool gameover;
    bool gamestart;
    int rangetime;
    public Pop Popup;
    public bool yesStamp = false;
    public bool noStamp = false;

    void Start()
    {
        // 이전 씬에서 게임 매니저가 이미 생성되었는지 확인하고, 이미 있다면 현재 씬에서 생성된 것을 파괴
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // 게임 매니저를 씬 전환 시 파괴되지 않도록 설정
        DontDestroyOnLoad(gameObject);

        // 현재 씬이 로드될 때 호출되는 이벤트에 함수 등록
        SceneManager.sceneLoaded += OnSceneLoaded;
    

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
            // 현재 씬이 메인 씬이 아니라면 게임 매니저를 활성화합니다.
            if (scene.name != "Main")
            {
                gameObject.SetActive(false);
            }
            else
            {
                gameObject.SetActive(true);
                Popup.Hide();
            }
        }

    DontDestroyOnLoad(Popup);
        environment = 100; // 자연
        capital = 50; // 자본
        reputation = 50; // 회사의 명성
        staff = 50; // 직원 수
        time = 0f; // 9 to 6
        realtime = 0f; // 현재 시간
        rangetime = 1; // 시계(time +1) 넘어가는 시간
        gamestart = true; 
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        gameObject.SetActive(true); // 씬이 로드될 때 GameManager를 활성화합니다.
        time = 0f;
        day = 0;
        gamestart = true;
    }

    void Update()
    {
        time_start();

        if (time >= 74.8f) // 예시로 하루가 75f까지로 가정
        {
            EndOfDay();
        }
    }
    
    void time_start()
    {
        if (gamestart)
        {
            if(realtime < rangetime)
            {
                realtime += Time.deltaTime;
            }
            else
            {
                realtime = 0f;
                if(time < 75f) time += 8.33f;
                if (time >= 74.9f)
                {
                    day += 1;
                    // time = 0f;
                    gamestart = false;
                }
                Debug.Log(time);
            }
        }
    }


    void isgamevoer()
    {
        if (environment == 0 || capital == 0 || reputation == 0 || staff==0)
        {
            // gameover = true;
        }
    }
    void EndOfDay()
    {
        if (empent != null)
        {
            empent.StopAction(); // 멈추고자 하는 스크립트의 StopAction 함수 호출
        }
        // EndOfDay 함수가 호출된 후 1초 뒤에 팝업을 표시
        StartCoroutine(ShowPopupAfterDelay(1f));
    }

    IEnumerator ShowPopupAfterDelay(float delay)
    {
        // delay 시간만큼 대기
        yield return new WaitForSeconds(delay);

        // 팝업을 표시
        Popup.Show();
    }


    #region getter setter code
    public void set_environment(int environment)
    {
        if (this.environment >= 0 && this.environment > environment) this.environment = this.environment - environment;
        else this.environment = 0;
    }

    public void set_capital(int capital)
    {
        if (this.capital >= 0 && this.capital > capital) this.capital = this.capital - capital;
        else this.capital = 0;
    }
    public void set_reputation(int reputation)
    {
        if (this.reputation >= 0 && this.reputation > reputation) this.reputation = this.reputation - reputation;
        else this.reputation = 0;
    }
    public void set_staff(int staff)
    {
        if (this.staff >= 0 && this.staff > staff) this.staff = this.staff - staff;
        else this.staff = 0;
    }

    public float get_environment()
    {
        return this.environment;
    }

    public float get_capital()
    {
        return this.capital;
    }

    public float get_reputation()
    {
        return this.reputation;
    }

    public float get_staff()
    {
        return this.staff;
    }

    public void set_time(float time)
    {
        this.time += time;
    }
    public float get_time()
    {
        return this.time;
    }

    public void set_day(int day)
    {
        this.day += day;
    }
    public int get_day()
    {
        return this.day;
    }
    #endregion 
}
