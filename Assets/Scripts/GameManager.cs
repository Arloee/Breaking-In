using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int money = 0;
    public TextMeshProUGUI moneyText;

    public void UpdateMoney(int moneyToAdd){
        money += moneyToAdd;
        moneyText.text = "Money: " + money + "$";
        Debug.Log(moneyText.text);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
