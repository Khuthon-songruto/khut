using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class animal : MonoBehaviour
{
    public Sprite[] sprites;
    SpriteRenderer spriteRenderer;
    public float realtime = 0f; // ���� �ð�
    int rangetime = 2; // �ð�(time +1) �Ѿ�� �ð�


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        realtime = 0;
        //Funciton_RandomImage();
    }

    private void Funciton_RandomImage()
    {
        int index = Random.Range(0, sprites.Length);
        Sprite select = sprites[index];
        spriteRenderer.sprite = select;
        Debug.LogFormat("index : {0}, image name : {1}", index, sprites[index].name);
    }



    // Update is called once per frame
    void Update()
    {
        if(realtime < rangetime)
        {
            realtime += Time.deltaTime;
            //Funciton_RandomImage();
            realtime = 0;
        }
        //Random.Range(0, 6);

    }
}
