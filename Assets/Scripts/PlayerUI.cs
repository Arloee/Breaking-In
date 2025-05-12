using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Alteruna;
using TMPro;

public class PlayerUI : AttributesSync
{
    [SynchronizableField] private int money = 0;
    public TextMeshProUGUI moneyText;

    [SynchronizableMethod]
    public void UpdateMoney(int moneyToAdd)
    {
        money += moneyToAdd;
        moneyText.text = "Money: " + money + "$";
    }
}
