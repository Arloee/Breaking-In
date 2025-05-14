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
    public Image correctTopPrint;
    public Image correctMidPrint;
    public Image correctBotPrint;
    public Sprite[] fingerprintSpriteList;
    public GameObject buttons;
    private int topPrintCount;
    private int midPrintCount;
    private int botPrintCount;
    private int randomFingerprint;
    private Alteruna.Avatar _avatar;

    public void StartFingerprint()
    {
        randomFingerprint = UnityEngine.Random.Range(0, 7);

        correctTopPrint.sprite = GetFingerprint(randomFingerprint, 0);
        correctMidPrint.sprite = GetFingerprint(randomFingerprint, 1);
        correctBotPrint.sprite = GetFingerprint(randomFingerprint, 2);

        topPrintCount = UnityEngine.Random.Range(0, fingerprintSpriteList.Count());
        midPrintCount = UnityEngine.Random.Range(0, fingerprintSpriteList.Count());
        botPrintCount = UnityEngine.Random.Range(0, fingerprintSpriteList.Count());

        topPrint.sprite = fingerprintSpriteList[topPrintCount];
        midPrint.sprite = fingerprintSpriteList[midPrintCount];
        botPrint.sprite = fingerprintSpriteList[botPrintCount];
    }

    private Sprite GetFingerprint(int finger, int index)
    {
        if (finger < 4)
        {
            return fingerprintSpriteList[finger + index * 4];
        }
        else
        {
            return fingerprintSpriteList[8 + finger + index * 4];
        }
    }

    private void CheckFingerprint()
    {
        if (correctTopPrint.sprite == topPrint.sprite && correctMidPrint.sprite == midPrint.sprite &&
        correctBotPrint.sprite == botPrint.sprite)
        {
            buttons.SetActive(false);
            GameObject.FindGameObjectWithTag("PlayerUI").GetComponent<PlayerUI>().BroadcastRemoteMethod("UpdateMoneySafe");
        }
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
        CheckFingerprint();
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
        CheckFingerprint();
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
        CheckFingerprint();
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
        CheckFingerprint();
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
        CheckFingerprint();
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
        CheckFingerprint();
    }
}
