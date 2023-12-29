using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseAutoCliker : UpgradeJar
{
    [SerializeField]
    GameObject autoCruncher;
    public override void BoughtUpgrade()
    {
        base.BoughtUpgrade();
        if (!autoCruncher.activeInHierarchy)
        {
            autoCruncher.SetActive(true); 
        }

    }
}
