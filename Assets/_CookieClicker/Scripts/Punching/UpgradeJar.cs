using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public partial class UpgradeJar : Punchable
{
    [SerializeField]
    UpgradeJarScriptable stats;
    [SerializeField]
    TMP_Text priceText;
    [SerializeField]
    TMP_Text upgradeDescription;
    ParticleSystem particles;
    public override void Start()
    {
        base.Start();
        priceText.text = stats.price.ToString() + " Cookies";
        upgradeDescription.text = stats.upgradeDescription.ToString();
        particles = GetComponentInChildren<ParticleSystem>();
        if (stats.upgradeBought)
        {
            BoughtUpgrade();
        }
    }

    public override void punched()
    {
        if (GameManager.Instance.playerStats.cookieCount >= stats.price)
        {
            GameManager.Instance.playerStats.cookieCount -= stats.price;
            if (!stats.upgradeBought)
            {
                BoughtUpgrade();
                stats.upgradeBought = true;
                particles.Play();
            }
            Debug.Log("ItemBough");
        }
    }
    public virtual void BoughtUpgrade() 
    {
        priceText.text = "Bought";
    }
}
