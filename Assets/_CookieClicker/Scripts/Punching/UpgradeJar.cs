using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeJar : Punchable
{
    [SerializeField]
    int price;
    [SerializeField]
    TMP_Text priceText;
    public override void Start()
    {
        base.Start();
        priceText.text = price.ToString();
    }

    public override void punched()
    {
        if(GameManager.Instance.playerStats.cookieCount >= price)
        {
            GameManager.Instance.playerStats.cookieCount -= price;
            GameManager.Instance.objectWasPunched?.Invoke();
            Debug.Log("ItemBough");
        }

    }
}
