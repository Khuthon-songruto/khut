using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines1;
    public string[] lines2;
    public string[] lines3;
    public string[] lines4;
    public string[] lines5;
    public string[] lines6;
    public string[] lines7;
    public string[] lines8;
    public float textSpeed;
    public GameObject panel;
    public bool is_talk = false;

    private int index;

    private string[] line;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        panel.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        /*
         if (Input.GetKeyUp(KeyCode.Space))
        {
            lines(2);
        }else if(Input.GetKeyDown(KeyCode.A))
        {
            lines(3);
        }
         */

        if (Input.GetKeyDown("1"))
        {
            lines(0);
        }
        else if (Input.GetKeyDown("2"))
        {
            lines(1);
        }
        else if (Input.GetKeyDown("3"))
        {
            lines(2);
        }
        else if (Input.GetKeyDown("4"))
        {
            lines(3);
        }
        else if (Input.GetKeyDown("5"))
        {
            lines(4);
        }
        else if (Input.GetKeyDown("6"))
        {
            lines(5);
        }
        else if (Input.GetKeyDown("7"))
        {
            lines(6);
        }
        else if (Input.GetKeyDown("8"))
        {
            lines(7);
        }


        if (Input.GetMouseButtonDown(0) && is_talk == true)
        {
            StopAllCoroutines(); // 먼저 모든 코루틴을 중단시킵니다.

            if (textComponent.text != line[index]) // 현재 텍스트가 전체 라인과 다르면
            {
                textComponent.text = line[index]; // 전체 라인의 텍스트를 즉시 표시합니다.
            }
            else
            {
                NextLine(); // 다음 라인으로 넘어갑니다.
            }
            /*
             * if (textComponent.text == line[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = line[index];
            }
             */

        }
    }

    void StartDialogue()
    {
        panel.SetActive(true);
        index = 0;
        is_talk = true;
        textComponent.text = string.Empty;
        StartCoroutine(TypeLine());

    }

    IEnumerator TypeLine()
    {
        foreach (char c in line[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < line.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            is_talk = false;
            panel.SetActive(false);
        }
    }

    void lines(int index)
    {
        /*
         if(index == 0)
        {
            line = new string[lines1.Length];

            for(int i  = 0; i < lines1.Length; i++)
            {
                line[i] = lines1[i];
            }
        }else if(index == 1)
        {
            line = new string[lines2.Length];
            for(int i = 0; i < lines2.Length; i++)
            {
                line[i] = lines2[i];
            }
        }

         */

        switch (index)
        {
            case 0:
                line = new string[lines1.Length];

                for (int i = 0; i < lines1.Length; i++)
                {
                    line[i] = lines1[i];
                }
                break;
            case 1:
                line = new string[lines2.Length];
                for (int i = 0; i < lines2.Length; i++)
                {
                    line[i] = lines2[i];
                }
                break;
            case 2:
                line = new string[lines3.Length];
                for (int i = 0; i < lines3.Length; i++)
                {
                    line[i] = lines3[i];
                }
                break;
            case 3:
                line = new string[lines4.Length];
                for (int i = 0; i < lines4.Length; i++)
                {
                    line[i] = lines4[i];
                }
                break;
            case 4:
                line = new string[lines5.Length];
                for (int i = 0; i < lines5.Length; i++)
                {
                    line[i] = lines5[i];
                }
                break;
            case 5:
                line = new string[lines6.Length];
                for (int i = 0; i < lines6.Length; i++)
                {
                    line[i] = lines6[i];
                }
                break;
            case 6:
                line = new string[lines7.Length];
                for (int i = 0; i < lines7.Length; i++)
                {
                    line[i] = lines7[i];
                }
                break;
            case 7:
                line = new string[lines8.Length];
                for (int i = 0; i < lines8.Length; i++)
                {
                    line[i] = lines8[i];
                }
                break;
        }


        textComponent.text = string.Empty;
        StartDialogue();
    }
}
