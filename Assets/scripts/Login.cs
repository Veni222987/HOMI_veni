using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine;

public class Login : MonoBehaviour
{
    // Start is called before the first frame update
    
    //淡入之前先移位,初始调用
    static void Initialize(int direction, GameObject UIElement, int distance=200,int maxTime=2)//FadeIn*2
    {
        UIElement.SetActive(false);
        float angle = direction*90.0f*Mathf.Deg2Rad;
        Vector3 Move = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0)*distance/2*maxTime;
        UIElement.transform.Translate(Move);
        UIElement.SetActive(true);
    }
    static void FadeIn( int direction, GameObject UIElement ,float timer,int distance=100,int maxTime=2)
    {
        Image UIImage = UIElement.GetComponent<Image>();
        
        float angle = direction*90.0f*Mathf.Deg2Rad;
        Vector3 Move = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);
        UIImage.transform.Translate(Move*Time.deltaTime*distance);
        UIImage.color= new Color(UIImage.color.r, UIImage.color.g, UIImage.color.b, timer/maxTime);//除以两秒
    }

    public float bubbleSpeed=80.0f;

    private GameObject logo;
    private GameObject homi;
    private GameObject[] bubbles;
    private bool Available;

    private float timer=0;
    void Start()
    {
        logo= GameObject.Find("Logo");
        homi=GameObject.Find("Homi");
        bubbles = GameObject.FindGameObjectsWithTag("bubbles");
        Initialize(1,logo);
        Initialize(3,homi);

    }

    // Update is called once per frame
    void Update()
    {
        foreach (var bub in bubbles)
        {
            if (bub.transform.position.y > 600)
                bub.transform.Translate(0,-1000,0);
            else
            {
                bub.transform.Translate(Vector3.up*bubbleSpeed);
            }
        }
        //sprite renderer 的RGB值，后面是渐变值
        
        if(timer<2)
        {
            FadeIn(1,homi,timer,100);
            FadeIn(3,logo,timer,100);
            timer += Time.deltaTime;
        }
    }
    
}
