using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeJar : Punchable
{
    [SerializeField]
    UpgradeJarScriptable stats;
    [SerializeField]
    TMP_Text priceText;
    [SerializeField]
    TMP_Text upgradeDescription;
    public override void Start()
    {
        base.Start();
        priceText.text = stats.price.ToString();
        upgradeDescription.text = stats.upgradeDescription.ToString();
    }

    public override void punched()
    {
        if(GameManager.Instance.playerStats.cookieCount >= stats.price)
        {
            GameManager.Instance.playerStats.cookieCount -= stats.price;
            if (!stats.upgradeBought)
            {
                stats.upgradeBought = true;
            }
            GameManager.Instance.objectWasPunched?.Invoke();
            Debug.Log("ItemBough");
        }
    }
}
