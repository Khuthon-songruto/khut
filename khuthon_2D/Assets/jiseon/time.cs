using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class time : MonoBehaviour
{
    bool start_game;
    public Slider env_slider;
    public Slider cap_slider;
    public Slider rep_slider;
    public Slider stf_slider;
    public Image watch;
    public float clock_;
    public float watch_start, watch_end, watch_step;
    public float maxHP, env_currentHP, cap_currentHP, rep_currentHP, stf_currentHP;
    Image watch_image;

    public TextMeshProUGUI daytext;

    void Start()
    {
        env_currentHP = GameManager.Instance.get_environment();
        cap_currentHP = GameManager.Instance.get_capital();
        rep_currentHP = GameManager.Instance.get_reputation();
        stf_currentHP = GameManager.Instance.get_staff();
        clock_ = GameManager.Instance.get_time();
        watch_start = 0f;
        watch_end = 100f;
        watch_step = 100 / 12;

        watch_image = watch.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        env_currentHP = GameManager.Instance.get_environment();
        cap_currentHP = GameManager.Instance.get_capital();
        rep_currentHP = GameManager.Instance.get_reputation();
        stf_currentHP = GameManager.Instance.get_staff();
        clock_ = GameManager.Instance.get_time();

        env_slider.value = env_currentHP / 100;
        cap_slider.value = cap_currentHP / 100;
        rep_slider.value = rep_currentHP / 100;
        stf_slider.value = stf_currentHP / 100;

        if(watch_image.fillAmount <= 100)
        {
            watch_image.fillAmount = clock_/100;
        }
        int day = GameManager.Instance.get_day();
        daytext.text = day.ToString();
    }

    public void changeset()
    {
        GameManager.Instance.set_environment(10);
    }


}
