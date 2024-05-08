using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region singletone
    public static GameManager Instance = null;
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

    private float environment, capital, reputation, staff;
    float time, realtime;
    int day; // 시간(9~6)과 날짜
    // 시간은 1~10 9to6
    bool gameover, gamestart;
    int rangetime;

    void Start()
    {
        environment = 100; // 자연
        capital = 50; // 자본
        reputation = 50; // 회사의 명성
        staff = 50; // 직원 수
        time = 0f; // 9 to 6
        realtime = 0f; // 현재 시간
        rangetime = 1; // 시계(time +1) 넘어가는 시간
        gamestart = true; 
    }

    void Update()
    {
        time_start();
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
            gameover = true;
        }
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
