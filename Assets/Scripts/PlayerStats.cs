using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public static int Wave;
    public int startMoney = 400;
    public Text money;

    private void Start()
    {
        Money = startMoney;
    }

    private void Update()
    {

        //Money.ToString = money;
        money.text = Money.ToString();
    }
}
