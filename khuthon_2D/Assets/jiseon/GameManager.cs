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
    int day; // �ð�(9~6)�� ��¥
    // �ð��� 1~10 9to6
    // bool gameover;
    bool gamestart;
    int rangetime;
    public Pop Popup;
    public bool yesStamp = false;
    public bool noStamp = false;

    void Start()
    {
        // ���� ������ ���� �Ŵ����� �̹� �����Ǿ����� Ȯ���ϰ�, �̹� �ִٸ� ���� ������ ������ ���� �ı�
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // ���� �Ŵ����� �� ��ȯ �� �ı����� �ʵ��� ����
        DontDestroyOnLoad(gameObject);

        // ���� ���� �ε�� �� ȣ��Ǵ� �̺�Ʈ�� �Լ� ���
        SceneManager.sceneLoaded += OnSceneLoaded;
    

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
            // ���� ���� ���� ���� �ƴ϶�� ���� �Ŵ����� Ȱ��ȭ�մϴ�.
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
        environment = 100; // �ڿ�
        capital = 50; // �ں�
        reputation = 50; // ȸ���� ��
        staff = 50; // ���� ��
        time = 0f; // 9 to 6
        realtime = 0f; // ���� �ð�
        rangetime = 1; // �ð�(time +1) �Ѿ�� �ð�
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
        gameObject.SetActive(true); // ���� �ε�� �� GameManager�� Ȱ��ȭ�մϴ�.
        time = 0f;
        day = 0;
        gamestart = true;
    }

    void Update()
    {
        time_start();

        if (time >= 74.8f) // ���÷� �Ϸ簡 75f������ ����
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
            empent.StopAction(); // ���߰��� �ϴ� ��ũ��Ʈ�� StopAction �Լ� ȣ��
        }
        // EndOfDay �Լ��� ȣ��� �� 1�� �ڿ� �˾��� ǥ��
        StartCoroutine(ShowPopupAfterDelay(1f));
    }

    IEnumerator ShowPopupAfterDelay(float delay)
    {
        // delay �ð���ŭ ���
        yield return new WaitForSeconds(delay);

        // �˾��� ǥ��
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
