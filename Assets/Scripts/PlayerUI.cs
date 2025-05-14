using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Alteruna;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerUI : AttributesSync
{
    [SynchronizableField] private int money = 0;
    public TextMeshProUGUI moneyText;

    [SynchronizableMethod]
    public void UpdateMoney(int moneyToAdd)
    {
        if(money < 1000)
        {
            money += moneyToAdd;
            moneyText.text = "Money: " + money + "$";
        }
    }

    [SynchronizableMethod]
    public void UpdateMoneySafe()
    {
        if (money < 1000)
        {
            money += 250;
            moneyText.text = "Money: " + money + "$";
        }
    }

    [SynchronizableMethod]
    public void Escape()
    {
        if(money >= 1000)
        {
            SceneManager.LoadScene(2);
        }
    }
}
