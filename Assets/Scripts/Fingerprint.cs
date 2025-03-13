using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.ParticleSystemJobs;
using UnityEngine.UI;

public class Fingerprint : MonoBehaviour
{

    public Image topPrint;
    public Image midPrint;
    public Image botPrint;
    public Sprite[] fingerprintSpriteList;
    public Sprite[] fingerprintSprite1;
    public Sprite[] fingerprintSprite2;
    public Sprite[] fingerprintSprite3;
    public Sprite[] fingerprintSprite4;
    public Sprite[] fingerprintSprite5;
    public Sprite[] fingerprintSprite6;
    public Sprite[] fingerprintSprite7;
    public Sprite[] fingerprintSprite8;
    public Sprite[] topPrints;
    public Sprite[] midPrints;
    public Sprite[] botPrints;
    private int topPrintCount;
    private int midPrintCount;
    private int botPrintCount;

    private void Start()
    {
        topPrintCount = UnityEngine.Random.Range(0, fingerprintSpriteList.Count());
        midPrintCount = UnityEngine.Random.Range(0, fingerprintSpriteList.Count());
        botPrintCount = UnityEngine.Random.Range(0, fingerprintSpriteList.Count());
        topPrint.sprite = fingerprintSpriteList[topPrintCount];
        midPrint.sprite = fingerprintSpriteList[midPrintCount];
        botPrint.sprite = fingerprintSpriteList[botPrintCount];
    }

    public void ChangeTopPrintUp()
    {
        if (topPrintCount == 23)
        {
            topPrintCount = 0;
        }
        else
        {
            topPrintCount += 1;
        }
        topPrint.sprite = fingerprintSpriteList[topPrintCount];
    }
    public void ChangeMidPrintUp()
    {
        if (midPrintCount == 23)
        {
            midPrintCount = 0;
        }
        else
        {
            midPrintCount += 1;
        }
        midPrint.sprite = fingerprintSpriteList[midPrintCount];
    }
    public void ChangeBotPrintUp()
    {
        if (botPrintCount == 23)
        {
            botPrintCount = 0;
        }
        else
        {
            botPrintCount += 1;
        }
        botPrint.sprite = fingerprintSpriteList[botPrintCount];
    }
    public void ChangeTopPrintDown()
    {
        if (topPrintCount == 0)
        {
            topPrintCount = 23;
        }
        else
        {
            topPrintCount -= 1;
        }
        topPrint.sprite = fingerprintSpriteList[topPrintCount];
    }
    public void ChangeMidPrintDown()
    {
        if (midPrintCount == 0)
        {
            midPrintCount = 23;
        }
        else
        {
            midPrintCount -= 1;
        }
        midPrint.sprite = fingerprintSpriteList[midPrintCount];
    }
    public void ChangeBotPrintDown()
    {
        if (botPrintCount == 0)
        {
            botPrintCount = 23;
        }
        else
        {
            botPrintCount -= 1;
        }
        botPrint.sprite = fingerprintSpriteList[botPrintCount];
    }
}
